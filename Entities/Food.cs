using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake.Entities {
    public class Food : AbstructEntity {
        public Food(
            int horizentalCount,
            int verticalCount,
            Brush fill,
            Brush stroke,
            double strokeThickness
            ) : base(
                horizentalCount,
                verticalCount,
                fill,
                stroke,
                strokeThickness,
                new EllipseGeometry(
                    new Rect(0, 0, GameEnvironment.gridSize, GameEnvironment.gridSize)
                    )
                ) { }
    }
}