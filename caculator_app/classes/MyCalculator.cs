using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.classes
{
    public class MyCalculator
    {
        private Queue<Expression> __queue = new Queue<Expression>();
        public Expression currentExpression;
        public string currentOperandStr = "";
        public string currentExpressionStr = "";

        public void addExpression(string a = "0", string b = "0", string o = "+")
        {
            __queue.Enqueue(new Expression(a, b, o));
        }

        public void addExpression(Expression exp)
        {
            __queue.Enqueue(exp);
        }

        public double getResult()
        {
            Expression exp = __queue.Dequeue();
            return exp.getResult();
        }

        public double getResults()
        {
            double result = 0;
            return result;
        }
    }
}
