namespace CogntiveDemos
{
    partial class frmTranslator
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
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnTranslate = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.chkListBoxLanguages = new System.Windows.Forms.CheckedListBox();
            this.btnLanguages = new System.Windows.Forms.Button();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.txtLanguages = new System.Windows.Forms.TextBox();
            this.btnDetectLanguage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(34, 62);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(219, 259);
            this.txtInput.TabIndex = 0;
            this.txtInput.Text = "Hello World";
            // 
            // btnTranslate
            // 
            this.btnTranslate.Location = new System.Drawing.Point(561, 363);
            this.btnTranslate.Name = "btnTranslate";
            this.btnTranslate.Size = new System.Drawing.Size(150, 46);
            this.btnTranslate.TabIndex = 1;
            this.btnTranslate.Text = "&Translate";
            this.btnTranslate.UseVisualStyleBackColor = true;
            this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(762, 62);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(349, 545);
            this.txtOutput.TabIndex = 2;
            // 
            // chkListBoxLanguages
            // 
            this.chkListBoxLanguages.FormattingEnabled = true;
            this.chkListBoxLanguages.Location = new System.Drawing.Point(542, 130);
            this.chkListBoxLanguages.Name = "chkListBoxLanguages";
            this.chkListBoxLanguages.Size = new System.Drawing.Size(194, 172);
            this.chkListBoxLanguages.TabIndex = 3;
            // 
            // btnLanguages
            // 
            this.btnLanguages.Location = new System.Drawing.Point(288, 62);
            this.btnLanguages.Name = "btnLanguages";
            this.btnLanguages.Size = new System.Drawing.Size(235, 46);
            this.btnLanguages.TabIndex = 4;
            this.btnLanguages.Text = "&Get Supported Languages";
            this.btnLanguages.UseVisualStyleBackColor = true;
            this.btnLanguages.Click += new System.EventHandler(this.btnLanguages_Click);
            // 
            // dgv1
            // 
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(12, 441);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowTemplate.Height = 28;
            this.dgv1.Size = new System.Drawing.Size(252, 135);
            this.dgv1.TabIndex = 5;
            this.dgv1.Visible = false;
            // 
            // txtLanguages
            // 
            this.txtLanguages.Location = new System.Drawing.Point(288, 130);
            this.txtLanguages.Multiline = true;
            this.txtLanguages.Name = "txtLanguages";
            this.txtLanguages.ReadOnly = true;
            this.txtLanguages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLanguages.Size = new System.Drawing.Size(235, 477);
            this.txtLanguages.TabIndex = 6;
            // 
            // btnDetectLanguage
            // 
            this.btnDetectLanguage.Location = new System.Drawing.Point(561, 427);
            this.btnDetectLanguage.Name = "btnDetectLanguage";
            this.btnDetectLanguage.Size = new System.Drawing.Size(150, 46);
            this.btnDetectLanguage.TabIndex = 7;
            this.btnDetectLanguage.Text = "&Detect Language";
            this.btnDetectLanguage.UseVisualStyleBackColor = true;
            this.btnDetectLanguage.Click += new System.EventHandler(this.btnDetectLanguage_Click);
            // 
            // frmCognitiveDemos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 658);
            this.Controls.Add(this.btnDetectLanguage);
            this.Controls.Add(this.txtLanguages);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.btnLanguages);
            this.Controls.Add(this.chkListBoxLanguages);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnTranslate);
            this.Controls.Add(this.txtInput);
            this.Name = "frmCognitiveDemos";
            this.Text = "Translator Demo";
            this.Load += new System.EventHandler(this.frmCognitiveDemos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnTranslate;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.CheckedListBox chkListBoxLanguages;
        private System.Windows.Forms.Button btnLanguages;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.TextBox txtLanguages;
        private System.Windows.Forms.Button btnDetectLanguage;
    }
}

