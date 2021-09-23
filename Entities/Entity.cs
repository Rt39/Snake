using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Snake.Entities {
    public abstract class Entity {
        protected int _horizentalCount;
        public int HorizentalCount { get { return _horizentalCount; } }
        protected int _verticalCount;
        public int VerticalCount { get { return _verticalCount; } }

        public int X { get { return HorizentalCount * StaticUtils.gridSize; } }
        public int Y { get { return VerticalCount * StaticUtils.gridSize; } }

        private Point? _position = null;
        public Point Position {
            get {
                return (Point)(_position == null ? (_position = new Point(HorizentalCount * StaticUtils.gridSize, VerticalCount * StaticUtils.gridSize)) : _position);
            }
        }

        public UIElement Shape { get; set; }
    }
}
