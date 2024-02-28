using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.classes
{
    public static class ArithmeticOperator
    {
        public const string AdditionOperator = "+";
        public const string SubtractionOperator = "-";
        public const string MultiplicationOperator = "x";
        public const string DivisionOperator = "/";
        public const string ModOperator = "%";

        static public bool IsValid(string c)
        {
            switch (c)
            {
                case ArithmeticOperator.AdditionOperator:
                case ArithmeticOperator.SubtractionOperator:
                case ArithmeticOperator.MultiplicationOperator:
                case ArithmeticOperator.DivisionOperator:
                case ArithmeticOperator.ModOperator:
                    {
                        return true;
                    }
                default:
                    return false;
            };
        }

        static public bool IsMorePrecedence(string c)
        {
            switch (c)
            {
                case ArithmeticOperator.MultiplicationOperator:
                case ArithmeticOperator.DivisionOperator:
                case ArithmeticOperator.ModOperator:
                    {
                        return true;
                    }
                default:
                    return false;
            };
        }
    }

    public class Expression
    {
        private double? __operandA;
        private double? __operandB;

        private string __operator = "";

        public void setOperand(double a)
        {
            if (ArithmeticOperator.IsValid(__operator) && __operandB == null)
                setOperandB(a);
            else if(__operandA == null)
                setOperandA(a);
        }
        public void setOperand(string a)
        {
            if (ArithmeticOperator.IsValid(__operator) && __operandB == null)
                setOperandB(a);
            else if (__operandA == null)
                setOperandA(a);
        }
        public void setOperandA(double? a = null)
        {
            __operandA = a;
        }
        public void setOperandB(double? b = null)
        {
            __operandB = b;
        }
        public void setOperandA(string a)
        {
            __operandA = double.Parse(a);
        }
        public void setOperandB(string b)
        {
            __operandB = double.Parse(b);
        }
        public void setOperator(string o) { __operator = o; }
        public string getOperator() { return __operator; }

        public bool isComplete()
        {
            if (ArithmeticOperator.IsValid(__operator)) return true;

            bool checkA = __operandA != null, checkB = __operandB != null;

            return checkA && checkB;
        }

        public bool isBridge()
        {
            return __operandA == null && __operandB == null && __operator != "";
        }

        public string getExpressionStr()
        {
            string a = "", b = "";

            if (__operandA != null) a = __operandA.Value.ToString();
            if (__operandB != null) b = __operandB.Value.ToString();

            return a + " " + __operator + " " + b;
        }

        public double getResult()
        {
            double resultA = 0, resultB = 0;

            if (ArithmeticOperator.IsMorePrecedence(__operator))
            {
                resultA = 0;
                resultB = 1;
            }

            if (__operandA != null) resultA = __operandA.Value;
            if (__operandB != null) resultB = __operandB.Value;


            switch (__operator)
            {
                case ArithmeticOperator.SubtractionOperator:
                    {
                        return resultA - resultB;
                    }
                case ArithmeticOperator.MultiplicationOperator:
                    {
                        return resultA * resultB;
                    }
                case ArithmeticOperator.DivisionOperator:
                    {
                        return resultA / resultB;
                    }
                case ArithmeticOperator.ModOperator:
                    {
                        return resultA % resultB;
                    }
                case ArithmeticOperator.AdditionOperator:
                default:
                    {
                        return resultA + resultB;
                    }
            };
        }
    }
}
