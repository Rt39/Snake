using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake {
    public class GameField {
        private Canvas _gameField;  // 放置游戏场地的位置

        // 横、纵格子的数量
        private int _widthGridCount;
        private int _heightGridCount;
        public int WidthGridCount { get { return _widthGridCount; } }
        public int HeightGridCount { get { return _heightGridCount; } }

        public int WidthTotal { get { return StaticUtils.gridSize * _widthGridCount; } }
        public int HeightTotal { get { return StaticUtils.gridSize * _heightGridCount; } }

        // 相间格子的颜色
        private Brush _grid1Color;
        private Brush _grid2Color;
        public Brush Grid1Color { get { return _grid1Color; } }
        public Brush Grid2Color { get { return _grid2Color; } }

        // 背景图片
        private Image _background = null;
        public Image Background { get { return _background; } }

        public GameField(Canvas gameField, int widthGridCount, int heightGridCount, Brush grid1Color, Brush grid2Color, Image background = null) {
            _gameField = gameField;
            _widthGridCount = widthGridCount;
            _heightGridCount = heightGridCount;
            _grid1Color = grid1Color;
            _grid2Color = grid2Color;
            _background = background;
        }

        public void DrawGameField() {
            bool outer_interval = true;
            for (int i = 0; i < _heightGridCount; ++i) {
                bool inner_interval = outer_interval;
                for (int j = 0; j < _widthGridCount; ++j) {
                    Rectangle rectangle = new Rectangle() { Width = StaticUtils.gridSize, Height = StaticUtils.gridSize };
                    rectangle.Fill = inner_interval ? _grid1Color : _grid2Color;
                    inner_interval = !inner_interval;   // 间隔放置方块
                    _gameField.Children.Add(rectangle);
                    Canvas.SetLeft(rectangle, j * StaticUtils.gridSize);
                    Canvas.SetTop(rectangle, i * StaticUtils.gridSize);
                }
                outer_interval = !outer_interval;
            }

            // 设置背景
            if (_background == null) return;
            ImageBrush imgBrush = new ImageBrush(_background.Source);
            _gameField.Background = imgBrush;
        }
    }
}
