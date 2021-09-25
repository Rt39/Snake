using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Snake.Entities;

namespace Snake.Controllers {
    public class BackgroundGridController {
        private Collection<AbstructEntity> _entities;  // 游戏场景的所有实体

        // 横、纵格子的数量
        private readonly int _widthGridCount;
        private readonly int _heightGridCount;
        public int WidthGridCount { get { return _widthGridCount; } }
        public int HeightGridCount { get { return _heightGridCount; } }

        public int WidthTotal { get { return GameEnvironment.gridSize * _widthGridCount; } }
        public int HeightTotal { get { return GameEnvironment.gridSize * _heightGridCount; } }

        // 相间格子的颜色
        private readonly Brush _grid1Color;
        private readonly Brush _grid2Color;
        public Brush Grid1Color { get { return _grid1Color; } }
        public Brush Grid2Color { get { return _grid2Color; } }

        public BackgroundGridController(Collection<AbstructEntity> entities, int widthGridCount, int heightGridCount, Brush grid1Color, Brush grid2Color) {
            _entities = entities;
            _widthGridCount = widthGridCount;
            _heightGridCount = heightGridCount;
            _grid1Color = grid1Color;
            _grid2Color = grid2Color;
        }

        public void GenerateBackgroundGrid() {
            bool outer_interval = true;
            for (int i = 0; i < _widthGridCount; ++i) {
                bool inner_interval = outer_interval;
                for (int j = 0; j < _heightGridCount; ++j) {
                    _entities.Add(new BackgroundGrid(i, j, inner_interval ? _grid1Color : _grid2Color, null, 0));
                    inner_interval = !inner_interval;
                }
                outer_interval = !outer_interval;
            }
        }
    }
}
