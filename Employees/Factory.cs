using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Employees
{
    class Factory
    {
        static int numberOfEmployees = 3;
        private Employee[] myEmployees = new Employee[numberOfEmployees];
        static void Main(string[] args)
        {
            Factory f = new Factory();
            f.Menu();

        }

        void Menu()
        {
            string input;
            do
            {
                Console.WriteLine("|====================================|");
                Console.WriteLine("|         FIRST NATIONAL BANK        |");
                Console.WriteLine("|************Menu Options************|");
                Console.WriteLine("|____________________________________|");
                Console.WriteLine("|      Press 1 To Load Employees     |");
                Console.WriteLine("| Press 2 To Populate a new Employee |");
                Console.WriteLine("|    Press 3 To Access An Employee   |");
                Console.WriteLine("|        Press 4 To Save/Exit        |");
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
                Console.WriteLine("\nWhat type of employee is this, hourly, salary, or commission?");
                String type = Console.ReadLine();

                if (type.Equals("hourly", StringComparison.InvariantCultureIgnoreCase))
                {
                    myEmployees[index] = new HourlyEmployee("","","",0m,0m);
                }
                else if (type.Equals("salary", StringComparison.InvariantCultureIgnoreCase))
                {
                    myEmployees[index] = new SalariedEmployee("", "", "", 0m);
                }
                else if (type.Equals("commission", StringComparison.InvariantCultureIgnoreCase))
                {
                    myEmployees[index] = new CommissionEmployee("", "", "", 0m, 0m);
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
            if(choice == 1 || choice == 2 || choice == 3)
            {
                myEmployees[choice - 1].Menu();
                SaveEmployees();
            }
            else
            {
                Console.WriteLine("Invalid Employee Number\n");
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
            try
            {
                if (File.Exists("Employees.bin"))
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream("Employees.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                    myEmployees = (Employee[])formatter.Deserialize(stream);
                    stream.Close();
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine();
                Console.WriteLine("Error in LoadAccounts:");
                Console.WriteLine(exc.Message);
                Console.WriteLine(exc.StackTrace);
            }
        }
    }
}
