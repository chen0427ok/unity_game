namespace final_project
{
    partial class UserControlDays
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
            this.lbdays = new System.Windows.Forms.Label();
            this.label_insert = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbdays
            // 
            this.lbdays.AutoSize = true;
            this.lbdays.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbdays.Location = new System.Drawing.Point(47, 19);
            this.lbdays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbdays.Name = "lbdays";
            this.lbdays.Size = new System.Drawing.Size(53, 19);
            this.lbdays.TabIndex = 0;
            this.lbdays.Text = "label1";
            // 
            // label_insert
            // 
            this.label_insert.AutoSize = true;
            this.label_insert.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_insert.Location = new System.Drawing.Point(15, 78);
            this.label_insert.Name = "label_insert";
            this.label_insert.Size = new System.Drawing.Size(0, 19);
            this.label_insert.TabIndex = 1;
            this.label_insert.Click += new System.EventHandler(this.UserControlDays_Load);
            // 
            // UserControlDays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.label_insert);
            this.Controls.Add(this.lbdays);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserControlDays";
            this.Size = new System.Drawing.Size(150, 141);
            this.Load += new System.EventHandler(this.UserControlDays_Load);
            this.Click += new System.EventHandler(this.UserControlDays_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbdays;
        private System.Windows.Forms.Label label_insert;
    }
}
