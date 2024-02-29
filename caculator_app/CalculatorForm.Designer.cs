namespace Caculator
{
    partial class CalculatorForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSaveToHistory = new Button();
            btnClearAll = new Button();
            btnBackspace = new Button();
            btnDiv = new Button();
            btnCloseBracket = new Button();
            btnOpenBracket = new Button();
            btnMul = new Button();
            btnNine = new Button();
            btnEight = new Button();
            btnSeven = new Button();
            btnSub = new Button();
            btnSix = new Button();
            btnFive = new Button();
            btnFour = new Button();
            btnAdd = new Button();
            buttonThree = new Button();
            btnTwo = new Button();
            btnOne = new Button();
            btnCalc = new Button();
            btnComma = new Button();
            btnZero = new Button();
            btnSign = new Button();
            txtPolynomial = new TextBox();
            txtResult = new TextBox();
            label1 = new Label();
            lstHistory = new ListView();
            btnPercent = new Button();
            btnDeleteHistory = new Button();
            btnLoadHistoryItem = new Button();
            btnDeleteHistoryItem = new Button();
            SuspendLayout();
            // 
            // btnSaveToHistory
            // 
            btnSaveToHistory.BackColor = SystemColors.Window;
            btnSaveToHistory.FlatAppearance.BorderColor = Color.Black;
            btnSaveToHistory.FlatStyle = FlatStyle.Flat;
            btnSaveToHistory.ForeColor = SystemColors.WindowText;
            btnSaveToHistory.Location = new Point(229, 113);
            btnSaveToHistory.Margin = new Padding(3, 2, 3, 2);
            btnSaveToHistory.Name = "btnSaveToHistory";
            btnSaveToHistory.Size = new Size(63, 35);
            btnSaveToHistory.TabIndex = 0;
            btnSaveToHistory.Tag = "";
            btnSaveToHistory.Text = "Lưu";
            btnSaveToHistory.UseVisualStyleBackColor = false;
            // 
            // btnClearAll
            // 
            btnClearAll.BackColor = SystemColors.Window;
            btnClearAll.FlatStyle = FlatStyle.Flat;
            btnClearAll.ForeColor = Color.Red;
            btnClearAll.Location = new Point(24, 113);
            btnClearAll.Margin = new Padding(3, 2, 3, 2);
            btnClearAll.Name = "btnClearAll";
            btnClearAll.Size = new Size(63, 35);
            btnClearAll.TabIndex = 1;
            btnClearAll.Text = "CE";
            btnClearAll.UseVisualStyleBackColor = false;
            btnClearAll.Click += btnClearAll_Click;
            // 
            // btnBackspace
            // 
            btnBackspace.BackColor = SystemColors.Window;
            btnBackspace.FlatStyle = FlatStyle.Flat;
            btnBackspace.Location = new Point(93, 113);
            btnBackspace.Margin = new Padding(3, 2, 3, 2);
            btnBackspace.Name = "btnBackspace";
            btnBackspace.Size = new Size(63, 35);
            btnBackspace.TabIndex = 3;
            btnBackspace.Text = "<--";
            btnBackspace.UseVisualStyleBackColor = false;
            btnBackspace.Click += btnBackspace_Click;
            // 
            // btnDiv
            // 
            btnDiv.BackColor = SystemColors.Window;
            btnDiv.FlatStyle = FlatStyle.Flat;
            btnDiv.Location = new Point(229, 152);
            btnDiv.Margin = new Padding(3, 2, 3, 2);
            btnDiv.Name = "btnDiv";
            btnDiv.Size = new Size(63, 35);
            btnDiv.TabIndex = 7;
            btnDiv.Text = "/";
            btnDiv.UseVisualStyleBackColor = false;
            btnDiv.Click += btnDiv_Click;
            // 
            // btnCloseBracket
            // 
            btnCloseBracket.BackColor = SystemColors.Window;
            btnCloseBracket.FlatStyle = FlatStyle.Flat;
            btnCloseBracket.Location = new Point(93, 152);
            btnCloseBracket.Margin = new Padding(3, 2, 3, 2);
            btnCloseBracket.Name = "btnCloseBracket";
            btnCloseBracket.Size = new Size(63, 35);
            btnCloseBracket.TabIndex = 5;
            btnCloseBracket.Text = ")";
            btnCloseBracket.UseVisualStyleBackColor = false;
            btnCloseBracket.Click += btnCloseBracket_Click;
            // 
            // btnOpenBracket
            // 
            btnOpenBracket.BackColor = SystemColors.Window;
            btnOpenBracket.FlatStyle = FlatStyle.Flat;
            btnOpenBracket.Location = new Point(24, 152);
            btnOpenBracket.Margin = new Padding(3, 2, 3, 2);
            btnOpenBracket.Name = "btnOpenBracket";
            btnOpenBracket.Size = new Size(63, 35);
            btnOpenBracket.TabIndex = 4;
            btnOpenBracket.Text = "(";
            btnOpenBracket.UseVisualStyleBackColor = false;
            btnOpenBracket.Click += btnOpenBracket_Click;
            // 
            // btnMul
            // 
            btnMul.BackColor = SystemColors.Window;
            btnMul.FlatStyle = FlatStyle.Flat;
            btnMul.Location = new Point(229, 192);
            btnMul.Margin = new Padding(3, 2, 3, 2);
            btnMul.Name = "btnMul";
            btnMul.Size = new Size(63, 35);
            btnMul.TabIndex = 11;
            btnMul.Text = "X";
            btnMul.UseVisualStyleBackColor = false;
            btnMul.Click += btnMul_Click;
            // 
            // btnNine
            // 
            btnNine.BackColor = SystemColors.Window;
            btnNine.FlatStyle = FlatStyle.Flat;
            btnNine.Location = new Point(161, 192);
            btnNine.Margin = new Padding(3, 2, 3, 2);
            btnNine.Name = "btnNine";
            btnNine.Size = new Size(63, 35);
            btnNine.TabIndex = 10;
            btnNine.Text = "9";
            btnNine.UseVisualStyleBackColor = false;
            btnNine.Click += btnNine_Click;
            // 
            // btnEight
            // 
            btnEight.BackColor = SystemColors.Window;
            btnEight.FlatStyle = FlatStyle.Flat;
            btnEight.Location = new Point(93, 192);
            btnEight.Margin = new Padding(3, 2, 3, 2);
            btnEight.Name = "btnEight";
            btnEight.Size = new Size(63, 35);
            btnEight.TabIndex = 9;
            btnEight.Text = "8";
            btnEight.UseVisualStyleBackColor = false;
            btnEight.Click += btnEight_Click;
            // 
            // btnSeven
            // 
            btnSeven.BackColor = SystemColors.Window;
            btnSeven.FlatStyle = FlatStyle.Flat;
            btnSeven.Location = new Point(24, 192);
            btnSeven.Margin = new Padding(3, 2, 3, 2);
            btnSeven.Name = "btnSeven";
            btnSeven.Size = new Size(63, 35);
            btnSeven.TabIndex = 8;
            btnSeven.Text = "7";
            btnSeven.UseVisualStyleBackColor = false;
            btnSeven.Click += btnSeven_Click;
            // 
            // btnSub
            // 
            btnSub.BackColor = SystemColors.Window;
            btnSub.FlatStyle = FlatStyle.Flat;
            btnSub.Location = new Point(229, 232);
            btnSub.Margin = new Padding(3, 2, 3, 2);
            btnSub.Name = "btnSub";
            btnSub.Size = new Size(63, 35);
            btnSub.TabIndex = 15;
            btnSub.Text = "-";
            btnSub.UseVisualStyleBackColor = false;
            btnSub.Click += btnSub_Click;
            // 
            // btnSix
            // 
            btnSix.BackColor = SystemColors.Window;
            btnSix.FlatStyle = FlatStyle.Flat;
            btnSix.Location = new Point(161, 232);
            btnSix.Margin = new Padding(3, 2, 3, 2);
            btnSix.Name = "btnSix";
            btnSix.Size = new Size(63, 35);
            btnSix.TabIndex = 14;
            btnSix.Text = "6";
            btnSix.UseVisualStyleBackColor = false;
            btnSix.Click += btnSix_Click;
            // 
            // btnFive
            // 
            btnFive.BackColor = SystemColors.Window;
            btnFive.FlatStyle = FlatStyle.Flat;
            btnFive.Location = new Point(93, 232);
            btnFive.Margin = new Padding(3, 2, 3, 2);
            btnFive.Name = "btnFive";
            btnFive.Size = new Size(63, 35);
            btnFive.TabIndex = 13;
            btnFive.Text = "5";
            btnFive.UseVisualStyleBackColor = false;
            btnFive.Click += btnFive_Click;
            // 
            // btnFour
            // 
            btnFour.BackColor = SystemColors.Window;
            btnFour.FlatStyle = FlatStyle.Flat;
            btnFour.Location = new Point(24, 232);
            btnFour.Margin = new Padding(3, 2, 3, 2);
            btnFour.Name = "btnFour";
            btnFour.Size = new Size(63, 35);
            btnFour.TabIndex = 12;
            btnFour.Text = "4";
            btnFour.UseVisualStyleBackColor = false;
            btnFour.Click += btnFour_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.Window;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(229, 271);
            btnAdd.Margin = new Padding(3, 2, 3, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(63, 35);
            btnAdd.TabIndex = 19;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // buttonThree
            // 
            buttonThree.BackColor = SystemColors.Window;
            buttonThree.FlatStyle = FlatStyle.Flat;
            buttonThree.Location = new Point(161, 271);
            buttonThree.Margin = new Padding(3, 2, 3, 2);
            buttonThree.Name = "buttonThree";
            buttonThree.Size = new Size(63, 35);
            buttonThree.TabIndex = 18;
            buttonThree.Text = "3";
            buttonThree.UseVisualStyleBackColor = false;
            buttonThree.Click += buttonThree_Click;
            // 
            // btnTwo
            // 
            btnTwo.BackColor = SystemColors.Window;
            btnTwo.FlatStyle = FlatStyle.Flat;
            btnTwo.Location = new Point(93, 271);
            btnTwo.Margin = new Padding(3, 2, 3, 2);
            btnTwo.Name = "btnTwo";
            btnTwo.Size = new Size(63, 35);
            btnTwo.TabIndex = 17;
            btnTwo.Text = "2";
            btnTwo.UseVisualStyleBackColor = false;
            btnTwo.Click += btnTwo_Click;
            // 
            // btnOne
            // 
            btnOne.BackColor = SystemColors.Window;
            btnOne.FlatStyle = FlatStyle.Flat;
            btnOne.Location = new Point(24, 271);
            btnOne.Margin = new Padding(3, 2, 3, 2);
            btnOne.Name = "btnOne";
            btnOne.Size = new Size(63, 35);
            btnOne.TabIndex = 16;
            btnOne.Text = "1";
            btnOne.UseVisualStyleBackColor = false;
            btnOne.Click += btnOne_Click;
            // 
            // btnCalc
            // 
            btnCalc.BackColor = SystemColors.Window;
            btnCalc.FlatStyle = FlatStyle.Flat;
            btnCalc.Location = new Point(229, 311);
            btnCalc.Margin = new Padding(3, 2, 3, 2);
            btnCalc.Name = "btnCalc";
            btnCalc.Size = new Size(63, 35);
            btnCalc.TabIndex = 23;
            btnCalc.Text = "=";
            btnCalc.UseVisualStyleBackColor = false;
            btnCalc.Click += btnCalc_Click;
            // 
            // btnComma
            // 
            btnComma.BackColor = SystemColors.Window;
            btnComma.FlatStyle = FlatStyle.Flat;
            btnComma.Location = new Point(161, 311);
            btnComma.Margin = new Padding(3, 2, 3, 2);
            btnComma.Name = "btnComma";
            btnComma.Size = new Size(63, 35);
            btnComma.TabIndex = 22;
            btnComma.Text = ",";
            btnComma.UseVisualStyleBackColor = false;
            // 
            // btnZero
            // 
            btnZero.BackColor = SystemColors.Window;
            btnZero.FlatStyle = FlatStyle.Flat;
            btnZero.Location = new Point(93, 311);
            btnZero.Margin = new Padding(3, 2, 3, 2);
            btnZero.Name = "btnZero";
            btnZero.Size = new Size(63, 35);
            btnZero.TabIndex = 21;
            btnZero.Text = "0";
            btnZero.UseVisualStyleBackColor = false;
            btnZero.Click += btnZero_Click;
            // 
            // btnSign
            // 
            btnSign.BackColor = SystemColors.Window;
            btnSign.FlatStyle = FlatStyle.Flat;
            btnSign.Location = new Point(24, 311);
            btnSign.Margin = new Padding(3, 2, 3, 2);
            btnSign.Name = "btnSign";
            btnSign.Size = new Size(63, 35);
            btnSign.TabIndex = 20;
            btnSign.Text = "+/-";
            btnSign.UseVisualStyleBackColor = false;
            // 
            // txtPolynomial
            // 
            txtPolynomial.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtPolynomial.Location = new Point(24, 30);
            txtPolynomial.Margin = new Padding(3, 2, 3, 2);
            txtPolynomial.Name = "txtPolynomial";
            txtPolynomial.ReadOnly = true;
            txtPolynomial.Size = new Size(269, 26);
            txtPolynomial.TabIndex = 24;
            txtPolynomial.TextAlign = HorizontalAlignment.Right;
            // 
            // txtResult
            // 
            txtResult.BorderStyle = BorderStyle.FixedSingle;
            txtResult.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point);
            txtResult.Location = new Point(24, 60);
            txtResult.Margin = new Padding(3, 2, 3, 2);
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.Size = new Size(269, 44);
            txtResult.TabIndex = 25;
            txtResult.TextAlign = HorizontalAlignment.Right;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(299, 43);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 27;
            label1.Text = "Lịch sử phép tính";
            // 
            // lstHistory
            // 
            lstHistory.BackColor = SystemColors.ButtonFace;
            lstHistory.Location = new Point(299, 61);
            lstHistory.Name = "lstHistory";
            lstHistory.Size = new Size(298, 245);
            lstHistory.TabIndex = 28;
            lstHistory.UseCompatibleStateImageBehavior = false;
            // 
            // btnPercent
            // 
            btnPercent.BackColor = SystemColors.Window;
            btnPercent.FlatAppearance.BorderColor = Color.Black;
            btnPercent.FlatStyle = FlatStyle.Flat;
            btnPercent.ForeColor = SystemColors.MenuHighlight;
            btnPercent.Location = new Point(161, 152);
            btnPercent.Margin = new Padding(3, 2, 3, 2);
            btnPercent.Name = "btnPercent";
            btnPercent.Size = new Size(63, 35);
            btnPercent.TabIndex = 29;
            btnPercent.Tag = "";
            btnPercent.Text = "%";
            btnPercent.UseVisualStyleBackColor = false;
            btnPercent.Click += btnPercent_Click;
            // 
            // btnDeleteHistory
            // 
            btnDeleteHistory.BackColor = SystemColors.Window;
            btnDeleteHistory.FlatStyle = FlatStyle.Flat;
            btnDeleteHistory.Location = new Point(534, 311);
            btnDeleteHistory.Margin = new Padding(3, 2, 3, 2);
            btnDeleteHistory.Name = "btnDeleteHistory";
            btnDeleteHistory.Size = new Size(63, 35);
            btnDeleteHistory.TabIndex = 30;
            btnDeleteHistory.Text = "Xóa hết";
            btnDeleteHistory.UseVisualStyleBackColor = false;
            // 
            // btnLoadHistoryItem
            // 
            btnLoadHistoryItem.BackColor = SystemColors.Window;
            btnLoadHistoryItem.FlatStyle = FlatStyle.Flat;
            btnLoadHistoryItem.Location = new Point(299, 311);
            btnLoadHistoryItem.Margin = new Padding(3, 2, 3, 2);
            btnLoadHistoryItem.Name = "btnLoadHistoryItem";
            btnLoadHistoryItem.Size = new Size(63, 35);
            btnLoadHistoryItem.TabIndex = 31;
            btnLoadHistoryItem.Text = "Lấy lại";
            btnLoadHistoryItem.UseVisualStyleBackColor = false;
            // 
            // btnDeleteHistoryItem
            // 
            btnDeleteHistoryItem.BackColor = SystemColors.Window;
            btnDeleteHistoryItem.FlatStyle = FlatStyle.Flat;
            btnDeleteHistoryItem.Location = new Point(368, 311);
            btnDeleteHistoryItem.Margin = new Padding(3, 2, 3, 2);
            btnDeleteHistoryItem.Name = "btnDeleteHistoryItem";
            btnDeleteHistoryItem.Size = new Size(63, 35);
            btnDeleteHistoryItem.TabIndex = 32;
            btnDeleteHistoryItem.Text = "Xóa";
            btnDeleteHistoryItem.UseVisualStyleBackColor = false;
            // 
            // CalculatorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(621, 366);
            Controls.Add(btnDeleteHistoryItem);
            Controls.Add(btnLoadHistoryItem);
            Controls.Add(btnDeleteHistory);
            Controls.Add(btnPercent);
            Controls.Add(lstHistory);
            Controls.Add(label1);
            Controls.Add(txtResult);
            Controls.Add(txtPolynomial);
            Controls.Add(btnCalc);
            Controls.Add(btnComma);
            Controls.Add(btnZero);
            Controls.Add(btnSign);
            Controls.Add(btnAdd);
            Controls.Add(buttonThree);
            Controls.Add(btnTwo);
            Controls.Add(btnOne);
            Controls.Add(btnSub);
            Controls.Add(btnSix);
            Controls.Add(btnFive);
            Controls.Add(btnFour);
            Controls.Add(btnMul);
            Controls.Add(btnNine);
            Controls.Add(btnEight);
            Controls.Add(btnSeven);
            Controls.Add(btnDiv);
            Controls.Add(btnCloseBracket);
            Controls.Add(btnOpenBracket);
            Controls.Add(btnBackspace);
            Controls.Add(btnClearAll);
            Controls.Add(btnSaveToHistory);
            Margin = new Padding(3, 2, 3, 2);
            Name = "CalculatorForm";
            Text = "SIMPLE CALCULATOR";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSaveToHistory;
        private Button btnClearAll;
        private Button btnBackspace;
        private Button btnDiv;
        private Button btnCloseBracket;
        private Button btnOpenBracket;
        private Button btnMul;
        private Button btnNine;
        private Button btnEight;
        private Button btnSeven;
        private Button btnSub;
        private Button btnSix;
        private Button btnFive;
        private Button btnFour;
        private Button btnAdd;
        private Button buttonThree;
        private Button btnTwo;
        private Button btnOne;
        private Button btnCalc;
        private Button btnComma;
        private Button btnZero;
        private Button btnSign;
        private TextBox txtPolynomial;
        private TextBox txtResult;
        private Label label1;
        private ListView lstHistory;
        private Button btnPercent;
        private Button btnDeleteHistory;
        private Button btnLoadHistoryItem;
        private Button btnDeleteHistoryItem;
    }
}