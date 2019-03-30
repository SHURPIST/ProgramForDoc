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
using Microsoft.Speech.Internal;
using Microsoft.Speech.Recognition.SrgsGrammar;
using System;
using System.Collections.Generic;
using Microsoft.Speech.Recognition;
using Microsoft.Speech.Synthesis;
using System.Globalization;
using System.Net;
using System.Reflection;
using System.Text;
using Microsoft.Speech.Synthesis.TtsEngine;
using CheckBox = System.Windows.Controls.CheckBox;
using MessageBox = System.Windows.MessageBox;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Threading;
using IronPython.Modules;
using RadioButton = System.Windows.Controls.RadioButton;

namespace TestProject
{
    public partial class SecondMain : Window
    {
        public bool shablon_nach_a4TF = true;
        public bool AnamnezlivetableTF = false;
        public bool GinekAnalizTF = false;
        public bool TechBerTF = false;


        public bool BaseObjectTF = false;
        public bool VlagIssledPanelTF = false;
        public bool PlanVedodTF = false;
        public bool ShkalaPerRiskTF = false;
        public bool NaznachTF = false;


        public string VectorDock;

        public string[] DateTime = new string[4];// Массивы с параметрами
        public string[] twoHis = new string[6];
        public string[] startMake = new string[6];

        public string[] anamLife = new string[17];
        public string[] husOldS = new string[4];
        public string[] husBlood = new string[4];
        public string[] husSmoke = new string[4];
        public string[] allWordsEnd = new string[50]; // Все парамметры добавляй сюда 


        //Анамез жизни
        public string AllDiases;

        public string PacientState;

        public string Smoke;

        public string ProfHar;

        public string Gemotransf;

        public string DrugsPacient;

        public string Vhich;

        public string Anam;

        public string HronDiases;

        public string HusbandGroup;

        public string Rh;

        public string SmokeHusband;



//Гинекологический анмнез

        public string Minarh;

        public string Contr;


        //Течение данной беременности
        public string Since;
        public string DinamikAD;

        public string BloodGroup;
        public string BRh;
        public string GospBer;
        public string TimeBerM;
        public string TimeBerZ;
        public string TimeBerUzi;
        public string TimeBerOb;



        //Строка с директорией поиска файла
        public string directory = @"E:\";
        public string SaveDierectory;

        public List<TextBox> textList = new List<TextBox>();
        public List<RadioButton> checkList = new List<RadioButton>();

        public string saveTextVol = "";
        public string[] oneString = new string[8] {"Дата","Время","ИСТОРИЯ РОДОВ","ФИО:","ВОЗРАСТ","Хронические","Rh","Наркотики"}; // Массив однострочных парамметров, но поплнять его уже вроде как не надо

        public string[] tittleString = new string[7]
        {
            "Анамнез", "Гинекологический анамнез", "Исход предыдущих беременностей",
            "Течение данной беременности", "Данные объективного обследования", "Влагалищное исследование",
            "План ведения родов"
        }; // Массив заголовков он нужен для их обособления
        public SecondMain()
        {
            //  voice = scope.GetVariable("word");
         //   System.Diagnostics.Process p = new System.Diagnostics.Process();
        //    p.StartInfo.FileName = @"python vol.py";
        //    p.Start();
            
            InitializeComponent();
            System.Diagnostics.Process.Start("pythonw.exe",@"get.pyw"); 
            try
                        {
                           directory =  File.ReadAllText("SetDirectory.set");
                        }
                        catch
                        {
                            File.WriteAllText("SetDirectory.set","");
                            directory = @"E:\";
                        }
                        try
                        {
                            SaveDierectory =  File.ReadAllText("SarchtDirectory.set");
                        }
                        catch
                        {
                            File.WriteAllText("SarchtDirectory.set","");
                            SaveDierectory = "";
                        }
        }
        
        //Активация голосового поиска

        void ActivationGolVvod(object sender, RoutedEventArgs e)
        {

            try
            {
                if (File.ReadAllText("ready.st") == "true")
                {
                    string text  = File.ReadAllText("vol.txt",Encoding.GetEncoding(1251));

          
                        
                            saveTextVol = text;
                            SearchPacientok.Text = text;
                        
                    
                }
                else
                {
                    MessageBox.Show(
                        "В данный момент модуь обработки звука не запущен. Повторите запрос через пару минут");
                }
            }
            catch
            {
                MessageBox.Show(
                    "В данный момент модуь обработки звука не запущен. Повторите запрос через пару минут");
            }

        }


        void DrugsMain(object sender, RoutedEventArgs e)
        {
            
        }
        
        void DuringChiled(object sender, RoutedEventArgs e)
        {
            During_childbrin dur_chil = new During_childbrin();
            dur_chil.Show();
            Close();
        } 
        

        void SelectedFindFileDirectClick(object sender, RoutedEventArgs e) //Функция вызова меню с выбором поиска файла
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            DialogResult result = folderBrowser.ShowDialog();

            if (!string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
            {
                File.WriteAllText("SarchtDirectory.set",folderBrowser.SelectedPath);
      
                directory = folderBrowser.SelectedPath;
            }
        }

        void SelectedCreateFileDirectClick(object sender,
            RoutedEventArgs e) //Функция вызова меню с выбором поиска файла
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            DialogResult result = folderBrowser.ShowDialog();

            if (!string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
            {
                File.WriteAllText("SetDirectory.set", folderBrowser.SelectedPath);
               
                SaveDierectory = folderBrowser.SelectedPath;
            }
        }

