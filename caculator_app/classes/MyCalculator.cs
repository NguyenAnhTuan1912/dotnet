using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.classes
{
    public class MyCalculator
    {
        private Queue<Expression> __expressionQueue = new Queue<Expression>();
        private Expression __topExpression = new Expression();
        private Expression __currentSubExpression = new Expression();
        private Expression __currentExpression = new Expression();

        public double? currentResult;
        public string currentOperandStr = "";

        static private void __buildExpression(ref Expression e, string s)
        {
            if (String.IsNullOrEmpty(s)) s = "0";

            // Set operator
            if (ArithmeticOperator.IsValid(s))
            {
                e.setOperator(s);
            }
            else
            {
                e.setOperand(s);
            }
        }

        public void buildCurrentExpression(string s)
        {
            if (currentResult != null) __currentExpression.setOperandA((double)currentResult);
            else MyCalculator.__buildExpression(ref __currentExpression, s);
        }

        public string getCurrentExpressionStr()
        {
            return __currentExpression.getExpressionStr();
        }

        public double getCurrentExpressionResult()
        {
            return __currentExpression.getResult();
        }

        public void buildTopExpression(string s)
        {
            MyCalculator.__buildExpression(ref __topExpression, s);
        }

        public void buildSubExpression(string s)
        {
            MyCalculator.__buildExpression(ref __currentSubExpression, s);
        }

        public void resetCurrentExpression()
        {
            currentResult = null;
            __currentExpression = new Expression();
        }
    }
}
