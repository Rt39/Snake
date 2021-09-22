using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Snake.Entities;

namespace Snake {
    /// <summary>
    /// 负责计时及碰撞检测
    /// </summary>
    public class GameControl {
        private readonly Timer _timer = new Timer();
        private readonly GameField _gameField;
        private readonly SnakeEntity _snakeEntity;
        private readonly List<Brick> _bricks;
        private readonly Canvas _canvas;

        private Food _food;

        public GameControl(Canvas canvas, GameField gameField, SnakeEntity snakeEntity, List<Brick> bricks) {
            _canvas = canvas;
            _gameField = gameField;
            _snakeEntity = snakeEntity;
            _bricks = bricks;
            _timer.Interval = 100;
            _timer.Elapsed += delegate (object o, ElapsedEventArgs e) {
                _canvas.Dispatcher.Invoke(new Action(() =>
                _snakeEntity.MoveSnake(EatFood())));
                //GenerateFood();
            };
            GenerateFood();
        }

        public void StartTick() { _timer.Start(); }

        private bool CrashIntoWall() {
            foreach (var b in _bricks)
                if (Point.Equals(b.Position, _snakeEntity.HeadPosition)) return true;
            return false;
        }

        private bool EatFood() {
            return Point.Equals(_food.Position, _snakeEntity.HeadPosition);
        }

        private void GenerateFood() {
            if (_food != null)
                _canvas.Children.Remove(_food.Shape);
            List<Point> forbiddenPoints = new List<Point>();
            foreach (var b in _bricks) forbiddenPoints.Add(b.Position);
            forbiddenPoints.Add(_snakeEntity.HeadPosition);
            int X = StaticUtils.rand.Next(_gameField.WidthGridCount);
            int Y = StaticUtils.rand.Next(_gameField.HeightGridCount);
            while (forbiddenPoints.FirstOrDefault(
                p => Point.Equals(p, new Point(X * StaticUtils.gridSize, Y * StaticUtils.gridSize))) != default(Point)) {
                X = StaticUtils.rand.Next(_gameField.WidthGridCount);
                Y = StaticUtils.rand.Next(_gameField.HeightGridCount);
            }
            _food = new Food(X, Y, System.Windows.Media.Brushes.Yellow);
            _canvas.Children.Add(_food.Shape);
            Canvas.SetLeft(_food.Shape, _food.Position.X);
            Canvas.SetTop(_food.Shape, _food.Position.Y);
        }

    }
}
