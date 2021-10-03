using Snake.Controllers;
using Snake.Entities;
using Snake.ViewModels;
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
    /// Interaction logic for EditPage.xaml
    /// </summary>
    public partial class EditPage : Page {
        private readonly BackgroundGridController _backgroundGridController;
        private readonly SnakeController _snakeController;
        private readonly EditViewModel _editViewModel;
        public EditPage() {
            InitializeComponent();
            DataContext = _editViewModel = new EditViewModel();
        }
    }
}
