using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSBcSharpZaaw
{
    class Person
    {
        protected string name;
        protected string surname;
        protected short age;
        public Person(string name, string surname, short age)
        {
            this.name = name; this.surname = surname; this.age = age;
        }

        public override string ToString()
        {
            //return base.ToString();
            return $"{name} {surname}";
        }
    }

    class Employee : Person
    {
        private List<Operation> myOperations = new List<Operation>();
        private jobMode contract;
        private int salary;
        public int Salary { get { return salary; } }
        public Employee(string name, string surname, short age, jobMode contract,int salary):base(name,surname,age)
        {
            this.contract = contract; this.salary = salary;
            _changeDetected += NOTIFY_detection;
            _changeDetected += NOTIFY_incautious;
        }

        public Operation this[int index] => myOperations[index];

        public void AddNewOperation()
        {
            short price;
            DateTime date;
            Console.WriteLine(this.name+" -> Adding new Operation");
            Console.Write("Enter price: ");
            short.TryParse(Console.ReadLine(), out price);
            Console.WriteLine();
            Console.Write("Enter date: ");
            DateTime.TryParse(Console.ReadLine(),out date);
            myOperations.Add(new Operation(price,date));
            Console.WriteLine();
        }

        public void ShowOperations()
        {
            Console.WriteLine(this.name + " -> Showing Operations");
            for (int i = 0; i < myOperations.Count; i++)
            {
                Console.WriteLine(i+1 + " " + myOperations[i].Price + " " + myOperations[i].Date.ToString("dd-MM-yyyy"));
            }
            Console.WriteLine("Count: " + myOperations.Count);
        }

        public void SumOfOperations()
        {
            Console.WriteLine(this.name + " -> Sum");
            int sum = 0;
            foreach (Operation op in myOperations)
                sum += op.Price;
            Console.WriteLine("Total: " + sum);
        }

        public void ShowSpecifiedOperations(DateTime start, DateTime end)
        {
            Console.WriteLine(this.name + " -> Showing Specified Operations");
            short counter = 0;
            foreach(Operation op in myOperations)
            {
                if (op.Date >= start && op.Date <= end)
                {
                    counter++;
                    Console.WriteLine(counter+" "+op.Price+" "+op.Date.ToString("dd-MM-yyyy"));
                }
            }
            Console.WriteLine("Count: " + counter);
        }

        //operators ovveride -------------------------------------------

        public static bool operator < (Employee emp1, Employee emp2)
        {
            if (emp1.salary < emp2.salary)
                return true;
            return false;
        }

        public static bool operator > (Employee emp1, Employee emp2)
        {
            if (emp1.salary > emp2.salary)
                return true;
            return false;
        }

        public static int operator +(Employee emp, int number)
        {
            emp.salary += number;
            return emp.salary + number;
        }

        //employee delegators ------------------------------------------
        public void ChangeName(string newName)
        {
            this.name = newName;
            _changeDetected('N');
        }
        
        public void ChangeSurname(string newSurname)
        {
            this.surname = newSurname;
            _changeDetected('S');
        }

        public delegate void DataChange(char sign);
        public DataChange _changeDetected;
        
        
        private void NOTIFY_detection(char type)
        {
            Console.WriteLine("WARNING! Employee data has changed! TYPE: "+type);
        }

        private void NOTIFY_incautious(char dummy)
        {
            Console.WriteLine("Be more careful when adding an employee to the base!");
        }
       
    }
}
