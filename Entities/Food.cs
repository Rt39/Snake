using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake.Entities {
    public class Food : Entity {
        private Brush _brush;
        public Brush Brush { get { return _brush; } }

        public Food(int X, int Y, Brush brush) {
            this._horizentalCount = X;
            this._verticalCount = Y;
            _brush = brush;
            this.Shape = new Ellipse() { Width = StaticUtils.gridSize, Height = StaticUtils.gridSize, Fill = brush };
        }
    }
}
