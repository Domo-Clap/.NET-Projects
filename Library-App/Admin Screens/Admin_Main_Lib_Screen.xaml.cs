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
 * Class that holds all callback functions for the Admin Main Screen UI
 * Main function is the getBooks function which grabs all the book objects from the Library Context and displays them in a datagrid
 * Other functions specifically for Admin users such as add and delete books
 * ----------------------------------------------------------------------------------------------------
 */

namespace Library_App
{
    /// <summary>
    /// Interaction logic for Admin_Main_Lib_Screen.xaml
    /// </summary>
    public partial class Admin_Main_Lib_Screen : Window
    {
        public Admin_Main_Lib_Screen()
        {
            InitializeComponent();
            getBooks();

        }



        // Function to get books from the Library Context and display them. The library context maps items from our Book table in the DB to our Book object class.
        // Loads items into the data grid on the UI
        public void getBooks()
        {

            using (var context = new LibraryContext())
            {

                var books = context.Books.ToList();

                BooksTableGrid.ItemsSource = books;


            }

        }


        // Function to open to the add new book page, which can be used to add new books to the database via the entity framework.
        // After the dialog box closes, the books are shown again in case a new book is added.
        public void AddNewBook(object sender, RoutedEventArgs e)
        {

            
            AddBook AddBookDialog = new AddBook();

            AddBookDialog.Show();


            getBooks();

        }



        // Function to delete a book from the data grid.
        // Works by grabbing the selected item from the data grid and then prompts the user to ensure they want to delete the book object.
        // Does access the Library Context, which connects to the db to delete the specific book.
        public void DeleteBook(object sender, RoutedEventArgs e)
        {

            var selectedBook = BooksTableGrid.SelectedItem as Book;

            if (selectedBook == null)
            {

                MessageBox.Show("Not a valid book!");
                return;
                
            }

            var result = MessageBox.Show($"Are you sure you want to delete '{selectedBook.Book_Title}'?",
                                 "Confirm Delete",
                                 MessageBoxButton.YesNo,
                                 MessageBoxImage.Question);


            if (result == MessageBoxResult.Yes)
            {

                using (var context = new LibraryContext())
                {

                    var bookToDelete = context.Books.Find(selectedBook.Book_ID);

                    if (bookToDelete != null)
                    {

                        context.Books.Remove(bookToDelete);
                        context.SaveChanges();

                    }

                }

                getBooks();
                
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
