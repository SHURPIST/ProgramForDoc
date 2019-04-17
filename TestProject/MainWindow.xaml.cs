using System;
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
            bool flag = true;
            
            string[] Login = new string[10];
            Login[0] = "ЧИВ";
            Login[1] = "Черноиванов Игорь Владимирович";
            
            string[] Pass = new string[10];
            Pass[0] = "12345";
            Pass[1] = "Help12345";

            for (int i = 0; i < Login.Length; i++)
                if(logBox.Text == Login[i])
                    for(int j = 0; j < Pass.Length; j++  )
                        if (passBox.Password == Pass[j])
                        {
                            selectMenuItem.Show();
                            Close();
                        }
                        else
                            flag = false;

            if (flag)
                MessageBox.Show("Введён неверно логин/пароль!");
        }
    }
}