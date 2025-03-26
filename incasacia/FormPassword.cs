using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using incasacia;

namespace incasacia
{
	public partial class FormPassword : Form
	{
		public string EnteredPassword { get; private set; }

		public FormPassword()
		{
			InitializeComponent();			
		}	

		private void save_pass_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(pass.Text))
			{
				MessageBox.Show("Пароль не может быть пустым!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			EnteredPassword = pass.Text;
			this.DialogResult = DialogResult.OK;
			Close();
		}
	}
}
