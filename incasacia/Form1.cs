using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace incasacia
{
	public partial class incas : Form
	{
		public incas()
		{
			InitializeComponent();			
		}

		private void save_Click(object sender, EventArgs e)
		{
			bool isLocked = !azs.Enabled; // Если заблокированы, значит true

			// Изменяем состояние всех текстовых полей
			azs.Enabled = isLocked;
			company.Enabled = isLocked;
			bank_name.Enabled = isLocked;
			schet.Enabled = isLocked;

			// Меняем текст кнопки
			save.Text = isLocked ? "Сохранить" : "Изменить";
		}

		
	}
}
