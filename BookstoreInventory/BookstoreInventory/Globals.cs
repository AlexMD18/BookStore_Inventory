/*
Alex Drogo
Due: 03/12/2020
CIS3309_001
BookStore - Globals Class
Description: This is the class makes it easier to call the methods in the bookstore class.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreInventory
{ 
        class Globals
        {
            // NOTE:
            //       Static methods of a class may be called without instantiating the class
            //              They called from the class itself
            //       Static objects or variables may be accessed without creating an instance of the class
            //              that contains them
            //       When you declare a class as static, all its members are automatically static

            // Application classes -- BookStore is accessible throughout all code without passing it as an argument
            public static BookStoreClass BookStore = new BookStoreClass();

        }  // end Globals Class
}   // end namespace

