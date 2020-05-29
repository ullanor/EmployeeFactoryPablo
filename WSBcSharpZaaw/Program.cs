using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSBcSharpZaaw
{
    class Program
    {
        static Random random = new Random();
        static int number;
        static bool EXIT;
        static Employess GCstaff = new Employess();

        static void Main(string[] args)
        {
            CreateStartUp();
            Console.WriteLine("Welcome to the GRANd CompaNY");
            while (!EXIT)
            {
                ProgramLoop();
            }
            Console.WriteLine("Press any key to exit..");
            Console.ReadKey();
        }

        static void ProgramLoop()
        {
            ShowMenu();
            Console.Write("Command: ");
            int.TryParse(Console.ReadLine(), out number);
            Console.WriteLine("-------------------------- +++ ------------------------"+Environment.NewLine);

            switch (number)
            {
                case 0:
                    PreAddEmployee();
                    break;
                case 1:
                    PreRemoveEmployee();
                    break;
                case 2:
                    GCstaff.ShowEmployees();
                    break;
                case 3:
                    PreChangeName(true);
                    break;
                case 4:
                    PreChangeName(false);
                    break;
                case 5:
                    GetRandomEmployee().AddNewOperation();
                    break;
                case 6:
                    GetRandomEmployee().ShowOperations();
                    break;
                case 7:
                    GetRandomEmployee().SumOfOperations();
                    break;
                case 8:
                    GetRandomEmployee().ShowSpecifiedOperations(new DateTime(2000,6,6),DateTime.Now);
                    break;
                case 9:
                    Employee temp = GetRandomEmployee();
                    int randedval = random.Next(1000);
                    int dummy = temp + randedval;
                    Console.WriteLine(temp.ToString()+" Salary +" + randedval);
                    break;
                case 10:
                    EXIT = true;
                    break;
                default:
                    break;
                 
            }
        }

        static Employee GetRandomEmployee()
        {
            int tempNo = GCstaff.GetEmployees().Count;
            return GCstaff[random.Next(tempNo)];
        }

        static void PreChangeName(bool isName)
        {
            string txt;
            Console.WriteLine("Changing Person Data");
            Console.Write("New string: ");
            txt = Console.ReadLine();
            Console.WriteLine();

            Employee temp = GetRandomEmployee();
            if (isName)
                temp.ChangeName(txt);
            else temp.ChangeSurname(txt);
        }

        static void PreAddEmployee()
        {
            string name;
            string surname;
            jobMode _jobMode;
            Console.WriteLine("Creating new Employee");
            Console.Write("Enter name: ");
            name = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter surname: ");
            surname = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter job mode(0 - Full, 1 - Part, 3 - Contract): ");
            switch (Console.ReadLine())
            {
                case "0":
                    _jobMode = jobMode.FullTime;
                    break;
                case "1":
                    _jobMode = jobMode.PartTime;
                    break;
                default:
                    _jobMode = jobMode.Contract;
                    break;
            }
            if (name == string.Empty && surname == string.Empty)
                return;
            GCstaff.AddEmployee(EmployessFactory.CreateCustomEmployee(name,surname,88,_jobMode,2000));
        }

        static void PreRemoveEmployee()
        {
            string name;
            string surname;
            Console.WriteLine("Removing Employee");
            Console.Write("Enter name: ");
            name = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter surname: ");
            surname = Console.ReadLine();
            Console.WriteLine();
            try { GCstaff.RemoveEmployee(GCstaff[name, surname]); } catch (Exception) { Console.WriteLine("Employee doesn't exist!"); }
        }

        static void CreateStartUp()
        {
            GCstaff.AddEmployee(EmployessFactory.CreateEmployeeOfTheMonth());
        }

        static void ShowMenu()
        {
            Console.WriteLine(Environment.NewLine+Environment.NewLine+"What do we do, boss?");
            Console.WriteLine(Environment.NewLine+"--List Management--");
            Console.WriteLine("0 - Add Employee");
            Console.WriteLine("1 - Remove Employee");
            Console.WriteLine("2 - Show Employees");
            Console.WriteLine(Environment.NewLine + "--Person Management--");
            Console.WriteLine("3 - Change Name");
            Console.WriteLine("4 - Change Surname");
            Console.WriteLine(Environment.NewLine+"--Employee Management--");
            Console.WriteLine("5 - Add Operation");
            Console.WriteLine("6 - Show Operations");
            Console.WriteLine("7 - Sum Operations");
            Console.WriteLine("8 - Show Specified Operations");
            Console.WriteLine("9 - Change Salary");
            Console.WriteLine(Environment.NewLine+"10 - Exit"+Environment.NewLine);
        }
    }
}
