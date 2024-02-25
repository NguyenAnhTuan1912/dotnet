using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Caculator.classes;

namespace Caculator
{
    public partial class CalculatorForm : Form
    {
        private MyCalculator __calculator;
        private string[] __history;
        private string __txtResultPlaceHolder = "0";

        public void showTxtExpression(string c)
        {
            txtExpression.Text = c;
        }

        public void showTxtResult(string c)
        {
            txtResult.Text = c;
        }

        public void showTxtResultPlaceHolder()
        {
            txtResult.Text = __calculator.currentResult == null ? "0" : __calculator.currentResult.ToString();
        }

        public void clearTxtResult()
        {
            txtResult.Text = "";
        }

        public void clearTxtExpression()
        {
            txtExpression.Text = "";
        }

        public void inputValue(string c)
        {
            if (String.IsNullOrEmpty(c)) return;

            // Handle operand
            if (ArithmeticOperator.IsValid(c))
            {
                // Reset operand
                __calculator.currentOperandStr = "";

                // Build current expression
                __calculator.buildCurrentExpression(c);

                // Show result in txtResult
                showTxtResult(__calculator.getCurrentExpressionResult().ToString());
            }
            else
            {
                __calculator.currentOperandStr += c;
                // Build current expression
                __calculator.buildCurrentExpression(__calculator.currentOperandStr);

                // Show operand in txtResult
                showTxtResult(__calculator.currentOperandStr);
            };

            // Show expression in txtExpression
            showTxtExpression(__calculator.getCurrentExpressionStr());

            // If operand is empty, show placeholder for txtResult
            if (__calculator.currentOperandStr == "") showTxtResultPlaceHolder();
        }

        public void calculate()
        {
            if (__calculator.currentResult != null) __calculator.buildCurrentExpression("");

            // Calculate result
            __calculator.currentResult = __calculator.getCurrentExpressionResult();

            // Show result in txtResult
            showTxtResultPlaceHolder();

            // Show expression in txtExpression
            showTxtExpression(__calculator.getCurrentExpressionStr() + " = ");
        }

        public CalculatorForm()
        {
            InitializeComponent();
            __calculator = new MyCalculator();
        }

        private void btnOpenBracket_Click(object sender, EventArgs e)
        {
            string value = "(";
            inputValue(value);
        }

        private void btnCloseBracket_Click(object sender, EventArgs e)
        {
            string value = ")";
            inputValue(value);
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            string value = "1";
            inputValue(value);
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            string value = "2";
            inputValue(value);
        }

        private void buttonThree_Click(object sender, EventArgs e)
        {
            string value = "3";
            inputValue(value);
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            string value = "4";
            inputValue(value);
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            string value = "5";
            inputValue(value);
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            string value = "6";
            inputValue(value);
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            string value = "7";
            inputValue(value);
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            string value = "8";
            inputValue(value);
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            string value = "9";
            inputValue(value);
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            string value = "0";
            inputValue(value);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string value = "+";
            inputValue(value);
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            string value = "-";
            inputValue(value);
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            string value = "x";
            inputValue(value);
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            string value = "/";
            inputValue(value);
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            string value = "%";
            inputValue(value);
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            calculate();
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (__calculator.currentResult != null)
            {
                __calculator.currentOperandStr = __calculator.currentResult.Value.ToString();
                __calculator.resetCurrentExpression();

                // Show expression in txtExpression
                showTxtExpression(__calculator.getCurrentExpressionStr());

                // Show operand in txtResult
                showTxtResult(__calculator.currentOperandStr);

                // Rebuild current expression
                __calculator.buildCurrentExpression(__calculator.currentOperandStr);
            }
            else
            {
                if (!String.IsNullOrEmpty(__calculator.currentOperandStr))
                    __calculator.currentOperandStr = __calculator.currentOperandStr.Substring(0, __calculator.currentOperandStr.Length - 1);

                // Rebuild current expression
                __calculator.buildCurrentExpression(__calculator.currentOperandStr);

                // Show expression in txtExpression
                showTxtExpression(__calculator.getCurrentExpressionStr());

                // Show operand in txtResult
                showTxtResult(__calculator.currentOperandStr);

                // If operand is empty, show placeholder for txtResult
                if (__calculator.currentOperandStr == "") showTxtResultPlaceHolder();
            }
        }
    }
}
