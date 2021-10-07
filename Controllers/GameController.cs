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
        #region 字段
        private readonly Timer _timer;
        //private readonly DispatcherTimer _timer;
        private readonly BackgroundGridController _backgroundGridController;
        private readonly SnakeController _snakeController;
        private readonly BrickController _brickController;
        private readonly FoodController _foodController;
        #endregion

        /// <summary>
        /// 游戏结束信号
        /// </summary>
        public event EventHandler<EventArgs> GameOver;

        #region 属性
        /// <summary>
        /// 禁着点，蛇头、蛇身及砖块所在位置
        /// 不允许生成食物
        /// </summary>
        public IEnumerable<GridPosition> ForbiddenGridPosition {
            get {
                return _snakeController.SnakeBodyPositions.Union(new List<GridPosition>() { _snakeController.SnakeHeadPosition }).Union(_brickController.BrickPositions);
            }
        }

        /// <summary>
        /// 蛇头方向，修改时立刻移动蛇
        /// </summary>
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
        #endregion
        /// <summary>
        /// 游戏控制构造函数，设置项从GameEnvironment中读取
        /// </summary>
        /// <param name="entities">需要绘制的集合</param>
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
        #region 公共函数
        /// <summary>
        /// 开始游戏
        /// </summary>
        public void InitialGame() {
            _backgroundGridController.GenerateBackgroundGrid();
            _brickController.GenerateBricks();
            _snakeController.InitialSnake();
            _foodController.GenerateFood(ForbiddenGridPosition);
            _timer.Start();
        }
        /// <summary>
        /// 结束游戏，不允许重新启动
        /// </summary>
        public void StopGame() {
            _timer.Stop();
            _timer.Dispose();
        }
        #endregion

        #region 私有函数
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
        #endregion
    }
}
