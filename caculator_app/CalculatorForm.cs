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
        private int __selectedHistoryIndex = -1;

        public void showTxtExpresion(string c)
        {
            txtExpresion.Text = c;
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

        public void clearTxtExpresion()
        {
            txtExpresion.Text = "";
        }

        public void inputValue(string c)
        {
            if (String.IsNullOrEmpty(c)) return;

            // Handle operand
            if (Operators.IsValid(c))
            {
                if (Operators.IsValid(__calculator.previousInput)) return;

                // Build current expression
                __calculator.buildExpression(c);

                // Add current input to expression string.
                __calculator.expressionStr += " " + c + " ";

                // Set to previous input
                __calculator.previousInput = c;

                // Reset current input
                __calculator.currentInput = "";

                // Show result in txtResult
                showTxtResult(__calculator.getExpressionResult().ToString());
            }

            // Handle ()
            else if ((c == "(" || c == ")"))
            {
                if (
                    (__calculator.previousInput == ")" && c == "(") ||
                    (__calculator.previousInput != "" && !Operators.IsValid(__calculator.previousInput) && c == "(")
                )
                    __calculator.buildExpression(Operators.MultiplicationOperator);

                __calculator.buildSubExpression(c);

                // Add current input to expression string.
                __calculator.expressionStr += c;

                // Set to previous input
                __calculator.previousInput = c;

                // Reset current input
                __calculator.currentInput = "";
            }

            // Any thing else
            else
            {
                if (__calculator.result != null) clearAll();

                __calculator.currentInput += c;

                // Build current expression
                __calculator.buildExpression(__calculator.currentInput);

                // Add current input to expression string.
                __calculator.expressionStr += c;

                // Set to previous input
                __calculator.previousInput = __calculator.currentInput;

                // Show operand in txtResult
                showTxtResult(__calculator.currentInput);
            }

            // Show polynomial in txtExpression
            showTxtExpresion(__calculator.expressionStr);

            // If operand is empty, show placeholder for txtResult
            if (__calculator.currentInput == "") showTxtResultPlaceHolder();
        }

        public void clearAll()
        {
            __calculator.reset();

            // Show polynomial in txtExpression
            showTxtExpresion("");

            // Show placeholder in txtResult
            showTxtResultPlaceHolder();
        }

        public void calculate()
        {
            // Calculate result
            __calculator.getResult();

            // Show result in txtResult
            showTxtResultPlaceHolder();

            // Show polynomial in txtExpression
            showTxtExpresion(__calculator.expressionStr + " = ");

            if(__calculator.result != null) __calculator.expressionStr = __calculator.getExpressionStr();
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
            if (__calculator.getCurrentDepth() == 0)
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

        private void btnDot_Click(object sender, EventArgs e)
        {
            string value = ".";
            inputValue(value);
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (__calculator.currentInput == "") return;
            string value = __calculator.currentInput;
            int N = value.Length;

            __calculator.expressionStr = __calculator.expressionStr.Substring(0, __calculator.expressionStr.Length - N);

            if (value[0] == '-') value = value.Substring(1);
            else value = "-" + value;

            __calculator.currentInput = "";

            inputValue(value);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string value = Operators.AdditionOperator;
            inputValue(value);
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            string value = Operators.SubtractionOperator;
            inputValue(value);
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            string value = Operators.MultiplicationOperator;
            inputValue(value);
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            string value = Operators.DivisionOperator;
            inputValue(value);
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            string value = Operators.ModOperator;
            inputValue(value);
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            // Calculate final result
            calculate();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            // If has result.
            if (__calculator.result != null)
            {
                __calculator.currentInput = __calculator.result.Value.ToString();
                // __calculator.reset();

                // Show polynomial in txtExpression
                showTxtExpresion(__calculator.expressionStr);

                // Show operand in txtResult
                showTxtResult(__calculator.currentInput);

                // Rebuild current expression
                __calculator.buildExpression(__calculator.currentInput);

                return;
            }

            if (!String.IsNullOrEmpty(__calculator.currentInput))
            {
                __calculator.currentInput = __calculator.currentInput.Substring(0, __calculator.currentInput.Length - 1);
                __calculator.expressionStr = __calculator.expressionStr.Substring(0, __calculator.expressionStr.Length - 1);
            }
            else return;

            // Rebuild current expression
            __calculator.buildExpression(__calculator.currentInput == "" ? "0" : __calculator.currentInput);

            // Show expression in txtExpression
            showTxtExpresion(__calculator.expressionStr);

            // Show operand in txtResult
            showTxtResult(__calculator.currentInput);

            // If operand is empty, show placeholder for txtResult
            if (__calculator.currentInput == "") showTxtResultPlaceHolder();
        }

        private void btnSaveToHistory_Click(object sender, EventArgs e)
        {
            Calculation? c = __calculator.saveCalculation();
            if (c != null) lbxHistory.Items.Add(c.getExpressionStr());
        }

        private void lbxHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            __selectedHistoryIndex = lbxHistory.SelectedIndex;
        }

        private void btnLoadHistoryItem_Click(object sender, EventArgs e)
        {
            Calculation c = __calculator.loadCalculation(__selectedHistoryIndex);

            // Show expression in txtExpression
            showTxtExpresion(c.getExpressionStr());
        }

        private void btnDeleteHistoryItem_Click(object sender, EventArgs e)
        {
            __calculator.deleteCalculation(__selectedHistoryIndex);
            lbxHistory.Items.RemoveAt(__selectedHistoryIndex);

            // Show expression in txtExpression
            showTxtExpresion(__calculator.getExpressionStr());

            // Show placeholder in txtResult
            showTxtResultPlaceHolder();
        }

        private void btnDeleteHistory_Click(object sender, EventArgs e)
        {
            __calculator.clearHistory();
            lbxHistory.Items.Clear();
        }
    }
}
