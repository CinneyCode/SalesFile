using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_6
{
    class Program
    {

        static List<string> fullName = new List<string>(); 
        static List<decimal> salesAmt = new List<decimal>();
        static List<int> salesSort = new List<int>();
        //create three list for salesperson name, their sale amount, and a list for index loop 
        static void Main(string[] args)
        {
            Console.WriteLine("    Welcome to Sommet SalesForce   ");
            while (true)
            {
                ReadFile(); // Display MenuOption based on ReadFile
                MenuOption(); 
                int menuChoice = Convert.ToInt32(Console.ReadLine());
                switch (menuChoice) //use switch statment to let user select the options
                {
                    case 1:
                        CurrentSale();
                        break;

                    case 2:
                        AdditionalSale();
                        break;

                    case 3:
                        TopThreeSalesPerson();
                        break;
                    case 4:
                        SalesTotal();
                        break;
                }

                Console.ReadKey();
            }

        }
        static private void MenuOption() //Display MenuOption 
        {
            Console.WriteLine("                     ");
            Console.WriteLine("Please select the following:");
            Console.WriteLine("1.Display the information from input file: ");
            Console.WriteLine("2. Enter sales report :");
            Console.WriteLine("3.Display the  top three sales person in the order:");
            Console.WriteLine("4.Display the total sales for all saleperson:");

        }
        static private void CurrentSale() //Display Current Sale from ReadFile 
        {
            Console.WriteLine($"The number of salesperson from the input File = {fullName.Count} people.");
            for (int i = 0; i < salesAmt.Count; i++) //loop through the file to display their names and amt 
            {
                Console.WriteLine($"{fullName[i]} has total sales of {salesAmt[i]:C}");

            }
        }
        static private void AdditionalSale() //Ask the user if there's addtional sales 
        {
            Console.WriteLine("Is there additional sales to report? Y/N");
            string moreSalesReport = Console.ReadLine(); //if Yes , loop through this 
            while (true)
            {
                {
                    switch (moreSalesReport)
                    {
                        case "Y":
                            Console.WriteLine("Please enter the saleperson full name");
                            string name = Console.ReadLine(); //userinput's variable is "name"
                            int salesPersonIndex = 0;
                            //declare userinput as an index. Give 0 as the index number since the zero index value in the fullName list starts at the first saleperson
                            for (int i = 0; i < fullName.Count; i++)
                            //the userinput's index will be equal to the fullname index and will loop through the List or array to find that person
                            {
                                if (name.ToLower() == fullName[i].ToLower()) //use if statement to trim the userinput to lower case 
                                {
                                    salesPersonIndex = i;
                                    break;
                                }

                            }
                            if (salesPersonIndex != 0) //if the user input match the index in the List, add the userinput's amount into the Salesamount List 
                            {
                                Console.WriteLine("Saleperson found! Now Please enter the sales amount to add:");
                                decimal amount = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine($"The current sales amount for this person is  {salesAmt[salesPersonIndex]:C}");
                                salesAmt[salesPersonIndex] += amount;
                                Console.WriteLine($"Added the new amount to exisitng amount, the new amount is  {salesAmt[salesPersonIndex]:C}");

                            }
                            else //if the user type a name that's not in the list, show an error message 
                            {
                                Console.WriteLine("Invaild:SalesPerson not found");
                            }
                            break;
                        case "N": //if no, loop thourgh the MenuOption and let the user select again 

                            while (true)
                            {
                                ReadFile();
                                MenuOption(); //method 
                                int menuChoice = Convert.ToInt32(Console.ReadLine());
                                switch (menuChoice) //Display menuOption
                                {
                                    case 1:
                                        CurrentSale();
                                        break;

                                    case 2:
                                        AdditionalSale();
                                        break;

                                    case 3:
                                        TopThreeSalesPerson();
                                        break;

                                    case 4:
                                        SalesTotal();
                                        break;

                                }
                                Console.ReadKey();
                            }
                    }
                    break;
                }
            }
        }

        static private void TopThreeSalesPerson() //Find top three sales person and recall each methods used to calculate the sales and full name 
        {
            string highestSalePerson = FindTopSalesPerson();
            decimal highestNumber = salesAmt.Max();
            Console.WriteLine($" {highestSalePerson} with sales total of :{ highestNumber:C2}");

            string secondHighestSalePerson = FindSecondTopSalesPerson();
            decimal secondAmt = FindSecondNumber();
            Console.WriteLine($"{secondHighestSalePerson} with sales total of :{secondAmt:C2}");

            string thridHighestPerson = FindThridTopSalesPerson();
            decimal thridNumber = FindThirdNumber();
            Console.WriteLine($"{thridHighestPerson} with sales total of:{thridNumber:C2} ");

        }
        static private string FindTopSalesPerson() //Find Top Sales Person Using loop 
        {
            decimal max = salesAmt.Max();
            string outputString = "The highest ranked saleperson is ";
            for (int i = 0; i < salesAmt.Count; i++)
            {
                if (salesAmt[i] == max)  //Use Max statment to find top salesperson 
                {
                    outputString += " " + fullName[i];
                }
            }
            return outputString;
        }
        static private decimal FindSecondNumber() //Use if statment to find top second number 
        {
            decimal first = salesAmt.Max(); //set the first number equal to Max 
            decimal second = decimal.MinValue; //set a value for second number 

            for (int i = 0; i < salesAmt.Count; i++) //loop thourgh the array 
            {
                if (salesAmt[i] > second && salesAmt[i] < first)// if the arry is bigger than second number and less than first number 
                {
                    second = salesAmt[i]; //set the arry equal to second number
                }
            }
            return second;
        }

        static private decimal FindThirdNumber() //find third number using similar method used ro find second number 
        {
            decimal second = FindSecondNumber();
            decimal third = decimal.MinValue;

            for (int i=0; i < salesAmt.Count; i++) //loop through the array 
            {
                if (salesAmt[i] > third && salesAmt[i] < second)
                {
                    third = salesAmt[i];                    //set the arry equal to thrid number 
                }
            }
            return third;
        }

        static private string FindSecondTopSalesPerson() // A method to display second top sales person with string output
        {
            string outputString = "The second highest ranked saleperson is";
            int secondHighestSalePerson = salesAmt.IndexOf(FindSecondNumber()); //match the second highest index with its sale amount 
            string matchedNameForSecondHighest = fullName[secondHighestSalePerson]; //match the sale amount with the name 

            return outputString += " " + matchedNameForSecondHighest;
        }
        static private string FindThridTopSalesPerson() //a method to display top sales person with string output 
        {
            string outputString = "The third highest ranked saleperson is";
            int thirdHighestSalePerson = salesAmt.IndexOf(FindThirdNumber()); //match the highest index with its sale amt 
            string matchedNameForThirdHighest = fullName[thirdHighestSalePerson]; //match the sale amt with the sanme 

            return outputString += " " + matchedNameForThirdHighest;
        }
        

        static void SalesTotal() //calculate total 
        {
            decimal Totalamount;
            Totalamount = salesAmt.Sum();
            Console.WriteLine($"The total sale of all saleperson is {Totalamount:C}");
        }
        static void ReadFile() //read Rows by Rows from the input file 
        {
            String[] rows = File.ReadAllLines("Proj6Input.csv");
            for (int i = 0; i < rows.Length; i++) //loop thorugh the rows 
            {
                string[] cells = rows[i].Split(','); //not string,
                string currName = cells[0].Trim() + " " + cells[1].Trim();
                fullName.Add(currName);
                salesAmt.Add(Convert.ToDecimal(cells[2]));
            }
        }

       
    }
}
