using System.Data.Common;
using System.Data.Odbc;
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


/*
 * ----------------------------------------------------------------------------------------------------
 * Class that holds all callback functions for the Initial Login screen of the app
 * This is the first screen that is displayed upon the app being opened.
 * Main function is to allow users to login to the app, or to move to the register account page.
 * ----------------------------------------------------------------------------------------------------
 */

namespace Library_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private bool isInitialized = false;

        // Initializes the page and sets the login button to false to ensure it can't be clicked until the entry text fields are populated
        public MainWindow()
        {
            InitializeComponent();

            isInitialized = true;

            Console.WriteLine("Page Initialized");


            loginBTN.IsEnabled = false;
        }

        public void entryBoxChanged(object sender, TextChangedEventArgs e)
        {

            if (isInitialized)
            {

                checkEntryFields();

            }



        }



        // Function used to check if the entry text boxes have text
        // Is called whenever the text boxes have their text changed
        public void checkEntryFields()
        {

            if (string.IsNullOrEmpty(usernameText.Text))
            {


                loginBTN.IsEnabled = false;


            }

            else
            {

                loginBTN.IsEnabled = true;
            }


        }


        // Function that connects to the db and ensures the entered data matches an account in the db.
        // Could probably improve this and use the entity framework to represent user and the user table.
        public void onLoginBTNClick(object sender, RoutedEventArgs e)
        {

            Console.WriteLine("Login Button Clicked");

            if (string.IsNullOrEmpty(passwordText.Password) || string.IsNullOrEmpty(usernameText.Text))
            {


                loginFailed.Content = "All fields must have a value!";
                return;


            }

            string queryUsername = null;
            string queryPassword = null;
            string queryRole = null;

            string connectionStr = @"";

            string query = $"SELECT UserName, UserPassword, UserRole FROM dbo.USERDB where UserName = ? and UserPassword = ?";

            try
            {

                using (OdbcConnection connection = new OdbcConnection(connectionStr))
                {

                    connection.Open();

                    using (OdbcCommand readCommand = new OdbcCommand(query, connection))
                    {

                        readCommand.Parameters.Clear();
                        readCommand.Parameters.AddWithValue("?", usernameText.Text);
                        readCommand.Parameters.AddWithValue("?", passwordText.Password);

                        using (OdbcDataReader reader = readCommand.ExecuteReader())
                        {

                            while (reader.Read())
                            {

                                queryUsername = reader.GetString(0);
                                queryPassword = reader.GetString(1);
                                queryRole = reader.GetString(2);


                            }

                        }


                    }



                }

                if ((queryUsername != null && queryUsername == usernameText.Text) && (queryPassword != null && queryPassword == passwordText.Password))
                {

                    Console.WriteLine("Login Successful!");


                    if (queryRole == "Admin")
                    {

                        Admin_Main_Lib_Screen admin_Main_Lib_Screen = new Admin_Main_Lib_Screen();

                        admin_Main_Lib_Screen.Show();


                    }

                    else
                    {

                        Main_Lib_Screen mainScreen = new Main_Lib_Screen();

                        mainScreen.Show();

                    }

                    this.Close();

                }

                else
                {

                    Console.WriteLine("Login Info is not correct. Try again.");

                    loginFailed.Content = "Incorrect Info. Please try again!";

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                MessageBox.Show($"Error: {ex.Message}\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);


            }

        }



        // Function used to open the Register dialog/screen
        public void openRegisterDialog(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Register Link Button Clicked");

            RegisterDialog dialog = new RegisterDialog();

            dialog.ShowDialog();

        }

    }
}