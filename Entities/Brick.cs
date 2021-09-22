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

        public Brick(int X, int Y, Brush brush) {
            this.X = X;
            this.Y = Y;
            _brush = brush;
            this.Shape = new Rectangle() { Width = StaticUtils.gridSize, Height = StaticUtils.gridSize, Fill = brush };
        }
    }
}
