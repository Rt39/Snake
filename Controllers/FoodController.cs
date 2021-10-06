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

        public GridPosition FoodPosition { get { return _food.Position; } }

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
                System.Windows.Application.Current.Dispatcher.Invoke(new Action(() => _entities.Remove(_food)));
            GridPosition p;
            do {
                uint row = (uint)GameEnvironment.rand.Next((int)GameEnvironment.rowCount);
                uint column = (uint)GameEnvironment.rand.Next((int)GameEnvironment.columnCount);
                p = new GridPosition(row, column);
            } while (forbiddenGridPossions.Contains(p));
            _food = new Food(p, _foodBrush, _foodStrokeBrush, _strokeThickness);
            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() => _entities.Add(_food)));
        }
    }
}
