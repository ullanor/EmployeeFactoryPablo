using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSBcSharpZaaw
{
    class Employess
    {
        private List<Employee> employees = new List<Employee>();

        public Employee this[int index] => employees[index];

        public Employee this[string name,string surname] => employees.First(x => x.ToString() == $"{name} {surname}");

        public void AddEmployee(Employee emp)
        {
            if(!EmployeeExists(emp))
                employees.Add(emp);
        }

        public void RemoveEmployee(Employee emp)
        {
            if(EmployeeExists(emp))
                employees.Remove(emp); 
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        bool EmployeeExists(Employee emp)
        {
            if (employees.Contains(emp))
                return true;
            return false;               
        }

        //print
        public void ShowEmployees()
        {
            short counter = 0;
            foreach(Employee emp in employees)
            {
                counter++;
                Console.WriteLine(counter + " " + emp.ToString()+" Salary: "+emp.Salary);
            }
            Console.WriteLine("Count: "+counter);
        }
    }

    class EmployessFactory
    {
        public static Employee CreateCustomEmployee(string name, string surname, short age, jobMode contract,int salary)
        {
            return new Employee(name, surname, age, contract, salary);
        }

        public static Employee CreateEmployeeOfTheMonth()
        {
            return new Employee("Michael", "Scott", 40, jobMode.FullTime, 10000);
        }
    }
}
