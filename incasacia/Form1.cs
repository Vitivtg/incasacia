using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using ClosedXML.Excel;
using System.Reflection;
using System.Text.RegularExpressions;

namespace incasacia
{
	public partial class incas : Form
	{
		private string filePath;

		public incas()
		{
			InitializeComponent();
			InitFilePath();
			LoadData();
		}

		private void InitFilePath()
		{
			string appDataFolder = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
				"incasacia");

			// Создаём папку, если её нет
			Directory.CreateDirectory(appDataFolder);

			filePath = Path.Combine(appDataFolder, "data_file.json");

			// Если файл не существует — создаём его
			if (!File.Exists(filePath))
			{
				File.WriteAllText(filePath, "[]"); // Или другой стартовый JSON
			}
		}

		private string ExtractExcelTemplate()
		{
			string folderPath = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "инкассация");
			string templatePath = Path.Combine(folderPath, "sample.xlsx");

			if (!File.Exists(templatePath))
			{
				using (Stream resourcesStream = Assembly.GetExecutingAssembly()
					.GetManifestResourceStream("incasacia.Resources.sample.xlsx"))
				{
					if (resourcesStream != null)
					{
						Directory.CreateDirectory(folderPath);
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

		private void save_usd_click(object sender, EventArgs e)
		{
			string folderPath = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "инкассация", "usd");

			if (!Directory.Exists(folderPath))
			{
				Directory.CreateDirectory(folderPath);
			}

			string baseFileName = date_time_usd.Text;
			string extension = "_usd.xlsx";
			string excelFilePath = Path.Combine(folderPath, baseFileName + extension);

			int suffix = 1;
			while (File.Exists(excelFilePath))
			{
				string newFileName = $"{baseFileName} ({suffix}){extension}";
				excelFilePath = Path.Combine(folderPath, newFileName);
				suffix++;
			}

			string templatePath = ExtractExcelTemplate();

			if (templatePath == null)
			{
				return;
			}
			else
			{
				using (var workbook = new XLWorkbook(templatePath))
				{
					var ws = workbook.Worksheet(1);
					string input = bags_number_usd.Text;
					int errorCount = 0;

					List<Label> banknoteBox = new List<Label> { lusd100, lusd50, lusd20, lusd10, lusd5, lusd2, lusd1 };
					List<TextBox> banknoteCount = new List<TextBox> { usd100, usd50, usd20, usd10, usd5, usd2, usd1 };
					List<TextBox> banknoteSum = new List<TextBox> { sum_usd100, sum_usd50, sum_usd20, sum_usd10, sum_usd5, sum_usd2, sum_usd1 };

					foreach (var sum in banknoteSum)
					{
						if (sum.Text == "Ошибка")
						{
							errorCount++;
						}
					}

					if (!Regex.IsMatch(input, @"^\d{3}\/\d$") || !DateTime.TryParse(date_time_usd.Text, out DateTime date))
					{
						MessageBox.Show("Неверный формат номера мешка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					else if (errorCount > 0)
					{
						MessageBox.Show("Ошибка в расчетах суммы банкнот!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					else
					{
						File.Copy(templatePath, excelFilePath, true);

						ws.Cell("D7").Value = azs.Text + "  " + company.Text; //от кого
						ws.Cell("D51").Value = azs.Text + "  " + company.Text;//от кого
						ws.Cell("D94").Value = azs.Text + "  " + company.Text;//от кого					

						ws.Cell("B4").Value = date.ToString("dd MMMM yyyy года", new System.Globalization.CultureInfo("ru-RU"));
						ws.Cell("B48").Value = date.ToString("dd MMMM yyyy года", new System.Globalization.CultureInfo("ru-RU"));
						ws.Cell("B91").Value = date.ToString("dd MMMM yyyy года", new System.Globalization.CultureInfo("ru-RU"));

						ws.Cell("S9").Value = schet_usd.Text;//счет №	
						ws.Cell("S53").Value = schet_usd.Text;//счет №
						ws.Cell("S96").Value = schet_usd.Text;//счет №

						ws.Cell("E9").Value = company.Text;//наименование банка
						ws.Cell("E53").Value = company.Text;//наименование банка
						ws.Cell("E96").Value = company.Text;//наименование банка

						ws.Cell("N10").Value = summa_usd.Text;//сумма
						ws.Cell("AD8").Value = summa_usd.Text;//сумма
						ws.Cell("AH13").Value = summa_usd.Text;//сумма
						ws.Cell("N54").Value = summa_usd.Text;//сумма
						ws.Cell("AD52").Value = summa_usd.Text;//сумма
						ws.Cell("AH57").Value = summa_usd.Text;//сумма
						ws.Cell("N97").Value = summa_usd.Text;//сумма
						ws.Cell("AD95").Value = summa_usd.Text;//сумма
						ws.Cell("AH100").Value = summa_usd.Text;//сумма
						ws.Cell("AD246").Value = summa_usd.Text;//сумма
						ws.Cell("AD290").Value = summa_usd.Text;//сумма

						ws.Cell("M12").Value = bank_name.Text;//наименование банка
						ws.Cell("M56").Value = bank_name.Text;//наименование банка
						ws.Cell("M99").Value = bank_name.Text;//наименование банка

						ws.Cell("M1").Value = bags_number_usd.Text;//номер мешка
						ws.Cell("AH1").Value = bags_number_usd.Text;//номер мешка
						ws.Cell("M45").Value = bags_number_usd.Text;//номер мешка
						ws.Cell("AH45").Value = bags_number_usd.Text;//номер мешка
						ws.Cell("M88").Value = bags_number_usd.Text;//номер мешка
						ws.Cell("AH88").Value = bags_number_usd.Text;//номер мешка						

						string full = NumberToWordsUsd(decimal.Parse(summa_usd.Text));

						// Разбиваем строку по словам
						var words = full.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

						// Получаем первые 3 слова
						string firstLine = string.Join(" ", words.Take(3));

						// Остаток — во вторую строку
						string secondLine = string.Join(" ", words.Skip(3)) + " США (498)";

						// Записываем в Excel

						ws.Cell("T16").Value = firstLine.ToString(); // первая строка
						ws.Cell("A18").Value = secondLine.ToString(); // вторая строка
						ws.Cell("T60").Value = firstLine.ToString(); // вторая строка
						ws.Cell("A62").Value = secondLine.ToString(); // вторая строка
						ws.Cell("T103").Value = firstLine.ToString(); // вторая строка
						ws.Cell("A105").Value = secondLine.ToString(); // вторая строка
						
						int startRow = 210;

						foreach (var box in banknoteCount)
						{
							if (!string.IsNullOrWhiteSpace(box.Text) && box.Text != "0")
							{
								ws.Cell($"B{startRow}").Value = banknoteBox[banknoteCount.IndexOf(box)].Text;
								ws.Cell($"J{startRow}").Value = banknoteCount[banknoteCount.IndexOf(box)].Text;
								ws.Cell($"AA{startRow}").Value = banknoteSum[banknoteCount.IndexOf(box)].Text;
								startRow += 2;
							}
						}

						workbook.SaveAs(excelFilePath);
						MessageBox.Show("Файл сохранен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
			}
		}

		private void save_lei_click(object sender, EventArgs e)
		{
			string folderPath = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "инкассация", "lei");

			if (!Directory.Exists(folderPath))
			{
				Directory.CreateDirectory(folderPath);
			}

			string baseFileName = date_time_lei.Text;
			string extension = "_lei.xlsx";
			string excelFilePath = Path.Combine(folderPath, baseFileName + extension);

			int suffix = 1;
			while (File.Exists(excelFilePath))
			{
				string newFileName = $"{baseFileName} ({suffix}){extension}";
				excelFilePath = Path.Combine(folderPath, newFileName);
				suffix++;
			}

			string templatePath = ExtractExcelTemplate();

			if (templatePath == null)
			{
				return;
			}
			else
			{
				using (var workbook = new XLWorkbook(templatePath))
				{
					var ws = workbook.Worksheet(1);
					string input = bags_number_lei.Text;
					int errorCount = 0;

					List<Label> banknoteBox = new List<Label> { ll1000, ll500, ll200, ll100, ll50, ll20, ll10, ll5, ll2, ll1 };
					List<TextBox> banknoteCount = new List<TextBox> { l1000, l500, l200, l100, l50, l20, l10, l5, l2, l1 };
					List<TextBox> banknoteSum = new List<TextBox> { sum_l1000, sum_l500, sum_l200, sum_l100, sum_l50, sum_l20, sum_l10, sum_l5, sum_l2, sum_l1 };

					foreach (var sum in banknoteSum)
					{
						if (sum.Text == "Ошибка")
						{
							errorCount++;
						}
					}

					if (!Regex.IsMatch(input, @"^\d{3}\/\d$") || !DateTime.TryParse(date_time_lei.Text, out DateTime date))
					{
						MessageBox.Show("Неверный формат номера мешка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					else if(errorCount>0)
					{
						MessageBox.Show("Ошибка в расчетах суммы банкнот!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					else
					{
						File.Copy(templatePath, excelFilePath, true);

						ws.Cell("D7").Value = azs.Text + "  " + company.Text; //от кого
						ws.Cell("D51").Value = azs.Text + "  " + company.Text;//от кого
						ws.Cell("D94").Value = azs.Text + "  " + company.Text;//от кого					

						ws.Cell("B4").Value = date.ToString("dd MMMM yyyy года", new System.Globalization.CultureInfo("ru-RU"));
						ws.Cell("B48").Value = date.ToString("dd MMMM yyyy года", new System.Globalization.CultureInfo("ru-RU"));
						ws.Cell("B91").Value = date.ToString("dd MMMM yyyy года", new System.Globalization.CultureInfo("ru-RU"));

						ws.Cell("S9").Value = schet_lei.Text;//счет №	
						ws.Cell("S53").Value = schet_lei.Text;//счет №
						ws.Cell("S96").Value = schet_lei.Text;//счет №

						ws.Cell("E9").Value = company.Text;//наименование банка
						ws.Cell("E53").Value = company.Text;//наименование банка
						ws.Cell("E96").Value = company.Text;//наименование банка

						ws.Cell("N10").Value = summa_lei.Text;//сумма
						ws.Cell("AD8").Value = summa_lei.Text;//сумма
						ws.Cell("AH13").Value = summa_lei.Text;//сумма
						ws.Cell("N54").Value = summa_lei.Text;//сумма
						ws.Cell("AD52").Value = summa_lei.Text;//сумма
						ws.Cell("AH57").Value = summa_lei.Text;//сумма
						ws.Cell("N97").Value = summa_lei.Text;//сумма
						ws.Cell("AD95").Value = summa_lei.Text;//сумма
						ws.Cell("AH100").Value = summa_lei.Text;//сумма
						ws.Cell("AD246").Value = summa_lei.Text;//сумма
						ws.Cell("AD290").Value = summa_lei.Text;//сумма

						ws.Cell("M12").Value = bank_name.Text;//наименование банка
						ws.Cell("M56").Value = bank_name.Text;//наименование банка
						ws.Cell("M99").Value = bank_name.Text;//наименование банка

						ws.Cell("M1").Value = bags_number_lei.Text;//номер мешка
						ws.Cell("AH1").Value = bags_number_lei.Text;//номер мешка
						ws.Cell("M45").Value = bags_number_lei.Text;//номер мешка
						ws.Cell("AH45").Value = bags_number_lei.Text;//номер мешка
						ws.Cell("M88").Value = bags_number_lei.Text;//номер мешка
						ws.Cell("AH88").Value = bags_number_lei.Text;//номер мешка						

						string full = NumberToWordsLei(decimal.Parse(summa_lei.Text));

						// Разбиваем строку по словам
						var words = full.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

						// Получаем первые 3 слова
						string firstLine = string.Join(" ", words.Take(3));

						// Остаток — во вторую строку
						string secondLine = string.Join(" ", words.Skip(3)) + " (498)";

						// Записываем в Excel

						ws.Cell("T16").Value = firstLine.ToString(); // первая строка
						ws.Cell("A18").Value = secondLine.ToString(); // вторая строка
						ws.Cell("T60").Value = firstLine.ToString(); // вторая строка
						ws.Cell("A62").Value = secondLine.ToString(); // вторая строка
						ws.Cell("T103").Value = firstLine.ToString(); // вторая строка
						ws.Cell("A105").Value = secondLine.ToString(); // вторая строка

						int startRow = 210;

						foreach (var box in banknoteCount)
						{
							if (!string.IsNullOrWhiteSpace(box.Text) && box.Text != "0")
							{
								ws.Cell($"B{startRow}").Value = banknoteBox[banknoteCount.IndexOf(box)].Text;
								ws.Cell($"J{startRow}").Value = banknoteCount[banknoteCount.IndexOf(box)].Text;
								ws.Cell($"AA{startRow}").Value = banknoteSum[banknoteCount.IndexOf(box)].Text;
								startRow += 2;
							}
						}

						workbook.SaveAs(excelFilePath);
						MessageBox.Show("Файл сохранен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
			}
		}

		private void save_rub_click(object sender, EventArgs e)
		{
			string folderPath = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "инкассация", "rub");

			if (!Directory.Exists(folderPath))
			{
				Directory.CreateDirectory(folderPath);
			}

			string baseFileName = date_time.Text;
			string extension = "_rub.xlsx";
			string excelFilePath = Path.Combine(folderPath, baseFileName + extension);

			int suffix = 1;
			while (File.Exists(excelFilePath))
			{
				string newFileName = $"{baseFileName} ({suffix}){extension}";
				excelFilePath = Path.Combine(folderPath, newFileName);
				suffix++;
			}

			string templatePath = ExtractExcelTemplate();

			if (templatePath == null)
			{
				return;
			}
			else
			{
				using (var workbook = new XLWorkbook(templatePath))
				{
					var ws = workbook.Worksheet(1);
					string input = bags_number.Text;
					int errorCount = 0;

					List<Label> banknoteBox = new List<Label> { m500, m200, m100, m50, m25, m10, m5, m3, m1, k50, k25, k10, k5 };
					List<TextBox> banknoteCount = new List<TextBox> { r500, r200, r100, r50, r25, r10, r5, r3, r1, rc50, rc25, rc10, rc5 };
					List<TextBox> banknoteSum = new List<TextBox> { sum500, sum200, sum100, sum50, sum25, sum10, sum5, sum3, sum1, sum_rc50, sum_rc25, sum_rc10, sum_rc5 };

					foreach (var sum in banknoteSum)
					{
						if (sum.Text == "Ошибка")
						{
							errorCount++;
						}
					}

					if (!Regex.IsMatch(input, @"^\d{3}\/\d$") || !DateTime.TryParse(date_time.Text, out DateTime date))
					{
						MessageBox.Show("Неверный формат номера мешка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					else if(errorCount > 0)
					{
						MessageBox.Show("Ошибка в расчетах суммы банкнот!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					else
					{
						File.Copy(templatePath, excelFilePath, true);

						ws.Cell("AD13").Value = "02";
						ws.Cell("AD57").Value = "02";
						ws.Cell("AD100").Value = "02";

						ws.Cell("D7").Value = azs.Text + "  " + company.Text; //от кого
						ws.Cell("D51").Value = azs.Text + "  " + company.Text;//от кого
						ws.Cell("D94").Value = azs.Text + "  " + company.Text;//от кого					

						ws.Cell("B4").Value = date.ToString("dd MMMM yyyy года", new System.Globalization.CultureInfo("ru-RU"));
						ws.Cell("B48").Value = date.ToString("dd MMMM yyyy года", new System.Globalization.CultureInfo("ru-RU"));
						ws.Cell("B91").Value = date.ToString("dd MMMM yyyy года", new System.Globalization.CultureInfo("ru-RU"));

						ws.Cell("S9").Value = schet_rub.Text;//счет №	
						ws.Cell("S53").Value = schet_rub.Text;//счет №
						ws.Cell("S96").Value = schet_rub.Text;//счет №

						ws.Cell("E9").Value = company.Text;//наименование банка
						ws.Cell("E53").Value = company.Text;//наименование банка
						ws.Cell("E96").Value = company.Text;//наименование банка

						ws.Cell("N10").Value = summa.Text;//сумма
						ws.Cell("AD8").Value = summa.Text;//сумма
						ws.Cell("AH13").Value = summa.Text;//сумма
						ws.Cell("N54").Value = summa.Text;//сумма
						ws.Cell("AD52").Value = summa.Text;//сумма
						ws.Cell("AH57").Value = summa.Text;//сумма
						ws.Cell("N97").Value = summa.Text;//сумма
						ws.Cell("AD95").Value = summa.Text;//сумма
						ws.Cell("AH100").Value = summa.Text;//сумма
						ws.Cell("AD246").Value = summa.Text;//сумма
						ws.Cell("AD290").Value = summa.Text;//сумма

						ws.Cell("M12").Value = bank_name.Text;//наименование банка
						ws.Cell("M56").Value = bank_name.Text;//наименование банка
						ws.Cell("M99").Value = bank_name.Text;//наименование банка

						ws.Cell("M1").Value = bags_number.Text;//номер мешка
						ws.Cell("AH1").Value = bags_number.Text;//номер мешка
						ws.Cell("M45").Value = bags_number.Text;//номер мешка
						ws.Cell("AH45").Value = bags_number.Text;//номер мешка
						ws.Cell("M88").Value = bags_number.Text;//номер мешка
						ws.Cell("AH88").Value = bags_number.Text;//номер мешка						

						string full = NumberToWordsRub(decimal.Parse(summa.Text));

						// Разбиваем строку по словам
						var words = full.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

						// Получаем первые 3 слова
						string firstLine = string.Join(" ", words.Take(3));

						// Остаток — во вторую строку
						string secondLine = string.Join(" ", words.Skip(3)) + " (000)";

						// Записываем в Excel

						ws.Cell("T16").Value = firstLine.ToString(); // первая строка
						ws.Cell("A18").Value = secondLine.ToString(); // вторая строка
						ws.Cell("T60").Value = firstLine.ToString(); // вторая строка
						ws.Cell("A62").Value = secondLine.ToString(); // вторая строка
						ws.Cell("T103").Value = firstLine.ToString(); // вторая строка
						ws.Cell("A105").Value = secondLine.ToString(); // вторая строка					

						int startRow = 210;

						foreach (var box in banknoteCount)
						{
							if (!string.IsNullOrWhiteSpace(box.Text) && box.Text != "0")
							{
								ws.Cell($"B{startRow}").Value = banknoteBox[banknoteCount.IndexOf(box)].Text;
								ws.Cell($"J{startRow}").Value = banknoteCount[banknoteCount.IndexOf(box)].Text;
								ws.Cell($"AA{startRow}").Value = banknoteSum[banknoteCount.IndexOf(box)].Text;
								startRow += 2;
							}
						}

						workbook.SaveAs(excelFilePath);
						MessageBox.Show("Файл сохранен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
			}
		}

		private void LoadData()
		{
			date_time.Value = DateTime.Now;
			date_time_lei.Value = DateTime.Now;
			date_time_usd.Value = DateTime.Now;

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

		private void sum_usd100_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(usd100.Text, out int num100))
			{
				int sum = num100 * 100;
				sum_usd100.Text = sum.ToString();
			}
			else
			{
				sum_usd100.Text = "Ошибка";
			}
		}

		private void sum_usd50_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(usd50.Text, out int num50))
			{
				int sum = num50 * 50;
				sum_usd50.Text = sum.ToString();
			}
			else
			{
				sum_usd50.Text = "Ошибка";
			}
		}

		private void sum_usd20_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(usd20.Text, out int num20))
			{
				int sum = num20 * 20;
				sum_usd20.Text = sum.ToString();
			}
			else
			{
				sum_usd20.Text = "Ошибка";
			}
		}

		private void sum_usd10_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(usd10.Text, out int num10))
			{
				int sum = num10 * 10;
				sum_usd10.Text = sum.ToString();
			}
			else
			{
				sum_usd10.Text = "Ошибка";
			}
		}

		private void sum_usd5_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(usd5.Text, out int num5))
			{
				int sum = num5 * 5;
				sum_usd5.Text = sum.ToString();
			}
			else
			{
				sum_usd5.Text = "Ошибка";
			}
		}

		private void sum_usd2_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(usd2.Text, out int num2))
			{
				int sum = num2 * 2;
				sum_usd2.Text = sum.ToString();
			}
			else
			{
				sum_usd2.Text = "Ошибка";
			}
		}

		private void sum_usd1_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(usd1.Text, out int num1))
			{
				int sum = num1 * 1;
				sum_usd1.Text = sum.ToString();
			}
			else
			{
				sum_usd1.Text = "Ошибка";
			}
		}

		private void sum_l1000_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(l1000.Text, out int num1000))
			{
				int sum = num1000 * 1000;
				sum_l1000.Text = sum.ToString();
			}
			else
			{
				sum_l1000.Text = "Ошибка";
			}
		}

		private void sum_l500_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(l500.Text, out int num500))
			{
				int sum = num500 * 500;
				sum_l500.Text = sum.ToString();
			}
			else
			{
				sum_l500.Text = "Ошибка";
			}
		}

		private void sum_l200_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(l200.Text, out int num200))
			{
				int sum = num200 * 200;
				sum_l200.Text = sum.ToString();
			}
			else
			{
				sum_l200.Text = "Ошибка";
			}
		}

		private void sum_l100_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(l100.Text, out int num100))
			{
				int sum = num100 * 100;
				sum_l100.Text = sum.ToString();
			}
			else
			{
				sum_l100.Text = "Ошибка";
			}
		}

