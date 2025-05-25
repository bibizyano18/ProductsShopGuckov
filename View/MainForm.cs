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
            if (listViewProducts.Columns.Count == 0)
            {
                listViewProducts.Columns.Add("ID", 50);
                listViewProducts.Columns.Add("Название", 150);
                listViewProducts.Columns.Add("Цена", 100);
                listViewProducts.Columns.Add("Тип", 100);
                listViewProducts.Columns.Add("Ед. изм.", 80);
            }
        }
        public event EventHandler AddProductRequested;
        public event EventHandler SaveDataInFile;
        public event EventHandler ReadDataFromFile;
        public event EventHandler DeleteProductRequested;
        public void DisplayProducts(List<Product> products)
        {
            listViewProducts.Items.Clear();
           
            foreach (var product in products)
            {
                ListViewItem item = new ListViewItem(product.Id.ToString());
                item.SubItems.Add(product.Name);
                item.SubItems.Add(product.Price.ToString("C")); // Формат валюты
                item.SubItems.Add(product.IsWeighted ? "Взвешиваемый" : "Штучный");
                item.SubItems.Add(product.IsWeighted ? "кг" : "шт.");
                item.BackColor = product.IsWeighted ? Color.LightBlue : Color.LightGreen;

                listViewProducts.Items.Add(item);
            }

            // Автоподбор ширины колонок
            foreach (ColumnHeader column in listViewProducts.Columns)
            {
                column.Width = -2; // Автоширина по содержимому
            }
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
                //ReadDataFromFile?.Invoke(openFileDialog.FileName, EventArgs.Empty);
                FileReader fileReader = new FileReader();
                DisplayProducts(fileReader.ReadProductsFromFile(openFileDialog.FileName));
            }
        }
    }
}
