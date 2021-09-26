using Snake.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Snake.Controllers {
    public class FoodController : AbstructController {
        private Food _food = null;

        private readonly Brush _foodBrush;
        private readonly Brush _foodStrokeBrush;
        private readonly double _strokeThickness;
        public FoodController(ICollection<AbstructEntity> entities, Brush foodBrush, Brush foodStrokeBrush, double strokeThickness) {
            _entities = entities;
            _foodBrush = foodBrush;
            _foodStrokeBrush = foodStrokeBrush;
            _strokeThickness = strokeThickness;
        }

        public void GenerateFood(IEnumerable<GridPosition> forbiddenGridPossions) {
            if (_food != null)
                _entities.Remove(_food);
            uint row;
            uint column;

        }
    }
}
