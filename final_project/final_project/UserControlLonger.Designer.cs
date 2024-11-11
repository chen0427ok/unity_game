namespace final_project
{
    partial class UserControlLonger
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelday = new System.Windows.Forms.Label();
            this.labelweek = new System.Windows.Forms.Label();
            this.label_insert = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelday
            // 
            this.labelday.AutoSize = true;
            this.labelday.Font = new System.Drawing.Font("Perpetua Titling MT", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelday.Location = new System.Drawing.Point(26, 19);
            this.labelday.Name = "labelday";
            this.labelday.Size = new System.Drawing.Size(83, 60);
            this.labelday.TabIndex = 0;
            this.labelday.Text = "27";
            // 
            // labelweek
            // 
            this.labelweek.AutoSize = true;
            this.labelweek.Font = new System.Drawing.Font("Perpetua Titling MT", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelweek.Location = new System.Drawing.Point(31, 79);
            this.labelweek.Name = "labelweek";
            this.labelweek.Size = new System.Drawing.Size(142, 30);
            this.labelweek.TabIndex = 1;
            this.labelweek.Text = "Monday";
            // 
            // label_insert
            // 
            this.label_insert.AutoSize = true;
            this.label_insert.Location = new System.Drawing.Point(417, 74);
            this.label_insert.Name = "label_insert";
            this.label_insert.Size = new System.Drawing.Size(0, 15);
            this.label_insert.TabIndex = 2;
            // 
            // UserControlLonger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.label_insert);
            this.Controls.Add(this.labelweek);
            this.Controls.Add(this.labelday);
            this.Name = "UserControlLonger";
            this.Size = new System.Drawing.Size(1129, 135);
            this.Load += new System.EventHandler(this.UserControlLonger_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelday;
        private System.Windows.Forms.Label labelweek;
        private System.Windows.Forms.Label label_insert;
    }
}
