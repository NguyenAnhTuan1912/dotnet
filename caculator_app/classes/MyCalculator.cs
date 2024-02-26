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
        private List<Expression> __expressions = new List<Expression>();
        private Expression __expression = new Expression();
        private Expression? __prev;
        private int __subExpressionDepth = 0;
        private double? __previousOperand;

        public double? result;
        public string currentOperandStr = "";
        public string polynomialStr = "";
        
        public void buildSubExpression(string s)
        {
            // In subexpression
            if (s == ")" && __subExpressionDepth > 0)
            {
                __subExpressionDepth--;
                return;
            }

            // Prepend current expression to stack
            if(!__expression.isComplete())
            {
                __expression = new Expression();
                __expression.isPrecedent = true;

                __subExpressionDepth++;
                return;
            }

            if (__expression.isPrecedent) __expressions.Insert(0, __expression);
            else __expressions.Add(__expression);

            __prev = __expression;
            __expression = new Expression();
        }

        public void buildExpression(string s)
        {
            // If there are complete expression before, create new expression with
            // __previous operand and pop the previous expression for modification.
            if (ArithmeticOperator.IsMorePrecedence(s) && (__prev != null && !__prev.isPrecedent))
            {
                // Modify previous expression
                __prev.setOperandB();

                // Set operand A (left) for expresssion
                __expression = new Expression();
                __expression.setOperandA(__previousOperand);
                __expression.setOperator(s);
                __expression.isPrecedent = true;
                return;
            }

            // Set operator
            // User inputs operator
            if (ArithmeticOperator.IsValid(s))
            {
                __expression.setOperator(s);
                return;
            }

            // User input operand
            __expression.setOperand(s);
            __previousOperand = double.Parse(s);

            // If expression is complete, prepend or append expression to list
            if (!__expression.isComplete()) return;

            // Check if previous expression is bridge
            if (__prev != null && __prev.isBridge())
            {
                __prev.setOperandB(__expression.getResult());
                __expression = new Expression();
                return;
            }

            if (__expression.isPrecedent) __expressions.Insert(0, __expression);
            else __expressions.Add(__expression);

            __prev = __expression;
            __expression = new Expression();
        }

        public double getResult()
        {
            double result = 0;

            foreach(Expression e in __expressions)
            {
                e.setOperand(result);
                result = e.getResult();
            }

            return result;
        }

        public string getExpressionStr()
        {
            return __expression.getExpressionStr();
        }

        public double getExpressionResult()
        {
            return __expression.getResult();
        }

        public void reset()
        {
            __expressions.Clear();
            __expression = new Expression();
            __prev = null;

            __subExpressionDepth = 0;
            __previousOperand = null;

            result = null;
            currentOperandStr = "";
            polynomialStr = "";
    }
    }
}
