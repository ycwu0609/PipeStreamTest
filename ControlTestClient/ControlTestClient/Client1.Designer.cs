namespace ControlTestClient
{
    partial class Client1
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
            KillThread();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.BUT_SendMsg = new System.Windows.Forms.Button();
            this.TXT_InputBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BUT_SendMsg
            // 
            this.BUT_SendMsg.Location = new System.Drawing.Point(300, 19);
            this.BUT_SendMsg.Name = "BUT_SendMsg";
            this.BUT_SendMsg.Size = new System.Drawing.Size(75, 23);
            this.BUT_SendMsg.TabIndex = 1;
            this.BUT_SendMsg.Text = "Send";
            this.BUT_SendMsg.UseVisualStyleBackColor = true;
            this.BUT_SendMsg.Click += new System.EventHandler(this.BUT_SendMsg_Click);
            // 
            // TXT_InputBox
            // 
            this.TXT_InputBox.Location = new System.Drawing.Point(12, 20);
            this.TXT_InputBox.Name = "TXT_InputBox";
            this.TXT_InputBox.Size = new System.Drawing.Size(282, 22);
            this.TXT_InputBox.TabIndex = 2;
            this.TXT_InputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TXT_InputBox_KeyPress);
            // 
            // Client1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 61);
            this.Controls.Add(this.TXT_InputBox);
            this.Controls.Add(this.BUT_SendMsg);
            this.Name = "Client1";
            this.Text = "Client1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BUT_SendMsg;
        private System.Windows.Forms.TextBox TXT_InputBox;
    }
}

