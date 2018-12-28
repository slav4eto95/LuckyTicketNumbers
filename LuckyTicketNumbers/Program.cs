namespace LuckyTicketNumbers
{
    using System;

    public class Program
    {
        public const long TICKET_MIN_NUMBER = 00000;
        public const long TICKET_MAX_NUMBER = 99999;

        public static void Main(string[] args)
        {
            long startNumber = long.Parse(Console.ReadLine());
            long endNumber = long.Parse(Console.ReadLine());

            Console.WriteLine();

            if (!IsBetween(startNumber))
            {
                Console.WriteLine($"{startNumber} is not in the range {TICKET_MIN_NUMBER} - {TICKET_MAX_NUMBER}!");
                return;
            }
            else if (!IsBetween(endNumber))
            {
                Console.WriteLine($"{endNumber} is not in the range {TICKET_MIN_NUMBER} - {TICKET_MAX_NUMBER}!");
                return;
            }
            else
            {
                for (long number = startNumber; number < endNumber; number++)
                {
                    if (IsLuckyNumber(number))
                    {
                        Console.WriteLine(string.Format("{0:D5}", number));
                    }
                }
            }
        }

        private static int SumOfDigits(int number)
        {
            int sum = 0;
            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }

            return sum;
        }

        private static bool IsLuckyNumber(long luckyTicketNumber)
        {
            string luckyNumberStr = string.Format("{0:D5}", luckyTicketNumber);

            int firstPart = int.Parse(luckyNumberStr.Substring(0, 2));
            int secondPart = int.Parse(luckyNumberStr.Substring(2, 1));
            int thirdPart = int.Parse(luckyNumberStr.Substring(3));

            if (SumOfDigits(firstPart) == secondPart && secondPart == SumOfDigits(thirdPart))
                return true;

            return false;
        }

        private static bool IsBetween(long number)
        {
            if (number < 00000 || number > 99999)
                return false;

            return true;
        }
    }
}
