using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Text_Editor___Dom_Style
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        private string _currentFileName;
        private System.Timers.Timer _autoSaveTimer;
        //private bool _AutoSaveOn = true;
        //private string _autoSaving = "Saved";


        /*
        public bool AutoSaveOn
        {

            get { return _AutoSaveOn; }

            set
            {
                _AutoSaveOn = value;
                OnPropertyChanged();

            }

        }
        */

        public string CurrentFileName
        {
            get => _currentFileName;


            set {

                if (_currentFileName != value) {
                
                    _currentFileName = value;
                    OnPropertyChanged();
                
                }

            }
            
            
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            CurrentFileName = "Untitled";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /*
         * Methods involving the File Menu Items
         * This includes Exit, Save As, Open, and Export.
         */

        private void ExitApp(object sender, RoutedEventArgs e)
        {

            Close();

        }

        //Callback to save file as txt
        private void SaveFileAs(object sender, RoutedEventArgs e) 
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File (.txt)|*.txt";
            saveFileDialog.InitialDirectory = @"C:\";

            if (saveFileDialog.ShowDialog() == true)
            {

                File.WriteAllText(saveFileDialog.FileName, txteditor.Text);

                CurrentFileName = saveFileDialog.FileName;
            }


        }

        // Callback to open file
        private void OpenFile(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"D:\";

            if (openFileDialog.ShowDialog() == true)
            {

                txteditor.Text = File.ReadAllText(openFileDialog.FileName);

            }

        }

        // Callback used to open save dialog to save only as pdf
        private void ExportPDF(object sender, RoutedEventArgs e)
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.InitialDirectory = @"D:\";
            saveFileDialog1.Filter = "PDF File (.pdf)|*.pdf";

            if (saveFileDialog1.ShowDialog() == true)
            {

                File.WriteAllText(saveFileDialog1.FileName, txteditor.Text);

            }

        }

        // Callback used to open save dialog to save only as docx
        private void ExportDocx(object sender, RoutedEventArgs e) {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.InitialDirectory = @"D:\";
            saveFileDialog1.Filter = "Docs File (.docx)|*.docx";

            if (saveFileDialog1.ShowDialog() == true)
            {

                File.WriteAllText(saveFileDialog1.FileName, txteditor.Text);

            }


        }


// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /*
         * Methods for the View Menu Items
         * Zoom In and Zoom Out
         */



        // Callback to "zoom in" on the notepad
        private void ZoomIn(object sender, RoutedEventArgs e)
        {

            txteditor.FontSize += 2;

        }

        // Callback to "zoom out" on the notepad
        private void ZoomOut(object sender, RoutedEventArgs e) { 
        
            txteditor.FontSize -= 2;
        
        }

        //Callback to update the word and character counts
        private void txteditor_TextChanged(object sender, RoutedEventArgs e)
        {

            string currentText = txteditor.Text;

            string[] words = currentText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int wordCount = words.Length;

            WordCountLbl.Content = "Word Count: " + wordCount;

            //WordCountLbl.Dispatcher.Invoke(() => { }, System.Windows.Threading.DispatcherPriority.Render);
            //


            int charCount = currentText.Length;

            CharCountLbl.Content = "Character Count: " + charCount;

        }





        // ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /*
         * Methods for the History Menu Items
         * Clicking Versions will open a new page with versions from previous saves
         * Also will have built in button that spawns dialog to turn autosave on or off
         */

        /*
        private void OpenVersionPage(object sender, RoutedEventArgs e)
        {



        }


        private void InitializeAutoSaveTimer()
        {

            _autoSaveTimer = new System.Timers.Timer(300000);
            _autoSaveTimer.Elapsed += AutoSaveTimer_Elapsed;
            _autoSaveTimer.Start();

        }

        private void AutoSaveTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Ensure the method runs on the UI thread
            Dispatcher.Invoke(() =>
            {
                AutoSaveFunction();
            });
        }

        private void AutoSaveFunction()
        {

            if (!string.IsNullOrEmpty(CurrentFileName))
            {

                try
                {

                    if (_AutoSaveOn)
                    {
                        autoSaveNotif.Text = "Saving...";


                        File.WriteAllText(CurrentFileName, txteditor.Text);

                        Console.WriteLine($"Autosaved to {CurrentFileName} at {DateTime.Now}.");



                        autoSaveNotif.Text = "Saved";
                    }

                    else
                    {
                        return;
                    }


                }
                catch (Exception e) {

                    Console.WriteLine($"Error Occurred during auto save at {DateTime.Now}. Message: {e}");
                               
                
                }


            }

        }

        protected override void OnClosed(EventArgs e)
        {
            _autoSaveTimer?.Stop();
            base.OnClosed(e);
        }

        private void AutoSaveSwitch(object sender, RoutedEventArgs e)
        {

            AutoSaveOn = !AutoSaveOn;

        }

        */

        // ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /*
        private void OpenOptionsMenu(object sender, RoutedEventArgs e)
        {

            OptionsPane optionsScreen = new OptionsPane();
            optionsScreen.Show();

        }
        */

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            txteditor.Text = "";
        }

    }

    
}