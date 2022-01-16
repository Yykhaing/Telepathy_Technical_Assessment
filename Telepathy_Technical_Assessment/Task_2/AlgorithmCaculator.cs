using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Telepathy_Technical_Assessment.Task_2
{
    public class AlgorithmCaculator
    {
        public decimal ExtractSubExpressions(string expression)
        {
            decimal outValue = 0;
            string regPattern = @"\([0-9+x\-÷]+\)";

            expression = Regex.Replace(expression, @"\s+", "");

            if (!Regex.IsMatch(expression, @"^-?\d+$"))
            {
                var match = Regex.Match(expression, regPattern);
                if (match.Success)
                {
                    var subValue = CalculateExpression(expression.Substring(match.Index, match.Length).TrimStart('(').TrimEnd(')'));
                    expression = expression.Replace(match.Value, subValue.ToString());
                    outValue = ExtractSubExpressions(expression);
                }
            }
            else
                outValue = CalculateExpression(expression);
            return 0;
        }

        public decimal CalculateExpression(string expression)
        {
            decimal result = 0;
            var regPattern = "^(?<num1>[0-9]+)(?<sign>[+-x÷]{1})(?<num2>[0-9]+)$";
            var match = Regex.Match(expression, regPattern);
            if (match.Success)
            {
                switch (match.Groups["sign"].Value)
                {
                    case "+":
                        result = Convert.ToDecimal(match.Groups["num1"].Value) + Convert.ToDecimal(match.Groups["num2"].Value);
                        break;
                    case "-":
                        result = Convert.ToDecimal(match.Groups["num1"].Value) - Convert.ToDecimal(match.Groups["num2"].Value);
                        break;
                    case "x":
                        result = Convert.ToDecimal(match.Groups["num1"].Value) * Convert.ToDecimal(match.Groups["num2"].Value);
                        break;
                    case "÷":
                        result = Convert.ToDecimal(match.Groups["num1"].Value) / Convert.ToDecimal(match.Groups["num2"].Value);
                        break;
                }

            }
            return result;
        }

    }
}
