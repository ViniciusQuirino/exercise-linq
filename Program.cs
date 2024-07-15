using System;
using Entities;
using System.Globalization;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Enter salary: ");
            double limit = double.Parse(Console.ReadLine());

            List<Employee> list = new List<Employee>();

            try
            {

                using (StreamReader sr = File.OpenText("/home/vinicius/Área de Trabalho/exercise-linq/in.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] fields = sr.ReadLine().Split(',');
                        string name = fields[0];
                        string email = fields[1];
                        double salaryEmployee = double.Parse(fields[2], CultureInfo.InvariantCulture);
                        list.Add(new Employee(name, email, salaryEmployee));
                    }
                }

                var emails = list.Where(obj => obj.Salary > limit).OrderBy(obj => obj.Email).Select(obj => obj.Email);

                var sum = list.Where(obj => obj.Name[0] == 'A').Sum(obj => obj.Salary);

                Console.WriteLine("Email of people whose salary is more than " + limit.ToString("F2", CultureInfo.InvariantCulture));
                foreach (string email in emails)
                {
                    Console.WriteLine(email);
                }

                Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sum.ToString("F2", CultureInfo.InvariantCulture));
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}