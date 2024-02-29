using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.classes
{
    public static class Operators
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
                case Operators.AdditionOperator:
                case Operators.SubtractionOperator:
                case Operators.MultiplicationOperator:
                case Operators.DivisionOperator:
                case Operators.ModOperator:
                {
                    return true;
                }
                default:
                    return false;
            };
        }

        static public int GetPrecedentValue(Expression e)
        {
            return __GetPrecedentValue(e.getOperator());
        }

        static public int GetPrecedentValue(string c)
        {
            return __GetPrecedentValue(c);
        }

        static private int __GetPrecedentValue(string c)
        {
            switch(c)
            {
                case Operators.AdditionOperator:
                case Operators.SubtractionOperator:
                {
                    return 0;
                }
                case Operators.MultiplicationOperator:
                case Operators.DivisionOperator:
                case Operators.ModOperator:
                {
                    return 1;
                }
                default: return 0;
            }
        }
    }
}
