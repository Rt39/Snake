using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake.Entities {
    public class Brick : Entity {
        private Brush _brush;
        public Brush Brush { get { return _brush; } }

        public Brick(int horizentalCount, int verticalCount, Brush brush) {
            this._horizentalCount = horizentalCount;
            this._verticalCount = verticalCount;
            _brush = brush;
            this.Shape = new Rectangle() { Width = StaticUtils.gridSize, Height = StaticUtils.gridSize, Fill = brush };
        }
    }
}
