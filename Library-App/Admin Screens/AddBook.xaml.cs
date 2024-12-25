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
using System.Windows.Shapes;


/*
 * ----------------------------------------------------------------------------------------------------
 * Class that holds all callback functions for the Add Book Dialog
 * Can only be accessed via the admin main screen UI
 * Adds books to the connected MSSQL DB by using the Entity Framework
 * ----------------------------------------------------------------------------------------------------
 */
namespace Library_App
{
    /// <summary>
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        public AddBook()
        {
            InitializeComponent();
            AddNewBookBTN.IsEnabled = false;

        }


        public void EntryBoxesChanged(object sender, TextChangedEventArgs e)
        {

            CheckEntryBoxes();

        }



        // Function used to check if the entry text boxes have text
        // Is called whenever the text boxes have their text changed
        public void CheckEntryBoxes()
        {

            if (string.IsNullOrEmpty(BookTitleEntry.Text) || string.IsNullOrEmpty(BookAuthorEntry.Text) || string.IsNullOrEmpty(BookGenreEntry.Text) || string.IsNullOrEmpty(YearPublishedEntry.Text) || string.IsNullOrEmpty(CopiesEntry.Text))
            {

                AddNewBookBTN.IsEnabled = false;

            }
            else
            {

                AddNewBookBTN.IsEnabled = true;

            }


        }



        // Function used to actually add the book to the db
        // First ensures that all entry fields have values and are valid
        // Then creates a new instance of the Library Context to access the db and add in a new Book object that can be mapped to the db
        public void AddDefinedBook(object sender, RoutedEventArgs e)
        {


            if (!string.IsNullOrEmpty(BookTitleEntry.Text) && !string.IsNullOrEmpty(BookAuthorEntry.Text) && !string.IsNullOrEmpty(BookGenreEntry.Text) && !string.IsNullOrEmpty(YearPublishedEntry.Text) && !string.IsNullOrEmpty(CopiesEntry.Text))
            {

                if (int.TryParse(YearPublishedEntry.Text, out int yearPublished) && int.TryParse(CopiesEntry.Text, out int numCopies))
                {


                    using (var context = new LibraryContext())
                    {
                        var newBook = new Book
                        {

                            Book_Title = BookTitleEntry.Text,
                            Book_Author = BookAuthorEntry.Text,
                            Book_Genre = BookGenreEntry.Text,
                            Book_Year_Published = yearPublished,
                            Book_copies_available = numCopies,


                        };

                        context.Books.Add(newBook);
                        context.SaveChanges();


                    }
                }

                else
                {

                    MessageBox.Show("You need to fill out all fields for the Book to be entered! Please try again!");
                    return;

                }

                this.Close();

            }

            else
            {

                MessageBox.Show("You need to fill out all fields for the Book to be entered! Please try again!");
                return;

            }

            

        }

    }
}
