using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Employees
{
    class Payroll
    {
        static int numberOfEmployees = 3;
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
                Console.WriteLine("| Press 4 To Save/Exit               |");
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
                    SaveEmployees();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid input, please choose 1, 2, 3, or 4");
                }
                Console.WriteLine();
            } while (input != "4");
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

                Console.WriteLine("\nPlease Enter the Employee's Social Security Number");
                String SocialSecurityNumber = Console.ReadLine();

                Console.WriteLine("\nWhat type of employee is this, hourly(h), salary(s), or commission(c)? Please answer h/s/c");
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
                    //this is a commisson employee

                    Console.WriteLine("\nPlease Enter the number of Units Sold:");
                    decimal grossSales = Convert.ToDecimal(Console.ReadLine());

                    Console.WriteLine("\nPlease enter the price per Unit:");
                    decimal commissonRate = Convert.ToDecimal(Console.ReadLine());

                    myEmployees[index] = new CommissionEmployee(firstName, lastName, SocialSecurityNumber, grossSales, commissonRate);
                }
                else
                {
                    Console.WriteLine("\nInvalid employee type");
                    PopulateEmployee();
                }
            }
            else
            {
                Console.WriteLine("\nSorry, all available employee slots are full\n");
                Menu();
            }
        }

        void ChooseEmployee()
        {
            Console.WriteLine("Please enter the number of the employee you want to access");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1 || choice == 2 || choice == 3)
            {
                try
                {
                    myEmployees[choice - 1].Menu();
                    SaveEmployees();
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine("\nNo employee exists with that number.");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid Employee Number\n");
                ChooseEmployee();
            }
        }

        void SaveEmployees()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("Employees.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, myEmployees);
                stream.Close();
            }
            catch (SerializationException exc)
            {
                Console.WriteLine();
                Console.WriteLine("Error in SaveEmployees:");
                Console.WriteLine(exc.Message);
                Console.WriteLine(exc.StackTrace);
            }
        }

        void LoadEmployees()
        {
            if (!employeeTableLoaded)
            {
                try
                {
                    if (File.Exists("Employees.bin"))
                    {
                        IFormatter formatter = new BinaryFormatter();
                        Stream stream = new FileStream("Employees.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                        myEmployees = (Employee[])formatter.Deserialize(stream);
                        stream.Close();
                        employeeTableLoaded = true;
                    }
                    else
                    {
                        Console.WriteLine("There is no file to load from.");
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine("\nError in LoadAccounts:");
                    Console.WriteLine(exc.Message);
                    Console.WriteLine(exc.StackTrace);
                }
            }
            else
            {
                Console.WriteLine("Employees have already been loaded. Please save the file and quit to reload");
            }
        }
    }
}