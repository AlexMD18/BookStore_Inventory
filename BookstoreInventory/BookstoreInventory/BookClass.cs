/*
Alex Drogo
Due: 03/12/2020
CIS3309_001
BookStore - Book Class
Description: This class consists of the attributes that a book is made from such as ISBN, Title, Author ect. It checks to make sure
the book's ISBN that the user enters is the same as in the book file. It will also format the input so the data can be inserted into
into a list with the books.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookstoreInventory
{
    class BookClass
    {
        //Private Variables
        private string hiddenISBN;
        private string hiddenTitle;
        private string hiddenAuthor;
        private decimal hiddenPrice;
        private int hiddenNumOnHand;
        private DateTime hiddenLastTransaction;

        //Constructor
        public BookClass()
        {

        }

        public BookClass(string hiddenISBN, string hiddenTitle, string hiddenAuthor, decimal hiddenPrice, int hiddenNumOnHand, DateTime hiddenLastTransaction)
        {
            this.hiddenISBN = hiddenISBN;
            this.hiddenTitle = hiddenTitle;
            this.hiddenAuthor = hiddenAuthor;
            this.hiddenPrice = hiddenPrice;
            this.hiddenNumOnHand = hiddenNumOnHand;
            this.hiddenLastTransaction = hiddenLastTransaction;
        }

        //Getters to be able to place the items from the file into the text box in the panel
        public string getHiddenISBN
        {
            get
            {
                return (hiddenISBN);
            }
        }

        public string getHiddenTitle
        {
            get
            {
                return (hiddenTitle);
            }
        }

        public string getHiddenAuthor
        {
            get
            {
                return (hiddenAuthor);
            }
        }

        public decimal getHiddenPrice
        {
            get
            {
                return (hiddenPrice);
            }
        }

        public int getHiddenNumOnHand
        {
            get
            {
                return (hiddenNumOnHand);
            }
        }

        public DateTime getHiddenLastTransaction
        {
            get
            {
                return (hiddenLastTransaction);
            }
        }
        //end of get methods

        //Creates a string for the programmer can see the items in the list when they move them from the current book file 
        //to the updated book file
        public void displayBookRecord()
        {
            string bookString;

            bookString = "ISBN: " + hiddenISBN + "\nTitle: " + hiddenTitle + "\nAuthor: " + hiddenAuthor + "\nPrice: $" + hiddenPrice +
                         "\nIn Inventory: " + hiddenNumOnHand + "\nLast Transaction: " + hiddenLastTransaction;

            MessageBox.Show(bookString, "Book Information");
        }

        //This method takes the data from the text file and formats the data to the proper types required. 
        //It splits the data at the asterisk and reads all the lines and does checks to validate that the proper data is 
        //being inserted as well as the proper lengths of the ISBN number.
        public bool createBookObject(string b)
        {
            BookClass thisBook = this;
            string[] bookString = b.Split('*');

            hiddenISBN = bookString[0].Trim();
            hiddenTitle = bookString[1].Trim();
            hiddenAuthor = bookString[2].Trim();

            for (int i = 0; i < bookString.Length; i++)
            {
                bookString[i] = bookString[i].Trim();
            }

            //Checks to make sure the value inserted into the isbn text boxes is equal to the required length of the ISBN
            if (hiddenISBN.Length != Globals.BookStore.getFullISBNLength)
            {
                MessageBox.Show(bookString[0] + ": the ISBN number is not 6 digits.", "ERROR");
                return false;
            }

            //Checks to make sure the title is not empty
            if (hiddenTitle == "")
            {
                MessageBox.Show(bookString[1] + ": there is no title for this book.");
                return false;
            }

            //Checks to make sure the author is not empty
            if (hiddenAuthor == "")
            {
                MessageBox.Show(bookString[2] + ": there is no author for this book.");
            }

            //Converts the price to a decimal and gets rid of the dollar sign and any commas
            try
            {
                hiddenPrice = Convert.ToDecimal(bookString[3].Replace("$","").Replace(",",""));
            }
            catch
            {
                MessageBox.Show("Could not convert the price to a decimal", "ERROR");
                return false;
            }

            //Converts the on hand number to an integer
            try
            {
                hiddenNumOnHand = Convert.ToInt32(bookString[4]);
            }
            catch
            {
                MessageBox.Show("Could not convert " + bookString[4] + " to an integer", "ERROR");
                return false;
            }

            //Parses the date
            try
            {
                hiddenLastTransaction = DateTime.Parse(bookString[5]);
            }
            catch
            {
                MessageBox.Show("The date accessed is not in a valid date form.", "ERROR");
                return false;
            }

            return true;
        }

        //This Method checks to see if the isbn that is eneted by the user is equal to the hidden isbn which is in the current
        //book file.
        public bool bookMatch(string enteredISBN)
        {
            if (enteredISBN == hiddenISBN)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}