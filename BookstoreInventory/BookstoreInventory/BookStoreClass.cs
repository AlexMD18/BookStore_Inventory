/*
Alex Drogo
Due: 03/12/2020
CIS3309_001
BookStore - Bookstore Class
Description: This class connects all the others together, becuase all the other classes kind of belong within the broader bookstore
scope. This is the class that gets called many times in the forms becuase it contains the text files.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookstoreInventory
{
    class BookStoreClass
    {
        // Books and the EmployeeList and all the text files belong to the Bookstore
        public BookClass Book;
        public EmployeeListClass EmployeeList;

        private currentFile currentBookFile;
        private UpdatedFile updatedBookFile;
        private currentFile currentEmployeeFile;
        private UpdatedFile updatedEmployeeFile;

        // The Files the Bookstore Owns
        private string currentBookFilePath = "currentBookFile.txt";
        private string updatedBookFilePath = "updatedBookFile.txt";
        private string currentEmployeeFilePath = "currentEmployeeFile.txt";
        private string updatedEmployeeFilePath = "updatedEmployeeFile.txt";

        //private currentFile currentBookFile = new currentFile(currentBookFilePath);
        //private UpdatedFile updatedBookFile = new UpdatedFile(updatedBookFilePath);
        //private currentFile currentEmployeeFile = new currentFile(currentEmployeeFilePath);
        //private UpdatedFile updatedEmployeeFile = new UpdatedFile(updatedEmployeeFilePath);

        // Bookstore parameters (Named constants defined by the Bookstore)
        private int hiddenAccessIDLength = 5;   // Length of AccessNet ID
        private int hiddenISBNLeftLength = 3;   // Length of left part of ISBN
        private int hiddenISBNRightLength = 3;  // Length of right part of ISBN
        // Number of attempts BookStore allows a user before terminating an inventory update session
        private int hiddenTryCountMax = 3;

        //Constructor
        public BookStoreClass()
        {
            Book = new BookClass();
            EmployeeList = new EmployeeListClass();

            currentBookFile = new currentFile(currentBookFilePath);
            updatedBookFile = new UpdatedFile(updatedBookFilePath);
            currentEmployeeFile = new currentFile(currentEmployeeFilePath);
            updatedEmployeeFile = new UpdatedFile(updatedEmployeeFilePath);
        }

        //Get methods to use private variables
        public currentFile getCurrentEmployeeFile
        {
            get
            {
                return currentEmployeeFile;
            }
        }

        public UpdatedFile getUpdatedEmployeeFile
        {
            get
            {
                return updatedEmployeeFile;
            }
        }

        public currentFile getCurrentBookFile
        {
            get
            {
                return currentBookFile;
            }
        }

        public UpdatedFile getUpdatedBookFile
        {
            get
            {
                return updatedBookFile;
            }
        }
        public int getFullISBNLength
        {
            get
            {
                return (hiddenISBNLeftLength + hiddenISBNRightLength + 1);
            }
        }
        //end of get methods

        //Closes all files
        public void closeFiles()
        {
            getCurrentBookFile.closeFile();
            getUpdatedBookFile.closeFile();
        }

        //Rewinds files back to the beginning of each
        public void rewindFiles()
        {
            getCurrentBookFile.rewindFile();
            getUpdatedBookFile.rewindFile();
        }

        //Writes a single record to the updated file
        public void writeOneRecord(string record)
        {
            updatedBookFile.putNextRecord(record);
        }

        //Checks for another record with the same ISBN when the user inserts an ISBN number
        public bool checkForDuplicateRecord(string ISBN)
        {
            string nextRecord;
            Boolean isEndOfFile = true;
            Boolean success;
            int countProcessedRecords = 0;

            nextRecord = Globals.BookStore.getCurrentBookFile.getNextRecord(ref isEndOfFile);

            while (!isEndOfFile)
            {
                countProcessedRecords++;
                success = Book.createBookObject(nextRecord);

                if (success != true)
                {
                    MessageBox.Show("Unable to create book object.", "Book Creation Unsuccessfu;", MessageBoxButtons.OK);
                    return false;
                }
                if (!Book.bookMatch(ISBN))
                {
                    //Need to put next record here in able to see all the records before the one you are updating or deleting
                    updatedBookFile.putNextRecord(nextRecord);
                    nextRecord = getCurrentBookFile.getNextRecord(ref isEndOfFile);
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        //When an employee is added, updated, or deleted, the remaining records that are not used are written to 
        //the updated book record.
        public void copyRemainingRecords()
        {
            string nextRecord;
            Boolean isEndOfFile = true;
            Boolean success;
            int countProcessedRecords = 0;

            nextRecord = Globals.BookStore.getCurrentBookFile.getNextRecord(ref isEndOfFile);

            while (!isEndOfFile)
            {
                countProcessedRecords++;
                success = Book.createBookObject(nextRecord);

                if (success != true)
                {
                    MessageBox.Show("Unable to copy book object.", "Book Creation Unsuccessfu;", MessageBoxButtons.OK);
                }
                updatedBookFile.putNextRecord(nextRecord);
                nextRecord = currentBookFile.getNextRecord(ref isEndOfFile);
            }
        }
    }
}