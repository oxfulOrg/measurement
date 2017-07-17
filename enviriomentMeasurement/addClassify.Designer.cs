namespace enviriomentMeasurement
{
    partial class addClassify
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
            this.add = new System.Windows.Forms.Button();
            this.addClassifyRichTextBox = new System.Windows.Forms.RichTextBox();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(73, 168);
            this.add.Margin = new System.Windows.Forms.Padding(4);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(100, 31);
            this.add.TabIndex = 0;
            this.add.Text = "添加";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // addClassifyRichTextBox
            // 
            this.addClassifyRichTextBox.Location = new System.Drawing.Point(4, 16);
            this.addClassifyRichTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.addClassifyRichTextBox.Name = "addClassifyRichTextBox";
            this.addClassifyRichTextBox.Size = new System.Drawing.Size(404, 127);
            this.addClassifyRichTextBox.TabIndex = 1;
            this.addClassifyRichTextBox.Text = "";
            this.addClassifyRichTextBox.TextChanged += new System.EventHandler(this.addClassifyRichTextBox_TextChanged);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(224, 168);
            this.cancel.Margin = new System.Windows.Forms.Padding(4);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(100, 31);
            this.cancel.TabIndex = 0;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // addClassify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 227);
            this.Controls.Add(this.addClassifyRichTextBox);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.add);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "addClassify";
            this.Text = "添加测试对象";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.addClassify_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button add;
        private System.Windows.Forms.RichTextBox addClassifyRichTextBox;
        private System.Windows.Forms.Button cancel;
    }
}