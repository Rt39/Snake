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
        private readonly DispatcherTimer _timer;
        private readonly BackgroundGridController _backgroundGridController;
        private readonly SnakeController _snakeController;
        public GameController(ICollection<AbstructEntity> entities) {
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            _backgroundGridController = new BackgroundGridController(entities, GameEnvironment.grid1Brush, GameEnvironment.grid2Brush);
            _snakeController = new SnakeController(entities, GameEnvironment.snakeHeadBrush, GameEnvironment.snakeBodyBrush, GameEnvironment.initialBodyCount, GameEnvironment.initialSnakeHead, GameEnvironment.initialDirection);
            _timer.Tick += Timer_Elapsed;
        }

        public void InitialGame() {
            _backgroundGridController.GenerateBackgroundGrid();
            _snakeController.InitialSnake();
            _timer.Start();
        }

        private void Timer_Elapsed(object sender, EventArgs e) {
            _snakeController.MoveSnake(false);
        }
    }
}
