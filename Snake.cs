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
    public class Snake {
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
        public SnakeDirection Direction { get; set; }

        private GameField _gameField;
        private Canvas _canvas;
        private List<SnakePart> _snakeParts;

        public void InitialSnake(int initialcount) {
            int y = _gameField.HeightGridCount / 2 * GridSize.gridSize;
            int headx = GridSize.gridSize * (initialcount + 1);
            _snakeParts.Add(new SnakePart()
            {
                position = new Point(headx, y),
                snakeShape = new Rectangle() { Width = GridSize.gridSize, Height = GridSize.gridSize, Fill = Brushes.Red }
            });
            for (int i = 0; i < initialcount; ++i)
                _snakeParts.Add(new SnakePart()
                {
                    position = new Point(headx - i * GridSize.gridSize, y),
                    snakeShape = new Rectangle() { Width = GridSize.gridSize, Height = GridSize.gridSize, Fill = Brushes.Green }
                });

            foreach (var v in _snakeParts) {
                _canvas.Children.Add(v.snakeShape);
                Canvas.SetLeft(v.snakeShape, v.position.X);
                Canvas.SetTop(v.snakeShape, v.position.Y);
            }
        }

        public void MoveSnake() {

            _snakeParts.RemoveAt(_snakeParts.Count - 1);

        }
    }
}
