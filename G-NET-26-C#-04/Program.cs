using System.Text;
using System.Diagnostics;
namespace G_NET_26_CSharp_04
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Q1
            //Question 01 : A junior developer wrote this code to build 
            //a comma - separated list of 5,000 product IDs:
            //(a) Explain why this code is inefficient. Reference what happens in memory.
            //answer:
            //This code is inefficient because strings in C# are immutable,
            //meaning that every time you concatenate a new product ID to the string,
            //a new string object is created in memory.
            //This leads to a large number of temporary string objects being created and discarded,
            //which can cause significant memory overhead and slow down performance,
            //especially when dealing with a large number of product IDs like 5,000.
            //In this case where we are concatenating 5000 product IDs,
            //and editing the string 5000 times, StringBuilder is needed as it is more efficient for such operations.
            //========================================================================================================
            //(b) Rewrite the code to be more efficient.
            //StringBuilder ProductList = new StringBuilder("");
            //for(int i=1; i <= 5000; i++)
            //{
            //    ProductList.Append($"Prod-{i},");
            //}
            //ProductList.ToString();
            //========================================================================================================
            //(c) Add timing code (using Stopwatch) to both versions and report the time difference.
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Starting Timer for 5000 iterations.");
            GC.Collect();
            sw.Start();
            string prodList = "";
            for (int i = 0; i <= 5000; i++)
            {
                prodList += $"Prod-{i},";
            }
            sw.Stop();
            int Time1 = (int)sw.ElapsedMilliseconds;
            sw.Reset();
            GC.Collect();
            Console.WriteLine("Starting Timer for 5000 iterations (Using StringBuilder).");
            sw.Start();
            StringBuilder ProductList = new StringBuilder(50000);
            for (int i = 0; i <= 5000; i++)
            {
                ProductList.Append($"Prod-{i},");
            }
            string prodList2 = ProductList.ToString();
            sw.Stop();
            int Time2 = (int)sw.ElapsedMilliseconds;
            Console.WriteLine($"Time taken for string concatenation: {Time1} ms ");
            Console.WriteLine($"Time taken for StringBuilder concatenation: {Time2} ms ");


            #endregion
            #region Q2
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine();
            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter day of week (1-7, where 6=Fri, 7=Sat): ");
            int dayOfWeek = int.Parse(Console.ReadLine());
            Console.Write("Do you have a valid student ID? (yes/no): ");
            string studentInput = Console.ReadLine().Trim().ToLower();
            bool isStudent = (studentInput == "yes");

            double basePrice = 0;
            string ageBracket = "";

            // Task (a):
            if (age < 5)
            {
                basePrice = 0;
                ageBracket = "Age < 5";
            }
            else if (age >= 5 && age <= 12)
            {
                basePrice = 30;
                ageBracket = "Age 5 - 12";
            }
            else if (age >= 13 && age <= 59)
            {
                basePrice = 50;
                ageBracket = "Age 13 - 59";
            }
            else if (age >= 60)
            {
                basePrice = 25;
                ageBracket = "Age 60+";
            }
            //Task (b):
            double finalPrice = basePrice;
            double weekendSurcharge = 0;
            double studentDiscountAmount = 0;

            if (basePrice > 0 && (dayOfWeek == 6 || dayOfWeek == 7))
            {
                weekendSurcharge = 10;
                finalPrice += weekendSurcharge;
            }

            if (basePrice > 0 && isStudent)
            {
                studentDiscountAmount = finalPrice * 0.20;
                finalPrice -= studentDiscountAmount;
            }

            // Task (c): 
            Console.WriteLine("\n/// Ticket Price Breakdown ///");
            Console.WriteLine($"Base Price ({ageBracket}): {basePrice} LE");

            if (weekendSurcharge > 0)
            {
                Console.WriteLine($"Weekend Surcharge: +{weekendSurcharge} LE");
            }

            if (studentDiscountAmount > 0)
            {
                Console.WriteLine($"Student Discount (20%): -{studentDiscountAmount} LE");
            }

            Console.WriteLine("------------------------------");
            Console.WriteLine($"Final Ticket Price: {finalPrice} LE");
            #endregion
            #region Q3
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine();
            //Task (a):
            string fileExtension = ".pdf";
            string fileType;
            Console.WriteLine("Task (a) Q3:");
            //switch (fileExtension)
            //{
            //    case ".pdf":
            //        fileType = "PDF Document";
            //        break;
            //    case ".docx":
            //    case ".doc":
            //        fileType = "Word Document";
            //        break;
            //    case ".xlsx":
            //    case ".xls":
            //        fileType = "Excel Spreadsheet";
            //        break;
            //    case ".jpg":
            //    case ".png":
            //    case ".gif":
            //        fileType = "Image File";
            //        break;
            //    default:
            //        fileType = "Unknown File Type";
            //        break;
            //}
            Console.WriteLine("==============================================");
            Console.WriteLine("Task (b) Q3: ");
            //Task (b):
            //string fileExtension = ".pdf";

            //string fileType = fileExtension switch
            //{
            //    ".pdf" => "PDF Document",
            //    ".docx" or ".doc" => "Word Document",
            //    ".xlsx" or ".xls" => "Excel Spreadsheet",
            //    ".jpg" or ".png" or ".gif" => "Image File",
            //    _ => "Unknown File Type"
            //};
            #endregion
            #region Q4
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine();
            int temperature = 35;

            string weatherAdvice = (temperature < 0) ? "Freezing! Stay indoors." :
                                   (temperature < 15) ? "Cold. Wear a jacket." :
                                   (temperature < 25) ? "Pleasant weather." :
                                   (temperature < 35) ? "Warm. Stay hydrated." :
                                   "Hot! Avoid sun exposure.";
            //Ternary operator can degrade code readability, especially when there are multiple conditions and nested ternary operators,
            //So, in this case, if-else statements is suggested for better readability and maintainability.
            #endregion
            #region Q5
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine();
            /*
            int attempts = 0;
            int maxAttempts = 5;
            bool isValid = false;

            do
            {
                Console.Write("Enter password: ");
                string password = Console.ReadLine() ?? "";
                attempts++;

                bool hasMinLength = password.Length >= 8;
                bool hasUpper = false;
                bool hasDigit = false;
                bool hasNoSpace = true;

                foreach (char c in password)
                {
                    if (char.IsUpper(c)) hasUpper = true;
                    if (char.IsDigit(c)) hasDigit = true;
                    if (c == ' ') hasNoSpace = false;
                }

                isValid = hasMinLength && hasUpper && hasDigit && hasNoSpace;

                if (isValid)
                {
                    Console.WriteLine("Password accepted!");
                }
                else
                {
                    Console.WriteLine("Invalid password. Violations:");
                    if (!hasMinLength) Console.WriteLine("- Minimum 8 characters required.");
                    if (!hasUpper) Console.WriteLine("- At least one uppercase letter required.");
                    if (!hasDigit) Console.WriteLine("- At least one digit required.");
                    if (!hasNoSpace) Console.WriteLine("- No spaces allowed.");

                    Console.WriteLine($"Attempts remaining: {maxAttempts - attempts}\n");
                }

            } while (!isValid && attempts < maxAttempts);

            if (!isValid)
            {
                Console.WriteLine("Account locked");
            }
            */
            #endregion
            #region Q6
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine();
            int[] scores = { 85, 45, 92, 38, 75, 60, 95, 50, 88, 72 };

            // (a):
            Console.WriteLine("Failing scores (below 50):");
            foreach (int score in scores)
            {
                if (score < 50)
                {
                    Console.WriteLine(score);
                }
            }

            // (b) :
            Console.WriteLine("\nFirst score above 90:");
            for (int i = 0; i < scores.Length; i++)
            {
                if (scores[i] > 90)
                {
                    Console.WriteLine(scores[i]);
                    break;
                }
            }

            // (c) :
            int sum = 0;
            int validCount = 0;

            foreach (int score in scores)
            {
                if (score >= 40)
                {
                    sum += score;
                    validCount++;
                }
            }

            double average = validCount > 0 ? (double)sum / validCount : 0;
            Console.WriteLine($"\nClass average (excluding scores < 40): {average:F2}");

            // (d) :
            int countA = 0, countB = 0, countC = 0, countD = 0, countF = 0;

            foreach (int score in scores)
            {
                if (score >= 90 && score <= 100) countA++;
                else if (score >= 80 && score <= 89) countB++;
                else if (score >= 70 && score <= 79) countC++;
                else if (score >= 60 && score <= 69) countD++;
                else if (score < 60) countF++;
            }

            Console.WriteLine("\nGrade Distribution:");
            Console.WriteLine($"A (90-100): {countA}");
            Console.WriteLine($"B (80-89): {countB}");
            Console.WriteLine($"C (70-79): {countC}");
            Console.WriteLine($"D (60-69): {countD}");
            Console.WriteLine($"F (Below 60): {countF}");
            #endregion

        }
    }
}
