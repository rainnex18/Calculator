using System;
using System.Linq;

namespace TechAX
{
    /// <summary>
    /// 
    /// PEMDAS Rules
    /// 
    /// </summary>
    public class Calculator
    {
        /**
         *  Get calculate result with string parameter
         *  format: Numbers & operators separated by spaces
         *  Ex. 1 + 2 + 3
         */
        public double Calculate(string sum)
        {
            /*
             * Handle all parenthesis 
             * Calculate it and replace new value back into string
             */
            while (sum.Contains("("))
            {
                var eq = getBracket(sum);
                if (!string.IsNullOrEmpty(eq))
                {
                    var value = Solve(eq);
                    sum = sum.Replace(eq, $"{value}");
                }
            }

            /*
             * Handle remain 
             */
            sum = Solve(sum);

            return double.Parse(sum);
        }

        /*
         * Calculation
         */
        private string Solve(string sum)
        {
            sum = sum.Replace("(", "");
            sum = sum.Replace(")", "");

            /**
             * Looking for Multiply and Divide 
             * Process first * or / in the list (Left to Right)
             * Calculate and replace value back into string
             */
            while (sum.Contains("*") || sum.Contains("/"))
            {
                var list = sum.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var idx = list.Where(x => x == "*" || x == "/").First();

                var num1 = list[list.IndexOf(idx) - 1];
                var num2 = list[list.IndexOf(idx) + 1];

                var newValue = 0.0;
                if (idx == "*")
                {
                    newValue = Multiply(double.Parse(num1), double.Parse(num2));
                }
                else
                {
                    newValue = Divide(double.Parse(num1), double.Parse(num2));
                }

                var oldeq = $"{num1} {idx} {num2}";
                sum = sum.Replace(oldeq, $"{newValue}");
            }

            /**
             * Looking for Addition and Subtraction 
             * Process + or - in the list (Left to Right)
             * Calculate and replace value back into string
             */

            while (sum.Contains("+") || sum.Contains("-"))
            {
                var list = sum.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var idx = list.Where(x => x == "+" || x == "-").First();

                var num1 = list[list.IndexOf(idx) - 1];
                var num2 = list[list.IndexOf(idx) + 1];

                var newValue = 0.0;
                if (idx == "+")
                {
                    newValue = Add(double.Parse(num1), double.Parse(num2));
                }
                else
                {
                    newValue = Sub(double.Parse(num1), double.Parse(num2));
                }

                var oldeq = $"{num1} {idx} {num2}";
                sum = sum.Replace(oldeq, $"{newValue}");
            }

            return sum.Trim();
        }

        /**
         * Addition, Subtract, Multiply, Divide Method
         */
        private double Divide(double x, double y)
        {
            return x / y;
        }

        private double Multiply(double x, double y)
        {
            return x * y;
        }

        private double Add(double x, double y)
        {
            return x + y;
        }

        private double Sub(double x, double y)
        {
            return x - y;
        }

        /**
         * Get deepest parenthesis bracket 
         * Last "(" and First ")" after Last "(" in string
         */
        private string getBracket(string str)
        {
            var idxS = str.LastIndexOf('(');

            if (idxS == -1)
            {
                return null;
            }

            var trimmed = str.Substring(idxS);

            var idxE = trimmed.IndexOf(')');

            trimmed = trimmed.Substring(0, idxE + 1);

            return trimmed;
        }

    }
}
