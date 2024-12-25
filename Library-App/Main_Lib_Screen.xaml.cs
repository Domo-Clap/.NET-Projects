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
using Microsoft.IdentityModel.Tokens;



/*
 * ----------------------------------------------------------------------------------------------------
 * Class that holds all callback functions for the User Main Screen UI
 * Main function is the getBooks function which grabs all the book objects from the Library Context and displays them in a datagrid
 * Only other function is to search/filter for books
 * Only users will see this screen
 * ----------------------------------------------------------------------------------------------------
 */

namespace Library_App
{
    /// <summary>
    /// Interaction logic for Main_Lib_Screen.xaml
    /// </summary>
    public partial class Main_Lib_Screen : Window
    {
        public Main_Lib_Screen()
        {
            InitializeComponent();
            getBooks();

        }


        // Function to get books from the Library Context and display them. The library context maps items from our Book table in the DB to our Book object class.
        // Loads items into the data grid on the UI
        public void getBooks ()
        {

            using (var context = new LibraryContext())
            {

                var books = context.Books.ToList();

                BooksTableGrid.ItemsSource = books;


            }
            
        }


        // Function to filter the books shown in the data grid
        // Takes input from both title and author search fields. Uses conditional statements to determine what to filter by.
        // Can filter by both author and title, only author, or only title
        public void filterBooks(object sender, RoutedEventArgs e)
        {

            string book_title, book_author;


            book_author = bookAuthorSearch.Text;
            book_title = bookTitleSearch.Text;

            if (!string.IsNullOrEmpty(bookTitleSearch.Text) && !string.IsNullOrEmpty(bookAuthorSearch.Text))
            {

                using (var context = new LibraryContext())
                {
                    var filteredBooks = context.Books
                    .Where(b => b.Book_Title.ToLower().Contains(book_title) && b.Book_Author.ToLower().Contains(book_author))
                    .ToList();

                    BooksTableGrid.ItemsSource = filteredBooks;

                }

                return;


            }

            else if (!string.IsNullOrEmpty(bookTitleSearch.Text) && string.IsNullOrEmpty(bookAuthorSearch.Text))
            {

                using (var context = new LibraryContext())
                {
                    var filteredBooks = context.Books
                    .Where(b => b.Book_Title.ToLower().Contains(book_title))
                    .ToList();

                    BooksTableGrid.ItemsSource = filteredBooks;

                }

                return;


            }

            else if (!string.IsNullOrEmpty(bookAuthorSearch.Text) && string.IsNullOrEmpty(bookTitleSearch.Text))
            {

                using (var context = new LibraryContext())
                {
                    var filteredBooks = context.Books
                    .Where(b => b.Book_Author.ToLower().Contains(book_author))
                    .ToList();

                    BooksTableGrid.ItemsSource = filteredBooks;

                }

                return;

            }

            else
            {

                return;

            }


        }

    }
}
