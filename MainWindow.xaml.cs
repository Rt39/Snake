using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Snake.Controllers;
using Snake.Entities;

namespace Snake {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public ObservableCollection<AbstructEntity> Entities { get; set; } = new ObservableCollection<AbstructEntity>();

        //private BackgroundGridController _gameField;
        //private SnakeEntity _snakeEntity;
        //private GameControl _gameControl;

        private GameController _gameController;

        public MainWindow() {
            InitializeComponent();
            DataContext = this;

            _gameController = new GameController(Entities);

            //BindingOperations.EnableCollectionSynchronization(Entities, new object());
            Loaded += delegate { _gameController.InitialGame(); };

            //_gameField = new BackgroundGridController(
            //    Entities,
            //    Brushes.White,
            //    Brushes.Gray
            //    );
            //_gameField.GenerateBackgroundGrid();

            //_snakeEntity = new SnakeEntity(gameField, _gameField);
            //_snakeEntity.InitialSnake(4);

            //_gameControl = new GameControl(gameField, _gameField, _snakeEntity, new List<Entities.Brick>());
            //_gameControl.StartTick();
        }

        //private void ChangeDirection(object sender, KeyEventArgs e) {
        //    switch (e.Key) {
        //        case Key.Left:
        //            if (_snakeEntity.Direction != SnakeEntity.SnakeDirection.Left && _snakeEntity.Direction != SnakeEntity.SnakeDirection.Right)
        //                _snakeEntity.Direction = SnakeEntity.SnakeDirection.Left;
        //            break;
        //        case Key.Up:
        //            if (_snakeEntity.Direction != SnakeEntity.SnakeDirection.Up && _snakeEntity.Direction != SnakeEntity.SnakeDirection.Down)
        //                _snakeEntity.Direction = SnakeEntity.SnakeDirection.Up;
        //            break;
        //        case Key.Right:
        //            if (_snakeEntity.Direction != SnakeEntity.SnakeDirection.Left && _snakeEntity.Direction != SnakeEntity.SnakeDirection.Right)
        //                _snakeEntity.Direction = SnakeEntity.SnakeDirection.Right;
        //            break;
        //        case Key.Down:
        //            if (_snakeEntity.Direction != SnakeEntity.SnakeDirection.Up && _snakeEntity.Direction != SnakeEntity.SnakeDirection.Down)
        //                _snakeEntity.Direction = SnakeEntity.SnakeDirection.Down;
        //            break;
        //    }
        //}
    }
}
