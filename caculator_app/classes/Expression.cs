using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.classes
{
    public class Expression
    {
        private double __operandA;
        private double __operandB = 0;
        private string __operator = "";

        // Static properties
        public const string AdditionOperator = "+";
        public const string SubtractionOperator = "-";
        public const string MultiplicationOperator = "x";
        public const string DivisionOperator = "/";
        public const string ModOperator = "%";

        public Expression(string a = "0", string b = "0", string o = "+")
        {
            __operandA = double.Parse(a);
            __operandB = double.Parse(b == "" ? a : b);
            __operator = o;
        }

        public void setOperandA(double a) { __operandA = a; }
        public void setOperandA(string a) { __operandA = double.Parse(a); }
        public void setOperandB(double b) { __operandB = b; }
        public void setOperandB(string b) { __operandB = double.Parse(b); }
        public void setOperator(string o) { __operator = o; }
        public void setOperand(string n)
        {
            double.chec
        }

        public double getResult()
        {
            switch (__operator)
            {
                case Expression.SubtractionOperator:
                    {
                        return __operandA - __operandA;
                    }
                case Expression.MultiplicationOperator:
                    {
                        return __operandA * __operandA;
                    }
                case Expression.DivisionOperator:
                    {
                        return __operandA / __operandA;
                    }
                case Expression.ModOperator:
                    {
                        return __operandA % __operandA;
                    }
                case Expression.AdditionOperator:
                default:
                    {
                        return __operandA + __operandA;
                    }
            };
        }

        // Static methods
        static public bool IsValidOperator(string c)
        {
            switch (c)
            {
                case Expression.AdditionOperator:
                case Expression.SubtractionOperator:
                case Expression.MultiplicationOperator:
                case Expression.DivisionOperator:
                case Expression.ModOperator:
                    {
                        return true;
                    }
                default:
                    return false;
            };
        }
    }
}
