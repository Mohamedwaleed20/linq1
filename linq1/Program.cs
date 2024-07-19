using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace Linq1
{

    internal class Program
    {
        //6.
        public class Employee
        {
            public string Name { get; set; }
            public int Salary { get; set; }

            public Employee(string name, int salary)
            {
                Name = name;
                Salary = salary;
            }

            public override string ToString()
            {
                return $"{Name} - {Salary}";
            }
        }
        //7.
        public class Book
        {
            public string Name { get; set; }
            public string Author { get; set; }
            public Book(string name, string author)
            {
                Name = name;
                Author = author;
            }
            public override string ToString()
            {
                return $"{Name} - {Author}";
            }
        }
        //8.
        public class Sale
        {
            public string Name { get; set; }
            public int Salary { get; set; }
            public Sale(string name, int salary)
            {
                Name = name;
                Salary = salary;
            }
            public override string ToString()
            {
                return $"{Name} - {Salary}";
            }
        }
        //9.
        public class StudentScores
        {
            public string Name { get; set; }
            public string Subject { get; set; }
            public int Score { get; set; }
            public StudentScores(string name, string subject, int score)
            {
                Name = name;
                Subject = subject;
                Score = score;
            }
            public override string ToString()
            {
                return $"{Name} - {Subject} - {Score}";
            }

        }
        //10.
        public class Order
        {
            public int Price1 { get; set; }
            public int Price2 { get; set; }
            public Order(int price1, int price2)
            {
                Price1 = price1;
                Price2 = price2;
            }
            public override string ToString()
            {
                return $"{Price1} - {Price2}";
            }
        }
        //11.
        public static List<Tuple<int, int>> GetFrequencyList(List<int> numbers)
        {
            return numbers.GroupBy(n => n)
                          .Select(g => new Tuple<int, int>(g.Key, g.Count()))
                          .ToList();
        }
        //16.
        public class Employe
        {
            public string Name { get; set; }
            public string Job { get; set; }

            public Employe(string name, string job)
            {
                Name = name;
                Job = job;
            }

            public override string ToString()
            {
                return $"{Name} - {Job}";
            }
        }
        //17.
        public class Product
        {
            public string Name { get; set; }
            public string Category { get; set; }
            public int Price { get; set; }

            public Product(string name, string category, int price)
            {
                Name = name;
                Category = category;
                Price = price;
            }
        }
        public static List<Product> GetMostExpensiveProducts(List<Product> products)
        {
            return products.GroupBy(p => p.Category)
                .Select(g => g.OrderByDescending(p => p.Price).First())
                .ToList();
        }
        //18.
        public class StudentGrades
        {
            public string StudentName { get; set; }
            public string Subject { get; set; }
            public int Grade { get; set; }

            public StudentGrades(string studentName, string subject, int grade)
            {
                StudentName = studentName;
                Subject = subject;
                Grade = grade;
            }
        }
        public static Dictionary<string, double> GetAverageGrades(List<StudentGrades> grades)
        {
            return grades.GroupBy(g => g.StudentName)
                .ToDictionary(g => g.Key, g => g.Average(sg => sg.Grade));
        }
        //19.
        public class Transaction
        {
            public DateTime Date { get; set; }
            public int Amount { get; set; }

            public Transaction(DateTime date, int amount)
            {
                Date = date;
                Amount = amount;
            }
        }
        //20.
        public class Orde
        {
            public DateTime Dates { get; set; }
            public int Amount { get; set; }

            public Orde(DateTime dates, int amount)
            {
                Dates = dates;
                Amount = amount;
            }
        }




        static void Main(string[] args)
        {
            //1.
            var numbers = new List<int> { 1, 2, 3, 4 };
            int k = 1;
            foreach (var number in numbers)
            {
                k = k * number;
            }
            Console.WriteLine(k);
            Console.WriteLine("---------------------");
            //2.
            var words = new List<string> { "apple", "banana", "cherry" };
            string word = string.Join(" , ", words);
            Console.WriteLine(word);
            Console.WriteLine("---------------------");
            //3.
            var nums = new List<int> { 1, 2, 3, 4 };
            var num = nums.Select(x => x * x).ToList();
            Console.WriteLine(string.Join(" , ", num));
            Console.WriteLine("---------------------");
            //4.
            List<string> words2 = new List<string> { "apple", "banana", "cherry" };
            Dictionary<string, int> stringLengths = words2.ToDictionary(x => x, x => x.Length);
            Console.WriteLine($"Output: {string.Join(", ", stringLengths.Select(x => $"{{\"{x.Key}\": {x.Value}}}"))}");
            Console.WriteLine("---------------------");
            //5.
            var list1 = new List<int> { 1, 2, 3, 4 };
            var list2 = new List<int> { 3, 4, 5, 6 };
            var list3 = list1.Intersect(list2).ToList();
            string list4 = string.Join(" , ", list3.Select(x => x.ToString()));
            Console.WriteLine(list4);
            Console.WriteLine("---------------------");
            //6.
            List<Employee> employees = new List<Employee>()
            {
            new Employee("Ali", 60000),
            new Employee("Ramy", 45000),
            new Employee("Samy", 80000)
            };
            var highestSalaryEmployee = employees.OrderByDescending(x => x.Salary).First();
            Console.WriteLine($"Employee with highest salary: {highestSalaryEmployee}");
            Console.WriteLine("---------------------");
            //7.
            List<Book> books = new List<Book>()
            {
            new Book("Book1", "Author1"),
            new Book("Book2", "Author2"),
            new Book("Book3", "Author1")
            };
            List<Book> groupedBooks = books.OrderBy(x => x.Name).ToList();
            Console.WriteLine("Books grouped by author:");
            foreach (Book book in groupedBooks)
            {
                Console.WriteLine($"{book.Name} by {book.Author}");
            }
            Console.WriteLine("---------------------");
            //8.
            List<Sale> sales = new List<Sale>()
            {
            new Sale("Ali", 100),
            new Sale("Ramy", 200),
            new Sale("Ali", 150)
            };
            int totalSalesAmount = sales.Sum(x => x.Salary);
            Console.WriteLine($"Total sales amount: {totalSalesAmount}");
            Console.WriteLine("---------------------");
            //9.
            List<StudentScores> scores = new List<StudentScores>()
            {
               new StudentScores("Ali", "Math", 90),
               new StudentScores("Ali", "Science", 85),
               new StudentScores("Ramy", "Math", 80)
            };
            var highestScores = scores
                .GroupBy(x => x.Name)
                .Select(g => new { StudentName = g.Key, HighestScore = g.OrderByDescending(x => x.Score).First().Score });
            Console.WriteLine("Highest scores for each student:");
            foreach (var item in highestScores)
            {
                Console.WriteLine($"{item.StudentName}: {item.HighestScore}");
            }
            Console.WriteLine("---------------------");
            //10.
            List<Order> orders = new List<Order>()
            {
            new Order(101, 50),
            new Order(102, 200),
            new Order(103, 150)
            };
            double averageOrderPrice = orders.Average(x => (x.Price1 + x.Price2) / 2.0);
            Console.WriteLine($"Average order price: {averageOrderPrice}");
            Console.WriteLine("---------------------");
            //11.
            List<int> no = new List<int>() { 1, 2, 2, 3, 3, 3 };
            List<Tuple<int, int>> frequencyList = GetFrequencyList(numbers);
            Console.WriteLine("Frequency list of integers:");
            foreach (var tuple in frequencyList)
            {
                Console.WriteLine($"({tuple.Item1}, {tuple.Item2})");
            }
            Console.WriteLine("---------------------");
            //12.
            var nemo = new List<string>() { "cat", "elephant", "dog", "tiger" };
            var sortedNemo = nemo.OrderBy(x => x.Contains('e') ? 0 : 1).ToList();
            static string GetFirstStringWithE(List<string> nemo)
            {
                return nemo.FirstOrDefault(w => w.Contains('e'));
            }
            Console.WriteLine(GetFirstStringWithE(nemo));
            Console.WriteLine("---------------------");
            //13.
            List<int> neno = new List<int> { 1, 2, 3, 4 };
            List<int> result = new List<int>();
            for (int i = 0; i < neno.Count; i++)
            {
                result.Add(neno[i] * i);
            }
            Console.WriteLine(string.Join(" , ", result));
            Console.WriteLine("---------------------");
            //14.
            List<string> wo = new List<string> { "apple", "banana" };
            List<char> res = new List<char>();
            foreach (string wor in wo)
            {
                foreach (char c in wor)
                {
                    if (!result.Contains(c))
                    {
                        result.Add(c);
                        Console.Write(string.Join(" , ", c));
                    }
                }
            }
            Console.WriteLine("---------------------");
            //15.
            var numero = new List<int> { 1, 2, 3, 4, 5, 6 };
            int evenCount = 0;
            int oddCount = 0;
            foreach (int numbe in numero)
            {
                if (numbe % 2 == 0)
                {
                    evenCount++;
                }
                else
                {
                    oddCount++;
                }
            }
            Console.WriteLine($"Even : {evenCount} , Odd : {oddCount}");
            Console.WriteLine("---------------------");
            //16.
            List<Employe> employes = new List<Employe> 
            { 
                new Employe ("Ali","HR"), 
                new Employe ("Ramy", "IT"),
                new Employe ("Samy", "HR"), 
                new Employe ("Sara", "IT"), 
                new Employe ("John", "IT") 
            };
            Dictionary<string, int> departmentCount = new Dictionary<string, int>();
            foreach (Employe employe in employes)
            {
                if (departmentCount.ContainsKey(employe.Job))
                {
                    departmentCount[employe.Job]++;
                }
                else
                {
                    departmentCount[employe.Job] = 1;
                }
            }
            string mostEmployeesDepartment = departmentCount.OrderByDescending(x => x.Value).First().Key;
            Console.WriteLine( mostEmployeesDepartment);
            Console.WriteLine("---------------------");
            //17.
            List<Product> products = new List<Product>()
            {
            new Product("Laptop", "Electronics", 1000),
            new Product("Phone", "Electronics", 800),
            new Product("Shirt", "Clothing", 50),
            new Product("Pants", "Clothing", 60)
            };
            List<Product> mostExpensiveProducts = GetMostExpensiveProducts(products);
            Console.WriteLine("Most Expensive Products:");
            foreach (Product product in mostExpensiveProducts)
            {
                Console.WriteLine($"{product.Name} ({product.Category}): {product.Price}");
            }
            Console.WriteLine("---------------------");
            //18.
            List<StudentGrades> grades = new List<StudentGrades>()
            {
            new StudentGrades("Ali", "Math", 90),
            new StudentGrades("Ali", "Science", 85),
            new StudentGrades("Ramy", "Math", 80),
            new StudentGrades("Ramy", "Science", 70)
            };

            Dictionary<string, double> averageGrades = GetAverageGrades(grades);
            Console.WriteLine("\nAverage Grades:");
            foreach (var kvp in averageGrades)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            Console.WriteLine("---------------------");
            //19.
            List<Transaction> transactions = new List<Transaction>() 
            {
            new Transaction(new DateTime(2024, 1, 10), 100),
            new Transaction(new DateTime(2024, 1, 20), 200),
            new Transaction(new DateTime(2024, 2, 5), 150)
            };
            var monthlyTransactionAmounts = transactions.GroupBy(t => t.Date.Month).Select(g => new { Month = g.Key, TotalAmount = g.Sum(t => t.Amount) }).ToList();
            Console.WriteLine("Monthly transaction amounts:");
            foreach (var item in monthlyTransactionAmounts)
            {
                Console.WriteLine($"Month {item.Month}: {item.TotalAmount}");
            }
            Console.WriteLine("---------------------");
            //20.
            List<Orde> ordes = new List<Orde>() 
            {
            new Orde(new DateTime(2024, 7, 10), 50),
            new Orde(new DateTime(2024, 7, 15), 200),
            new Orde(new DateTime(2024, 7, 16), 150)
            };
            var last7DaysOrderAmounts = ordes.Where(o => (o.Dates >= DateTime.Now.AddDays(-7))).Select(o => o.Amount).ToList();
            Console.WriteLine("Order amounts for the last 7 days:");
            foreach (var amount in last7DaysOrderAmounts)
            {
                Console.WriteLine($"{amount}");
            }
            Console.WriteLine("---------------------");
            Console.ReadLine();

        }




    }
}
