using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Snake.Entities {
    public abstract class Entity {
        public int X { get; set; }
        public int Y { get; set; }

        private Point? _position = null;
        public Point Position {
            get {
                return (Point)(_position == null ? (_position = new Point(X * StaticUtils.gridSize, Y * StaticUtils.gridSize)) : _position);
            }
        }

        public UIElement Shape { get; set; }
    }
}
