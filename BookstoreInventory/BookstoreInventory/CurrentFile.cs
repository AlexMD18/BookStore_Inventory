/*
Alex Drogo
Due: 03/12/2020
CIS3309_001
BookStore - Current File Class
Description: This class contains methods that are used to read the data in from the text file, get the next record, keep a count
of the records read, and then rewind back to the beginning of the file after its done being used.
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookstoreInventory
{
    class currentFile
    {
        private string currentFilePath;                 //File Path
        private System.IO.StreamReader currentFileSR;   // Reference variable of type SR
        private int recordReadCount;                    //Tracks number of records read

        // Constructor with file path input
        // Create instance of StreamReader class (type) and store reference
        public currentFile(string filePath)
        {
            recordReadCount = 0;
            currentFilePath = filePath;
            try
            {
                currentFileSR = new System.IO.StreamReader(currentFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open file" + currentFilePath + "Terminate Program.",
                                "Output File Connection Error.",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } // end Try
        } // end currentFileClass Constructor 



        // Read a record from the current file
        // Returns: the text string read and (through an output argument) a true-false 
        //          indicator for end-of-file
        public string getNextRecord(ref Boolean endOfFileFlag)
        {
            string nextRecord;

            endOfFileFlag = false;
            nextRecord = currentFileSR.ReadLine();

            if (nextRecord == null)
            {
                endOfFileFlag = true;
            }
            else
            {
                recordReadCount += 1;
            } // end if

            return (nextRecord);
        } // end getNextRecord


        // Get value of number of records read
        public int getRecordsReadCount()
        {
            return recordReadCount;
        } // end getRecordsReadCount


        // Close the input file
        public void closeFile()
        {
            currentFileSR.Close();
        }  // end closeFile


        // Rewind the input file
        public void rewindFile()
        {
            recordReadCount = 0;
            currentFileSR = new System.IO.StreamReader(currentFilePath);
            currentFileSR.DiscardBufferedData();
            currentFileSR.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
        }  // end rewindFile

    } // end currentFileClass
} // end namespace