        void ClearTextMenuVspl(object sender, RoutedEventArgs e)
        {
            SearchPacientok.Clear();
            DockPanelLeftMenu.Visibility = Visibility.Hidden;
        }

        //Печать файла
        void PrintTheFile(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.PrintVisual(FileBlock, "Успешно!");
        }

        //Блок поиска пациентки
        void TextBoxChanged(object sender, TextChangedEventArgs e)
        {
            bool child = true;
            TextBox textBox = (TextBox) sender;

            gridLayout.Children.Clear();
            DockPanelLeftMenu.Visibility = Visibility.Visible;
            if (textBox.Text != "")
            {
                SearchDirectory(directory, textBox.Text);
            }
        }

        void SearchDirectory(string dir, string textIn)
        {
               string SubFileName;
            string text = textIn.ToLower();
            foreach (string lowfile in Directory.GetFiles(dir))
            {
                string file = lowfile.ToLower();
                if (file[dir.Length] != '\\')

                {
                    SubFileName =
                        file.Substring(dir.Length);
                }
                else
                {
                    SubFileName =
                        file.Substring(dir.Length + 1);
                }


                if (SubFileName.StartsWith(text) && Ending(SubFileName))
                {
                    Button SearchPaButton = new Button
                    {
                        Height = 23,
                        Background = (Brush) this.TryFindResource("BorderToButtonMenu"),
                        Width = ColumnAddPacWeidth.MinWidth + 120,
                        BorderBrush = Brushes.Transparent,
                        BorderThickness = new Thickness(0),
                        Foreground = (Brush) this.TryFindResource("ForegroundToButtonMenu"),
                        FontSize = 11,
                        FontWeight = FontWeights.Bold,
                        HorizontalContentAlignment = HorizontalAlignment.Left,
                        Padding = new Thickness(5, 0, 0, 0),

                    };
                    SearchPaButton.Content = lowfile.Substring(dir.Length);
                    SearchPaButton.ContentStringFormat = lowfile;
                    SearchPaButton.Click += ViewFile;

                    gridLayout.Children.Add(SearchPaButton);
                }


            }



          
                string[] directoriesFile = Directory.GetDirectories(dir);
                foreach (string dirT in directoriesFile)
                {

                    string[] files = Directory.GetFiles(dir);
                    if (files.Length != 0)
                    {
                        try
                        {
                            foreach (string lowfile in files)
                            {
                                string  file = lowfile.ToLower();
                                SubFileName =
                                    file.Substring(dirT.Length + 1);



                                if (SubFileName.StartsWith(text) && Ending(SubFileName))
                                {
                                    Button SearchPaButton = new Button
                                    {
                                        Height = 23,
                                        Background = (Brush) this.TryFindResource("BorderToButtonMenu"),
                                        Width = ColumnAddPacWeidth.MinWidth + 120,
                                        BorderBrush = Brushes.Transparent,
                                        BorderThickness = new Thickness(0),
                                        Foreground = (Brush) this.TryFindResource("ForegroundToButtonMenu"),
                                        FontSize = 11,
                                        FontWeight = FontWeights.Bold,
                                        HorizontalContentAlignment = HorizontalAlignment.Left,
                                        Padding = new Thickness(5, 0, 0, 0),

                                    };
                                    SearchPaButton.Content = lowfile.Substring(dir.Length);;
                                    SearchPaButton.ContentStringFormat = lowfile;
                                    SearchPaButton.Click += ViewFile;

                                    gridLayout.Children.Add(SearchPaButton);
                                }


                            }

                        }
                        catch
                        {
                           continue;
                        }
                    }

                    try
                    {
                        SearchDirectory(dirT, text);
                    }
                    catch
                    {
                        continue;
                    }
                }


        }

        void SeetingsClick(object sender, RoutedEventArgs e) // Открытие меню настроек
            {
                if (StackMenu.Visibility == Visibility.Hidden)
                {
                    StackMenu.Visibility = Visibility.Visible;
                }
                else StackMenu.Visibility = Visibility.Hidden;
            }

