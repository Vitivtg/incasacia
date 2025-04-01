using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using ClosedXML.Excel;
using System.Reflection;
using DocumentFormat.OpenXml.Drawing.Diagrams;

namespace incasacia
{
	public partial class incas : Form
	{
		private string filePath = "data_file.json";

		public incas()
		{
			InitializeComponent();
			LoadData();
		}		

		private string ExtractExcelTemplate()
		{
			string folderPath = @"D:\incasation\rub\";
			string templatePath = Path.Combine(folderPath, "sample.xlsx");
			
			if (!File.Exists(templatePath))
			{
				
				using (Stream resourcesStream= Assembly.GetExecutingAssembly().GetManifestResourceStream("incasacia.incasacia.Resources.sample.xlsx"))
				{
					if(resourcesStream != null)
					{
						using (FileStream fileStream = new FileStream(templatePath, FileMode.Create, FileAccess.Write))
						{
							resourcesStream.CopyTo(fileStream);
						}
					}
					else
					{
						MessageBox.Show("Не найден шаблон Excel!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return null;
					}
				}					
			}
			return templatePath;
		}

		private void save_rub_click(object sender, EventArgs e)
		{
			string folderPath = @"D:\incasation\rub\";
			string excelFilePath = Path.Combine(folderPath, $"{DateTime.Now:dd-MM-yyyy}.xlsx");
			string templatePath = ExtractExcelTemplate();

			if (templatePath == null)
			{
				return;
			}
			else
			{
				File.Copy(templatePath, excelFilePath, true);

				using (var workbook = new XLWorkbook(templatePath))
				{
					var ws = workbook.Worksheet(1);

					ws.Cell("M1").Value = bags_number.Text;
					ws.Cell("AH1").Value = bags_number.Text;
					ws.Cell("M45").Value = bags_number.Text;
					ws.Cell("AH45").Value = bags_number.Text;
					ws.Cell("M88").Value = bags_number.Text;
					ws.Cell("AH88").Value = bags_number.Text;
					ws.Cell("D7").Value = azs.Text + "  " + company.Text;
					ws.Cell("D51").Value = azs.Text + "  " + company.Text;
					ws.Cell("D94").Value = azs.Text + "  " + company.Text;
					if (DateTime.TryParse(date_time.Text, out DateTime date))
					{
						ws.Cell("B4").Value = date.ToString("dd MMMM yyyy года", new System.Globalization.CultureInfo("ru-RU"));
						ws.Cell("B48").Value = date.ToString("dd MMMM yyyy года", new System.Globalization.CultureInfo("ru-RU"));
						ws.Cell("B91").Value = date.ToString("dd MMMM yyyy года", new System.Globalization.CultureInfo("ru-RU"));
					}
					else
					{
						ws.Cell("B4").Value = "Ошибка";
						ws.Cell("B48").Value = "Ошибка";
						ws.Cell("B91").Value = "Ошибка";
					}
					ws.Cell("R9").Value = schet_rub.Text;	
					ws.Cell("R53").Value = schet_rub.Text;
					ws.Cell("R96").Value = schet_rub.Text;

					workbook.SaveAs(excelFilePath);					
				}
			}
		}

		private void LoadData()
		{
			if (File.Exists(filePath))
			{
				string json = File.ReadAllText(filePath);

				// Проверяем, что файл не пустой
				if (!string.IsNullOrWhiteSpace(json))
				{
					try
					{
						var data = JsonConvert.DeserializeObject<TextBoxData>(json);
						if (data != null)
						{
							azs.Text = data.Azs;
							company.Text = data.Company;
							bank_name.Text = data.BankName;
							schet_rub.Text = data.SchetRub;
							schet_usd.Text = data.SchetUsd;
							schet_lei.Text = data.SchetLei;
						}
					}
					catch (JsonException)
					{
						MessageBox.Show("Ошибка при загрузке данных из JSON. Проверьте файл.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}

			azs.Enabled = false;
			company.Enabled = false;
			bank_name.Enabled = false;
			schet_rub.Enabled = false;
			schet_usd.Enabled = false;
			schet_lei.Enabled = false;
			save.Text = "Изменить";
		}

		class TextBoxData
		{
			public string Azs { get; set; }
			public string Company { get; set; }
			public string BankName { get; set; }
			public string SchetRub { get; set; }
			public string SchetUsd { get; set; }
			public string SchetLei { get; set; }
		}

		private void save_Click(object sender, EventArgs e)
		{
			if (!azs.Enabled)
			{
				FormPassword formPassword = new FormPassword();

				if (formPassword.ShowDialog() != DialogResult.OK)
				{
					return;
				}

				if (formPassword.EnteredPassword != "9482640")
				{
					MessageBox.Show("Неверный пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}

			var data = new TextBoxData
			{
				Azs = azs.Text,
				Company = company.Text,
				BankName = bank_name.Text,
				SchetRub = schet_rub.Text,
				SchetUsd = schet_usd.Text,
				SchetLei = schet_lei.Text
			};
			string json = JsonConvert.SerializeObject(data);
			File.WriteAllText(filePath, json);
			MessageBox.Show("Данные успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

			// Изменяем состояние всех текстовых полей
			bool isLocked = !azs.Enabled; // Если заблокированы, значит true
			azs.Enabled = isLocked;
			company.Enabled = isLocked;
			bank_name.Enabled = isLocked;
			schet_rub.Enabled = isLocked;
			schet_usd.Enabled = isLocked;
			schet_lei.Enabled = isLocked;

			// Меняем текст кнопки
			save.Text = isLocked ? "Сохранить" : "Изменить";
		}

		private void sum500_TextChanged(object sender, EventArgs e)
		{						
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
			if (int.TryParse(r25.Text, out int num25))
			{
				int sum = num25 * 25;
				sum25.Text = sum.ToString();
			}
			else
			{
				sum25.Text = "Ошибка";
			}
		}

		private void sum10_TextChanged(object sender, EventArgs e)
		{			
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
			if (double.TryParse(rc50.Text, out double num05))
			{
				double sum = num05 * 0.5;
				sum_rc50.Text = sum.ToString();
			}
			else
			{
				sum_rc50.Text = "Ошибка";
			}
		}

		private void sum_rc25_TextChanged(object sender, EventArgs e)
		{			
			if (double.TryParse(rc25.Text, out double num025))
			{
				double sum = num025 * 0.25;
				sum_rc25.Text = sum.ToString();
			}
			else
			{
				sum_rc25.Text = "Ошибка";
			}
		}

		private void sum_rc10_TextChanged(object sender, EventArgs e)
		{			
			if (double.TryParse(rc10.Text, out double num01))
			{
				double sum = num01 * 0.1;
				sum_rc10.Text = sum.ToString();
			}
			else
			{
				sum_rc10.Text = "Ошибка";
			}
		}

		private void sum_rc5_TextChanged(object sender, EventArgs e)
		{			
			if (double.TryParse(rc5.Text, out double num005))
			{
				double sum = num005 * 0.05;
				sum_rc5.Text = sum.ToString();
			}
			else
			{
				sum_rc5.Text = "Ошибка";
			}
		}

		private void total_sum_LabelChanged(object sender, EventArgs e)
		{
			double sum = 0;			
			TextBox[] textBoxes = { sum500, sum200, sum100, sum50, sum25, sum10, sum5, sum3, sum1, sum_rc50, sum_rc25, sum_rc10, sum_rc5 };

			foreach (TextBox tb in textBoxes)
			{
				if (double.TryParse(tb.Text, out double value))
				{
					sum += value;
				}
			}
			summa.Text = sum.ToString()+" руб.";
		}
	}
}