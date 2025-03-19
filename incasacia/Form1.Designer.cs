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
			this.Рубли = new System.Windows.Forms.TabPage();
			this.Доллары = new System.Windows.Forms.TabPage();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.Леи = new System.Windows.Forms.TabPage();
			this.Настройки = new System.Windows.Forms.TabPage();
			this.a1.SuspendLayout();
			this.Рубли.SuspendLayout();
			this.SuspendLayout();
			// 
			// a1
			// 
			this.a1.AccessibleName = "";
			this.a1.Controls.Add(this.Рубли);
			this.a1.Controls.Add(this.Доллары);
			this.a1.Controls.Add(this.Леи);
			this.a1.Controls.Add(this.Настройки);
			this.a1.Location = new System.Drawing.Point(-3, -4);
			this.a1.Name = "a1";
			this.a1.SelectedIndex = 0;
			this.a1.Size = new System.Drawing.Size(802, 454);
			this.a1.TabIndex = 0;
			// 
			// Рубли
			// 
			this.Рубли.Controls.Add(this.listBox1);
			this.Рубли.Location = new System.Drawing.Point(4, 22);
			this.Рубли.Name = "Рубли";
			this.Рубли.Padding = new System.Windows.Forms.Padding(3);
			this.Рубли.Size = new System.Drawing.Size(794, 428);
			this.Рубли.TabIndex = 0;
			this.Рубли.Text = "tabPage1";
			this.Рубли.UseVisualStyleBackColor = true;
			// 
			// Доллары
			// 
			this.Доллары.Location = new System.Drawing.Point(4, 22);
			this.Доллары.Name = "Доллары";
			this.Доллары.Padding = new System.Windows.Forms.Padding(3);
			this.Доллары.Size = new System.Drawing.Size(794, 428);
			this.Доллары.TabIndex = 1;
			this.Доллары.Text = "tabPage2";
			this.Доллары.UseVisualStyleBackColor = true;
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(24, 47);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(175, 82);
			this.listBox1.TabIndex = 0;
			// 
			// Леи
			// 
			this.Леи.Location = new System.Drawing.Point(4, 22);
			this.Леи.Name = "Леи";
			this.Леи.Padding = new System.Windows.Forms.Padding(3);
			this.Леи.Size = new System.Drawing.Size(794, 428);
			this.Леи.TabIndex = 2;
			this.Леи.Text = "tabPage3";
			this.Леи.UseVisualStyleBackColor = true;
			// 
			// Настройки
			// 
			this.Настройки.Location = new System.Drawing.Point(4, 22);
			this.Настройки.Name = "Настройки";
			this.Настройки.Padding = new System.Windows.Forms.Padding(3);
			this.Настройки.Size = new System.Drawing.Size(794, 428);
			this.Настройки.TabIndex = 3;
			this.Настройки.Text = "tabPage4";
			this.Настройки.UseVisualStyleBackColor = true;
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
			this.Рубли.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.TabPage Рубли;
		private System.Windows.Forms.TabPage Доллары;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.TabControl a1;
		private System.Windows.Forms.TabPage Леи;
		private System.Windows.Forms.TabPage Настройки;
	}
}

