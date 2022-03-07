using System;
using System.Collections.Generic;
using System.Linq;

namespace lab8_list
{
    class Program
    {
        private static Random rnd = new Random();
        static void Main()
        {
            var list = new List<Person>();
            for (int i = 1; i <= 10; i++)
            {
                var fName = "Ivan" + i;
                var lName = "Ivanov" + i;
                var tName = "Ivanovich" + i;
                var post = "Santechnik" + i;
                var salary = rnd.Next(2500, 7000);
                var bithday = new DateTime(1995, 1, 1)
                    .AddYears(rnd.Next(-10, 10))
                    .AddMonths(rnd.Next(-10, 10))
                    .AddDays(rnd.Next(-30, 30));
                list.Add(new Person(tName, lName, fName, post, salary, bithday));
            }

            var avgSalary = list.Sum(a => a.Salary) / list.Count;
            Console.WriteLine("Зарплата выше средней и возраст менее 30-ти лет");
            var newList = list.Where(item => item.Salary > avgSalary && calcAge(item.Birthday) < 30).ToList();
            foreach (var item in newList)
            {
                Console.WriteLine(item);
            }
            if (newList.Count == 0)
            {
                Console.WriteLine("Список пуст");
            }


            var listLowSalary = list.Where(p => p.Salary < avgSalary).ToList();
            Console.WriteLine("Cписок тех, у кого зарплата ниже средней");
            foreach (var item in listLowSalary)
            {
                Console.WriteLine(item);
            }
            if (listLowSalary.Count == 0)
            {
                Console.WriteLine("Список пуст");
            }

            var listAvgSalary = list.Where(p => p.Salary >= avgSalary).ToList();
            Console.WriteLine("Cписок тех, у кого зарплата равна и выше средней");
            foreach (var item in listAvgSalary)
            {
                Console.WriteLine(item);
            }
            if (listAvgSalary.Count == 0)
            {
                Console.WriteLine("Список пуст");
            }
        }

        private static int calcAge(DateTime dateTime)
        {
            var now = DateTime.Now;
            var age = now.Year - dateTime.Year;
            if (now.Month < dateTime.Month || (now.Month == dateTime.Month && now.Day < dateTime.Day))
            {
                age--;
            }
            return age;
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ThirdName { get; set; }
        public string Post { get; set; }
        public int Salary { get; set; }
        public DateTime Birthday { get; set; }

        public Person(string firstName, string lastName, string thirdName, string post, int salary, DateTime birthday)
        {
            FirstName = firstName;
            LastName = lastName;
            ThirdName = thirdName;
            Post = post;
            Salary = salary;
            Birthday = birthday;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {ThirdName}, {Post}, {Salary}$, {Birthday:d}";
        }
    }

}
