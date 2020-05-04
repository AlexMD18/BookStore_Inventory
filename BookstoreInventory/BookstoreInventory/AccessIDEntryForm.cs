/*
Alex Drogo
Due: 03/12/2020
CIS3309_001
BookStore - Access ID Form
Description: This is the class for the first form. It loads in the text file into the arraylist when the from is initiated. It verifies
all the data that the user inserts into the text box to make sure it is 5 numerical digits and then calls the methods that it needs to 
check and see if the id that the user inserts is in the file. If it is, the form then opens the second form
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookstoreInventory
{
    public partial class frmAccessID : Form
    {
        int attemptCount = 0;

        public frmAccessID()
        {
            InitializeComponent();
        }

        //When the form is loaded, we want the text file to be read and the arraylist to be filled.
        private void frmAccessID_Load(object sender, EventArgs e)
        {
            Globals.BookStore.EmployeeList.initializeEntireList();
        }

        /*When the "Find Me" button is clicked by the user, various things happen. The text that the user inserts is converted into an
          integer that the program will use. It handles a lot of data validation such as making sure the input is five numbers long and 
          checks to make sure the data inputted is only numbers. It also keeps track of the attempts that the user has remaining. If
          the data passes all the tests, the method calls for the next form to be opened.*/
        private void btnFindMe_Click(object sender, EventArgs e)
        {
            bool found = true;
            string empAccessIDString = txtFindMe.Text;
            int empAccessID;
            empAccessID = Convert.ToInt32(empAccessIDString);
            EmployeeClass emp = Globals.BookStore.EmployeeList.returnEmployeeInList(empAccessID);
            emp.updateEmployeeTransactionDate(DateTime.Today, emp);

            //Checks input length
            if (empAccessIDString.Length != 5)
            {
                if (attemptCount >= 3)
                {
                    MessageBox.Show("You have used up all your attempts. Please visit your supervisor to login", "Too Many Attempts", MessageBoxButtons.OK);
                    this.Close();
                }
                MessageBox.Show("Your accessID must be a 5 digit integer. You have " + (2 - attemptCount) + " attempt(s) left.", "Invalid AccessID");
                attemptCount++;
                txtFindMe.Clear();
                txtFindMe.Focus();
                return;
            }

            //Converts data to an integer
            try
            {
                empAccessID = Convert.ToInt32(empAccessIDString);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Needs to be 5 numerical digits. You have " + (3 - attemptCount) +  " attempt(s) left.", "Invalid Account");
                attemptCount++;
                txtFindMe.Clear();
                txtFindMe.Focus();
                if (attemptCount >= 3)
                {
                    MessageBox.Show("You have used up all your attempts. Please visit your supervisor to login", "Too Many Attempts", MessageBoxButtons.OK);
                    this.Close();
                }
            }

            //If the employee id is found in the list, open the next form.
            if(found == Globals.BookStore.EmployeeList.findEmployeeInList(Convert.ToInt32(txtFindMe.Text)))
            {
                Form PinIDEntryForm = new frmPinIDEntryForm();
                this.Visible = false;
                PinIDEntryForm.ShowDialog();
                this.Close();
                
            }
            else
            {
                attemptCount++;
                MessageBox.Show("The access ID could not be found. Please try again. You have " + (3 - attemptCount) + " attempt(s) left", "No Access ID Found");
                txtFindMe.Clear();
                txtFindMe.Focus();
                if (attemptCount >= 3)
                {
                    MessageBox.Show("You have used up all your attempts. Please visit your supervisor to login", "Too Many Attempts", MessageBoxButtons.OK);
                    this.Close();
                }
            }
        }
    }
}