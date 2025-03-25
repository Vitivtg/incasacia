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

		private void sum500_TextChanged(object sender, EventArgs e)
		{
			sum500.Enabled = false;
			if (int.TryParse(r500.Text, out int num500))
			{
				int sum = num500 * 500;
				sum500.Text = sum.ToString();
			}
			else
			{
				sum500.Text = "Ошибка";
			}
		}

		private void sum200_TextChanged(object sender, EventArgs e)
		{
			sum200.Enabled = false;
			if (int.TryParse(r200.Text, out int num200))
			{
				int sum = num200 * 200;
				sum200.Text = sum.ToString();
			}
			else
			{
				sum200.Text = "Ошибка";
			}
		}

		private void sum100_TextChanged(object sender, EventArgs e)
		{
			sum100.Enabled = false;
			if (int.TryParse(r100.Text, out int num100))
			{
				int sum = num100 * 100;
				sum100.Text = sum.ToString();
			}
			else
			{
				sum100.Text = "Ошибка";
			}
		}

		private void sum50_TextChanged(object sender, EventArgs e)
		{
			sum50.Enabled = false;
			if (int.TryParse(r50.Text, out int num50))
			{
				int sum = num50 * 50;
				sum50.Text = sum.ToString();
			}
			else
			{
				sum50.Text = "Ошибка";
			}
		}

		private void sum25_TextChanged(object sender, EventArgs e)
		{
			sum25.Enabled = false;
			if (int.TryParse(r25.Text, out int num20))
			{
				int sum = num20 * 25;
				sum25.Text = sum.ToString();
			}
			else
			{
				sum25.Text = "Ошибка";
			}
		}

		private void sum10_TextChanged(object sender, EventArgs e)
		{
			sum10.Enabled = false;
			if (int.TryParse(r10.Text, out int num10))
			{
				int sum = num10 * 10;
				sum10.Text = sum.ToString();
			}
			else
			{
				sum10.Text = "Ошибка";
			}
		}

		private void sum5_TextChanged(object sender, EventArgs e)
		{
			sum5.Enabled = false;
			if (int.TryParse(r5.Text, out int num5))
			{
				int sum = num5 * 5;
				sum5.Text = sum.ToString();
			}
			else
			{
				sum5.Text = "Ошибка";
			}
		}

		private void sum3_TextChanged(object sender, EventArgs e)
		{
			sum3.Enabled = false;
			if (int.TryParse(r3.Text, out int num3))
			{
				int sum = num3 * 3;
				sum3.Text = sum.ToString();
			}
			else
			{
				sum3.Text = "Ошибка";
			}
		}

		private void sum1_TextChanged(object sender, EventArgs e)
		{
			sum1.Enabled = false;
			if (int.TryParse(r1.Text, out int num1))
			{
				int sum = num1 * 1;
				sum1.Text = sum.ToString();
			}
			else
			{
				sum1.Text = "Ошибка";
			}
		}

		private void sum_rc50_TextChanged(object sender, EventArgs e)
		{
			sum_rc50.Enabled = false;
			if (int.TryParse(rc50.Text, out int num05))
			{
				double sum = num05 *0.5;
				sum_rc50.Text = sum.ToString();
			}
			else
			{
				sum_rc50.Text = "Ошибка";
			}
		}

		private void sum_rc25_TextChanged(object sender, EventArgs e)
		{
			sum_rc25.Enabled = false;
			if (int.TryParse(rc25.Text, out int num025))
			{
				double sum = num025 *0.25;
				sum_rc25.Text = sum.ToString();
			}
			else
			{
				sum_rc25.Text = "Ошибка";
			}
		}

		private void sum_rc10_TextChanged(object sender, EventArgs e)
		{
			sum_rc10.Enabled = false;
			if (int.TryParse(rc10.Text, out int num01))
			{
				double sum = num01 * 0.1 ;
				sum_rc10.Text = sum.ToString();
			}
			else
			{
				sum_rc10.Text = "Ошибка";
			}
		}

		private void sum_rc5_TextChanged(object sender, EventArgs e)
		{
			sum_rc5.Enabled = false;
			if (int.TryParse(rc5.Text, out int num005))
			{
				double sum = num005 * 0.05;
				sum_rc5.Text = sum.ToString();
			}
			else
			{
				sum_rc5.Text = "Ошибка";
			}
		}
	}
}
