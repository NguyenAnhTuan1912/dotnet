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
        private string __calculatedExpressionStr = "";

        public void showTxtPolynomial(string c)
        {
            txtPolynomial.Text = c;
        }

        public void showTxtResult(string c)
        {
            txtResult.Text = c;
        }

        public void showTxtResultPlaceHolder()
        {
            txtResult.Text = __calculator.result == null ? "0" : __calculator.result.ToString();
        }

        public void clearTxtResult()
        {
            txtResult.Text = "";
        }

        public void clearTxtPolynomial()
        {
            txtPolynomial.Text = "";
        }

        public void inputValue(string c)
        {
            if (String.IsNullOrEmpty(c)) return;

            // Handle operand
            if (ArithmeticOperator.IsValid(c))
            {
                // Reset operand
                __calculator.currentOperandStr = "";
                __calculator.polynomialStr += " " + c + " ";

                // Build current expression
                __calculator.buildExpression(c);

                // Show result in txtResult
                showTxtResult(__calculator.getExpressionResult().ToString());
            }
            else if ((c != "(" && c != ")"))
            {
                __calculator.currentOperandStr += c;
                __calculator.polynomialStr += c;

                // Build current expression
                __calculator.buildExpression(__calculator.currentOperandStr);

                // Show operand in txtResult
                showTxtResult(__calculator.currentOperandStr);
            };

            // Handle ()
            if (c == "(" || c == ")")
            {
                __calculator.polynomialStr += c;
                __calculator.buildSubExpression(c);
            }

            // Show polynomial in txtExpression
            showTxtPolynomial(__calculator.polynomialStr);

            // If operand is empty, show placeholder for txtResult
            if (__calculator.currentOperandStr == "") showTxtResultPlaceHolder();
        }

        public void calculateCurrent()
        {
            // Calculate result
            __calculator.result = __calculator.getExpressionResult();

            // Show result in txtResult
            showTxtResultPlaceHolder();

            // Show polynomial in txtExpression
            showTxtPolynomial(__calculator.polynomialStr);

        }

        public void calculatePolynomial()
        {
            // Calculate result
            double? r = __calculator.getResult();

            // Show result in txtResult
            showTxtResultPlaceHolder();

            if (__calculatedExpressionStr != "") __calculator.polynomialStr = __calculator.getExpressionStr() + " = ";
            else __calculatedExpressionStr = __calculator.polynomialStr += " = ";

            // Show polynomial in txtExpression
            showTxtPolynomial(__calculatedExpressionStr);
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

            // Update label for button
            btnOpenBracket.Text = value + " - " + __calculator.getCurrentDepth();
        }

        private void btnCloseBracket_Click(object sender, EventArgs e)
        {
            string value = ")";
            inputValue(value);

            // Update label for button
            if(__calculator.getCurrentDepth() == 0)
                btnOpenBracket.Text = "(";
            else
                btnOpenBracket.Text = value + " - " + __calculator.getCurrentDepth();
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
            string value = ArithmeticOperator.AdditionOperator;
            inputValue(value);
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            string value = ArithmeticOperator.SubtractionOperator;
            inputValue(value);
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            string value = ArithmeticOperator.MultiplicationOperator;
            inputValue(value);
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            string value = ArithmeticOperator.DivisionOperator;
            inputValue(value);
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            string value = ArithmeticOperator.ModOperator;
            inputValue(value);
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            calculatePolynomial();

            // Clear calculated expression string
            __calculatedExpressionStr = "";
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            __calculator.reset();

            // Show polynomial in txtExpression
            showTxtPolynomial(__calculator.polynomialStr);

            // Show placeholder in txtResult
            showTxtResultPlaceHolder();
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            // If has result.
            if (__calculator.result != null)
            {
                __calculator.currentOperandStr = __calculator.result.Value.ToString();
                // __calculator.reset();

                // Show polynomial in txtExpression
                showTxtPolynomial(__calculator.polynomialStr);

                // Show operand in txtResult
                showTxtResult(__calculator.currentOperandStr);

                // Rebuild current expression
                __calculator.buildExpression(__calculator.currentOperandStr);

                return;
            }

            if (!String.IsNullOrEmpty(__calculator.currentOperandStr))
                __calculator.currentOperandStr = __calculator.currentOperandStr.Substring(0, __calculator.currentOperandStr.Length - 1);

            // Rebuild current expression
            __calculator.buildExpression(__calculator.currentOperandStr);

            // Show polynomial in txtExpression
            showTxtPolynomial(__calculator.polynomialStr);

            // Show operand in txtResult
            showTxtResult(__calculator.currentOperandStr);

            // If operand is empty, show placeholder for txtResult
            if (__calculator.currentOperandStr == "") showTxtResultPlaceHolder();
        }
    }
}
