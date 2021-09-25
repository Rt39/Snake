using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Snake.Entities {
    public class BackgroundGrid : AbstructEntity {
        public BackgroundGrid(
            int horizentalCount,
            int verticalCount,
            Brush fill,
            Brush stroke,
            double strokeThickness
            ) :
            base(
                horizentalCount,
                verticalCount,
                fill,
                stroke,
                strokeThickness,
                new RectangleGeometry(
                    new System.Windows.Rect(0, 0, GameEnvironment.gridSize, GameEnvironment.gridSize)
                    )
                ) { }
    }
}
