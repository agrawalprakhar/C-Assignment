using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main()
        {
            // Ask user for details
            Console.WriteLine("Enter Employee Details:");

            Console.Write("Enter ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Department Name: ");
            string departmentName = Console.ReadLine();

            // Create an object of the Employee class using the provided details
            Employee emp = new Employee(id, name, departmentName);

            // Subscribe to the event
            emp.MethodCalled += Emp_MethodCalled;

            // Print initial details
            Console.WriteLine("\nInitial Employee Details:");
            Console.WriteLine("ID: " + emp.GetId());
            Console.WriteLine("Name: " + emp.GetName());
            Console.WriteLine("Department Name: " + emp.GetDepartmentName());
            Console.ReadLine(); // Keep console window open

            // Update Employee details
            emp.UpdateName("Prakhar"); // Update Name
            emp.UpdateId(101);    // Update ID
            emp.UpdateDepartment("IT"); // Update Department Name

            // Print updated details
            Console.WriteLine("\nUpdated Employee Details:");
            Console.WriteLine("ID: " + emp.GetId());
            Console.WriteLine("Name: " + emp.GetName());
            Console.WriteLine("Department Name: " + emp.GetDepartmentName());

            Console.ReadLine(); // Keep console window open
        }

        // Event handler method
        private static void Emp_MethodCalled(object sender, EventArgs e)
        {
            Console.WriteLine("A method of Employee class has been called.");
        }
    }
    public class Employee
    {
        // Private properties
        private int Id;
        private string Name;
        private string DepartmentName;

        // Event declaration
        public event EventHandler MethodCalled;

        // Constructor accepting all three properties
        public Employee(int id, string name, string departmentName)
        {
            Id = id;
            Name = name;
            DepartmentName = departmentName;
        }

        // Method to return Id
        public int GetId()
        {
            OnMethodCalled();
            return Id;
        }

        // Method to return Name
        public string GetName()
        {
            OnMethodCalled();
            return Name;
        }

        // Method to return DepartmentName
        public string GetDepartmentName()
        {
            OnMethodCalled();
            return DepartmentName;
        }

        // Method to invoke the event
        protected virtual void OnMethodCalled()
        {
            MethodCalled?.Invoke(this, EventArgs.Empty);
        }

        // Overloaded method to update Id
        public void UpdateId(int newId)
        {
            Id = newId;
            Console.WriteLine("ID Updated to: " + newId);
        }

        // Overloaded method to update Name
        public void UpdateName(string newName)
        {
            Name = newName;
            Console.WriteLine("Name Updated to: " + newName);
        }

        // Overloaded method to update DepartmentName
        public void UpdateDepartment(string newDepartmentName)
        {
            DepartmentName = newDepartmentName;
            Console.WriteLine("Department Name Updated to: " + newDepartmentName);
        }
    }
}





