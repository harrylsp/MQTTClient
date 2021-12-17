namespace MQTTClient
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtTopic = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPayload = new System.Windows.Forms.TextBox();
            this.btnPublish = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnSubscribe = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(54, 57);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtTopic
            // 
            this.txtTopic.Location = new System.Drawing.Point(54, 301);
            this.txtTopic.Name = "txtTopic";
            this.txtTopic.Size = new System.Drawing.Size(166, 21);
            this.txtTopic.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "主题";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 355);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "内容";
            // 
            // txtPayload
            // 
            this.txtPayload.Location = new System.Drawing.Point(54, 382);
            this.txtPayload.Name = "txtPayload";
            this.txtPayload.Size = new System.Drawing.Size(166, 21);
            this.txtPayload.TabIndex = 4;
            // 
            // btnPublish
            // 
            this.btnPublish.Location = new System.Drawing.Point(145, 415);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(75, 23);
            this.btnPublish.TabIndex = 5;
            this.btnPublish.Text = "发布";
            this.btnPublish.UseVisualStyleBackColor = true;
            this.btnPublish.Click += new System.EventHandler(this.btnPublic_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(54, 108);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(166, 147);
            this.txtMessage.TabIndex = 6;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(145, 57);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 7;
            this.btnDisconnect.Text = "断开";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnSubscribe
            // 
            this.btnSubscribe.Location = new System.Drawing.Point(54, 415);
            this.btnSubscribe.Name = "btnSubscribe";
            this.btnSubscribe.Size = new System.Drawing.Size(75, 23);
            this.btnSubscribe.TabIndex = 8;
            this.btnSubscribe.Text = "订阅";
            this.btnSubscribe.UseVisualStyleBackColor = true;
            this.btnSubscribe.Click += new System.EventHandler(this.txtSubscribe_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(54, 25);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(166, 21);
            this.txtIP.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 450);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.btnSubscribe);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnPublish);
            this.Controls.Add(this.txtPayload);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTopic);
            this.Controls.Add(this.btnConnect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtTopic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPayload;
        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnSubscribe;
        private System.Windows.Forms.TextBox txtIP;
    }
}

