namespace Social.Pinterest
{
    partial class Home
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.btn_pin = new System.Windows.Forms.Button();
            this.btn_getPins = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // btn_pin
            // 
            this.btn_pin.Location = new System.Drawing.Point(216, 85);
            this.btn_pin.Name = "btn_pin";
            this.btn_pin.Size = new System.Drawing.Size(75, 23);
            this.btn_pin.TabIndex = 0;
            this.btn_pin.Text = "Pin";
            this.btn_pin.UseVisualStyleBackColor = true;
            this.btn_pin.Click += new System.EventHandler(this.btn_pin_Click);
            // 
            // btn_getPins
            // 
            this.btn_getPins.Location = new System.Drawing.Point(48, 85);
            this.btn_getPins.Name = "btn_getPins";
            this.btn_getPins.Size = new System.Drawing.Size(75, 23);
            this.btn_getPins.TabIndex = 1;
            this.btn_getPins.Text = "Get Pins";
            this.btn_getPins.UseVisualStyleBackColor = true;
            this.btn_getPins.Click += new System.EventHandler(this.btn_getPins_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 207);
            this.Controls.Add(this.btn_getPins);
            this.Controls.Add(this.btn_pin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Resize += new System.EventHandler(this.Home_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_pin;
        private System.Windows.Forms.Button btn_getPins;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

