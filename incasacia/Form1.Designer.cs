namespace incasacia
{
	partial class Form1
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
			this.a1 = new System.Windows.Forms.TabControl();
			this.rub = new System.Windows.Forms.TabPage();
			this.dol = new System.Windows.Forms.TabPage();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.lei = new System.Windows.Forms.TabPage();
			this.settings = new System.Windows.Forms.TabPage();
			this.a1.SuspendLayout();
			this.rub.SuspendLayout();
			this.SuspendLayout();
			// 
			// a1
			// 
			this.a1.AccessibleName = "";
			this.a1.Controls.Add(this.rub);
			this.a1.Controls.Add(this.dol);
			this.a1.Controls.Add(this.lei);
			this.a1.Controls.Add(this.settings);
			this.a1.Location = new System.Drawing.Point(1, 1);
			this.a1.Name = "a1";
			this.a1.SelectedIndex = 0;
			this.a1.Size = new System.Drawing.Size(802, 454);
			this.a1.TabIndex = 0;
			// 
			// rub
			// 
			this.rub.Controls.Add(this.listBox1);
			this.rub.Location = new System.Drawing.Point(4, 22);
			this.rub.Name = "rub";
			this.rub.Padding = new System.Windows.Forms.Padding(3);
			this.rub.Size = new System.Drawing.Size(794, 428);
			this.rub.TabIndex = 0;
			this.rub.Text = "Рубли";
			this.rub.UseVisualStyleBackColor = true;
			// 
			// dol
			// 
			this.dol.Location = new System.Drawing.Point(4, 22);
			this.dol.Name = "dol";
			this.dol.Padding = new System.Windows.Forms.Padding(3);
			this.dol.Size = new System.Drawing.Size(794, 428);
			this.dol.TabIndex = 1;
			this.dol.Text = "Доллары";
			this.dol.UseVisualStyleBackColor = true;
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(24, 47);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(175, 82);
			this.listBox1.TabIndex = 0;
			// 
			// lei
			// 
			this.lei.Location = new System.Drawing.Point(4, 22);
			this.lei.Name = "lei";
			this.lei.Padding = new System.Windows.Forms.Padding(3);
			this.lei.Size = new System.Drawing.Size(794, 428);
			this.lei.TabIndex = 2;
			this.lei.Text = "Леи";
			this.lei.UseVisualStyleBackColor = true;
			// 
			// settings
			// 
			this.settings.Location = new System.Drawing.Point(4, 22);
			this.settings.Name = "settings";
			this.settings.Padding = new System.Windows.Forms.Padding(3);
			this.settings.Size = new System.Drawing.Size(794, 428);
			this.settings.TabIndex = 3;
			this.settings.Text = "Настройки";
			this.settings.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.a1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.a1.ResumeLayout(false);
			this.rub.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.TabPage rub;
		private System.Windows.Forms.TabPage dol;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.TabControl a1;
		private System.Windows.Forms.TabPage lei;
		private System.Windows.Forms.TabPage settings;
	}
}

