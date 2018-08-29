using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComboFinder
{
    class Program
    {
        public static void Main(string[] args)
        {
            double target = 0;
            int length = 0;
            string numbersString;
            string[] numbersSplit;
            List<double> numbers = new List<double>();

            Console.Write("Enter the target sum: ");
            target = Double.Parse(Console.ReadLine());

            Console.Write("Enter combination size: ");
            length = Int32.Parse(Console.ReadLine());

            Console.Write("Enter a comma separated list of numbers to search: ");
            numbersString = Console.ReadLine();
            numbersSplit = numbersString.Split(',');

            foreach (string x in numbersSplit)
            {
                numbers.Add(Double.Parse(x));
            }

            sum_up(numbers, target, length);
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        private static void sum_up(List<double> numbers, double target, int length)
        {
            sum_up_recursive(numbers, target, length, new List<double>());
        }

        private static void sum_up_recursive(List<double> numbers, double target, int length, List<double> partial)
        {
            double s = 0;
            foreach (double x in partial) s += x;

            if (s == target && partial.ToArray().Length == length)
                Console.WriteLine("sum(" + string.Join(",", partial.ToArray()) + ")=" + target);

            if (s >= target)
                return;

            for (int i = 0; i < numbers.Count; i++)
            {
                List<double> remaining = new List<double>();
                double n = numbers[i];
                for (int j = i + 1; j < numbers.Count; j++) remaining.Add(numbers[j]);

                List<double> partial_rec = new List<double>(partial);
                partial_rec.Add(n);
                sum_up_recursive(remaining, target, length, partial_rec);
            }
        }
    }
}
