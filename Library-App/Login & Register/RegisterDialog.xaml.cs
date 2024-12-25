using System;
using System.Collections.Generic;
using System.Data.Odbc;
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
using System.Windows.Shapes;


/*
 * ----------------------------------------------------------------------------------------------------
 * Class that holds all callback functions for the register account dialog/UI
 * Can only be accessed by clicking on the reigster button on the main login screen/first shown UI
 * Main function of this UI is to allow users to register accounts by entering account info
 * ----------------------------------------------------------------------------------------------------
 */

namespace Library_App
{
    /// <summary>
    /// Interaction logic for RegisterDialog.xaml
    /// </summary>
    public partial class RegisterDialog : Window
    {

        bool isInitialized = false;

        // Initializes the page and sets the register button to false to ensure it can't be clicked until the entry text fields are populated correctly
        public RegisterDialog()
        {
            InitializeComponent();

            isInitialized = true;

            registerBTN.IsEnabled = false;

            Console.WriteLine("Page Initialized");
        }


        public void textEntryBoxChanged(object sender, TextChangedEventArgs e)
        {

            if (isInitialized)
            {

                checkEntryText();

            }


        }



        // Function used to check if the entry text boxes have text
        // Is called whenever the text boxes have their text changed
        public void checkEntryText()
        {

            if (string.IsNullOrEmpty(rUsername.Text) || string.IsNullOrEmpty(rPassword.Text) || string.IsNullOrEmpty(rEmail.Text) || string.IsNullOrEmpty(rConfirmPassword.Text))
            {

                registerBTN.IsEnabled = false;


            }

            else
            {

                registerBTN.IsEnabled = true;

            }


        }



        // Function used to connect to the DB and register/add an account to the users table
        // Once added, users will be taken back to the main page and if they try to login with the new info, it should work
        // First the functions checks to see if all fields are populated correctly (password includes certain values, username is certain length, passwords match etc...)
        public void onRegisterBTNClicked(object sender, RoutedEventArgs e)
        {

            //MessageBox.Show("Register Button Clicked");

            Console.WriteLine("Register Button Clicked");


            if (string.IsNullOrEmpty(rUsername.Text) && string.IsNullOrEmpty(rEmail.Text) && string.IsNullOrEmpty(rPassword.Text) && string.IsNullOrEmpty(rConfirmPassword.Text))
            {

                MessageBox.Show("All fields must be populated!");
                return;

            }

            if (rPassword.Text != rConfirmPassword.Text)
            {
                MessageBox.Show("Passwords must match!");
                return;

            }

            if (rUsername.Text.Length < 8)
            {

                MessageBox.Show("Username requires 8 or more characters!");
                return;

            }

            if (rPassword.Text.Length < 10 || !(rPassword.Text.Contains('!') || rPassword.Text.Contains('@') || rPassword.Text.Contains('_') || rPassword.Text.Contains('-')))
            {

                MessageBox.Show("Passwords must have a !, _, -, or @ in it!");
                return;

            }

            string connectionStr = @"";

            string getItemsQuery = $"SELECT UserName, UserEmail FROM dbo.USERDB where UserName = ? or UserEmail = ?";

            string insertQuery = $"INSERT INTO dbo.USERDB (UserName, UserEmail, UserPassword, UserRole) VALUES (?, ?, ?, ?)";

            try
            {

                using (OdbcConnection connection = new OdbcConnection(connectionStr))
                {

                    connection.Open();

                    using (OdbcCommand readCommand = new OdbcCommand(getItemsQuery, connection))
                    {
                        readCommand.Parameters.Clear();
                        readCommand.Parameters.AddWithValue("?", rUsername.Text);
                        readCommand.Parameters.AddWithValue("?", rEmail.Text);


                        using (OdbcDataReader reader = readCommand.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                registerFailLabel.Content = "Username or email already exists in the database.";
                                return;

                            }


                        }

                    }

                    using (OdbcCommand insertCommand = new OdbcCommand(insertQuery, connection))
                    {

                        insertCommand.Parameters.Clear();
                        insertCommand.Parameters.AddWithValue("?", rUsername.Text);
                        insertCommand.Parameters.AddWithValue("?", rEmail.Text);
                        insertCommand.Parameters.AddWithValue("?", rPassword.Text);
                        insertCommand.Parameters.AddWithValue("?", "User");


                        int rowsAffected = insertCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {

                            registerFailLabel.Content = "Registration Successful!";

                        }

                        else
                        {

                            registerFailLabel.Content = "Registration Failed!";

                        }

                    }


                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                MessageBox.Show($"Error: {ex.Message}\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);


            }


            this.Close();

        }


    }
}