		private void sum_l50_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(l50.Text, out int num50))
			{
				int sum = num50 * 50;
				sum_l50.Text = sum.ToString();
			}
			else
			{
				sum_l50.Text = "Ошибка";
			}
		}

		private void sum_l20_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(l20.Text, out int num20))
			{
				int sum = num20 * 20;
				sum_l20.Text = sum.ToString();
			}
			else
			{
				sum_l20.Text = "Ошибка";
			}
		}

		private void sum_l10_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(l10.Text, out int num10))
			{
				int sum = num10 * 10;
				sum_l10.Text = sum.ToString();
			}
			else
			{
				sum_l10.Text = "Ошибка";
			}
		}

		private void sum_l5_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(l5.Text, out int num5))
			{
				int sum = num5 * 5;
				sum_l5.Text = sum.ToString();
			}
			else
			{
				sum_l5.Text = "Ошибка";
			}
		}

		private void sum_l2_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(l2.Text, out int num2))
			{
				int sum = num2 * 2;
				sum_l2.Text = sum.ToString();
			}
			else
			{
				sum_l2.Text = "Ошибка";
			}
		}

		private void sum_l1_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(l1.Text, out int num1))
			{
				int sum = num1 * 1;
				sum_l1.Text = sum.ToString();
			}
			else
			{
				sum_l1.Text = "Ошибка";
			}
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

		private void total_sum_usd_LabelChanged(object sender, EventArgs e)
		{
			double sum = 0.00;
			TextBox[] textBoxes = { sum_usd100, sum_usd50, sum_usd20, sum_usd10, sum_usd5, sum_usd2, sum_usd1 };

			foreach (TextBox tb in textBoxes)
			{
				if (double.TryParse(tb.Text, out double value))
				{
					sum += value;
				}
			}
			summa_usd.Text = sum.ToString("F2");
		}

		private void total_sum_lei_LabelChanged(object sender, EventArgs e)
		{
			double sum = 0.00;
			TextBox[] textBoxes = { sum_l1000, sum_l500, sum_l200, sum_l100, sum_l50, sum_l20, sum_l10, sum_l5, sum_l2, sum_l1 };

			foreach (TextBox tb in textBoxes)
			{
				if (double.TryParse(tb.Text, out double value))
				{
					sum += value;
				}
			}
			summa_lei.Text = sum.ToString("F2");
		}

		private void total_sum_LabelChanged(object sender, EventArgs e)
		{
			double sum = 0.00;
			TextBox[] textBoxes = { sum500, sum200, sum100, sum50, sum25, sum10, sum5, sum3, sum1, sum_rc50, sum_rc25, sum_rc10, sum_rc5 };

			foreach (TextBox tb in textBoxes)
			{
				if (double.TryParse(tb.Text, out double value))
				{
					sum += value;
				}
			}
			summa.Text = sum.ToString("F2");
		}

		public static string NumberToWordsUsd(decimal amount)
		{
			if (amount == 0)
				return "ноль долларов 00 центов";

			string[] units = { "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
			string[] unitsFemale = { "одна", "две", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
			string[] teens = { "одиннадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" };
			string[] tens = { "десять", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто" };
			string[] hundreds = { "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };
			string[] thousandsForms = { "тысяча", "тысячи", "тысяч" };
			string[] millionsForms = { "миллион", "миллиона", "миллионов" };
			string[] dollarForms = { "доллар", "доллара", "долларов" };
			string[] centsForms = { "цент", "цента", "центов" };

			StringBuilder result = new StringBuilder();

			long intPart = (long)Math.Floor(amount);
			int cents = (int)Math.Round((amount - intPart) * 100);

			int GetFormIndex(int number)
			{
				int n = number % 100;
				if (n >= 11 && n <= 19) return 2;
				int last = n % 10;
				if (last == 1) return 0;
				if (last >= 2 && last <= 4) return 1;
				return 2;
			}

			void AppendTriplet(int n, bool isFemale, string[] forms)
			{
				if (n == 0) return;

				if (n >= 100)
				{
					int h = n / 100;
					result.Append(hundreds[h - 1] + " ");
				}

				int remainder = n % 100;

				if (remainder == 10)
				{
					result.Append(tens[0] + " "); // "десять"
				}
				else if (remainder > 10 && remainder < 20)
				{
					result.Append(teens[remainder - 11] + " "); // "одиннадцать" и т.п.
				}
				else
				{
					int ten = remainder / 10;
					int unit = remainder % 10;

					if (ten >= 2)
					{
						result.Append(tens[ten - 1] + " ");
					}

					if (unit > 0)
					{
						result.Append((isFemale ? unitsFemale[unit - 1] : units[unit - 1]) + " ");

					}
				}
				result.Append(forms[GetFormIndex(n)] + " ");
			}

			if (intPart >= 1000000)
			{
				int millions = (int)(intPart / 1000000);
				AppendTriplet(millions, false, millionsForms);
				intPart %= 1000000;
			}

			if (intPart >= 1000)
			{
				int thousands = (int)(intPart / 1000);
				AppendTriplet(thousands, true, thousandsForms);
				intPart %= 1000;
			}

			AppendTriplet((int)intPart, false, dollarForms);
			
			result.Append($"{cents:00} {centsForms[GetFormIndex(cents)]}"); // "бань" или "баней"

			return result.ToString().Trim();
		}

		public static string NumberToWordsLei(decimal amount)
		{
			if (amount == 0)
				return "ноль лей 00 бань";

			string[] units = { "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
			string[] unitsFemale = { "одна", "две", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
			string[] teens = { "одиннадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" };
			string[] tens = { "десять", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто" };
			string[] hundreds = { "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };
			string[] thousandsForms = { "тысяча", "тысячи", "тысяч" };
			string[] millionsForms = { "миллион", "миллиона", "миллионов" };
			string[] leiForms = { "лей", "лея", "леев" };			

			StringBuilder result = new StringBuilder();

			long intPart = (long)Math.Floor(amount);
			int kopeks = (int)Math.Round((amount - intPart) * 100);

			int GetFormIndex(int number)
			{
				int n = number % 100;
				if (n >= 11 && n <= 19) return 2;
				int last = n % 10;
				if (last == 1) return 0;
				if (last >= 2 && last <= 4) return 1;
				return 2;
			}

			void AppendTriplet(int n, bool isFemale, string[] forms)
			{
				if (n == 0) return;

				if (n >= 100)
				{
					int h = n / 100;					
					result.Append(hundreds[h - 1] + " ");					
				}

				int remainder = n % 100;

				if (remainder == 10)
				{
					result.Append(tens[0] + " "); // "десять"
				}
				else if (remainder > 10 && remainder < 20)
				{
					result.Append(teens[remainder - 11] + " "); // "одиннадцать" и т.п.
				}
				else
				{
					int ten = remainder / 10;
					int unit = remainder % 10;					

					if (ten >= 2)
					{
						result.Append(tens[ten - 1] + " ");
					}

					if(unit>0)
					{						
						result.Append((isFemale ? unitsFemale[unit - 1] : units[unit - 1]) + " ");
																		
					}					
				}
				result.Append(forms[GetFormIndex(n)] + " ");
			}

			if (intPart >= 1000000)
			{
				int millions = (int)(intPart / 1000000);
				AppendTriplet(millions, false, millionsForms);
				intPart %= 1000000;
			}

			if (intPart >= 1000)
			{
				int thousands = (int)(intPart / 1000);
				AppendTriplet(thousands, true, thousandsForms);
				intPart %= 1000;
			}

			AppendTriplet((int)intPart, false, leiForms);

			string baniWord=(kopeks == 1) ? "бань" : "баней";
			result.Append($"{kopeks:00} {baniWord}"); // "бань" или "баней"

			return result.ToString().Trim();
		}

		public static string NumberToWordsRub(decimal amount)
		{
			if (amount == 0)
				return "ноль рублей 00 копеек";

			string[] units = { "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
			string[] unitsFemale = { "одна", "две", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
			string[] teens = { "одиннадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" };
			string[] tens = { "десять", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто" };
			string[] hundreds = { "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };
			string[] thousandsForms = { "тысяча", "тысячи", "тысяч" };
			string[] millionsForms = { "миллион", "миллиона", "миллионов" };
			string[] rubForms = { "рубль", "рубля", "рублей" };
			string[] kopForms = { "копейка", "копейки", "копеек" };

			StringBuilder result = new StringBuilder();

			long intPart = (long)Math.Floor(amount);
			int kopeks = (int)Math.Round((amount - intPart) * 100);

			int GetFormIndex(int number)
			{
				int n = number % 100;
				if (n >= 11 && n <= 19) return 2;
				int last = n % 10;
				if (last == 1) return 0;
				if (last >= 2 && last <= 4) return 1;
				return 2;
			}

			void AppendTriplet(int n, bool isFemale, string[] forms)
			{
				if (n == 0) return;

				if (n >= 100)
				{
					int h = n / 100;
					if (h > 0)
					{
						result.Append(hundreds[h - 1] + " ");
					}
				}

				int remainder = n % 100;

				if (remainder == 10)
				{
					result.Append(tens[0] + " "); // "десять"
				}
				else if (remainder > 10 && remainder < 20)
				{
					result.Append(teens[remainder - 11] + " "); // "одиннадцать" и т.п.
				}
				else
				{
					int ten = remainder / 10;
					int unit = remainder % 10;

					if (ten >= 2)
					{
						result.Append(tens[ten - 1] + " ");
					}

					if (unit > 0)
					{
						if (isFemale)
						{
							result.Append(unitsFemale[unit - 1] + " ");
						}
						else
						{
							result.Append(units[unit - 1] + " ");
						}
					}
				}

				int formIndex = GetFormIndex(n);
				result.Append(forms[formIndex] + " ");
			}

			if (intPart >= 1000000)
			{
				int millions = (int)(intPart / 1000000);
				AppendTriplet(millions, false, millionsForms);
				intPart %= 1000000;
			}

			if (intPart >= 1000 && intPart < 1000000)
			{
				int thousands = (int)(intPart / 1000);
				AppendTriplet(thousands, true, thousandsForms);
				intPart %= 1000;
			}

			AppendTriplet((int)intPart, false, rubForms);

			result.Append($"{kopeks:00} {kopForms[GetFormIndex(kopeks)]}");

			return result.ToString().Trim();
		}		
	}
}