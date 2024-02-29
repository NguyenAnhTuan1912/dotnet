using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.classes
{
    /// <summary>
    /// Use this class to create an instance to store the calculation.
    /// </summary>
    public class Calculation
    {
        private Expression __calculatedExpression;
        private string __expressionStr = "";

        // Setters
        public void setCalculatedExpression(Expression e)
        {
            __calculatedExpression = e;
        }

        public void setExpressionStr(string s)
        {
            __expressionStr = s;
        }

        // Getters
        public Expression getCalculatedExpression() { return __calculatedExpression; }
        public string getExpressionStr() { return __expressionStr; }
    }

    public class MyCalculator
    {
        private List<Calculation> __history = new List<Calculation>();
        private List<Stack<Expression>> __expressions = new List<Stack<Expression>>(1);
        private Expression __expression = new Expression();
        private Expression? __prev;
        private int __depth = 0;
        private string __calculatedExpressionStr = "";

        public double? result;
        public string currentInput = "";
        public string previousInput = "";
        public string expressionStr = "";

        public MyCalculator()
        {
            if(__expressions.Count == 0) __expressions.Add(new Stack<Expression>());
        }
        
        /// <summary>
        /// Use this method to start new Calculation Stack (or create new sub expression).
        /// </summary>
        /// <param name="s"></param>
        public void buildSubExpression(string s)
        {
            // Case 3: ()
            // In subexpression
            if (s == ")" && __depth > 0)
            {
                if (__expression.getOperandA() != null && !Operators.IsValid(__expression.getOperator()))
                {
                    __expression.setOperator(Operators.AdditionOperator);
                    __expressions[__depth].Push(__expression);
                    __expression = new Expression();
                } else if (__expression.isComplete())
                {
                    __expressions[__depth].Push(__expression);
                    __expression = new Expression();
                }

                __prev = null;
                __depth--;
                return;
            }

            if (Operators.IsValid(__expression.getOperator()))
                __expressions[__depth].Push(__expression);

            __depth++;
            __expressions.Add(new Stack<Expression>());

            __prev = null;
            __expression = new Expression();
        }

        /// <summary>
        /// <para>
        /// Use this method to build expression. In each loop, user will input data through buttons on the GUI. There are 3
        /// possible values that user may input:
        /// </para>
        /// <list type="number">
        ///     <item>
        ///         <description>Numbers or dot .</description>
        ///     </item>
        ///     <item>
        ///         <description>( or )</description>
        ///     </item>
        ///     <item>
        ///         <description>Operators</description>
        ///     </item>
        /// </list>
        /// <para>
        /// This method will treat differently with each type.
        /// </para>
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public void buildExpression(string s)
        {
            // Case 1: If s is number.
            if (!Operators.IsValid(s))
            {
                // If "." is inputted but operand A or B is null, return false.
                if (s == "." && (__expression.getOperandA() == null || __expression.getOperandB() == null))
                    s = "0.";

                if (Operators.IsValid(__expression.getOperator())) __expression.setOperandB(s);
                else __expression.setOperandA(s);

                return;
            }

            // Case 2: operator
            // When user input a operator, that mean they are sure about the expression that is inputted before.
            if(__expression.isComplete())
            {
                __expressions[__depth].Push(__expression);
                __prev = __expression;
                __expression = new Expression();
            }


            if (Operators.IsValid(__expression.getOperator())) return;

            __expression.setOperator(s);

            if (__prev != null && __expression.isMorePrecedentThan(__prev))
            {
                double? operandB = __prev.getOperandB();
                __expression.setOperandA(operandB);
                __prev.setOperandB();
                return;
            }

            if (__prev != null && !__expression.isMorePrecedentThan(__prev))
            {
                Expression t = getExpressionInCurrentDepth(__depth, __expression);
                __expression.setOperandA(t.getResult());
                return;
            }

            // If expression is not bridge
            if (!__expression.isBridge()) return;

            // Get the expression at current depth, then assign its result to operanA of __expression.
            Expression temp = getExpressionInCurrentDepth(__depth, __expression);
            __expression.setOperandA(temp.getResult());
            return;
        }

        /// <summary>
        /// Use this method to get expression from the current depth (index) of calculation stack list.
        /// Each expression of calculation stack is computed, it will be assign to the null operand of the next one,
        /// the compution will be operated until reach the current depth.
        /// </summary>
        /// <returns>An expression of current depth.</returns>
        public Expression getExpressionInCurrentDepth(int depth = -1, Expression? e = null)
        {
            double result = 0;
            int N = __expressions.Count;
            Expression temp = new Expression();
            Expression prev = new Expression();

            depth = (depth == -1) ? __depth : depth;

            for (int i = N - 1; i >= depth; i--)
            {
                while (__expressions[i].Count > 0)
                {
                    temp = __expressions[i].Pop();

                    if (!Operators.IsValid(temp.getOperator())) continue;

                    // If current expression is less precedent than e, stop compute
                    if (e != null && e.isMorePrecedentThan(temp) && i == depth)
                    {
                        __expressions[i].Push(temp);
                        return prev;
                    };

                    temp.setOperand(result);
                    result = temp.getResult();
                    prev = temp;
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
            if (Operators.IsValid(__expression.getOperator()) && (__expression.getOperandA() != null || __expression.getOperandB != null)) __expressions[__depth].Push(__expression);
            if (result == null)
            {
                __depth = 0;
                __expression = getExpressionInCurrentDepth();
            }
            else __expression.setOperandA(result);

            currentInput = "";
            result = Math.Round((double)__expression.getResult(), 6);
            __calculatedExpressionStr = expressionStr;

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

            result = null;
            currentInput = "";
            expressionStr = "";
            previousInput = "";
        }

        /// <summary>
        /// Use this method to save calculation to history.
        /// </summary>
        public Calculation? saveCalculation()
        {
            if (!__expression.isComplete()) return null;
            // Save the calculation to history
            Calculation calculation = new Calculation();
            calculation.setCalculatedExpression(__expression);
            calculation.setExpressionStr(__calculatedExpressionStr);

            __history.Add(calculation);

            // Reset all after save the calculation.
            reset();

            return calculation;
        }

        /// <summary>
        /// Use this method to load calculation from history.
        /// </summary>
        /// <param name="index"></param>
        public Calculation loadCalculation(int index = 0)
        {
            // Reset first
            reset();

            // Load some data
            expressionStr = __history[index].getExpressionStr();
            __expression = __history[index].getCalculatedExpression();

            return __history[index];
        }

        /// <summary>
        /// Use this method to delete a calculation at index.
        /// </summary>
        /// <param name="index"></param>
        public void deleteCalculation(int index = 0)
        {
            // Remove calculation from history
            __history.RemoveAt(index);
        }

        /// <summary>
        /// Use this method to clear all calculations in history.
        /// </summary>
        public void clearHistory()
        {
            // Remove calculation from history
            __history.Clear();
        }
    }
}
