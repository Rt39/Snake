using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake {
    public class SnakeEntity {
        // 蛇的部分
        private struct SnakePart {
            public UIElement snakeShape;
            public Point position;
        }
        // 封装List，在每次对List进行操作时通知前端重绘
        private class SnakePartList {
            private Canvas _canvas;
            private List<SnakePart> _snakeParts = new List<SnakePart>();
            public IReadOnlyCollection<SnakePart> SnakeParts { get { return _snakeParts.AsReadOnly(); } }
            public SnakePartList(Canvas canvas) { _canvas = canvas; }
            public SnakePart this[int index] { get { return _snakeParts[index]; } }
            public int Count { get { return _snakeParts.Count; } }

            public void Insert(int index, SnakePart item) {
                _snakeParts.Insert(index, item);
                _canvas.Dispatcher.BeginInvoke(new Action(() =>
                {
                    _canvas.Children.Add(item.snakeShape);
                    Canvas.SetLeft(item.snakeShape, item.position.X);
                    Canvas.SetTop(item.snakeShape, item.position.Y);
                }
                ));
            }
            public void Add(SnakePart item) {
                _snakeParts.Add(item);
                _canvas.Dispatcher.BeginInvoke(new Action(() =>
                {
                    _canvas.Children.Add(item.snakeShape);
                    Canvas.SetLeft(item.snakeShape, item.position.X);
                    Canvas.SetTop(item.snakeShape, item.position.Y);
                }));
            }
            public void RemoveAt(int index) {
                _canvas.Dispatcher.Invoke(new Action(() =>
                {
                    _canvas.Children.Remove(_snakeParts[index].snakeShape);
                    Canvas.SetLeft(_snakeParts[index].snakeShape, _snakeParts[index].position.X);
                    Canvas.SetTop(_snakeParts[index].snakeShape, _snakeParts[index].position.Y);
                }));
                _snakeParts.RemoveAt(index);
            }
        }

        public enum SnakeDirection {
            Left,
            Up,
            Right,
            Down,
        }
        // 蛇的方向
        public SnakeDirection Direction { get; set; } = SnakeDirection.Right;
        // 蛇头部的位置
        public Point HeadPosition { get { return _snakeParts[0].position; } }
        // 蛇身子的位置
        public IEnumerable<Point> BodyPositions {
            get {
                return _snakeParts.SnakeParts.Skip(1).Select(t => t.position);
            }
        }

        private readonly GameField _gameField;
        private readonly Canvas _canvas;
        private readonly SnakePartList _snakeParts;

        public SnakeEntity(Canvas canvas, GameField gameField) {
            _canvas = canvas;
            _gameField = gameField;
            _snakeParts = new SnakePartList(canvas);
        }

        public void InitialSnake(int initialcount) {
            int y = _gameField.HeightGridCount / 2 * StaticUtils.gridSize;
            int headx = StaticUtils.gridSize * (initialcount + 1);
            _snakeParts.Add(new SnakePart()
            {
                position = new Point(headx, y),
                snakeShape = new Rectangle() { Width = StaticUtils.gridSize, Height = StaticUtils.gridSize, Fill = Brushes.Red }
            });
            for (int i = 1; i <= initialcount; ++i)
                _snakeParts.Add(new SnakePart()
                {
                    position = new Point(headx - i * StaticUtils.gridSize, y),
                    snakeShape = new Rectangle() { Width = StaticUtils.gridSize, Height = StaticUtils.gridSize, Fill = Brushes.Green }
                });
        }

        public void MoveSnake(bool eat) {
            if (!eat) {
                // 删除蛇尾
                _snakeParts.RemoveAt(_snakeParts.Count - 1);
            }
            // 将蛇头改为绿色
            ((Rectangle)_snakeParts[0].snakeShape).Fill = Brushes.Green;

            // 添加蛇头
            Point headPoint = _snakeParts[0].position;
            switch (Direction) {
                case SnakeDirection.Left:
                    _snakeParts.Insert(0, new SnakePart()
                    {
                        // Wrap
                        position = new Point((headPoint.X + _gameField.WidthTotal - StaticUtils.gridSize) % _gameField.WidthTotal, headPoint.Y),
                        snakeShape = new Rectangle() { Width = StaticUtils.gridSize, Height = StaticUtils.gridSize, Fill = Brushes.Red }
                    });
                    break;
                case SnakeDirection.Down:
                    _snakeParts.Insert(0, new SnakePart()
                    {
                        position = new Point(headPoint.X, (headPoint.Y + StaticUtils.gridSize) % _gameField.HeightTotal),
                        snakeShape = new Rectangle() { Width = StaticUtils.gridSize, Height = StaticUtils.gridSize, Fill = Brushes.Red }
                    });
                    break;
                case SnakeDirection.Right:
                    _snakeParts.Insert(0, new SnakePart()
                    {
                        position = new Point((headPoint.X + StaticUtils.gridSize) % _gameField.WidthTotal, headPoint.Y),
                        snakeShape = new Rectangle() { Width = StaticUtils.gridSize, Height = StaticUtils.gridSize, Fill = Brushes.Red }
                    });
                    break;
                case SnakeDirection.Up:
                    _snakeParts.Insert(0, new SnakePart()
                    {
                        position = new Point(headPoint.X, (headPoint.Y + _gameField.HeightTotal - StaticUtils.gridSize) % _gameField.HeightTotal),
                        snakeShape = new Rectangle() { Width = StaticUtils.gridSize, Height = StaticUtils.gridSize, Fill = Brushes.Red }
                    });
                    break;
            }
        }
    }
}
