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
        public BrickController(ICollection<AbstructEntity> entities, IEnumerable<GridPosition> brickPositions, Brush brickBrush) {
            _entities = entities;
            _brickPositions = brickPositions;
            _brickBrush = brickBrush;
        }
        public void GenerateBricks() {

        }
    }
}
