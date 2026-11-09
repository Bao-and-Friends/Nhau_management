namespace RestaurantManagement.UI
{
    partial class TestQMK
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
            Usernametxt = new Sunny.UI.UITextBox();
            SendOTP = new Sunny.UI.UIButton();
            SuspendLayout();
            // 
            // Usernametxt
            // 
            Usernametxt.Font = new Font("Microsoft Sans Serif", 12F);
            Usernametxt.Location = new Point(264, 126);
            Usernametxt.Margin = new Padding(4, 5, 4, 5);
            Usernametxt.MinimumSize = new Size(1, 16);
            Usernametxt.Name = "Usernametxt";
            Usernametxt.Padding = new Padding(5);
            Usernametxt.ShowText = false;
            Usernametxt.Size = new Size(225, 44);
            Usernametxt.TabIndex = 0;
            Usernametxt.TextAlignment = ContentAlignment.MiddleLeft;
            Usernametxt.Watermark = "";
            // 
            // SendOTP
            // 
            SendOTP.Font = new Font("Microsoft Sans Serif", 12F);
            SendOTP.Location = new Point(298, 265);
            SendOTP.MinimumSize = new Size(1, 1);
            SendOTP.Name = "SendOTP";
            SendOTP.Size = new Size(150, 52);
            SendOTP.TabIndex = 3;
            SendOTP.Text = "Gửi";
            SendOTP.TipsFont = new Font("Microsoft Sans Serif", 9F);
            SendOTP.Click += SendOTP_Click;
            // 
            // TestQMK
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SendOTP);
            Controls.Add(Usernametxt);
            Name = "TestQMK";
            Text = "TestQMK";
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UITextBox Usernametxt;
        private Sunny.UI.UIButton SendOTP;
    }
}