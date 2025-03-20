namespace incasacia
{
	partial class incas
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
			this.setings = new System.Windows.Forms.TabControl();
			this.settings = new System.Windows.Forms.TabPage();
			this.save = new System.Windows.Forms.Button();
			this.schet = new System.Windows.Forms.TextBox();
			this.schet_label = new System.Windows.Forms.Label();
			this.bank_name = new System.Windows.Forms.TextBox();
			this.bank_label = new System.Windows.Forms.Label();
			this.company = new System.Windows.Forms.TextBox();
			this.company_label = new System.Windows.Forms.Label();
			this.azs = new System.Windows.Forms.TextBox();
			this.azs_label = new System.Windows.Forms.Label();
			this.dol = new System.Windows.Forms.TabPage();
			this.lei = new System.Windows.Forms.TabPage();
			this.rub = new System.Windows.Forms.TabPage();
			this.data_label = new System.Windows.Forms.Label();
			this.date_time = new System.Windows.Forms.DateTimePicker();
			this.bag_label = new System.Windows.Forms.Label();
			this.bags_number = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.setings.SuspendLayout();
			this.settings.SuspendLayout();
			this.rub.SuspendLayout();
			this.SuspendLayout();
			// 
			// setings
			// 
			this.setings.AccessibleName = "";
			this.setings.Controls.Add(this.settings);
			this.setings.Controls.Add(this.dol);
			this.setings.Controls.Add(this.lei);
			this.setings.Controls.Add(this.rub);
			this.setings.Location = new System.Drawing.Point(1, 1);
			this.setings.Name = "setings";
			this.setings.SelectedIndex = 0;
			this.setings.Size = new System.Drawing.Size(802, 454);
			this.setings.TabIndex = 0;
			// 
			// settings
			// 
			this.settings.BackColor = System.Drawing.Color.DarkGray;
			this.settings.Controls.Add(this.save);
			this.settings.Controls.Add(this.schet);
			this.settings.Controls.Add(this.schet_label);
			this.settings.Controls.Add(this.bank_name);
			this.settings.Controls.Add(this.bank_label);
			this.settings.Controls.Add(this.company);
			this.settings.Controls.Add(this.company_label);
			this.settings.Controls.Add(this.azs);
			this.settings.Controls.Add(this.azs_label);
			this.settings.Location = new System.Drawing.Point(4, 22);
			this.settings.Name = "settings";
			this.settings.Padding = new System.Windows.Forms.Padding(3);
			this.settings.Size = new System.Drawing.Size(794, 428);
			this.settings.TabIndex = 0;
			this.settings.Text = "Настройки";
			// 
			// save
			// 
			this.save.BackColor = System.Drawing.Color.DimGray;
			this.save.FlatAppearance.BorderSize = 2;
			this.save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.save.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.save.Location = new System.Drawing.Point(171, 225);
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(174, 39);
			this.save.TabIndex = 8;
			this.save.Text = "Сохранить";
			this.save.UseVisualStyleBackColor = false;
			this.save.Click += new System.EventHandler(this.save_Click);
			// 
			// schet
			// 
			this.schet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.schet.Location = new System.Drawing.Point(172, 159);
			this.schet.Name = "schet";
			this.schet.Size = new System.Drawing.Size(173, 23);
			this.schet.TabIndex = 7;
			// 
			// schet_label
			// 
			this.schet_label.AutoSize = true;
			this.schet_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.schet_label.Location = new System.Drawing.Point(16, 165);
			this.schet_label.Name = "schet_label";
			this.schet_label.Size = new System.Drawing.Size(62, 17);
			this.schet_label.TabIndex = 6;
			this.schet_label.Text = "счет №";
			// 
			// bank_name
			// 
			this.bank_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.bank_name.Location = new System.Drawing.Point(172, 114);
			this.bank_name.Name = "bank_name";
			this.bank_name.Size = new System.Drawing.Size(174, 23);
			this.bank_name.TabIndex = 5;
			// 
			// bank_label
			// 
			this.bank_label.AutoSize = true;
			this.bank_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.bank_label.Location = new System.Drawing.Point(16, 117);
			this.bank_label.Name = "bank_label";
			this.bank_label.Size = new System.Drawing.Size(137, 17);
			this.bank_label.TabIndex = 4;
			this.bank_label.Text = "Банк получателя";
			// 
			// company
			// 
			this.company.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.company.Location = new System.Drawing.Point(172, 66);
			this.company.Name = "company";
			this.company.Size = new System.Drawing.Size(174, 23);
			this.company.TabIndex = 3;
			// 
			// company_label
			// 
			this.company_label.AutoSize = true;
			this.company_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.company_label.Location = new System.Drawing.Point(16, 72);
			this.company_label.Name = "company_label";
			this.company_label.Size = new System.Drawing.Size(82, 17);
			this.company_label.TabIndex = 2;
			this.company_label.Text = "Компания";
			// 
			// azs
			// 
			this.azs.BackColor = System.Drawing.Color.White;
			this.azs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.azs.Location = new System.Drawing.Point(172, 20);
			this.azs.Name = "azs";
			this.azs.Size = new System.Drawing.Size(174, 23);
			this.azs.TabIndex = 1;
			// 
			// azs_label
			// 
			this.azs_label.AutoSize = true;
			this.azs_label.BackColor = System.Drawing.Color.DarkGray;
			this.azs_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.azs_label.Location = new System.Drawing.Point(16, 23);
			this.azs_label.Name = "azs_label";
			this.azs_label.Size = new System.Drawing.Size(126, 17);
			this.azs_label.TabIndex = 0;
			this.azs_label.Text = "Подразделение";
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
			// rub
			// 
			this.rub.BackColor = System.Drawing.Color.DarkGray;
			this.rub.Controls.Add(this.label8);
			this.rub.Controls.Add(this.label7);
			this.rub.Controls.Add(this.label6);
			this.rub.Controls.Add(this.label5);
			this.rub.Controls.Add(this.label4);
			this.rub.Controls.Add(this.label3);
			this.rub.Controls.Add(this.label2);
			this.rub.Controls.Add(this.label1);
			this.rub.Controls.Add(this.bags_number);
			this.rub.Controls.Add(this.bag_label);
			this.rub.Controls.Add(this.date_time);
			this.rub.Controls.Add(this.data_label);
			this.rub.Location = new System.Drawing.Point(4, 22);
			this.rub.Name = "rub";
			this.rub.Padding = new System.Windows.Forms.Padding(3);
			this.rub.Size = new System.Drawing.Size(794, 428);
			this.rub.TabIndex = 3;
			this.rub.Text = "Рубли";
			// 
			// data_label
			// 
			this.data_label.AutoSize = true;
			this.data_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.data_label.Location = new System.Drawing.Point(17, 28);
			this.data_label.Name = "data_label";
			this.data_label.Size = new System.Drawing.Size(121, 17);
			this.data_label.TabIndex = 0;
			this.data_label.Text = "Выберите дату";
			// 
			// date_time
			// 
			this.date_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.date_time.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.date_time.Location = new System.Drawing.Point(160, 23);
			this.date_time.Name = "date_time";
			this.date_time.Size = new System.Drawing.Size(83, 23);
			this.date_time.TabIndex = 1;
			this.date_time.Value = new System.DateTime(2025, 3, 21, 0, 30, 1, 0);
			// 
			// bag_label
			// 
			this.bag_label.AutoSize = true;
			this.bag_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.bag_label.Location = new System.Drawing.Point(21, 67);
			this.bag_label.Name = "bag_label";
			this.bag_label.Size = new System.Drawing.Size(73, 17);
			this.bag_label.TabIndex = 2;
			this.bag_label.Text = "Сумка №";
			// 
			// bags_number
			// 
			this.bags_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.bags_number.Location = new System.Drawing.Point(160, 66);
			this.bags_number.Name = "bags_number";
			this.bags_number.Size = new System.Drawing.Size(82, 23);
			this.bags_number.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(381, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "label1";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(378, 66);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "label2";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(378, 101);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "label3";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(378, 133);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(35, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "label4";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(378, 161);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(35, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "label5";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(381, 197);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(35, 13);
			this.label6.TabIndex = 9;
			this.label6.Text = "label6";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(378, 225);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(35, 13);
			this.label7.TabIndex = 10;
			this.label7.Text = "label7";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(378, 255);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(35, 13);
			this.label8.TabIndex = 11;
			this.label8.Text = "label8";
			// 
			// incas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(799, 450);
			this.Controls.Add(this.setings);
			this.Name = "incas";
			this.Text = "Инкассация";
			this.setings.ResumeLayout(false);
			this.settings.ResumeLayout(false);
			this.settings.PerformLayout();
			this.rub.ResumeLayout(false);
			this.rub.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.TabPage settings;
		private System.Windows.Forms.TabPage dol;
		private System.Windows.Forms.TabControl setings;
		private System.Windows.Forms.TabPage lei;
		private System.Windows.Forms.TabPage rub;
		private System.Windows.Forms.TextBox azs;
		private System.Windows.Forms.Label azs_label;
		private System.Windows.Forms.Label company_label;
		private System.Windows.Forms.TextBox company;
		private System.Windows.Forms.TextBox bank_name;
		private System.Windows.Forms.Label bank_label;
		private System.Windows.Forms.TextBox schet;
		private System.Windows.Forms.Label schet_label;
		private System.Windows.Forms.Button save;
		private System.Windows.Forms.Label data_label;
		private System.Windows.Forms.DateTimePicker date_time;
		private System.Windows.Forms.Label bag_label;
		private System.Windows.Forms.TextBox bags_number;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}

