using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Snake.Entities {
    /// <summary>
    /// 在网格上的行、列位置
    /// </summary>
    public struct GridPosition {
        public uint row;
        public uint column;
        public GridPosition(uint row, uint column) {
            checked {
                this.row = row;
                this.column = column;
            }
        }
        public static explicit operator Point(GridPosition position) {
            return new Point(position.column * GameEnvironment.gridSize, position.row * GameEnvironment.gridSize);
        }
        public static explicit operator GridPosition(Point point) {
            return new GridPosition((uint)(point.Y / GameEnvironment.gridSize), (uint)(point.X / GameEnvironment.gridSize));
        }
    }
}
