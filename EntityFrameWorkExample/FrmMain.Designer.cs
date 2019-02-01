namespace EntityFrameWorkExample
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.btnEmpList = new System.Windows.Forms.Button();
            this.btnEmpReg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEmpList
            // 
            this.btnEmpList.Image = global::EntityFrameWorkExample.Properties.Resources._1479748737_preferences_contact_list;
            this.btnEmpList.Location = new System.Drawing.Point(12, 96);
            this.btnEmpList.Name = "btnEmpList";
            this.btnEmpList.Size = new System.Drawing.Size(134, 174);
            this.btnEmpList.TabIndex = 1;
            this.btnEmpList.Text = "سجل الموظفين";
            this.btnEmpList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEmpList.UseVisualStyleBackColor = true;
            this.btnEmpList.Click += new System.EventHandler(this.btnEmpList_Click);
            // 
            // btnEmpReg
            // 
            this.btnEmpReg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEmpReg.Image = ((System.Drawing.Image)(resources.GetObject("btnEmpReg.Image")));
            this.btnEmpReg.Location = new System.Drawing.Point(244, 96);
            this.btnEmpReg.Name = "btnEmpReg";
            this.btnEmpReg.Size = new System.Drawing.Size(134, 174);
            this.btnEmpReg.TabIndex = 0;
            this.btnEmpReg.Text = "تسجيل الموظفين";
            this.btnEmpReg.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEmpReg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEmpReg.UseVisualStyleBackColor = true;
            this.btnEmpReg.Click += new System.EventHandler(this.btnEmpReg_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(399, 313);
            this.Controls.Add(this.btnEmpList);
            this.Controls.Add(this.btnEmpReg);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الشاشة الرئيسية";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEmpReg;
        private System.Windows.Forms.Button btnEmpList;
    }
}