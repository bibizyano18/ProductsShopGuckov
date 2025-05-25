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
using ProductsShop.View;

namespace ProductsShop
{
    public partial class MainForm : Form, IProductView
    {
        public MainForm()
        {
            InitializeComponent();
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
                item.SubItems.Add(product.Price.ToString() + " руб.");
                listViewProducts.Items.Add(item);
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
    }
}
