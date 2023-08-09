namespace Accounting.App
{
    partial class newfrmAccounting
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(newfrmAccounting));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgCustomers = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtFillter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbRecive = new System.Windows.Forms.RadioButton();
            this.rbPay = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.rangeValidator1 = new ValidationComponents.RangeValidator(this.components);
            this.requiredFieldValidator1 = new ValidationComponents.RequiredFieldValidator(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgCustomers);
            this.groupBox1.Controls.Add(this.txtFillter);
            this.groupBox1.Location = new System.Drawing.Point(342, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 320);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اشخاص";
            // 
            // dgCustomers
            // 
            this.dgCustomers.AllowUserToAddRows = false;
            this.dgCustomers.AllowUserToDeleteRows = false;
            this.dgCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dgCustomers.Location = new System.Drawing.Point(6, 53);
            this.dgCustomers.Name = "dgCustomers";
            this.dgCustomers.ReadOnly = true;
            this.dgCustomers.Size = new System.Drawing.Size(175, 261);
            this.dgCustomers.TabIndex = 1;
            this.dgCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCustomers_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "FullName";
            this.Column1.HeaderText = "نام شخص";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // txtFillter
            // 
            this.txtFillter.Location = new System.Drawing.Point(6, 23);
            this.txtFillter.Name = "txtFillter";
            this.txtFillter.Size = new System.Drawing.Size(175, 23);
            this.txtFillter.TabIndex = 0;
            this.txtFillter.TextChanged += new System.EventHandler(this.txtFillter_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "طرف حساب :";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(91, 35);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(232, 23);
            this.txtName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "نوع تراکنش :";
            // 
            // rbRecive
            // 
            this.rbRecive.AutoSize = true;
            this.rbRecive.Location = new System.Drawing.Point(112, 68);
            this.rbRecive.Name = "rbRecive";
            this.rbRecive.Size = new System.Drawing.Size(61, 19);
            this.rbRecive.TabIndex = 4;
            this.rbRecive.TabStop = true;
            this.rbRecive.Text = "دریافت";
            this.rbRecive.UseVisualStyleBackColor = true;
            // 
            // rbPay
            // 
            this.rbPay.AutoSize = true;
            this.rbPay.Location = new System.Drawing.Point(236, 68);
            this.rbPay.Name = "rbPay";
            this.rbPay.Size = new System.Drawing.Size(60, 19);
            this.rbPay.TabIndex = 5;
            this.rbPay.TabStop = true;
            this.rbPay.Text = "پرداخت";
            this.rbPay.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "مبلغ :";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(91, 99);
            this.txtAmount.Maximum = new decimal(new int[] {
            268435455,
            1042612833,
            542101086,
            0});
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(232, 23);
            this.txtAmount.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "شرح :";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(91, 128);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(232, 175);
            this.txtDescription.TabIndex = 9;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(91, 309);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(232, 23);
            this.btnSubmit.TabIndex = 10;
            this.btnSubmit.Text = "ثبت تراکنش";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // rangeValidator1
            // 
            this.rangeValidator1.CancelFocusChangeWhenInvalid = false;
            this.rangeValidator1.ControlToValidate = this.txtAmount;
            this.rangeValidator1.ErrorMessage = "مبلغ نمی تواند خالی باشد";
            this.rangeValidator1.Icon = ((System.Drawing.Icon)(resources.GetObject("rangeValidator1.Icon")));
            this.rangeValidator1.MaximumValue = "999999999999999999";
            this.rangeValidator1.MinimumValue = "1";
            this.rangeValidator1.Type = ValidationComponents.ValidationDataType.Integer;
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.CancelFocusChangeWhenInvalid = false;
            this.requiredFieldValidator1.ControlToValidate = this.txtName;
            this.requiredFieldValidator1.ErrorMessage = "طرف حساب خود را از لیست اشخاص انتخاب کنید";
            this.requiredFieldValidator1.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator1.Icon")));
            // 
            // newfrmAccounting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 344);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rbPay);
            this.Controls.Add(this.rbRecive);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "newfrmAccounting";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تراکنش جدید";
            this.Load += new System.EventHandler(this.newfrmAccounting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgCustomers;
        private System.Windows.Forms.TextBox txtFillter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbRecive;
        private System.Windows.Forms.RadioButton rbPay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnSubmit;
        private ValidationComponents.RangeValidator rangeValidator1;
        private ValidationComponents.RequiredFieldValidator requiredFieldValidator1;
    }
}