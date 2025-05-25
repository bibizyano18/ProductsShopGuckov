using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductsShop.Model;
using ProductsShop.Model.Data;
using ProductsShop.View;

namespace ProductsShop
{
    public partial class MainForm : Form, IProductView
    {
        public MainForm()
        {
            InitializeComponent();
  
        }
        public int DataGridViewRowIndex;
        public event EventHandler AddProductRequested;
        public event EventHandler SaveDataInFile;
        public event EventHandler ReadDataFromFile;
        public event EventHandler DeleteProductRequested;
        public void DisplayProducts(List<Product> products)
        {
            // Настройка DataGridView
            dataGridViewProducts.AutoGenerateColumns = false;
            dataGridViewProducts.RowHeadersVisible = false;
            dataGridViewProducts.AllowUserToAddRows = false;
            dataGridViewProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Очистка старых колонок
            dataGridViewProducts.Columns.Clear();

            // Создаем колонки
            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 50
            });

            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Name",
                HeaderText = "Название",
                DataPropertyName = "Name",
                Width = 150,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Price",
                HeaderText = "Цена",
                Width = 80,
            });

            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Type",
                HeaderText = "Тип",
                Width = 120
            });

            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Unit",
                HeaderText = "Ед.изм.",
                Width = 80
            });

            // Заполняем данные
            var rows = new List<DataGridViewRow>();
            foreach (var product in products)
            {
                var row = new DataGridViewRow();
                row.CreateCells(dataGridViewProducts);

                row.Cells[0].Value = product.Id;
                row.Cells[1].Value = product.Name;
                row.Cells[2].Value = product.Price + " ₽";
                row.Cells[3].Value = product.IsWeighted ? "Взвешиваемый" : "Штучный";
                row.Cells[4].Value = product.IsWeighted ? "кг" : "шт.";

                row.DefaultCellStyle.BackColor = product.IsWeighted ? Color.Lavender : Color.Honeydew;
                rows.Add(row);
            }

            // Добавляем все строки сразу (для производительности)
            dataGridViewProducts.Rows.AddRange(rows.ToArray());
            dataGridViewProducts.EnableHeadersVisualStyles = false;
            dataGridViewProducts.ReadOnly = true;
            dataGridViewProducts.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.LightGray,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
        }
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonFileRead_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ReadDataFromFile?.Invoke(openFileDialog.FileName, EventArgs.Empty);
            }
        }

        private void buttonAddToCart_Click(object sender, EventArgs e)
        {
            AddProductRequested?.Invoke(DataGridViewRowIndex, EventArgs.Empty);
        }

        private void dataGridViewProducts_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView gv = sender as DataGridView;
            if (gv != null && gv.SelectedRows.Count > 0)
            {
                DataGridViewRow row = gv.SelectedRows[0];
                if (row != null)
                {
                    DataGridViewRowIndex = row.Index;
                }
            }
        }
    }
}
