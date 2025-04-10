namespace incasacia
{
	partial class FormPassword
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
			this.password_label = new System.Windows.Forms.Label();
			this.pass = new System.Windows.Forms.TextBox();
			this.save_pass = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// password_label
			// 
			this.password_label.AutoSize = true;
			this.password_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.password_label.Location = new System.Drawing.Point(115, 94);
			this.password_label.Name = "password_label";
			this.password_label.Size = new System.Drawing.Size(126, 17);
			this.password_label.TabIndex = 0;
			this.password_label.Text = "введите пароль";
			// 
			// pass
			// 
			this.pass.Location = new System.Drawing.Point(85, 130);
			this.pass.Multiline = true;
			this.pass.Name = "pass";
			this.pass.PasswordChar = '*';
			this.pass.Size = new System.Drawing.Size(193, 23);
			this.pass.TabIndex = 1;
			// 
			// save_pass
			// 
			this.save_pass.BackColor = System.Drawing.Color.Gray;
			this.save_pass.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.save_pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.save_pass.Location = new System.Drawing.Point(85, 181);
			this.save_pass.Name = "save_pass";
			this.save_pass.Size = new System.Drawing.Size(193, 46);
			this.save_pass.TabIndex = 4;
			this.save_pass.Text = "Ok";
			this.save_pass.UseVisualStyleBackColor = false;
			this.save_pass.Click += new System.EventHandler(this.save_pass_Click);
			// 
			// FormPassword
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DarkGray;
			this.ClientSize = new System.Drawing.Size(354, 361);
			this.Controls.Add(this.save_pass);
			this.Controls.Add(this.pass);
			this.Controls.Add(this.password_label);
			this.MaximumSize = new System.Drawing.Size(370, 400);
			this.MinimumSize = new System.Drawing.Size(370, 400);
			this.Name = "FormPassword";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FormPassword";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label password_label;
		private System.Windows.Forms.TextBox pass;
		private System.Windows.Forms.Button save_pass;
	}
}