using System.Windows;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Media;
using Button = System.Windows.Controls.Button;
using HorizontalAlignment = System.Windows.HorizontalAlignment;
using PrintDialog = System.Windows.Controls.PrintDialog;
using TextBox = System.Windows.Controls.TextBox;
using WinForms = System.Windows.Forms;
using Microsoft.Speech.Recognition;
using Label = System.Windows.Controls.Label;
using Microsoft.Speech.Synthesis;
using Word = Microsoft.Office.Interop.Word; //Надо подключить

namespace TestProject
{
    public partial class During_childbrin : Window
    {
        public During_childbrin()
        {
            InitializeComponent();
        }

        public string directory = @"E:\";
        public string SaveDierectory;

        void ClearSearch(object sender, RoutedEventArgs e)
        {
            SearchPacientok.Text = "";
        }

        void SeetingsClick(object sender, RoutedEventArgs e) // Открытие меню настроек
        {
            if (StackMenu.Visibility == Visibility.Hidden)
            {
                StackMenu.Visibility = Visibility.Visible;
            }
            else StackMenu.Visibility = Visibility.Hidden;
        }

        void AddPacientkuPZ(object sender, RoutedEventArgs e)
        {
            
        }
        
        //Блок поиска пациентки
        void TextBoxChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        
        //Меняем директорию
        void SelectedCreateFileDirectClick(object sender,
            RoutedEventArgs e) //Функция вызова меню с выбором поиска файла
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            DialogResult result = folderBrowser.ShowDialog();

            if (!string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
            {
                SaveDierectory = folderBrowser.SelectedPath;
            }
        }
        
        void SelectedFindFileDirectClick(object sender, RoutedEventArgs e) //Функция вызова меню с выбором поиска файла
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            DialogResult result = folderBrowser.ShowDialog();

            if (!string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
            {
                string[] files = Directory.GetFiles(folderBrowser.SelectedPath);
                string diraction = folderBrowser.SelectedPath;
                directory = diraction;
            }
        }
    }
}