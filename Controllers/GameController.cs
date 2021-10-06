using Snake.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Threading;

namespace Snake.Controllers {
    /// <summary>
    /// 负责计时及控制游戏状态
    /// </summary>
    public class GameController : AbstructController {
        private readonly Timer _timer;
        //private readonly DispatcherTimer _timer;
        private readonly BackgroundGridController _backgroundGridController;
        private readonly SnakeController _snakeController;
        private readonly BrickController _brickController;
        private readonly FoodController _foodController;

        public event EventHandler<EventArgs> GameOver;

        public IEnumerable<GridPosition> ForbiddenGridPosition {
            get {
                return _snakeController.SnakeBodyPositions.Union(new List<GridPosition>() { _snakeController.SnakeHeadPosition }).Union(_brickController.BrickPositions);
            }
        }

        public GameController(ICollection<AbstructEntity> entities) {
            //_timer = new DispatcherTimer();
            _timer = new Timer();
            //_timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            _timer.Interval = 300;
            _backgroundGridController = new BackgroundGridController(entities, GameEnvironment.grid1Brush, GameEnvironment.grid2Brush);
            _snakeController = new SnakeController(entities, GameEnvironment.snakeHeadBrush, GameEnvironment.snakeBodyBrush, GameEnvironment.initialBodyCount, GameEnvironment.initialSnakeHeadPosition, GameEnvironment.initialDirection);
            _foodController = new FoodController(entities, GameEnvironment.foodBrush, GameEnvironment.foodStroke, GameEnvironment.foodStrokeThickness);
            _brickController = new BrickController(entities, GameEnvironment.brickPositions, GameEnvironment.brickBrush, GameEnvironment.brickStroke, GameEnvironment.brickStrokeThickness);
            //_timer.Tick += Timer_Elapsed;
            _timer.Elapsed += Timer_Elapsed;
        }

        public void InitialGame() {
            _backgroundGridController.GenerateBackgroundGrid();
            _brickController.GenerateBricks();
            _snakeController.InitialSnake();
            _foodController.GenerateFood(ForbiddenGridPosition);
            _timer.Start();
        }

        public void StopGame() {
            _timer.Stop();
            _timer.Dispose();
        }

        private void Timer_Elapsed(object sender, EventArgs e) {
            if (EatFood()) {
                _snakeController.MoveSnakeRetainTail();
                _foodController.GenerateFood(ForbiddenGridPosition);
            }
            else _snakeController.MoveSnake();
            if (IsgameOver()) {
                _timer.Stop();
                _timer.Enabled = false;
                // 发出游戏结束事件
                GameOver(this, null);
                return;
            }
            // 重置计时器时间
            _timer.Stop();
            _timer.Start();
        }

        private bool EatFood() {
            return Equals(_snakeController.SnakeHeadPosition, _foodController.FoodPosition);
        }

        private bool IsgameOver() {
            return _snakeController.SnakeBodyPositions.Union(_brickController.BrickPositions).Contains(_snakeController.SnakeHeadPosition);
        }

        public SnakeController.SnakeDirection Direction {
            get {
                return _snakeController.Direction;
            }
            set {
                _snakeController.Direction = value;
                if (_timer.Enabled)
                    Timer_Elapsed(this, null);
            }
        }
    }
}
