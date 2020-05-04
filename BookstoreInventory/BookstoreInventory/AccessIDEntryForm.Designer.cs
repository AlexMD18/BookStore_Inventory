namespace BookstoreInventory
{
    partial class frmAccessID
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblBookstoreName = new System.Windows.Forms.Label();
            this.lblAccessInstructions = new System.Windows.Forms.Label();
            this.btnFindMe = new System.Windows.Forms.Button();
            this.txtFindMe = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Imprint MT Shadow", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(283, 71);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(402, 57);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome To The";
            // 
            // lblBookstoreName
            // 
            this.lblBookstoreName.AutoSize = true;
            this.lblBookstoreName.Font = new System.Drawing.Font("Old English Text MT", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookstoreName.ForeColor = System.Drawing.Color.Maroon;
            this.lblBookstoreName.Location = new System.Drawing.Point(214, 180);
            this.lblBookstoreName.Name = "lblBookstoreName";
            this.lblBookstoreName.Size = new System.Drawing.Size(577, 71);
            this.lblBookstoreName.TabIndex = 1;
            this.lblBookstoreName.Text = "Bookworm Bookstore";
            // 
            // lblAccessInstructions
            // 
            this.lblAccessInstructions.AutoSize = true;
            this.lblAccessInstructions.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccessInstructions.Location = new System.Drawing.Point(12, 338);
            this.lblAccessInstructions.Name = "lblAccessInstructions";
            this.lblAccessInstructions.Size = new System.Drawing.Size(985, 25);
            this.lblAccessInstructions.TabIndex = 2;
            this.lblAccessInstructions.Text = "Please Enter your FIVE DIGIT Access ID number in the Box Below, then press Find M" +
    "e:";
            // 
            // btnFindMe
            // 
            this.btnFindMe.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnFindMe.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindMe.ForeColor = System.Drawing.Color.LawnGreen;
            this.btnFindMe.Location = new System.Drawing.Point(525, 415);
            this.btnFindMe.Name = "btnFindMe";
            this.btnFindMe.Size = new System.Drawing.Size(149, 45);
            this.btnFindMe.TabIndex = 3;
            this.btnFindMe.Text = "Find Me";
            this.btnFindMe.UseVisualStyleBackColor = false;
            this.btnFindMe.Click += new System.EventHandler(this.btnFindMe_Click);
            // 
            // txtFindMe
            // 
            this.txtFindMe.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFindMe.Location = new System.Drawing.Point(303, 422);
            this.txtFindMe.Name = "txtFindMe";
            this.txtFindMe.Size = new System.Drawing.Size(197, 32);
            this.txtFindMe.TabIndex = 1;
            // 
            // frmAccessID
            // 
            this.AcceptButton = this.btnFindMe;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 551);
            this.Controls.Add(this.txtFindMe);
            this.Controls.Add(this.btnFindMe);
            this.Controls.Add(this.lblAccessInstructions);
            this.Controls.Add(this.lblBookstoreName);
            this.Controls.Add(this.lblWelcome);
            this.Name = "frmAccessID";
            this.Text = "Bookstore Access ID";
            this.Load += new System.EventHandler(this.frmAccessID_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblBookstoreName;
        private System.Windows.Forms.Label lblAccessInstructions;
        private System.Windows.Forms.Button btnFindMe;
        private System.Windows.Forms.TextBox txtFindMe;
    }
}

