using System;
using System.Collections.Generic;
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

namespace Snake {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private GameField _gameField;
        private SnakeEntity _snakeEntity;
        public MainWindow() {
            InitializeComponent();
            _gameField = new GameField(
                gameField,
                40,
                20,
                Brushes.White.Color,
                Brushes.Gray.Color
                );
            _gameField.DrawGameField();

            _snakeEntity = new SnakeEntity(gameField, _gameField);
            _snakeEntity.InitialSnake(4);
        }

    }
}