            //Блок добавления пациентки
            void AddPacientkuPZ(object sender, RoutedEventArgs e)
            {

                bool create = true;
                if (Family.Text == "")
                {
                    create = false;
                    MessageBox.Show("Строка ФИО не может быть пустой");
                }

                foreach (string file in Directory.GetFiles(SaveDierectory))
                {
                    if (file == Family.Text)
                    {
                        create = false;
                        MessageBox.Show("Файл с таким именем уже существет");
                    }
                }

                if (create)
                {

                    string DateTimeL = GroupToString(DateTime);
                   // MessageBox.Show(DateTimeL);
                    string twoHisL = GroupToString(twoHis);
                   // MessageBox.Show(twoHisL);
                    string[] startMakeL = filter(startMake);
                    string[] anamLifeL = filter(anamLife);
                    
                    List<string> AllMark = new List<string>();
                   AllMark.Add(DateTimeL);
                   AllMark.Add(twoHisL);
                //    MessageBox.Show(AllMark[0]);
                 //   MessageBox.Show(AllMark[1]);
             
               //     addArray(filter(DateTime),AllMark);
                 //   addArray(filter(twoHis),AllMark);
                    
                    addArray(startMakeL,AllMark);
                    addArray(anamLifeL,AllMark);
                    
                    AllMark.Add(GroupToString(husOldS));
                    AllMark.Add(GroupToString(husBlood));
                    AllMark.Add(GroupToString(husSmoke));

                    AllMark = filterList(AllMark);
                    foreach(string s in filterList(AllMark))
                    {
                        MessageBox.Show(s);
                    }
                    string newFile = SaveDierectory + @"\" + Family.Text + ".docx";
                    File.Copy("shablon.docx", newFile);
                    Word.Document doc = null;


                    try
                    {

                        Word.Application app = new Word.Application();

                        string source = newFile;

                        doc = app.Documents.Open(source);
                        doc.Activate();
                       
                        var paragraphone = doc.Content.Paragraphs.Add();
                        paragraphone.Range.Font.Size = 16;
                        var textTimer = doc.Content.Text;
                        doc.Content.SetRange(0, 0);
                        //for (int i = 2; i < AllMark.Count; i += 2)
                        int i = 0;
                        while (i < AllMark.Count)
                        {
                            MessageBox.Show(AllMark[i]);
                            if (AllMark[i] == "" || AllMark[i] == null)
                            {
                                i++;
                                continue;
                            }
                            if (filterString(AllMark[i],oneString))
                            {
                                AddText(doc,AllMark[i]);
                                i++;
                            }
                            else if(filterString(AllMark[i],tittleString))
                            {
                                MessageBox.Show("TITTTLE");
                                AddTextTittle(doc,AllMark[i]);
                                i++;
                            }
                            else
                            {
                                AddText(doc, AllMark[i] + AllMark[i + 1]);
                                i += 2;
                            }
                        }


                        
                        doc.Close();
                        doc = null;
                    }
                    catch
                    {


                        doc.Close();
                        doc = null;

                    }


                    for (int i = 0; i < textList.Count; i++)
                    {
                        textList[i].Text = "";
                    }

                    for (int i = 0;i< checkList.Count;i++)
                    {
                        checkList[i].IsChecked = false;
                    }

                    textList.Clear();


                    Array.Clear(DateTime, 0, DateTime.Length - 1);
                    Array.Clear(twoHis, 0, twoHis.Length - 1);
                    Array.Clear(startMake, 0, startMake.Length - 1);
                    Array.Clear(anamLife,0,anamLife.Length - 1);
                }

            }


   void AddText(Word.Document doc,string text){
       var paragraphone = doc.Content.Paragraphs.Add();
       paragraphone.Range.Font.Size = 12;
       paragraphone.Range.Text = text;
       paragraphone.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
     //  MessageBox.Show(text);

    
      var boldRange = doc.Range(paragraphone.Range.Start, paragraphone.Range.Start + text.IndexOf(":") + 1);

       foreach (string s in oneString)
       {
           int start = text.IndexOf(s);
       //    MessageBox.Show(start.ToString());
           if (start != -1)
           {
               var boldRangeT = doc.Range(paragraphone.Range.Start + start, paragraphone.Range.Start + start + s.Length);
               boldRangeT.Bold = 1;
           }
       }
           
       boldRange.Bold = 1;
       paragraphone.Range.InsertParagraphAfter();
   }

        bool filterString(string word, string[] wordArray)
        {
            MessageBox.Show("One Word");
            MessageBox.Show(word);
            foreach (string s in wordArray)
            {
                MessageBox.Show("Two Word");
                MessageBox.Show(s);  
                if (word.StartsWith(s))
                {
                    MessageBox.Show("ds");
                    
                    return true;
                }
            }
            return false;
        }
        void addArray(Array Arrayi,List<string> Listi)
        {
            foreach (string s in Arrayi)
            {
                Listi.Add(s);
            }
        }

        string GroupToString(string[] array)
        {
            string[] arrayF = filter(array);
            string GroupString = "";
            for (int i = 0; i <arrayF.Length;i +=2)
            {
                GroupString += arrayF[i] + arrayF[i + 1] + "\t";
            }

            return GroupString;
        }

        void AddTextTittle(Word.Document doc, string text)
        {
            var paragraphone = doc.Content.Paragraphs.Add();
            paragraphone.Range.Font.Size = 14;
            paragraphone.Range.Text = text;
    
            MessageBox.Show(text);


            var boldRange = doc.Range(paragraphone.Range.Start, paragraphone.Range.Start + text.Length);

            boldRange.Bold = 1;
            boldRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            paragraphone.Range.InsertParagraphAfter();
        }

        void ViewFile(object sender, RoutedEventArgs e) //Функция отображения файла
            {
                  Button buttonSearch = (Button) sender;
            string fileText;
            if (buttonSearch.ContentStringFormat.EndsWith(".docx"))
            {
                Object filename = buttonSearch.ContentStringFormat; 
                Object confirmConversions = Type.Missing; 
                Object readOnly = Type.Missing; 
                Object addToRecentFiles = Type.Missing; 
                Object passwordDocument = Type.Missing; 
                Object passwordTemplate = Type.Missing; 
                Object revert = Type.Missing; 
                Object writePasswordDocument = Type.Missing; 
                Object writePasswordTemplate = Type.Missing; 
                Object format = Type.Missing; 
                Object encoding = Type.Missing; 
                Object visible = Type.Missing; 
                Object openConflictDocument = Type.Missing; 
                Object openAndRepair = Type.Missing; 
                Object documentDirection = Type.Missing; 
                Object noEncodingDialog = Type.Missing; 
                Word.Application Progr = new Microsoft.Office.Interop.Word.Application(); 
                Progr.Documents.Open(ref filename, 
                    ref confirmConversions, 
                    ref readOnly, 
                    ref addToRecentFiles, 
                    ref passwordDocument, 
                    ref passwordTemplate, 
                    ref revert, 
                    ref writePasswordDocument, 
                    ref writePasswordTemplate, 
                    ref format, 
                    ref encoding, 
                    ref visible, 
                    ref openConflictDocument, 
                    ref openAndRepair, 
                    ref documentDirection, 
                    ref noEncodingDialog); 
                Word.Document Doc= new Microsoft.Office.Interop.Word.Document(); 
                Doc = Progr.Documents.Application.ActiveDocument; object start = 0; 
                object stop = Doc.Characters.Count; 
                Word.Range Rng = Doc.Range(ref start, ref stop); 
                fileText = Rng.Text; 
                object sch = Type.Missing; 
                object aq = Type.Missing; 
                object ab = Type.Missing; 
                Progr.Quit(ref sch, ref aq, ref ab);   
            }
            else
            {
                fileText = File.ReadAllText(buttonSearch.ContentStringFormat);
            }

            FileBlock.Text = fileText;
            //  MessageBox.Show(buttonSearch.ContentStringFormat);
            }



