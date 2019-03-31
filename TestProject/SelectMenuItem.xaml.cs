using System.Windows;

namespace TestProject
{
    public partial class SelectMenuItem : Window
    {
        public SelectMenuItem()
        {
            InitializeComponent();
        }
        

        void DragMoveWinFun(object sender, RoutedEventArgs e)
        {
            DragMove();
        }

        void CloseMainApplication(object sender, RoutedEventArgs e)
        {
            Close();
        }

        void birth_history(object sender, RoutedEventArgs e)
        {
            SecondMain birth_history_page = new SecondMain();
            birth_history_page.Show();
            Close();
        }

        void during_childbrin(object sender, RoutedEventArgs e)
        {
            During_childbrin dur_chil = new During_childbrin();
            dur_chil.Show();
            Close();
        }

        void dinamicObs(object sender, RoutedEventArgs e)
        {
            DinamicObservation dinam_obs = new DinamicObservation();
            dinam_obs.Show();
            Close();
        }
    }
}
