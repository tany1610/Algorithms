using System;
using System.Collections.Generic;
using System.Linq;

class Salaries
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        HashSet<Employee> employees = new HashSet<Employee>();

        //creating all the employees
        for (int i = 0; i < count; i++)
        {
            employees.Add(new Employee(i));
        }

        //making connections
        for(int i = 0; i < count; i++)
        {
            char[] input = Console.ReadLine().ToCharArray();

            for (int j = 0; j < input.Length; j++)
            {
                if (input[j] == 'Y')
                {
                    Employee other = employees.First(em => em.Id == j);
                    employees.First(em => em.Id == i).Employees.Add(other);
                }
            }
        }

        //printing result
        int result = 0;

        foreach (Employee employee in employees)
        {
            result += employee.Salary;
        }

        Console.WriteLine(result);
    }
}

class Employee
{
    public int Id;

    public HashSet<Employee> Employees;

    public int Salary { get
        {
            if (Employees.Count == 0)
            {
                return 1;
            }
            else
            {
                int salary = 0;

                foreach (Employee em in Employees)
                {
                    salary += em.Salary;
                }

                if (salary == 0)
                {
                    return 1;
                }

                else
                {
                    return salary;
                }
            }
        } }

    public Employee(int id)
    {
        Id = id;
        Employees = new HashSet<Employee>();
    }
}