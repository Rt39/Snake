using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using Snake.Views;

namespace Snake {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        //public ObservableCollection<AbstructEntity> Entities { get; set; } = new ObservableCollection<AbstructEntity>();

        ////private BackgroundGridController _gameField;
        ////private SnakeEntity _snakeEntity;
        ////private GameControl _gameControl;

        //private GameController _gameController;

        public MainWindow() {
            InitializeComponent();
            frame.Navigate(new GamePage());
            //DataContext = this;

            //_gameController = new GameController(Entities);

            //// .net framework 4.5新功能，不支持Windows XP
            ////BindingOperations.EnableCollectionSynchronization(Entities, new object());
            //Loaded += delegate { _gameController.InitialGame(); };

            //_gameController.GameOver += delegate { MessageBox.Show("你死了"); };

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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            if (MessageBox.Show("", "", MessageBoxButton.YesNoCancel) == MessageBoxResult.Cancel)
                e.Cancel = true;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        //private void ChangeDirection(object sender, KeyEventArgs e) {
        //    switch (e.Key) {
        //        case Key.Left:
        //            if (_gameController.Direction != SnakeController.SnakeDirection.Left && _gameController.Direction != SnakeController.SnakeDirection.Right)
        //                _gameController.Direction = SnakeController.SnakeDirection.Left;
        //            break;
        //        case Key.Up:
        //            if (_gameController.Direction != SnakeController.SnakeDirection.Up && _gameController.Direction != SnakeController.SnakeDirection.Down)
        //                _gameController.Direction = SnakeController.SnakeDirection.Up;
        //            break;
        //        case Key.Right:
        //            if (_gameController.Direction != SnakeController.SnakeDirection.Left && _gameController.Direction != SnakeController.SnakeDirection.Right)
        //                _gameController.Direction = SnakeController.SnakeDirection.Right;
        //            break;
        //        case Key.Down:
        //            if (_gameController.Direction != SnakeController.SnakeDirection.Up && _gameController.Direction != SnakeController.SnakeDirection.Down)
        //                _gameController.Direction = SnakeController.SnakeDirection.Down;
        //            break;
        //    }
        //}
    }
}
