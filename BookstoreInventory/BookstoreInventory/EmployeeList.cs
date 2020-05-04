/*
Alex Drogo
Due: 03/12/2020
CIS3309_001
BookStore - Employee List Class
Description: This class contains methods that are used to create the list that holds all the employees that are contained in the text
file. It finds the employee in the list and keeps track of the index that person is found of so the pin can easily be verified later.
It also has a method that can be called to write the contents of the arraylist to the updated file.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookstoreInventory
{
    class EmployeeListClass
    {
        private EmployeeClass Employee = new EmployeeClass();
        private int index;   // holds index of element in list that contains the employee who has logged in
        DateTime today;

        private List<EmployeeClass> InternalList;
        //private EmployeeClass emp = new EmployeeClass();

        // Parameterless constructor
        public EmployeeListClass()
        {
            InternalList = new List<EmployeeClass>(4);
        }  // end parameterless constructor

        //This method reads through the elements of the arraylist. It calls the method checkEmployeeID in the employeeClass which is a
        //bool type method and passes the ID that the user inserted as a parameter. If the ID that the user inserted is contained in
        //the arraylist, then the method returns true. If its not found, then the index increments and the program checks the next
        //element.
        public bool findEmployeeInList(int ID)   // IN: Employee AccessID to be checked.  This is the ID entered by the Employee
        {
            index = 0;
             foreach (EmployeeClass emp in InternalList)
             {
                 if (emp.checkEmployeeID(ID) == true)
                     return true;
                 else
                     index++;
             }
             return false;
        }  // end findEmployeeInList

        //This method is very similar to the method above, it just simply returns the object employee. It is used to update the employee
        //transaction date in the access id form.
        public EmployeeClass returnEmployeeInList(int ID)
        {
            index = 0;
            foreach(EmployeeClass emp in InternalList)
            {
                if(emp.checkEmployeeID(ID) == true)
                {
                    Employee = emp;
                }
                else
                {
                    index++;
                }
            }
            return Employee;
        }

        // Initialize entire employee list given data in current Book File 
        public Boolean initializeEntireList()
        {
            string nextRecord;
            Boolean isEndOfFile = true;
            Boolean success;
            int countProcessedRecords = 0;

            nextRecord = Globals.BookStore.getCurrentEmployeeFile.getNextRecord(ref isEndOfFile);

            while (!isEndOfFile)
            {
                countProcessedRecords++;
                EmployeeClass emp = new EmployeeClass();
                success = emp.createAndPopulateEmployeeObject(nextRecord);
                if (success != true)
                {
                    MessageBox.Show("Unable to create an Employee Object.  Employee list not created.",
                                    "Employee List Creation Failed", MessageBoxButtons.OK);
                    return false;
                }
                InternalList.Add(emp);
                nextRecord = Globals.BookStore.getCurrentEmployeeFile.getNextRecord(ref isEndOfFile);
            } //end While

            if (countProcessedRecords > 0)
                return true;
            else
                return false;
        }  // end initializeEntireList

        //This method takes the parameter enteredPin and calls the verify pin method in the employee class and returns the result.
        public Boolean verifyPin(int enteredPin)
        {
            return Employee.verifyPIN(enteredPin);
        }  // end verifyPin

        //Returns the amount of elements in the internal list
        public int getCount()
        {
            return InternalList.Count();
        }

        //Updates the last date of access to the current date
        public void updateEmployeeObject()
        {
            InternalList[index].updateEmployeeTransactionDate(today, Employee);
        }

        //Writes the contents of the employeeList object to the updated employee file object.
        public void writeEntireListToFile()
        {
            for(int i = 0; i < InternalList.Count; i++)
            {
                Globals.BookStore.getUpdatedEmployeeFile.putNextRecord(InternalList[i].createStringToWrite());
                //BookStoreClass.updatedEmployeeFile.putNextRecord(InternalList[i].createStringToWrite());
            }
            Globals.BookStore.getUpdatedEmployeeFile.closeFile();
            //BookStoreClass.updatedEmployeeFile.closeFile();
        }
    }
}