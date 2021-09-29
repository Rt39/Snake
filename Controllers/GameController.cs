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
            _snakeController = new SnakeController(entities, GameEnvironment.snakeHeadBrush, GameEnvironment.snakeBodyBrush, GameEnvironment.initialBodyCount, GameEnvironment.initialSnakeHead, GameEnvironment.initialDirection);
            _foodController = new FoodController(entities, GameEnvironment.foodBrush, GameEnvironment.foodStroke, GameEnvironment.foodStrokeThickness);
            _brickController = new BrickController(entities, GameEnvironment.brickPositions, GameEnvironment.brickBrush, GameEnvironment.brickStroke, GameEnvironment.brickStrokeThickness);
            //_timer.Tick += Timer_Elapsed;
            _timer.Elapsed += Timer_Elapsed;
        }

        public void InitialGame() {
            _backgroundGridController.GenerateBackgroundGrid();
            _snakeController.InitialSnake();
            _foodController.GenerateFood(ForbiddenGridPosition);
            _timer.Start();
        }

        //public void StopTimer() {
        //    _timer.Stop();
        //    _timer.Dispose();
        //}

        private void Timer_Elapsed(object sender, EventArgs e) {
            if (EatFood()) {
                _snakeController.MoveSnakeRetainTail();
                _foodController.GenerateFood(ForbiddenGridPosition);
            }
            else _snakeController.MoveSnake();
        }

        private bool EatFood() {
            return Equals(_snakeController.SnakeHeadPosition, _foodController.FoodPosition);
        }

        private bool IsgameOver() {
            throw new NotImplementedException();
        }

        public SnakeController.SnakeDirection Direction {
            get {
                return _snakeController.Direction;
            }
            set {
                _snakeController.Direction = value;
            }
        }
    }
}
