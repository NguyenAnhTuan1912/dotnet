using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.classes
{
    public class MyCalculator
    {
        private List<Stack<Expression>> __expressions = new List<Stack<Expression>>(1);
        private Expression __expression = new Expression();
        private Expression? __prev;
        private int __depth = 0;
        private double? __previousOperand;

        public double? result;
        public string currentOperandStr = "";
        public string polynomialStr = "";

        public MyCalculator()
        {
            if(__expressions.Count == 0) __expressions.Add(new Stack<Expression>());
        }
        
        public void buildSubExpression(string s)
        {
            // In subexpression
            if (s == ")" && __depth > 0)
            {
                __prev = null;
                __depth--;
                return;
            }

            __depth++;
            __expressions.Add(new Stack<Expression>());

            if (!__expression.isComplete())
            {
                __expression = new Expression();
                return;
            }

            __expressions[__depth - 1].Push(__expression);

            __prev = __expression;
            __expression = new Expression();
        }

        public void buildPrecedentOperatorExpression(string s)
        {
            /*
            if (__expression.isComplete())
            {
                __expressions[__depth].Push(__expression);
                __expression = new Expression();
                return;
            }
            */
            if (__prev == null)
            {
                __expression.setOperator(s);

                // If precedent expression (*, /, %) is bridge expression
                if (__expression.isBridge())
                {
                    Expression temp = getExpressionInCurrentDepth(__depth + 1);
                    __expression.setOperandA(temp.getResult());
                }

                return;
            }

            // Set operandB of previous expression to null
            __prev.setOperandB();

            // Create new expression
            __expression = new Expression();
            __expression.setOperandA(__previousOperand);
            __expression.setOperator(s);
        }

        public void buildExpression(string s)
        {
            // If s is operator
            // 1. Maybe *, /, %
            if(ArithmeticOperator.IsMorePrecedence(s))
            {
                buildPrecedentOperatorExpression(s);
                return;
            }

            // 2. Maybe +, -.
            // +, - operator must be in low precedence.
            // That means these operators are not in ()
            if(ArithmeticOperator.IsValid(s))
            {
                __expression.setOperator(s);

                // If expression is not a bridge, then terminate the process
                if (!__expression.isBridge()) return;

                // else caclulate them, assign to operandA of __epxression.
                Expression temp = getExpressionInCurrentDepth();
                __expression.setOperandA(temp.getResult());

                return;
            }

            // If s is number
            __expression.setOperand(s);
            __previousOperand = double.Parse(s);

            // If expression is complete
            if (__expression.isComplete())
            {
                __expressions[__depth].Push(__expression);
                __prev = __expression;
                __expression = new Expression();
            }
        }

        /// <summary>
        /// Use this method to get expression from the current depth (index) of calculation stack list.
        /// Each expression of calculation stack is computed, it will be assign to the null operand of the next one,
        /// the compution will be operated until reach the current depth.
        /// </summary>
        /// <returns>An expression of current depth.</returns>
        public Expression getExpressionInCurrentDepth(int depth = -1)
        {
            double result = 0;
            int N = __expressions.Count;
            Expression temp = new Expression();

            depth = (depth == -1) ? __depth : depth;

            for (int i = N - 1; i >= depth; i--)
            {
                while (__expressions[i].Count > 0)
                {
                    temp = __expressions[i].Pop();
                    temp.setOperand(result);
                    result = temp.getResult();
                }

                // If depth is less than numbers of calculation stack list elements, then
                // remove the element that its index in list is outside of depth.
                if (depth < __expressions.Count - 1) __expressions.RemoveAt(__expressions.Count - 1);
            }

            return temp;
        }

        /// <summary>
        /// Use this method to get final result, compute all calculation stack
        /// from calculation stack list.
        /// </summary>
        /// <returns>A result of calculation stack list.</returns>
        public double? getResult()
        {
            __depth = 0;
            if (__expressions[0].Count > 0) __expression = getExpressionInCurrentDepth();
            else if(result != null) __expression.setOperandA(result);

            result = __expression.getResult();

            return result;
        }

        /// <summary>
        /// Use this method to get the result of current expression.
        /// </summary>
        /// <returns>A result of current expression</returns>
        public double getExpressionResult()
        {
            return __expression.getResult();
        }

        /// <summary>
        /// Use this method to get expression string.
        /// </summary>
        /// <returns>A string of expression</returns>
        public string getExpressionStr()
        {
            return __expression.getExpressionStr();
        }

        public int getCurrentDepth()
        {
            return __depth;
        }

        /// <summary>
        /// Use this the method to reset state of Calculator.
        /// </summary>
        public void reset()
        {
            __expressions.Clear();
            __expressions.Add(new Stack<Expression>());

            __expression = new Expression();
            __prev = null;

            __depth = 0;
            __previousOperand = null;

            result = null;
            currentOperandStr = "";
            polynomialStr = "";
    }
    }
}
