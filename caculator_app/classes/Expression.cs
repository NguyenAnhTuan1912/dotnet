using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.classes
{

    public class Expression
    {
        private double? __operandA;
        private double? __operandB;

        private string __operator = "";

        // Setters
        public void setOperand(double a)
        {
            if (Operators.IsValid(__operator) && __operandB == null)
                setOperandB(a);
            else if(__operandA == null)
                setOperandA(a);
        }
        public void setOperand(string a)
        {
            if (Operators.IsValid(__operator) && __operandB == null)
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

        // Getters
        public string getOperator() { return __operator; }
        public double? getOperandA() { return __operandA; }
        public double? getOperandB() { return __operandB; }

        /// <summary>
        /// Use this method to get the "complete" status of an expression.
        /// An expression is complete when it has 2 operands and operator.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if expression has 2 operands and operator.
        /// <see langword="false"/> if expression lack 1 or 2 operands or operator then return false</returns>
        public bool isComplete()
        {
            return (__operandA != null) && (__operandB != null) && Operators.IsValid(__operator);
        }

        /// <summary>
        /// Use the method to compare precedent betwwee 2 expression.
        /// If 
        /// </summary>
        /// <param name="e"></param>
        /// <returns>
        ///     <see langword="true"/> if this expression has higher "precedent value".
        ///     <see langword="false"/> if this expression has equal or less than  "precedent value" then return false
        /// </returns>
        public bool isMorePrecedentThan(Expression e)
        {
            return Operators.GetPrecedentValue(__operator) > Operators.GetPrecedentValue(e.getOperator());
        }

        /// <summary>
        /// Use this method to check if this expression is bridge.
        /// An expression is bridge when it only has operator.
        /// </summary>
        /// <returns></returns>
        public bool isBridge()
        {
            return (__operandA == null) && (__operandB == null) && Operators.IsValid(__operator);
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

            if (Operators.GetPrecedentValue(__operator) >= 1)
            {
                resultA = 0;
                resultB = 1;
            }

            if (__operandA != null) resultA = __operandA.Value;
            if (__operandB != null) resultB = __operandB.Value;


            switch (__operator)
            {
                case Operators.SubtractionOperator:
                {
                    return resultA - resultB;
                }
                case Operators.MultiplicationOperator:
                {
                    return resultA * resultB;
                }
                case Operators.DivisionOperator:
                {
                    return resultA / resultB;
                }
                case Operators.ModOperator:
                {
                    return resultA % resultB;
                }
                case Operators.AdditionOperator:
                default:
                {
                    return resultA + resultB;
                }
            };
        }
    }
}