            void ClearSearch(object sender, RoutedEventArgs e)
            {
                SearchPacientok.Text = "";
            }


            bool Ending(string File) //Функция проверки формата
            {
                string[] format = new string[3] {".txt", ".doc",".docx"};
                foreach (string formatOne in format)
                {
                    if (File.EndsWith(formatOne))
                    {
                        return true;
                    }
                }

                return false;
            }



        string[] filter(string[] mass)
        {
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] == "" || mass[i] == null)
                {
                    for (int j = i; j < mass.Length; j++)
                    {
                        if (j + 1 != mass.Length)
                        {
                            mass[j] = mass[j + 1];
                        }
                        else
                        {
                            mass[j] = "";
                        }
                    }
                }
            }

            return mass;
        }
        List<string> filterList(List<string> mass)
        {
            for (int i = 0; i < mass.Count; i++)
            {
                if (mass[i] == "" || mass[i] == null)
                {
                    for (int j = i; j < mass.Count; j++)
                    {
                        if (j + 1 != mass.Count)
                        {
                            mass[j] = mass[j + 1];
                        }
                        else
                        {
                            mass[j] = "";
                        }
                    }
                }
            }

            return mass;
        }

            void OpenStart(object sender, RoutedEventArgs e)
            {
                if (shablon_nach_a4.Visibility == Visibility.Hidden)
                {
                    shablon_nach_a4.Visibility = Visibility;
                }
                else
                {
                    shablon_nach_a4.Visibility = Visibility.Hidden;
                }

                Anamnezlivetable.Visibility = Visibility.Hidden;
                GinekAnaliz.Visibility = Visibility.Hidden;
                TechBer.Visibility = Visibility.Hidden;
                BaseObject.Visibility = Visibility.Hidden;
                VlagIssledPanel.Visibility = Visibility.Hidden;
                PlanVedod.Visibility = Visibility.Hidden;
                ShkalaPerRisk.Visibility = Visibility.Hidden;
                Naznach.Visibility = Visibility.Hidden;
            }

            void OpenLive(object sender, RoutedEventArgs e)
            {
                if (Anamnezlivetable.Visibility == Visibility.Hidden)
                {
                    Anamnezlivetable.Visibility = Visibility;
                }
                else
                {
                    Anamnezlivetable.Visibility = Visibility.Hidden;
                }

                shablon_nach_a4.Visibility = Visibility.Hidden;
                GinekAnaliz.Visibility = Visibility.Hidden;
                TechBer.Visibility = Visibility.Hidden;
                BaseObject.Visibility = Visibility.Hidden;
                VlagIssledPanel.Visibility = Visibility.Hidden;
                PlanVedod.Visibility = Visibility.Hidden;
                ShkalaPerRisk.Visibility = Visibility.Hidden;
                Naznach.Visibility = Visibility.Hidden;
            }

            void OpenAnam(object sender, RoutedEventArgs e)
            {

                if (GinekAnaliz.Visibility == Visibility.Hidden)
                {
                    GinekAnaliz.Visibility = Visibility;
                }
                else
                {
                    GinekAnaliz.Visibility = Visibility.Hidden;
                }


                shablon_nach_a4.Visibility = Visibility.Hidden;
                Anamnezlivetable.Visibility = Visibility.Hidden;
                TechBer.Visibility = Visibility.Hidden;
                BaseObject.Visibility = Visibility.Hidden;
                VlagIssledPanel.Visibility = Visibility.Hidden;
                PlanVedod.Visibility = Visibility.Hidden;
                ShkalaPerRisk.Visibility = Visibility.Hidden;
                Naznach.Visibility = Visibility.Hidden;
            }

            void OpenIsxodBer(object sender, RoutedEventArgs e)
            {

//            if (TechBer.Visibility == Visibility.Hidden)
//            {
//                TechBer.Visibility = Visibility;
//            }
//            else
//            {
//                TechBer.Visibility = Visibility.Hidden;
//            }


                shablon_nach_a4.Visibility = Visibility.Hidden;
                Anamnezlivetable.Visibility = Visibility.Hidden;
                GinekAnaliz.Visibility = Visibility.Hidden;
                BaseObject.Visibility = Visibility.Hidden;
                VlagIssledPanel.Visibility = Visibility.Hidden;
                ShkalaPerRisk.Visibility = Visibility.Hidden;
                PlanVedod.Visibility = Visibility.Hidden;
                Naznach.Visibility = Visibility.Hidden;
                TechBer.Visibility = Visibility.Hidden;
            }

            void OpenTechBer(object sender, RoutedEventArgs e)
            {
                if (TechBer.Visibility == Visibility.Hidden)
                {
                    TechBer.Visibility = Visibility;
                }
                else
                {
                    TechBer.Visibility = Visibility.Hidden;
                }

                shablon_nach_a4.Visibility = Visibility.Hidden;
                Anamnezlivetable.Visibility = Visibility.Hidden;
                GinekAnaliz.Visibility = Visibility.Hidden;
                BaseObject.Visibility = Visibility.Hidden;
                VlagIssledPanel.Visibility = Visibility.Hidden;
                ShkalaPerRisk.Visibility = Visibility.Hidden;
                Naznach.Visibility = Visibility.Hidden;
            }

            void OpenObject(object sender, RoutedEventArgs e)
            {
                if (BaseObject.Visibility == Visibility.Hidden)
                {
                    BaseObject.Visibility = Visibility;
                }
                else
                {
                    BaseObject.Visibility = Visibility.Hidden;
                }

                shablon_nach_a4.Visibility = Visibility.Hidden;
                Anamnezlivetable.Visibility = Visibility.Hidden;
                GinekAnaliz.Visibility = Visibility.Hidden;
                TechBer.Visibility = Visibility.Hidden;
                VlagIssledPanel.Visibility = Visibility.Hidden;
                ShkalaPerRisk.Visibility = Visibility.Hidden;
                PlanVedod.Visibility = Visibility.Hidden;
                Naznach.Visibility = Visibility.Hidden;
            }

            void OpenIss(object sender, RoutedEventArgs e)
            {
                if (VlagIssledPanel.Visibility == Visibility.Hidden)
                {
                    VlagIssledPanel.Visibility = Visibility;
                }
                else
                {
                    VlagIssledPanel.Visibility = Visibility.Hidden;
                }

                shablon_nach_a4.Visibility = Visibility.Hidden;
                Anamnezlivetable.Visibility = Visibility.Hidden;
                GinekAnaliz.Visibility = Visibility.Hidden;
                TechBer.Visibility = Visibility.Hidden;
                BaseObject.Visibility = Visibility.Hidden;
                ShkalaPerRisk.Visibility = Visibility.Hidden;
                PlanVedod.Visibility = Visibility.Hidden;
                Naznach.Visibility = Visibility.Hidden;
            }

            void OpenShcala(object sender, RoutedEventArgs e)
            {
                if (ShkalaPerRisk.Visibility == Visibility.Hidden)
                {
                    ShkalaPerRisk.Visibility = Visibility;
                }
                else
                {
                    ShkalaPerRisk.Visibility = Visibility.Hidden;
                }

                shablon_nach_a4.Visibility = Visibility.Hidden;
                Anamnezlivetable.Visibility = Visibility.Hidden;
                GinekAnaliz.Visibility = Visibility.Hidden;
                TechBer.Visibility = Visibility.Hidden;
                BaseObject.Visibility = Visibility.Hidden;
                VlagIssledPanel.Visibility = Visibility.Hidden;
                PlanVedod.Visibility = Visibility.Hidden;
                Naznach.Visibility = Visibility.Hidden;
            }

            void OpenPlan(object sender, RoutedEventArgs e)
            {
                if (PlanVedod.Visibility == Visibility.Hidden)
                {
                    PlanVedod.Visibility = Visibility;
                }
                else
                {
                    PlanVedod.Visibility = Visibility.Hidden;
                }

                shablon_nach_a4.Visibility = Visibility.Hidden;
                Anamnezlivetable.Visibility = Visibility.Hidden;
                GinekAnaliz.Visibility = Visibility.Hidden;
                TechBer.Visibility = Visibility.Hidden;
                BaseObject.Visibility = Visibility.Hidden;
                VlagIssledPanel.Visibility = Visibility.Hidden;
                ShkalaPerRisk.Visibility = Visibility.Hidden;
                Naznach.Visibility = Visibility.Hidden;
//                .Visibility = Visibility.Hidden;

            }

            void naznach(object sender, RoutedEventArgs e)
            {
                if (Naznach.Visibility == Visibility.Hidden)
                {
                    Naznach.Visibility = Visibility;
                }
                else
                {
                    Naznach.Visibility = Visibility.Hidden;
                }

                shablon_nach_a4.Visibility = Visibility.Hidden;
                Anamnezlivetable.Visibility = Visibility.Hidden;
                GinekAnaliz.Visibility = Visibility.Hidden;
                TechBer.Visibility = Visibility.Hidden;
                BaseObject.Visibility = Visibility.Hidden;
                VlagIssledPanel.Visibility = Visibility.Hidden;
                ShkalaPerRisk.Visibility = Visibility.Hidden;
                PlanVedod.Visibility = Visibility.Hidden;
//                .Visibility = Visibility.Hidden;
            }
            //-------------------------------------
            //-------------------------------------
            //-------------------------------------
            /*
             * Дальше пойдут функции для RadioButton
             */
            //-------------------------------------
            //-------------------------------------
            //-------------------------------------

