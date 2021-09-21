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
        private struct SnakePart {
            public UIElement snakeShape;
            public Point position;
        }

        public enum SnakeDirection {
            Left,
            Up,
            Right,
            Down,
        }
        public SnakeDirection Direction { get; set; } = SnakeDirection.Right;

        private readonly GameField _gameField;
        private readonly Canvas _canvas;
        private readonly List<SnakePart> _snakeParts;

        public SnakeEntity(Canvas canvas, GameField gameField) {
            _canvas = canvas;
            _gameField = gameField;
            _snakeParts = new List<SnakePart>();
        }

        public void InitialSnake(int initialcount) {
            int y = _gameField.HeightGridCount / 2 * GridSize.gridSize;
            int headx = GridSize.gridSize * (initialcount + 1);
            _snakeParts.Add(new SnakePart()
            {
                position = new Point(headx, y),
                snakeShape = new Rectangle() { Width = GridSize.gridSize, Height = GridSize.gridSize, Fill = Brushes.Red }
            });
            for (int i = 1; i <= initialcount; ++i)
                _snakeParts.Add(new SnakePart()
                {
                    position = new Point(headx - i * GridSize.gridSize, y),
                    snakeShape = new Rectangle() { Width = GridSize.gridSize, Height = GridSize.gridSize, Fill = Brushes.Green }
                });

            foreach (SnakePart v in _snakeParts) {
                _canvas.Children.Add(v.snakeShape);
                Canvas.SetLeft(v.snakeShape, v.position.X);
                Canvas.SetTop(v.snakeShape, v.position.Y);
            }
        }

        public void MoveSnake() {
            _canvas.Children.Remove(_snakeParts[_snakeParts.Count - 1].snakeShape);
            _snakeParts.RemoveAt(_snakeParts.Count - 1);
            ((Rectangle)_snakeParts[0].snakeShape).Fill = Brushes.Green;

            Point headPoint = _snakeParts[0].position;
            switch (Direction) {
                case SnakeDirection.Left:
                    _snakeParts.Insert(0, new SnakePart()
                    {
                        position = new Point(headPoint.X - GridSize.gridSize, headPoint.Y),
                        snakeShape = new Rectangle() { Width = GridSize.gridSize, Height = GridSize.gridSize, Fill = Brushes.Red }
                    });
                    break;
                case SnakeDirection.Up:
                    _snakeParts.Insert(0, new SnakePart()
                    {
                        position = new Point(headPoint.X, headPoint.Y + GridSize.gridSize),
                        snakeShape = new Rectangle() { Width = GridSize.gridSize, Height = GridSize.gridSize, Fill = Brushes.Red }
                    });
                    break;
                case SnakeDirection.Right:
                    _snakeParts.Insert(0, new SnakePart()
                    {
                        position = new Point(headPoint.X + GridSize.gridSize, headPoint.Y),
                        snakeShape = new Rectangle() { Width = GridSize.gridSize, Height = GridSize.gridSize, Fill = Brushes.Red }
                    });
                    break;
                case SnakeDirection.Down:
                    _snakeParts.Insert(0, new SnakePart()
                    {
                        position = new Point(headPoint.X, headPoint.Y - GridSize.gridSize),
                        snakeShape = new Rectangle() { Width = GridSize.gridSize, Height = GridSize.gridSize, Fill = Brushes.Red }
                    });
                    break;
            }

            _canvas.Children.Add(_snakeParts[0].snakeShape);
            Canvas.SetLeft(_snakeParts[0].snakeShape, _snakeParts[0].position.X);
            Canvas.SetTop(_snakeParts[0].snakeShape, _snakeParts[0].position.Y);
        }
    }
}
