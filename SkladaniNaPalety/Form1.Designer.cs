namespace SkladaniNaPalety
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.runButton = new System.Windows.Forms.Button();
            this.palletWidthValue = new System.Windows.Forms.NumericUpDown();
            this.palletHeightValue = new System.Windows.Forms.NumericUpDown();
            this.boxWidthValue = new System.Windows.Forms.NumericUpDown();
            this.boxHeightValue = new System.Windows.Forms.NumericUpDown();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.chosenAlgoValue = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.areaBound = new System.Windows.Forms.Label();
            this.barnesBound = new System.Windows.Forms.Label();
            this.shiftInBoxes = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.palletWidthValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palletHeightValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxWidthValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxHeightValue)).BeginInit();
            this.SuspendLayout();
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(12, 288);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 0;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // palletWidthValue
            // 
            this.palletWidthValue.Location = new System.Drawing.Point(12, 54);
            this.palletWidthValue.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.palletWidthValue.Name = "palletWidthValue";
            this.palletWidthValue.Size = new System.Drawing.Size(75, 20);
            this.palletWidthValue.TabIndex = 1;
            this.palletWidthValue.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // palletHeightValue
            // 
            this.palletHeightValue.Location = new System.Drawing.Point(12, 105);
            this.palletHeightValue.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.palletHeightValue.Name = "palletHeightValue";
            this.palletHeightValue.Size = new System.Drawing.Size(75, 20);
            this.palletHeightValue.TabIndex = 2;
            this.palletHeightValue.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // boxWidthValue
            // 
            this.boxWidthValue.Location = new System.Drawing.Point(12, 153);
            this.boxWidthValue.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.boxWidthValue.Name = "boxWidthValue";
            this.boxWidthValue.Size = new System.Drawing.Size(75, 20);
            this.boxWidthValue.TabIndex = 3;
            this.boxWidthValue.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // boxHeightValue
            // 
            this.boxHeightValue.Location = new System.Drawing.Point(12, 203);
            this.boxHeightValue.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.boxHeightValue.Name = "boxHeightValue";
            this.boxHeightValue.Size = new System.Drawing.Size(75, 20);
            this.boxHeightValue.TabIndex = 4;
            this.boxHeightValue.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 336);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // chosenAlgoValue
            // 
            this.chosenAlgoValue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chosenAlgoValue.FormattingEnabled = true;
            this.chosenAlgoValue.Items.AddRange(new object[] {
            "5-block heuristic",
            "ecursive 5-block heuristic",
            "genetic programming"});
            this.chosenAlgoValue.Location = new System.Drawing.Point(12, 251);
            this.chosenAlgoValue.Name = "chosenAlgoValue";
            this.chosenAlgoValue.Size = new System.Drawing.Size(121, 21);
            this.chosenAlgoValue.Sorted = true;
            this.chosenAlgoValue.TabIndex = 1;
            this.chosenAlgoValue.Text = "Chose";
            this.chosenAlgoValue.SelectedIndexChanged += new System.EventHandler(this.chosenAlgoValue_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "width X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "height Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "width a";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "height b";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Algorithm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Progress";
            // 
            // areaBound
            // 
            this.areaBound.AutoSize = true;
            this.areaBound.Location = new System.Drawing.Point(12, 378);
            this.areaBound.Name = "areaBound";
            this.areaBound.Size = new System.Drawing.Size(68, 13);
            this.areaBound.TabIndex = 13;
            this.areaBound.Text = "Area bound: ";
            // 
            // barnesBound
            // 
            this.barnesBound.AutoSize = true;
            this.barnesBound.Location = new System.Drawing.Point(12, 400);
            this.barnesBound.Name = "barnesBound";
            this.barnesBound.Size = new System.Drawing.Size(79, 13);
            this.barnesBound.TabIndex = 14;
            this.barnesBound.Text = "Barnes bound: ";
            // 
            // shiftInBoxes
            // 
            this.shiftInBoxes.AutoSize = true;
            this.shiftInBoxes.Location = new System.Drawing.Point(12, 425);
            this.shiftInBoxes.Name = "shiftInBoxes";
            this.shiftInBoxes.Size = new System.Drawing.Size(35, 13);
            this.shiftInBoxes.TabIndex = 15;
            this.shiftInBoxes.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 442);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "label8";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.shiftInBoxes);
            this.Controls.Add(this.barnesBound);
            this.Controls.Add(this.areaBound);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chosenAlgoValue);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.boxHeightValue);
            this.Controls.Add(this.boxWidthValue);
            this.Controls.Add(this.palletHeightValue);
            this.Controls.Add(this.palletWidthValue);
            this.Controls.Add(this.runButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.palletWidthValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palletHeightValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxWidthValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxHeightValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.NumericUpDown palletWidthValue;
        private System.Windows.Forms.NumericUpDown palletHeightValue;
        private System.Windows.Forms.NumericUpDown boxWidthValue;
        private System.Windows.Forms.NumericUpDown boxHeightValue;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox chosenAlgoValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label areaBound;
        private System.Windows.Forms.Label barnesBound;
        private System.Windows.Forms.Label shiftInBoxes;
        private System.Windows.Forms.Label label8;
    }
}

