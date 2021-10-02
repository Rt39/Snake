using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Snake.ViewModels {
    public class NewGameEnvironmentViewModel : AbstructViewModel {
        #region 设置属性
        #region 场景设置
        private uint _row;
        public uint Row {
            get => _row;
            set => SetProperty(ref _row, value);
        }
        private uint _column;
        public uint Column {
            get => _column;
            set => SetProperty(ref _column, value);
        }
        private int _gridSize;
        public int GridSize {
            get => _gridSize;
            set => SetProperty(ref _gridSize, value);
        }
        private int _timeInterval;
        public int TimeInterval {
            get => _timeInterval;
            set => SetProperty(ref _timeInterval, value);
        }
        #endregion
        #region 背景砖块设置
        private Brush _grid1Fill;
        public Brush Grid1Fill {
            get => _grid1Fill;
            set => SetProperty(ref _grid1Fill, value);
        }
        private Brush _grid2Fill;
        public Brush Grid2Fill {
            get => _grid2Fill;
            set => SetProperty(ref _grid2Fill, value);
        }
        #endregion
        #region 蛇设置
        private Brush _snakeBodyFill;
        public Brush SnakeBodyFill {
            get => _snakeBodyFill;
            set => SetProperty(ref _snakeBodyFill, value);
        }
        private Brush _snakeHeadFill;
        public Brush SnakeHeadFill {
            get => _snakeHeadFill;
            set => SetProperty(ref _snakeHeadFill, value);
        }
        #endregion
        #region 食物设置
        private Brush _foodFill;
        public Brush FoodFill {
            get => _foodFill;
            set => SetProperty(ref _foodFill, value);
        }
        private Brush _foodStroke;
        public Brush FoodStroke {
            get => _foodStroke;
            set => SetProperty(ref _foodStroke, value);
        }
        private double _foodStrokeThickness;
        public double FoodStrokeThickness {
            get => _foodStrokeThickness;
            set => SetProperty(ref _foodStrokeThickness, value);
        }
        #endregion
        #region 砖块设置
        private Brush _brickFill;
        public Brush BrickFill {
            get => _brickFill;
            set => SetProperty(ref _brickFill, value);
        }
        private Brush _brickStroke;
        public Brush BrickStroke {
            get => _brickStroke;
            set => SetProperty(ref _brickStroke, value);
        }
        private double _brickStrokeThickness;
        public double BrickStrokeThickness {
            get => _brickStrokeThickness;
            set => SetProperty(ref _brickStrokeThickness, value);
        }
        #endregion
        #endregion
        public NewGameEnvironmentViewModel() {
            _row = GameEnvironment.rowCount;
            _column = GameEnvironment.columnCount;
            _gridSize = GameEnvironment.gridSize;
            _timeInterval = GameEnvironment.interval;
            _grid1Fill = GameEnvironment.grid1Brush;
            _grid2Fill = GameEnvironment.grid2Brush;
            _snakeBodyFill = GameEnvironment.snakeBodyBrush;
            _snakeHeadFill = GameEnvironment.snakeHeadBrush;
            _foodFill = GameEnvironment.foodBrush;
            _foodStroke = GameEnvironment.foodStroke;
            _foodStrokeThickness = GameEnvironment.foodStrokeThickness;
            _brickFill = GameEnvironment.brickBrush;
            _brickStroke = GameEnvironment.brickStroke;
            _brickStrokeThickness = GameEnvironment.brickStrokeThickness;
        }

        public void Submit() {
            GameEnvironment.rowCount = _row;
            GameEnvironment.columnCount = _column;
            GameEnvironment.gridSize = _gridSize;
            GameEnvironment.interval = _timeInterval;
            GameEnvironment.grid1Brush = _grid1Fill;
            GameEnvironment.grid2Brush = _grid2Fill;
            GameEnvironment.snakeBodyBrush = _snakeBodyFill;
            GameEnvironment.snakeHeadBrush = _snakeHeadFill;
            GameEnvironment.foodBrush = _foodFill;
            GameEnvironment.foodStroke = _foodStroke;
            GameEnvironment.foodStrokeThickness = _foodStrokeThickness;
            GameEnvironment.brickBrush = _brickFill;
            GameEnvironment.brickStroke = _brickStroke;
            GameEnvironment.brickStrokeThickness = _brickStrokeThickness;
        }
    }
}
