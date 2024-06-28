namespace PassWordGenerator
{
    partial class PassWordGenerator
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.generatorBtn = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.passwordLengthUpDown = new System.Windows.Forms.NumericUpDown();
            this.passwordLengthLabel = new System.Windows.Forms.Label();
            this.mailCmb = new System.Windows.Forms.ComboBox();
            this.mailLable = new System.Windows.Forms.Label();
            this.passwordPatternCmb = new System.Windows.Forms.ComboBox();
            this.passwordPatternLabel = new System.Windows.Forms.Label();
            this.Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.passwordLengthUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(12, 84);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(315, 19);
            this.nameTextBox.TabIndex = 3;
            // 
            // generatorBtn
            // 
            this.generatorBtn.Location = new System.Drawing.Point(343, 82);
            this.generatorBtn.Name = "generatorBtn";
            this.generatorBtn.Size = new System.Drawing.Size(75, 23);
            this.generatorBtn.TabIndex = 4;
            this.generatorBtn.Text = "生成";
            this.generatorBtn.UseVisualStyleBackColor = true;
            this.generatorBtn.Click += new System.EventHandler(this.generatorBtn_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 66);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(34, 12);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Name";
            // 
            // passwordLengthUpDown
            // 
            this.passwordLengthUpDown.Location = new System.Drawing.Point(12, 137);
            this.passwordLengthUpDown.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.passwordLengthUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.passwordLengthUpDown.Name = "passwordLengthUpDown";
            this.passwordLengthUpDown.Size = new System.Drawing.Size(76, 19);
            this.passwordLengthUpDown.TabIndex = 6;
            this.passwordLengthUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // passwordLengthLabel
            // 
            this.passwordLengthLabel.AutoSize = true;
            this.passwordLengthLabel.Location = new System.Drawing.Point(12, 122);
            this.passwordLengthLabel.Name = "passwordLengthLabel";
            this.passwordLengthLabel.Size = new System.Drawing.Size(76, 12);
            this.passwordLengthLabel.TabIndex = 5;
            this.passwordLengthLabel.Text = "パスワード桁数";
            // 
            // mailCmb
            // 
            this.mailCmb.FormattingEnabled = true;
            this.mailCmb.Location = new System.Drawing.Point(12, 37);
            this.mailCmb.Name = "mailCmb";
            this.mailCmb.Size = new System.Drawing.Size(315, 20);
            this.mailCmb.TabIndex = 1;
            // 
            // mailLable
            // 
            this.mailLable.AutoSize = true;
            this.mailLable.Location = new System.Drawing.Point(12, 18);
            this.mailLable.Name = "mailLable";
            this.mailLable.Size = new System.Drawing.Size(69, 12);
            this.mailLable.TabIndex = 0;
            this.mailLable.Text = "メールアドレス";
            // 
            // passwordPatternCmb
            // 
            this.passwordPatternCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.passwordPatternCmb.FormattingEnabled = true;
            this.passwordPatternCmb.Items.AddRange(new object[] {
            "英数字記号",
            "英数字",
            "英数字(大)",
            "英数字(小)"});
            this.passwordPatternCmb.Location = new System.Drawing.Point(112, 136);
            this.passwordPatternCmb.Name = "passwordPatternCmb";
            this.passwordPatternCmb.Size = new System.Drawing.Size(126, 20);
            this.passwordPatternCmb.TabIndex = 7;
            // 
            // passwordPatternLabel
            // 
            this.passwordPatternLabel.AutoSize = true;
            this.passwordPatternLabel.Location = new System.Drawing.Point(110, 121);
            this.passwordPatternLabel.Name = "passwordPatternLabel";
            this.passwordPatternLabel.Size = new System.Drawing.Size(86, 12);
            this.passwordPatternLabel.TabIndex = 8;
            this.passwordPatternLabel.Text = "パスワード組合せ";
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.Location = new System.Drawing.Point(333, 158);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(93, 12);
            this.Label.TabIndex = 9;
            this.Label.Text = "© 2023 木村憂哉";
            // 
            // PassWordGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 174);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.passwordPatternLabel);
            this.Controls.Add(this.passwordPatternCmb);
            this.Controls.Add(this.mailLable);
            this.Controls.Add(this.mailCmb);
            this.Controls.Add(this.passwordLengthLabel);
            this.Controls.Add(this.passwordLengthUpDown);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.generatorBtn);
            this.Controls.Add(this.nameTextBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(447, 213);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(447, 213);
            this.Name = "PassWordGenerator";
            this.Text = "パスワード生成";
            ((System.ComponentModel.ISupportInitialize)(this.passwordLengthUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button generatorBtn;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.NumericUpDown passwordLengthUpDown;
        private System.Windows.Forms.Label passwordLengthLabel;
        private System.Windows.Forms.ComboBox mailCmb;
        private System.Windows.Forms.Label mailLable;
        private System.Windows.Forms.ComboBox passwordPatternCmb;
        private System.Windows.Forms.Label passwordPatternLabel;
        private System.Windows.Forms.Label Label;
    }
}

