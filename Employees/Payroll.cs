using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Employees
{
    class Payroll
    {
        static readonly int numberOfEmployees = 4;
        private Employee[] myEmployees = new Employee[numberOfEmployees];
        private bool employeeTableLoaded = false; //bool to test if we have loaded the employee table
        private bool validChoice = false; //bool used to set if a choice is valid or not and then to allow to loop

        static void Main(string[] args)
        {
            Payroll f = new Payroll();
            f.Menu();
        }

        void Menu()
        {
            string input;
            do
            {
                Console.WriteLine("|====================================|");
                Console.WriteLine("|       Employee Payroll System      |");
                Console.WriteLine("|************Menu Options************|");
                Console.WriteLine("|____________________________________|");
                Console.WriteLine("| Press 1 To Load Employees          |");
                Console.WriteLine("| Press 2 To Populate a new Employee |");
                Console.WriteLine("| Press 3 To View an Employee        |");
                Console.WriteLine("| Press 4 To List all Employees      |");
                Console.WriteLine("| Press 5 To Delete an Employee      |");
                Console.WriteLine("| Press 6 To Save/Exit               |");
                Console.WriteLine("|____________________________________|");
                Console.WriteLine("|    Please Make Selection Now...    |");
                Console.WriteLine("|====================================|");
                Console.WriteLine();

                input = Console.ReadLine();

                Console.WriteLine();

                if (input == "1")
                {
                    LoadEmployees();
                }
                else if (input == "2")
                {
                    PopulateEmployee();
                }
                else if (input == "3")
                {
                    ChooseEmployee();
                }
                else if (input == "4")
                {
                    ListEmployees();
                }
                else if (input == "5")
                {
                    DeleteEmployee();
                }
                else if (input == "6")
                {
                    SaveEmployees();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid input, please choose 1, 2, 3, 4, 5, 6");
                }
                Console.WriteLine();
            } while (input != "6");
        }

        void PopulateEmployee()
        {
            int index = -99;
            for (int i = 0; i < myEmployees.Length; i++)
            {
                if (myEmployees[i] == null)
                {
                    index = i;
                    break;
                }
            }
            if (index != -99)
            {
                Console.WriteLine("\nPopulating Employee:");
                Console.WriteLine("\nPlease Enter the Employee's First Name:");
                String firstName = Console.ReadLine();

                Console.WriteLine("\nPlease Enter the Employee's Last Name");
                String lastName = Console.ReadLine();

                Console.WriteLine("\nPlease Enter the Employee's Social Security Number (9 digits,numbers only, no dashes)");
                String SocialSecurityNumber = Console.ReadLine();

                Console.WriteLine("\nWhat type of employee is this, hourly(h), salary(s), commission(c) or base plus commission (b)? Please answer h/s/c/b");
                String type = Console.ReadLine();

                if (type.Equals("h", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("\nPlease Enter number of hours");
                    int hoursWorked = int.Parse(Console.ReadLine());

                    Console.WriteLine("\nPlease Enter rate, (ex for $20 an hour enter 20):");
                    decimal hourlyWage = Convert.ToDecimal(Console.ReadLine());

                    myEmployees[index] = new HourlyEmployee(firstName, lastName, SocialSecurityNumber, hourlyWage, hoursWorked);
                }
                else if (type.Equals("s", StringComparison.InvariantCultureIgnoreCase))
                {
                    //This is a salary employee
                    decimal grossPay = 0m;
                    do
                    {
                        Console.WriteLine("\nIs this employee Staff(s) or Executive(e)? Please answer s or e.");
                        String Salarytype = Console.ReadLine();

                        if (Salarytype.Equals("s", StringComparison.InvariantCultureIgnoreCase))
                        {
                            grossPay = 50000M;
                            validChoice = true;
                        }
                        else if (Salarytype.Equals("e", StringComparison.InvariantCultureIgnoreCase))
                        {
                            grossPay = 100000M;
                            validChoice = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Employee Salary Type\n");
                            validChoice = false;
                        }

                    } while (validChoice == false);

                    myEmployees[index] = new SalariedEmployee(firstName, lastName, SocialSecurityNumber, grossPay);

                }
                else if (type.Equals("c", StringComparison.InvariantCultureIgnoreCase))
                {
                    //this is a commission employee

                    Console.WriteLine("\nPlease Enter the number of Units Sold:");
                    decimal grossSales = Convert.ToDecimal(Console.ReadLine());

                    Console.WriteLine("\nPlease enter the price per Unit:");
                    decimal commissionRate = Convert.ToDecimal(Console.ReadLine());

                    myEmployees[index] = new CommissionEmployee(firstName, lastName, SocialSecurityNumber, grossSales, commissionRate);
                }
                else if (type.Equals("b", StringComparison.InvariantCultureIgnoreCase))
                {
                    //this is a base plus commission employee

                    Console.WriteLine("\nPlease Enter the number of Units Sold:");
                    decimal grossSales = Convert.ToDecimal(Console.ReadLine());

                    Console.WriteLine("\nPlease enter the price per Unit:");
                    decimal commissionRate = Convert.ToDecimal(Console.ReadLine());

                    Console.WriteLine("\nPlease enter this employee's base salary:");
                    decimal baseSalary = Convert.ToDecimal(Console.ReadLine());

                    myEmployees[index] = new BasePlusCommissionEmployee(firstName, lastName, SocialSecurityNumber, grossSales, commissionRate, baseSalary);
                }
                else
                {
                    Console.WriteLine("\nInvalid employee type");
                    PopulateEmployee();
                }
            }
            else
            {
                Console.WriteLine("\nSorry, all available employee slots are full.\n");
                Menu();
            }
        }

        void ChooseEmployee()
        {
            Console.WriteLine("Please enter the number of the employee you want to access");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1 || choice == 2 || choice == 3 || choice == 4)
            {
                try
                {
                    myEmployees[choice - 1].Menu();
                    SaveEmployees();
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine("\nNo employee exists with that number.");
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                Console.WriteLine("\nInvalid Employee Number\n");
                ChooseEmployee();
            }
        }

        void ListEmployees()
        {
            int count = 0;
            for(int i = 0; i < myEmployees.Length; i++)
            {
                if(myEmployees[i] != null)
                {
                    Console.WriteLine($"Employee #{i + 1}: {myEmployees[i].FirstName} {myEmployees[i].LastName}");
                    count++;
                }
            }

            if(count == 0)
            {
                Console.WriteLine("No employees currently exist.");
            }
        }

        void DeleteEmployee()
        {
            Console.WriteLine("Please enter the employee number of the employee you want to delete. Press -1 to return to previous menu.");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1 || choice == 2 || choice == 3 || choice == 4)
            {
                if(myEmployees[choice - 1] != null)
                {
                    Console.WriteLine("\n" + myEmployees[choice - 1].FirstName + " " + myEmployees[choice - 1].LastName + " deleted successfully.");
                    myEmployees[choice - 1] = null;
                }
                else
                {
                    Console.WriteLine("\nNo employee exists with that employee number\n");
                    DeleteEmployee();
                }
                
            }
            else if(choice == -1)
            {
                //Let method end without deleting
            }
            else
            {
                Console.WriteLine("\nInvalid Employee Number\n");
                DeleteEmployee();
            }

        }

        void SaveEmployees()
        {
            Stream stream = null;
            StreamWriter file = null;
            try
            {
                //Serialization Code
                IFormatter formatter = new BinaryFormatter();
                stream = new FileStream("SerializedEmployees.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, myEmployees);

                //File Code  //Saved at Employees/Employees/bin/Debug/Employees.txt
                file = new StreamWriter("Employees.txt");
                for(int i = 0; i < myEmployees.Length; i++)
                {
                    if(myEmployees[i] != null)
                    {
                        file.Write($"Employee #{i + 1}\r\n" +
                            $"First Name: {myEmployees[i].FirstName}\r\n" +
                            $"Last Name: {myEmployees[i].LastName}\r\n" +
                            $"Social Security Number: {myEmployees[i].SocialSecurityNumber.Insert(5, "-").Insert(3, "-")}\r\n");

                        if(myEmployees[i].GetType().ToString() == "Employees.HourlyEmployee")
                        {
                            file.Write($"Hours: {myEmployees[i].hours}\r\n" +
                                $"Rate: {myEmployees[i].rate}\r\n");
                        }

                        file.Write($"Tax Rate: {myEmployees[i].taxrate}%\r\n" + 
                            $"Gross: {myEmployees[i].gross:C}\r\n" +
                            $"Tax: {myEmployees[i].tax:C}\r\n" +
                            $"Net: {myEmployees[i].net:C}\r\n" +
                            $"Net Percentage: {myEmployees[i].net_percent}%\r\n\r\n");
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine();
                Console.WriteLine("Error in SaveEmployees:");
                Console.WriteLine(exc.Message);
                Console.WriteLine(exc.StackTrace);
            }
            finally
            {
                if(stream != null)
                {
                    stream.Close();
                }

                if(file != null)
                {
                    file.Close();
                }
            }
        }

        void LoadEmployees()
        {
            if (!employeeTableLoaded)
            {
                Stream stream = null;
                try
                {
                    if (File.Exists("SerializedEmployees.bin"))
                    {
                        IFormatter formatter = new BinaryFormatter();
                        stream = new FileStream("SerializedEmployees.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                        myEmployees = (Employee[])formatter.Deserialize(stream);
                        stream.Close();
                        employeeTableLoaded = true;
                        Console.WriteLine("Employees loaded successfully.");
                    }
                    else
                    {
                        Console.WriteLine("There is no file to load from.");
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine("\nError in LoadEmployees:");
                    Console.WriteLine(exc.Message);
                    Console.WriteLine(exc.StackTrace);
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                }
            }
            else
            {
                Console.WriteLine("Employees have already been loaded. Please save the file and quit to reload");
            }
        }
    }
}