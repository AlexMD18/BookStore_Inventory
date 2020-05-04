/*
Alex Drogo
Due: 03/12/2020
CIS3309_001
BookStore - Employee Class
Description: This class contains all the attributes that make up an employee. It checks the employee Id by comparing the access id 
that the user inserts in the form to the one that is read in from the file. It verifies to make sure the PIN that the user enters 
matches the PIN in the file. This class formats the data that is inserted from the file so it can be added to the array list in the 
employee list class. Lastly, it creates the string that the user will see and updates the last accessed date to the current date.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookstoreInventory
{
    class EmployeeClass
    {
        //This is the number of integers the user is allowed to type into the text boxes for their id and pin to work
        private const int ALLOWED_ACCESS_ID_LENGTH = 5;
        private const int ALLOWED_PIN_LENGTH = 4;

        //Declared and initalized variables
        private int hiddenAccessID = 0;
        private string hiddenName = "";
        private int hiddenPIN = 0;
        private decimal hiddenSalary = 0m;
        private DateTime hiddenLastAccess = default(DateTime);

        //Constructor
        public EmployeeClass()
        {
            
        }

        //This method checks to make sure the number the user types matches a their number in the arraylist
        public Boolean checkEmployeeID (int ID)   // IN: user entered employee Access ID
        {
            EmployeeClass emp = this;

            if (ID == emp.hiddenAccessID)
            {
                // Save all data from current Employee Object for later reference.
                hiddenAccessID = emp.hiddenAccessID;
                hiddenPIN = emp.hiddenPIN;
                hiddenName = emp.hiddenName;
                hiddenSalary = emp.hiddenSalary;
                hiddenLastAccess = emp.hiddenLastAccess;
                return true;
            }
            else
            {
                return false;
            }
        }  // end checkEmployeeID

        //Compares the pin the user entered into the form with the hidden pin which is the pin that is contained in the employee
        //text file.
        public bool verifyPIN(int enteredPin)
        {
            if (enteredPin == hiddenPIN)
            {
                return true;
            }
            else
            {
               //MessageBox.Show("No Match");
                return false;
            }
        }

        //This method takes the data from the text file and formats the data to the proper types that will be inserted into the 
        //arraylist. It spits the data at the asterisk and reads all the lines and does checks to validate that the proper data is 
        //being inserted as well as the proper lengths of the access id and the pin number.
        public bool createAndPopulateEmployeeObject(string s)
        {
            EmployeeClass thisEmployee = this;
            string[] employeeString = s.Split('*');

            int employeeStringSize = employeeString.GetLength(0);

            for(int i = 0; i <= employeeStringSize - 1; i++)
            {
                employeeString[i] = employeeString[i].Trim();
            }

            //Checks the lenght of the access id. If it does not equal 5, the boolean returns false;
            if (employeeString[0].Length != ALLOWED_ACCESS_ID_LENGTH)
            {
                MessageBox.Show(employeeString[0] + ": The Access ID Number is not 5 digits exactly. Please contact the system administrator.", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            //This converts the string to an integer so it can be assigned to the hiddenAccessID which is an integer.
            try
            {
                hiddenAccessID = Convert.ToInt32(employeeString[0]);
            }
            catch
            {
                //If it cannot be converted, the user will recieve this message.
                MessageBox.Show("The Access ID containts non-numerical values. Please contact the system administrator.", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            //There is no need to convert this since hidden name and employeeString are both string types
            hiddenName = employeeString[1];
            if(hiddenName == ""){
                MessageBox.Show("Name is blank. Please contact the system administrator.", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            //Checks the lenth of the pin to make sure it is 4 digits
            if(employeeString[2].Length != ALLOWED_PIN_LENGTH)
            {
                MessageBox.Show("The PIN is not exacly 4 digits. Please contact the system administrator.", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            //Converts PIN string to an integer. If it cannot be converted, an error message is presented to the user.
            try
            {
                hiddenPIN = Convert.ToInt32(employeeString[2]);
            }
            catch
            {
                MessageBox.Show("The PIN containts non-numerical values. Please contact the system administrator.", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            //Converts the the employeeString to a decimal and assign it to hiddenSalary.
            try
            {
                hiddenSalary = Convert.ToDecimal(employeeString[3].Replace("$",
                    "").Replace(",", ""));
            }
            catch
            {
                MessageBox.Show("The salary contains non numberical data. Please contact the system administrator.", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            //Converts the last access date from a string to a dateTime data type
            try
            {
                hiddenLastAccess = DateTime.Parse(employeeString[4]);
            }
            catch
            {
                MessageBox.Show("The date accessed is not in a valid date form. Please contact the system administrator.", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return (true);
        }

        //This method formats what the user will see when they ask to see the employee information file
        public string createStringToWrite()
        {
            string decimalAsString = String.Format("{0:c}", hiddenSalary);
            string s = hiddenAccessID.ToString() + " * " + hiddenName + " * " + hiddenPIN.ToString()
                       + " * " + decimalAsString + " * " + hiddenLastAccess.ToString();
            /*MessageBox.Show(hiddenAccessID.ToString() + "\r\n" + hiddenName + "\r\n" + hiddenPIN.ToString() +
                            "\r\n" + decimalAsString + "\r\n" + hiddenLastAccess.ToString(),
                            "String Written to Updated Employee File", MessageBoxButtons.OK, MessageBoxIcon.Stop);*/
            return s;
        }


        //This method simply updates the last date field to the current date that the user accesses the data.
        public void updateEmployeeTransactionDate(DateTime thisDate,   // IN: date of tranaction to be performed
                                                  EmployeeClass emp)   // IN: Employee who is logged in and whose last date of access has to be changed
        {
            emp.hiddenLastAccess = thisDate;
            string message = "ID:                  " + emp.hiddenAccessID
                         + "\nName:                " + emp.hiddenName
                         + "\nPin:                 " + emp.hiddenPIN
                         + "\nAnnual Pay:          " + emp.hiddenSalary
                         + "\nLast Date Of Access: " + emp.hiddenLastAccess;
            //MessageBox.Show(message, "Revised Employee Record", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return;
        }  // end updateEmployeeTransactionDate

    }
}