using System.Windows;
using System.Windows.Media.Converters;

namespace TestProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Window secWin = new SecondMain();
        Window selectMenuItem = new SelectMenuItem();

        void CloseMainApplication(object sender, RoutedEventArgs e)
        {
            Close();
        }

        void DrugMoveApplication(object sender, RoutedEventArgs e)
        {
            DragMove();
        }

        void ShowSecWIn(object sender, RoutedEventArgs e)
        {
            selectMenuItem.Show();
            Close();
        }
    }
}