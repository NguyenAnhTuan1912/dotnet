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

        private Expression? __subExpressionA;
        private Expression? __subExpressionB;

        private string __operator = "";

        public void setOperand(double a)
        {
            if(__operator == "") setOperandA(a);
            else setOperandB(a);
        }
        public void setOperand(string a)
        {
            if (__operator == "") setOperandA(a);
            else setOperandB(a);
        }
        public void setOperandA(double a)
        {
            __operandA = a;
            if(__subExpressionA != null) __subExpressionA = null;
            // __operandB ??= __operandA;
        }
        public void setOperandB(double b)
        {
            __operandB = b;
            if (__subExpressionB != null)  __subExpressionB = null;
            // __operandA ??= __operandB;
        }
        public void setOperandA(string a)
        {
            __operandA = double.Parse(a);
            if (__subExpressionA != null)  __subExpressionA = null;
            // __operandB ??= __operandA;
        }
        public void setOperandB(string b)
        {
            __operandB = double.Parse(b);
            if (__subExpressionB != null) __subExpressionB = null;
            // __operandA ??= __operandB;
        }
        public void setExpressionA(Expression a) {
            __subExpressionA = a;
            if (__operandA != null) __operandA = null;
            // __operandB ??= 0;
        }
        public void setExpressionB(Expression b)
        {
            __subExpressionB = b;
            if (__operandB != null)  __operandB = null;
            // __operandA ??= 0;
        }
        public void setOperator(string o) { __operator = o; }

        public string getExpressionStr()
        {
            string a = "", b = "";

            if (__operandA != null) a = __operandA.Value.ToString();
            if (__operandB != null) b = __operandB.Value.ToString();

            if (__subExpressionA != null) a = __subExpressionA.getExpressionStr();
            if (__subExpressionB != null) b = __subExpressionB.getExpressionStr();

            return a + " " + __operator + " " + b;
        }

        public double getResult()
        {
            double resultA = 0, resultB = 0;

            if (__operandA != null) resultA = __operandA.Value;
            if (__operandB != null) resultB = __operandB.Value;

            if (__subExpressionA != null) resultA = __subExpressionA.getResult();
            if (__subExpressionB != null) resultB = __subExpressionB.getResult();

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
