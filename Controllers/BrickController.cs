using Snake.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Snake.Controllers {
    public class BrickController : AbstructController {
        private readonly IEnumerable<GridPosition> _brickPositions;
        private readonly Brush _brickBrush;
        private readonly Brush _brickStroke;
        private readonly double _strokeThickness;

        public IEnumerable<GridPosition> BrickPositions { get { return _brickPositions; } }

        public BrickController(ICollection<AbstructEntity> entities, IEnumerable<GridPosition> brickPositions, Brush brickBrush, Brush brickStroke, double strokeThickness) {
            _entities = entities;
            _brickPositions = brickPositions;
            _brickBrush = brickBrush;
            _brickStroke = brickStroke;
            _strokeThickness = strokeThickness;
        }
        public void GenerateBricks() {
            foreach (GridPosition p in _brickPositions)
                _entities.Add(new Brick(p, _brickBrush, _brickStroke, _strokeThickness));
        }
    }
}
