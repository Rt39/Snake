using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Snake.Controllers;
using Snake.Entities;

namespace Snake {
    /// <summary>
    /// 负责计时及碰撞检测
    /// </summary>
    public class GameControl {
        private readonly Timer _timer = new Timer();
        private readonly BackgroundGridController _gameField;
        private readonly SnakeEntity _snakeEntity;
        private readonly List<Brick> _bricks;
        private readonly Canvas _canvas;

        private Food _food;

        //public GameControl(Canvas canvas, BackgroundGridController gameField, SnakeEntity snakeEntity, List<Brick> bricks) {
        //    _canvas = canvas;
        //    _gameField = gameField;
        //    _snakeEntity = snakeEntity;
        //    _bricks = bricks;
        //    _timer.Interval = GameEnvironment.interval;
        //    _timer.Elapsed += _timer_Tick;
        //    GenerateFood();
        //}

        //public void StartTick() { _timer.Start(); }

        //private void _timer_Tick(object o,ElapsedEventArgs e)
        //{
        //    _canvas.Dispatcher.Invoke(new Action(() =>
        //    {
        //        _snakeEntity.MoveSnake(EatFood());
        //    }));
        //    if (IsGameOver()) {
        //        _timer.Stop();
        //        MessageBox.Show("你死了");
        //    }
        //}

        //private bool IsGameOver() {
        //    foreach (var b in _bricks)
        //        if (Point.Equals(b.Position, _snakeEntity.HeadPosition)) return true;
        //    foreach (var v in _snakeEntity.BodyPositions)
        //        if (Point.Equals(v, _snakeEntity.HeadPosition)) return true;
        //    return false;
        //}

        //private bool EatFood() {
        //    return Point.Equals(_food.Position, _snakeEntity.HeadPosition);
        //}

        //private void GenerateFood() {
        //    if (_food != null)
        //        _canvas.Children.Remove(_food.Shape);
        //    // 获取所有禁着点
        //    IEnumerable<Point> forbiddenPoints = new List<Point>();
        //    forbiddenPoints = _bricks.Select(t => t.Position).Append(_snakeEntity.HeadPosition).Union(_snakeEntity.BodyPositions);

        //    int X = GameEnvironment.rand.Next(_gameField.WidthGridCount);
        //    int Y = GameEnvironment.rand.Next(_gameField.HeightGridCount);
        //    while (forbiddenPoints.FirstOrDefault(
        //        p => Point.Equals(p, new Point(X * GameEnvironment.gridSize, Y * GameEnvironment.gridSize))) != default(Point)) {
        //        X = GameEnvironment.rand.Next(_gameField.WidthGridCount);
        //        Y = GameEnvironment.rand.Next(_gameField.HeightGridCount);
        //    }
        //    _food = new Food(X, Y, System.Windows.Media.Brushes.Yellow);
        //    _canvas.Children.Add(_food.Shape);
        //    Canvas.SetLeft(_food.Shape, _food.Position.X);
        //    Canvas.SetTop(_food.Shape, _food.Position.Y);
        //}

    }
}
