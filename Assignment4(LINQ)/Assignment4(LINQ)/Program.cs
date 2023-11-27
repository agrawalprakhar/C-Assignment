using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_LINQ_
{
    public class Program
    {
        IEnumerable<Employee> employeeList;
        IEnumerable<Salary> salaryList;

        public Program()
        {
            employeeList = new List<Employee>() {
            new Employee(){ EmployeeID = 1, EmployeeFirstName = "Rajiv", EmployeeLastName = "Desai", Age = 49},
            new Employee(){ EmployeeID = 2, EmployeeFirstName = "Karan", EmployeeLastName = "Patel", Age = 32},
            new Employee(){ EmployeeID = 3, EmployeeFirstName = "Sujit", EmployeeLastName = "Dixit", Age = 28},
            new Employee(){ EmployeeID = 4, EmployeeFirstName = "Mahendra", EmployeeLastName = "Suri", Age = 26},
            new Employee(){ EmployeeID = 5, EmployeeFirstName = "Divya", EmployeeLastName = "Das", Age = 20},
            new Employee(){ EmployeeID = 6, EmployeeFirstName = "Ridhi", EmployeeLastName = "Shah", Age = 60},
            new Employee(){ EmployeeID = 7, EmployeeFirstName = "Dimple", EmployeeLastName = "Bhatt", Age = 53}
        };

            salaryList = new  List<Salary>() {
            new Salary(){ EmployeeID = 1, Amount = 1000, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 1, Amount = 500, Type = SalaryType.Performance},
            new Salary(){ EmployeeID = 1, Amount = 100, Type = SalaryType.Bonus},
            new Salary(){ EmployeeID = 2, Amount = 3000, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 2, Amount = 1000, Type = SalaryType.Bonus},
            new Salary(){ EmployeeID = 3, Amount = 1500, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 4, Amount = 2100, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 5, Amount = 2800, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 5, Amount = 600, Type = SalaryType.Performance},
            new Salary(){ EmployeeID = 5, Amount = 500, Type = SalaryType.Bonus},
            new Salary(){ EmployeeID = 6, Amount = 3000, Type = SalaryType.Monthly},
            new Salary(){ EmployeeID = 6, Amount = 400, Type = SalaryType.Performance},
            new Salary(){ EmployeeID = 7, Amount = 4700, Type = SalaryType.Monthly}
        };
        }

        public static void Main()
        {
            Program program = new Program();

            program.Task1();

            program.Task2();

            program.Task3();
        }

        public void Task1()
        {
            var totalSalaryByName = employeeList
                .Join(salaryList, emp => emp.EmployeeID, sal => sal.EmployeeID, (emp, sal) => new { emp, sal })
                .GroupBy(x => $"{x.emp.EmployeeFirstName} {x.emp.EmployeeLastName}")
                .Select(g => new
                {
                    Name = g.Key,
                    TotalSalary = g.Sum(x => x.sal.Amount)
                })
                .OrderBy(x => x.TotalSalary);

            Console.WriteLine("Total Salary of all employees in ascending order:");
            foreach (var item in totalSalaryByName)
            {
                Console.WriteLine($"Name: {item.Name}, Total Salary: {item.TotalSalary}");
            }
             Console.ReadLine(); // Keep console window open;
        }


        public void Task2()
        {
            var secondOldestEmployee = employeeList
                .OrderByDescending(emp => emp.Age)
                .Skip(1)
                .FirstOrDefault();

            if (secondOldestEmployee != null)
            {
                var monthlySalary = salaryList
                    .Where(sal => sal.EmployeeID == secondOldestEmployee.EmployeeID && sal.Type == SalaryType.Monthly)
                    .Sum(sal => sal.Amount);

                Console.WriteLine($"Details of 2nd oldest employee: {secondOldestEmployee.EmployeeFirstName} {secondOldestEmployee.EmployeeLastName}");
                Console.WriteLine($"Age: {secondOldestEmployee.Age}");
                Console.WriteLine($"Total Monthly Salary: {monthlySalary}");
            }
            else
            {
                Console.WriteLine("No second oldest employee found.");
            }
            Console.ReadLine(); // Keep console window open;
        }

        public void Task3()
        {
            var meansOfSalaries = employeeList
                .Where(emp => emp.Age > 30)
                .Join(salaryList, emp => emp.EmployeeID, sal => sal.EmployeeID, (emp, sal) => sal)
                .GroupBy(sal => sal.Type)
                .Select(g => new
                {
                    SalaryType = g.Key,
                    MeanSalary = g.Average(sal => sal.Amount)
                });

            Console.WriteLine("Means of Monthly, Performance, and Bonus salaries for employees above 30:");
            foreach (var item in meansOfSalaries)
            {
                Console.WriteLine($"Salary Type: {item.SalaryType}, Mean Salary: {item.MeanSalary}");
            }
        Console.ReadLine(); // Keep console window open;
        }
    }

    public enum SalaryType
    {
        Monthly,
        Performance,
        Bonus
    }

    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public int Age { get; set; }
    }

    public class Salary
    {
        public int EmployeeID { get; set; }
        public int Amount { get; set; }
        public SalaryType Type { get; set; }
    }
}
