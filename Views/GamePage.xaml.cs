using Snake.Controllers;
using Snake.Entities;
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

namespace Snake.Views {
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page {
        public ObservableCollection<AbstructEntity> Entities { get; } = new ObservableCollection<AbstructEntity>();

        private GameController _gameController;
        public GamePage() {
            InitializeComponent();
            DataContext = this;

            _gameController = new GameController(Entities);
            //Loaded += delegate { _gameController.InitialGame(); };

            _gameController.GameOver += delegate { MessageBox.Show("你死了"); };
        }

        private void InitialGame(object sender, EventArgs e) {
            _gameController.InitialGame();
            // 获取主窗体并将按键绑定上去
            Window window = Window.GetWindow(this);
            window.KeyUp += ChangeDirection;
        }

        public void StopGame() {
            _gameController.StopGame();
            Window window = Window.GetWindow(this);
            window.KeyUp -= ChangeDirection;
        }

        private void ChangeDirection(object sender, KeyEventArgs e) {
            switch (e.Key) {
                case Key.Left:
                    if (_gameController.Direction != SnakeController.SnakeDirection.Left && _gameController.Direction != SnakeController.SnakeDirection.Right)
                        _gameController.Direction = SnakeController.SnakeDirection.Left;
                    break;
                case Key.Up:
                    if (_gameController.Direction != SnakeController.SnakeDirection.Up && _gameController.Direction != SnakeController.SnakeDirection.Down)
                        _gameController.Direction = SnakeController.SnakeDirection.Up;
                    break;
                case Key.Right:
                    if (_gameController.Direction != SnakeController.SnakeDirection.Left && _gameController.Direction != SnakeController.SnakeDirection.Right)
                        _gameController.Direction = SnakeController.SnakeDirection.Right;
                    break;
                case Key.Down:
                    if (_gameController.Direction != SnakeController.SnakeDirection.Up && _gameController.Direction != SnakeController.SnakeDirection.Down)
                        _gameController.Direction = SnakeController.SnakeDirection.Down;
                    break;
            }
        }
    }
}
