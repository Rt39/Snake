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
    public class BackgroundGridController : AbstructController {
        // 横、纵格子的数量
        private readonly uint _columnCount;
        private readonly uint _rowCount;
        public uint ColumnCount { get { return _columnCount; } }
        public uint RowGridCount { get { return _rowCount; } }

        public double WidthTotal { get { return GameEnvironment.gridSize * _columnCount; } }
        public double HeightTotal { get { return GameEnvironment.gridSize * _rowCount; } }

        // 相间格子的颜色
        private readonly Brush _grid1Brush;
        private readonly Brush _grid2Brush;
        public Brush Grid1Brush { get { return _grid1Brush; } }
        public Brush Grid2Brush { get { return _grid2Brush; } }

        public BackgroundGridController(Collection<AbstructEntity> entities, uint rowCount, uint columnCount, Brush grid1Color, Brush grid2Color) {
            _entities = entities;
            _rowCount = rowCount;
            _columnCount = columnCount;
            _grid1Brush = grid1Color;
            _grid2Brush = grid2Color;
        }

        public void GenerateBackgroundGrid() {
            bool outer_interval = true;
            for (uint i = 0; i < _rowCount; ++i) {
                bool inner_interval = outer_interval;
                for (uint j = 0; j < _columnCount; ++j) {
                    _entities.Add(new BackgroundGrid(i, j, inner_interval ? _grid1Brush : _grid2Brush, null, 0));
                    inner_interval = !inner_interval;
                }
                outer_interval = !outer_interval;
            }
        }
    }
}
