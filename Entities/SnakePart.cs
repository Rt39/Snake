using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Snake.Entities {
    public class SnakePart : AbstructEntity {
        public SnakePart(
            uint row,
            uint column,
            Brush fill,
            Brush stroke,
            double strokeThickness
            ) :
            base(
                row,
                column,
                fill,
                stroke,
                strokeThickness,
                new RectangleGeometry(
                    new System.Windows.Rect(0, 0, GameEnvironment.gridSize, GameEnvironment.gridSize)
                    )
                ) { }
        public SnakePart(
            GridPosition position,
            Brush fill,
            Brush stroke,
            double strokeThickness
            ) :
            base(
                position,
                fill,
                stroke,
                strokeThickness,
                new RectangleGeometry(
                    new System.Windows.Rect(0, 0, GameEnvironment.gridSize, GameEnvironment.gridSize)
                    )
                ) { }
    }
}
