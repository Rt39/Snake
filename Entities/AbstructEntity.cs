using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Snake.Entities {
    public abstract class AbstructEntity {
        protected readonly GridPosition _gridPosition;
        public GridPosition GridPos { get { return _gridPosition; } }
        public Point Position { get { return (Point)_gridPosition; } }
        public uint Row { get { return _gridPosition.row; } }
        public uint Column { get { return _gridPosition.column; } }
        public double X { get { return Position.X; } }
        public double Y { get { return Position.Y; } }

        protected readonly Geometry _shape;
        /// <summary>
        /// 实体的形状
        /// </summary>
        public Geometry Shape { get { return _shape; } }

        protected readonly Brush _fill;
        /// <summary>
        /// 实体的填充色
        /// </summary>
        public Brush Fill { get { return _fill; } }

        protected readonly Brush _stroke;
        /// <summary>
        /// 实体的边框色
        /// </summary>
        public Brush Stroke { get { return _stroke; } }

        protected readonly double _strokeThickness;
        /// <summary>
        /// 实体的边框厚度
        /// </summary>
        public double StrokeThickness { get { return _strokeThickness; } }

        #region 构造函数
        public AbstructEntity(GridPosition position, Brush fill, Brush stroke, double strokeThickness, Geometry shape) {
            _gridPosition = position;
            _fill = fill;
            _stroke = stroke;
            _strokeThickness = strokeThickness;
            _shape = shape;
        }
        public AbstructEntity(uint row, uint column, Brush fill, Brush stroke, double strokeThickness, Geometry shape) : this(new GridPosition(row, column), fill, stroke, strokeThickness, shape) { }
        #endregion
    }
}
