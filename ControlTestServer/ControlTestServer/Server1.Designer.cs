using System;

namespace ControlTestServer
{
    partial class Server1
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
            //KillThread();
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
            this.BUT_HostServer = new System.Windows.Forms.Button();
            this.txt_ServerName = new System.Windows.Forms.TextBox();
            this.Msg_TextBox = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BUT_HostServer
            // 
            this.BUT_HostServer.Location = new System.Drawing.Point(170, 10);
            this.BUT_HostServer.Name = "BUT_HostServer";
            this.BUT_HostServer.Size = new System.Drawing.Size(44, 22);
            this.BUT_HostServer.TabIndex = 0;
            this.BUT_HostServer.Text = "Host Server!";
            this.BUT_HostServer.UseVisualStyleBackColor = true;
            this.BUT_HostServer.Click += new System.EventHandler(this.BUT_HostServer_Click);
            // 
            // txt_ServerName
            // 
            this.txt_ServerName.Location = new System.Drawing.Point(12, 12);
            this.txt_ServerName.Name = "txt_ServerName";
            this.txt_ServerName.Size = new System.Drawing.Size(128, 22);
            this.txt_ServerName.TabIndex = 1;
            // 
            // Msg_TextBox
            // 
            this.Msg_TextBox.Location = new System.Drawing.Point(13, 80);
            this.Msg_TextBox.Name = "Msg_TextBox";
            this.Msg_TextBox.Size = new System.Drawing.Size(127, 22);
            this.Msg_TextBox.TabIndex = 2;
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(170, 78);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(44, 23);
            this.SendButton.TabIndex = 3;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // Server1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 131);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.Msg_TextBox);
            this.Controls.Add(this.txt_ServerName);
            this.Controls.Add(this.BUT_HostServer);
            this.Name = "Server1";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BUT_HostServer;
        private System.Windows.Forms.TextBox txt_ServerName;
        private System.Windows.Forms.TextBox Msg_TextBox;
        private System.Windows.Forms.Button SendButton;
    }
}

