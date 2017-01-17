using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataHelper;

namespace Lab_02
{
    class Program
    {
        private static IEnumerable<Employee> Employees = DataSource.Employees;
        private static IEnumerable<Product> Products = DataSource.Products;
        private static IEnumerable<ProductVendor> ProductVendors = DataSource.ProductVendors;
        private static IEnumerable<Vendor> Vendors = DataSource.Vendors;

        static void Main(string[] args)
        {
            Console.WriteLine("Lab 02 - LINQ");
            Console.WriteLine("=============\n");
            
            Exercise01();
            Exercise02();
            Exercise03();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }

        static void Exercise01()
        {
            Console.WriteLine("Exercise 01 - Start");
            List<string> answers = new List<string>();
            answers = DoExerciseOne();
            foreach (var answer in answers)
            {
                Console.WriteLine(answer);
            }

            Console.WriteLine("And now the same but with comprehensive methods");
            answers = (DoExerciseTwo());

            foreach (var answer in answers)
            {
                Console.WriteLine(answer);
            }
            Console.WriteLine("Exercise 01 - End\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }

        static void Exercise02()
        {
            Console.WriteLine("Exercise 02 - Start");
            List<string> answers = new List<string>();
            Console.WriteLine("And now the same but with comprehensive methods");
            answers = DoExerciseTwo();

            foreach (var answer in answers)
            {
                Console.WriteLine(answer);
            }
            Console.WriteLine("Exercise 02 - End\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }

        static void Exercise03()
        {
            Console.WriteLine("Exercise 03 - Start");
            List<string> answers = new List<string>();
            answers = DoExerciseThree();

            foreach (var answer in answers)
            {
                Console.WriteLine(answer);
            }
            Console.WriteLine("Exercise 03 - End\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }       

        private static List<string> DoExerciseTwo()
        {
            List<string> answers = new List<string>();
            var resultQuestionSickEmployeeQuery = from employee in Employees
                                                  where employee.SickLeaveHours < 21
                                                  select employee;

            answers.Add(resultQuestionSickEmployeeQuery.Count() > 0 ? "Answer to question one: yes" : "Answer to question one: No");
            answers.Add(resultQuestionSickEmployeeQuery.Count().ToString());
            foreach (var employee in resultQuestionSickEmployeeQuery)
            {
                answers.Add(string.Format("\nName: {0}, Gender: {1}, Sick leave hours: {2}", employee.Name, employee.Gender, employee.SickLeaveHours.ToString()));
            }

            resultQuestionSickEmployeeQuery = from employee in resultQuestionSickEmployeeQuery
                                              orderby employee.Gender, employee.Name
                                              select employee;                                              

            foreach (var employee in resultQuestionSickEmployeeQuery)
            {
                answers.Add(string.Format("\nName: {0}, Gender: {1}, Sick leave hours: {2}", employee.Name, employee.Gender, employee.SickLeaveHours.ToString()));
            }
            return answers;
        }

        private static List<string> DoExerciseOne()
        {
            var answers = new List<string>();
            var resultQuestionSickEmployeeQuery = Employees.Where(employee => employee.SickLeaveHours < 21);

            answers.Add(resultQuestionSickEmployeeQuery.Count() > 0 ? "Answer to question one: yes" : "Answer to question one: No");
            answers.Add(resultQuestionSickEmployeeQuery.Count().ToString());
            foreach (var employee in resultQuestionSickEmployeeQuery)
            {
                answers.Add(string.Format("\nName: {0}, Gender: {1}, Sick leave hours: {2}", employee.Name, employee.Gender, employee.SickLeaveHours.ToString()));
            }

            resultQuestionSickEmployeeQuery = resultQuestionSickEmployeeQuery.OrderBy(employee => employee.Gender)
                .ThenBy(employee => employee.Name);

            foreach (var employee in resultQuestionSickEmployeeQuery)
            {
                answers.Add(string.Format("\nName: {0}, Gender: {1}, Sick leave hours: {2}", employee.Name, employee.Gender, employee.SickLeaveHours.ToString()));
            }
            return answers;
        }
        private static List<string> DoExerciseThree()
        {
            List<string> answers = new List<string>();
            var resultQuery = from product in Products
                         join productVendor in ProductVendors on product.ID equals productVendor.ProductID
                         join vendor in Vendors on productVendor.VendorID equals vendor.ID
                         select new
                         {
                             vendorname = vendor.Name,
                             productVendor.Price,
                             product.Name ,
                         };
            foreach(var result in resultQuery)
            {
                answers.Add(string.Format("\nName: {0}, vendor name: {1}, Price: {2}", result.Name, result.vendorname, result.Price));
            }

            var resultQuery2 = resultQuery.GroupBy(result => result.Name);
            foreach(var result in resultQuery2)
            {
                var temp = result.OrderBy(product => product.Price);
                decimal cheapest = temp.First().Price;
                foreach (var offer in temp)
                {
                    if (offer.Price == cheapest)
                    {
                        answers.Add(string.Format("\nProduct: {0}\nOffering: {1} by {2}", offer.Name, offer.Price, offer.vendorname));
                    }
                }
            }
            return answers;
        }
    }
}
