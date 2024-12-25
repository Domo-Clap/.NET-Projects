using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * ----------------------------------------------------------------------------------------------------
 * Base Class used to define Book objects from the DB.
 * Contains getter and setter functions for each attribute/data point for Book objects in the database
 * ----------------------------------------------------------------------------------------------------
 */

namespace Library_App
{
    class Book
    {

        public string Book_Title
        {
            get; set;
        }

        public string Book_Author
        {
            get; set;
        }

        public string Book_Genre
        {
            get; set;
        }

        public int Book_ID
        {
            get; set;
        }

        public int Book_Year_Published
        {
            get; set;
        }

        public int Book_copies_available
        {
            get; set;
        }


    }
}
