using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Snake.Entities {
    public abstract class AbstructEntity {
        protected readonly int _horizentalCount;
        /// <summary>
        /// 横向位置（格）
        /// </summary>
        public int HorizentalCount { get { return _horizentalCount; } }
        protected readonly int _verticalCount;
        /// <summary>
        /// 纵向位置（格）
        /// </summary>
        public int VerticalCount { get { return _verticalCount; } }

        /// <summary>
        /// 横向位置（坐标X）
        /// </summary>
        public double X { get { return HorizentalCount * GameEnvironment.gridSize; } }
        /// <summary>
        /// 纵向位置（坐标Y）
        /// </summary>
        public double Y { get { return VerticalCount * GameEnvironment.gridSize; } }

        //private Point? _position = null;
        //public Point Position {
        //    get {
        //        return (Point)(_position == null ? (_position = new Point(HorizentalCount * StaticUtils.gridSize, VerticalCount * StaticUtils.gridSize)) : _position);
        //    }
        //}

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

        public AbstructEntity(int horizentalCount, int verticalCount, Brush fill, Brush stroke, double strokeThickness, Geometry shape) {
            _horizentalCount = horizentalCount;
            _verticalCount = verticalCount;
            _fill = fill;
            _stroke = stroke;
            _strokeThickness = strokeThickness;
            _shape = shape;
        }
    }
}
