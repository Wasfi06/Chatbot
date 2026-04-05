namespace ChatbotGUI
{
    partial class Form1
    {

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RichTextBox chatBox;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Button sendButton;

        private void InitializeComponent()
        {
            this.chatBox = new System.Windows.Forms.RichTextBox();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chatBox
            // 
            this.chatBox.Location = new System.Drawing.Point(59, 31);
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.Size = new System.Drawing.Size(413, 281);
            this.chatBox.TabIndex = 0;
            this.chatBox.Text = "";
            // 
            // inputBox
            // 
            this.inputBox.Location = new System.Drawing.Point(14, 321);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(360, 22);
            this.inputBox.TabIndex = 1;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(380, 318);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(92, 25);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Send";
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(789, 475);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.sendButton);
            this.Name = "Form1";
            this.Text = "Cybersecurity Awareness Bot";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}

