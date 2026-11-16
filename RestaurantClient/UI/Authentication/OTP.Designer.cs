namespace RestaurantManagement.UI
{
    partial class OTP
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
            OTPVerify = new Sunny.UI.UIButton();
            Otptxt = new Sunny.UI.UITextBox();
            ResendOTPbtn = new Sunny.UI.UIButton();
            SuspendLayout();
            // 
            // OTPVerify
            // 
            OTPVerify.Font = new Font("Microsoft Sans Serif", 12F);
            OTPVerify.Location = new Point(322, 269);
            OTPVerify.MinimumSize = new Size(1, 1);
            OTPVerify.Name = "OTPVerify";
            OTPVerify.Size = new Size(168, 52);
            OTPVerify.TabIndex = 5;
            OTPVerify.Text = "Xác nhận OTP";
            OTPVerify.TipsFont = new Font("Microsoft Sans Serif", 9F);
            OTPVerify.Click += OTPVerify_Click;
            // 
            // Otptxt
            // 
            Otptxt.Font = new Font("Microsoft Sans Serif", 12F);
            Otptxt.Location = new Point(288, 130);
            Otptxt.Margin = new Padding(4, 5, 4, 5);
            Otptxt.MinimumSize = new Size(1, 16);
            Otptxt.Name = "Otptxt";
            Otptxt.Padding = new Padding(5);
            Otptxt.ShowText = false;
            Otptxt.Size = new Size(225, 44);
            Otptxt.TabIndex = 4;
            Otptxt.TextAlignment = ContentAlignment.MiddleLeft;
            Otptxt.Watermark = "";
            // 
            // ResendOTPbtn
            // 
            ResendOTPbtn.Font = new Font("Microsoft Sans Serif", 12F);
            ResendOTPbtn.Location = new Point(325, 199);
            ResendOTPbtn.MinimumSize = new Size(1, 1);
            ResendOTPbtn.Name = "ResendOTPbtn";
            ResendOTPbtn.Size = new Size(165, 52);
            ResendOTPbtn.TabIndex = 6;
            ResendOTPbtn.Text = "Gửi lại OTP";
            ResendOTPbtn.TipsFont = new Font("Microsoft Sans Serif", 9F);
            ResendOTPbtn.Click += ResendOTPbtn_Click;
            // 
            // OTP
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ResendOTPbtn);
            Controls.Add(OTPVerify);
            Controls.Add(Otptxt);
            Name = "OTP";
            Text = "OTP";
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIButton OTPVerify;
        private Sunny.UI.UITextBox Otptxt;
        private Sunny.UI.UIButton ResendOTPbtn;
    }
}