//Шаблон начала

        //____________________________ИНСТРУКЦИЯ ПО ЗАПОЛНЕНИЮ_________________________
        /*
         * Как каждому текстбоксу или радиобатону надо создать функцию что логично
         * В этой функции надо сделать локальный объект элемента например:  TextBox textBox = (TextBox) sender;
         * И присвоить этот объект к массиву объектов для Текстбоксов это  textList.Add(textBox) а для кнопок  checkList.Add(radio)
         * И конечно добавить строку
         * Строка документа состоит из названия и вводящиегося парамметра
         * Нужно добавлять какждое название и вводимы парраметр в свое место в массиве как ты можешь увидеть на примере
         * И так же нужно постоянно добавлять в определенное место массива заголовок к которому относится элемент управления
         * Если что не понятно пиши и смотри уже сделанные функи
         * P.S Конечно алгоритм можно было сделть оптимизирование например добавляя строки в контент самих элементов но работа ввелась слишком сумбурно
         *
         */
        
        
        
        
        void DateText(object sender, TextChangedEventArgs e)
        {
            
            TextBox textBox = (TextBox) sender;
            DateTime[0] = "Дата: ";
            DateTime[1] = textBox.Text;
            textList.Add(textBox);
        }
        void TimeText(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox) sender;
            DateTime[2] = "Время: ";
            DateTime[3] = textBox.Text;
            textList.Add(textBox);
        }

        void HisCreateText(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox) sender;
            twoHis[0] = "ИСТОРИЯ РОДОВ №";
            twoHis[1] = textBox.Text;
            textList.Add(textBox);
            
        }
        void FIOText(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox) sender;
            twoHis[2] = "ФИО:";
            twoHis[3] = textBox.Text;
            textList.Add(textBox);
        }
        void OldText(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox) sender;
            twoHis[4] = "ВОЗРАСТ";
            twoHis[5] = textBox.Text;
            textList.Add(textBox);
        }
        
        
            void SMPVector(object sender, RoutedEventArgs e)
            {
                
                startMake[0] = "Поступила по направлению: ";
                startMake[1] = "CМП";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }

            void DockVector(object sender, RoutedEventArgs e)
            {
                startMake[0] = "Поступила по направлению: ";
                startMake[1] = "Врача ЖК";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }

            void SelfVector(object sender, RoutedEventArgs e)
            {
                startMake[0] = "Поступила по направлению: ";
                startMake[1] = "Cамостоятельно";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }
            
        void DSText(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox) sender;
            startMake[2] = "DS при поступление: ";
            startMake[3] = textBox.Text;
            textList.Add(textBox);
        }
        void ErText(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox) sender;
            startMake[4] = "Жалобы при поступление: ";
            startMake[5] = textBox.Text;
            textList.Add(textBox);
        }
        
