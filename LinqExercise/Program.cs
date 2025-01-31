﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            var sum = numbers.Sum();
            Console.WriteLine($"Sum: {sum}");

            //TODO: Print the Average of numbers
            var avg = numbers.Average();
            Console.WriteLine($"Average: {avg}");

            //TODO: Order numbers in ascending order and print to the console
            var asc = numbers.OrderBy(num => num);
            Console.WriteLine("___");
            Console.WriteLine("Asc");

            foreach (var num in asc)
            {
                Console.WriteLine(num);
            }
            //TODO: Order numbers in decsending order and print to the console
            var desc = numbers.OrderByDescending(x => x);
            Console.WriteLine("----");
            Console.WriteLine("Desc");
            foreach (var num in desc)
            {
                Console.WriteLine(num);
            }
            //TODO: Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(num => num > 6);

            foreach (var num in greaterThanSix)
            {
                Console.WriteLine("Extract");
                Console.WriteLine(num);
            }
            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("First Four");
            foreach (var num in asc.Take(4))
            {
                Console.WriteLine(num);
            }
            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            //numbers[4] = 46;
            //Console.WriteLine("Include my age in place of four.");
            //foreach (var num in numbers.OrderByDescending(num => num))
            //{
            //    Console.WriteLine(num);

            //}
            Console.WriteLine("Change Age");

            numbers.SetValue(46, 4);

            numbers.ToList().ForEach(Console.WriteLine);
            Console.WriteLine();

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var filtered =
                employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S'))
                .OrderBy(person => person.FirstName);
            Console.WriteLine("The Full name of employees who's, first name starts with C or S:");
            foreach (var employee in filtered)
            {
                Console.WriteLine(employee.FullName);
                Console.WriteLine();
            }
           
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Employees over 26:");
            var overTwentySix = employees.Where(emp => emp.Age > 26)
                .OrderBy(emp => emp.Age)
                .ThenBy(emp => emp.FirstName)
                .ThenBy(emp => emp.YearsOfExperience);
            foreach (var emp in overTwentySix)
            {
                Console.WriteLine($"{emp.FullName}, Age: {emp.Age} has {emp.YearsOfExperience} years of experience");
                Console.WriteLine(); 
            }
            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var years = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35) .OrderBy(x => x.Age);
            Console.WriteLine("The Sum & Average:");
            Console.WriteLine($"Sum {years.Sum(x => x.YearsOfExperience)} Avg {years.Average(x => x.YearsOfExperience)}");
            Console.WriteLine();
            //TODO: Add an employee to the end of the list without using employees.Add()
            Console.WriteLine("Add on to list:");
            employees = employees.Append(new Employee("First", "Last", 98, 1)).ToList();

            foreach (var emp in employees) 
            { 
                Console.WriteLine($"{emp.FirstName} {emp.Age}");
            }

            Console.WriteLine();

            Console.ReadLine();

        }
        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }

}