//Шаблон начала

//Анамез жизни

            void ColdDiases(object sender, RoutedEventArgs e)
            {
                anamLife[0] = "Анамнез жизни";
                anamLife[1] = "Оющие заболевания:";
                anamLife[2] = "Простудные";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }

            void GiperDiases(object sender, RoutedEventArgs e)
            {
                anamLife[0] = "Анамнез жизни";
                anamLife[1] = "Оющие заболевания:";
                anamLife[2] = "Гипертоническая болезнь";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }

            void SugarDiases(object sender, RoutedEventArgs e)
            {
                anamLife[0] = "Анамнез жизни";
                anamLife[1] = "Оющие заболевания:";
                anamLife[2] = "Сахарный диабет";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }

        void AllDiasesText(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox) sender;
            anamLife[0] = "Анамнез жизни";
            anamLife[1] = "Оющие заболевания:";
            anamLife[2] = textBox.Text;
            textList.Add(textBox);
            
        }

            void GoodState(object sender, RoutedEventArgs e)
            {
                anamLife[0] = "Анамнез жизни";
                anamLife[3] = "Социальное положене:";
                anamLife[4] = "Благополучное";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }

            void BadState(object sender, RoutedEventArgs e)
            {
                anamLife[0] = "Анамнез жизни";
                anamLife[3] = "Социальное положене:";
                anamLife[4] = "Неблагополучное";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }

            void NoSmoke(object sender, RoutedEventArgs e)
            {
                anamLife[0] = "Анамнез жизни";
                anamLife[5] = "Курение:";
                anamLife[6] = "Нет";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }

            void YesSmoke(object sender, RoutedEventArgs e)
            {
                anamLife[0] = "Анамнез жизни";
                anamLife[5] = "Курение:";
                anamLife[6] = "Одна пачка в день";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }

        void SmokeText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox) sender;
            anamLife[0] = "Анамнез жизни";
            anamLife[5] = "Курение:";
            anamLife[6] = textBox.Text;
            textList.Add(textBox);
            
        }
            void YesProfHar(object sender, RoutedEventArgs e)
            {
                anamLife[0] = "Анамнез жизни";
                anamLife[7] = "Проввесиональные вредности:";
                anamLife[8] = "Есть";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }

            void NoProfHar(object sender, RoutedEventArgs e)
            {
                anamLife[0] = "Анамнез жизни";
                anamLife[7] = "Проввесиональные вредности:";
                anamLife[8] = "Нет";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }

        void ProfHarText(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox) sender;
            anamLife[0] = "Анамнез жизни";
            anamLife[7] = "Проввесиональные вредности:";
            anamLife[8] = textBox.Text;
            textList.Add(textBox);
        }
        
            void YesGemotransf(object sender, RoutedEventArgs e)
            {
                anamLife[0] = "Анамнез жизни";
                anamLife[9] = "Гемотрансфузии:";
                anamLife[10] = "Были";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }

            void NoGemotransf(object sender, RoutedEventArgs e)
            {
                anamLife[0] = "Анамнез жизни";
                anamLife[9] = "Гемотрансфузии:";
                anamLife[10] = "Не были";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }

        void GemotrnsfText(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox) sender;
            anamLife[0] = "Анамнез жизни";
            anamLife[11] = "Гемотрансфузии:";
            anamLife[12] = textBox.Text;
            textList.Add(textBox);
        }
        
        
            void YesDrugs(object sender, RoutedEventArgs e)
            {
                anamLife[0] = "Анамнез жизни";
                anamLife[13] = "Наркотики:";
                anamLife[14] = "Принимала";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }

            void NoDrugs(object sender, RoutedEventArgs e)
            {
                anamLife[0] = "Анамнез жизни";
                anamLife[13] = "Наркотики:";
                anamLife[14] = "Не принимала";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }

        void DrugsText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox) sender;
            anamLife[0] = "Анамнез жизни";
            anamLife[13] = "Наркотики:";
            anamLife[14] = textBox.Text;
            textList.Add(textBox);
        }
        
        
            void YesVhich(object sender, RoutedEventArgs e)
            {
                anamLife[0] = "Анамнез жизни";
                anamLife[15] = "Контакт с инфекционными больными ВИЧ, гепатит, Tbc, Lues:";
                anamLife[16] = "Да";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }

            void NoVhich(object sender, RoutedEventArgs e)
            {
                anamLife[0] = "Анамнез жизни";
                anamLife[15] = "Контакт с инфекционными больными ВИЧ, гепатит, Tbc, Lues:";
                anamLife[16] = "Нет";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }

        void VichText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox) sender;
            anamLife[0] = "Анамнез жизни";
            anamLife[15] = "Контакт с инфекционными больными ВИЧ, гепатит, Tbc, Lues:";
            anamLife[16] = textBox.Text;
            textList.Add(textBox);
        }
        
            void YesAnam(object sender, RoutedEventArgs e)
            {
                anamLife[0] = "Анамнез жизни";
                anamLife[17] = "Аллергологический анамнез:";
                anamLife[18] = "Отягощен";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }

            void NoAnam(object sender, RoutedEventArgs e)
            {
                anamLife[0] = "Анамнез жизни";
                anamLife[17] = "Аллергологический анамнез:";
                anamLife[18] = "Не отягощен";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }

        void AnamText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox) sender;
            anamLife[0] = "Анамнез жизни";
            anamLife[17] = "Аллергологический анамнез:";
            anamLife[18] = textBox.Text;
            textList.Add(textBox);
        }

        void husOld(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox) sender;
            husOldS[0] = "Муж:";
            anamLife[1] = textBox.Text;
            textList.Add(textBox);
        }
            void YesHronDiases(object sender, RoutedEventArgs e)
            {
                husOldS[2] = "Хронические заболевания:";
                anamLife[3] = "Есть";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }

            void NoHronDiases(object sender, RoutedEventArgs e)
            {
                husOldS[2] = "Хронические заболевания:";
                anamLife[3] = "Нет";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }
         
        void HronDiasesText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox) sender;
            husOldS[2] = "Хронические заболевания:";
            anamLife[3] = textBox.Text;
            textList.Add(textBox); 
        }
            void GroupOne(object sender, RoutedEventArgs e)
            {
                husBlood[0] = "Группа крови:";
                husBlood[1] = "OI";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }

            void GroupTwo(object sender, RoutedEventArgs e)
            {
                husBlood[0] = "Группа крови:";
                husBlood[1] = "AII";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }

            void GroupThree(object sender, RoutedEventArgs e)
            {
                husBlood[0] = "Группа крови:";
                husBlood[1] = "BIII";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }

            void GroupForthy(object sender, RoutedEventArgs e)
            {
                husBlood[0] = "Группа крови:";
                husBlood[1] = "ABIV";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }

            void RhPlus(object sender, RoutedEventArgs e)
            {
                husBlood[2] = "Rh фактор:";
                husBlood[3] = "+";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }

            void RhMines(object sender, RoutedEventArgs e)
            {
                husBlood[2] = "Rh фактор:";
                husBlood[3] = "-";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }

            void YesSmokingHushband(object sender, RoutedEventArgs e)
            {
                husSmoke[0] = "Курение:";
                husSmoke[1] = "Да";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }

            void NoSmokingHushband(object sender, RoutedEventArgs e)
            {
                husSmoke[0] = "Курение:";
                husSmoke[1] = "Нет";
                RadioButton radio = (RadioButton) sender;
                checkList.Add(radio);
            }
        void SmokingHushbandText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox) sender;
            husSmoke[0] = "Курение:";
            husSmoke[1] = textBox.Text;
            textList.Add(textBox); 
        }
        
        
        
        
        
//Анамез жизни
//Гинекологический анамнез

            void RegularMinarh(object sender, RoutedEventArgs e)
            {
                GinekAnalizTF = true;
                Minarh = "Регулярные";
            }

            void NotRegularMinarh(object sender, RoutedEventArgs e)
            {
                GinekAnalizTF = true;
                Minarh = "Не регулярные";
            }

            void RegularContr(object sender, RoutedEventArgs e)
            {
                GinekAnalizTF = true;
                Contr = "Регулярная";
            }

            void NotRegularContr(object sender, RoutedEventArgs e)
            {
                GinekAnalizTF = true;
                Contr = "Не регулярная";
            }

//Гинекологический анамнез
            //   Течение данной беременности   
            void YesSince(object sender, RoutedEventArgs e)
            {
                Since = YesSinceText.Text;
            }

            void NoSince(object sender, RoutedEventArgs e)
            {
                Since = "Нет";
            }

            void UpdateNoSince(object sender, RoutedEventArgs e)
            {
                Since = NoSinceText.Text;
            }




            void StabilDinamick(object sender, RoutedEventArgs e)
            {
                DinamikAD = "Стабильная";
            }

            void StabilDinamickNot(object sender, RoutedEventArgs e)
            {
                DinamikAD = "Не стабильная";
            }

            void FirstGroup(object sender, RoutedEventArgs e)
            {
                BloodGroup = "OI";
            }

            void SecondGroup(object sender, RoutedEventArgs e)
            {
                BloodGroup = "AII";
            }

            void TreeGroup(object sender, RoutedEventArgs e)
            {
                BloodGroup = "BIII";
            }

            void FortinGroup(object sender, RoutedEventArgs e)
            {
                BloodGroup = "ABIV";
            }

            void RhFactPlus(object sender, RoutedEventArgs e)
            {
                BRh = "Положительный";
            }

            void RhFactMines(object sender, RoutedEventArgs e)
            {
                BRh = "Отрицательный";
            }

            //   Течение данной беременности
            void ShakeMatkClear(object sender, RoutedEventArgs e) // Для шейки матки(ShakeMatk)
            {
                string s;
            }

            void BeliVideleniya(object sender, RoutedEventArgs e) // Для OutVid(Выделения)
            {
                string s;
            }

            void OtklonTaz(object sender, RoutedEventArgs e) // Для SheikMatkiSecond(Шейка матки)
            {
                string s;
            }

            void CenterSheik(object sender, RoutedEventArgs e) // Для SheikMatkiSecond(Шейка матки)
            {
                string s;
            }

            void PoProvodnoy(object sender, RoutedEventArgs e) // Для SheikMatkiSecond(Шейка матки)
            {
                string s;
            }

            void PlotnayConsnant(object sender, RoutedEventArgs e) // Для Constinstation(Консистенция)
            {
                string s;
            }

            void MagkyPoPerefer(object sender, RoutedEventArgs e) // Для Constinstation(Консистенция)
            {
                string s;
            }

            void UmerenRaz(object sender, RoutedEventArgs e) // Для Constinstation(Консистенция)
            {
                string s;
            }

            void Magky(object sender, RoutedEventArgs e) // Для Constinstation(Консистенция)
            {
                string s;
            }

            void inWork1(object sender, RoutedEventArgs e) // Для Opened(Открытие)
            {
                string s;
            }

            void OutWork1(object sender, RoutedEventArgs e) // Для Opened(Открытие)
            {
                string s;
            }

            void NotPlodPuz(object sender, RoutedEventArgs e) // Для PlodnyPuzir(Плодный пузырь)
            {
                string s;
            }

            void CelPlodPuz(object sender, RoutedEventArgs e) // Для PlodnyPuzir(Плодный пузырь)
            {
                string s;
            }

            void PloskPlodPuz(object sender, RoutedEventArgs e) // Для PlodnyPuzir(Плодный пузырь)
            {
                string s;
            }

            void okayNalv(object sender, RoutedEventArgs e) // Для PlodnyPuzir(Плодный пузырь)
            {
                string s;
            }

            void VskritBransh(object sender, RoutedEventArgs e) // Для PlodnyPuzir(Плодный пузырь)
            {
                string s;
            }

            void OutIzlis(object sender, RoutedEventArgs e) // Для PlodnyPuzir(Плодный пузырь)
            {
                string s;
            }

            void NeplotToMatk(object sender, RoutedEventArgs e) //Для HeadPlod(Предлежит головка плода)
            {
                string s;
            }

            void PlotToMatk(object sender, RoutedEventArgs e) //Для HeadPlod(Предлежит головка плода)
            {
                string s;
            }

            void MinSegmen(object sender, RoutedEventArgs e) //Для HeadPlod(Предлежит головка плода)
            {
                string s;
            }

            void BigSegmen(object sender, RoutedEventArgs e) //Для HeadPlod(Предлежит головка плода)
            {
                string s;
            }

            void Vskrit(object sender, RoutedEventArgs e) //Для HeadPlod(Предлежит головка плода)
            {
                string s;
            }

            void InPolostMinTaz(object sender, RoutedEventArgs e) //Для HeadPlod(Предлежит головка плода)
            {
                string s;
            }

            void TazDno(object sender, RoutedEventArgs e) //Для HeadPlod(Предлежит головка плода)
            {
                string s;
            }

            void Vrez(object sender, RoutedEventArgs e) //Для HeadPlod(Предлежит головка плода)
            {
                string s;
            }

            void InLeftSize(object sender, RoutedEventArgs e) //Для StrelovidShow(Стреловидный шов)
            {
                string s;
            }

            void InRightSize(object sender, RoutedEventArgs e) //Для StrelovidShow(Стреловидный шов)
            {
                string s;
            }

            void InPoperxh(object sender, RoutedEventArgs e) //Для StrelovidShow(Стреловидный шов)
            {
                string s;
            }

            void InLineRaz(object sender, RoutedEventArgs e) //Для StrelovidShow(Стреловидный шов)
            {
                string s;
            }

            void NodDostig(object sender, RoutedEventArgs e) // Для Mis(Мыс)
            {
                string s;
            }

            void Dostig(object sender, RoutedEventArgs e) // Для Mis(Мыс)
            {
                string s;
            }

            void EcstozDefYes(object sender, RoutedEventArgs e) //Для EcstozDef(Экзастозы, деформации)
            {
                string s;
            }

            void EcstozDefNo(object sender, RoutedEventArgs e) //Для EcstozDef(Экзастозы, деформации)
            {
                string s;
            }

    }
    }



