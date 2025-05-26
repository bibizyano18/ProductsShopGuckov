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

namespace ProductsShop.View
{
    public partial class Cart : Form, ICartView
    {
        public Cart()
        {
            InitializeComponent();
        }

        public event EventHandler DeleteProductRequested;
        public event EventHandler UpdateCartCount;
        public event EventHandler SaveDataInFile;
        public event EventHandler ReadDataFromFile;

        public void DisplayProducts(List<Product> cartItems)
        {
            dataGridViewCart.AutoGenerateColumns = false;
            dataGridViewCart.RowHeadersVisible = false;
            dataGridViewCart.AllowUserToAddRows = false;
            dataGridViewCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCart.ReadOnly = true;

            dataGridViewCart.Columns.Clear();
            dataGridViewCart.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Name",
                HeaderText = "Товар",
                Width = 150,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dataGridViewCart.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Quantity",
                HeaderText = "Кол-во",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            dataGridViewCart.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Unit",
                HeaderText = "Ед.изм.",
                Width = 60
            });

            dataGridViewCart.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "PricePerUnit",
                HeaderText = "Цена за ед.",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "N2 ₽",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            dataGridViewCart.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "TotalPrice",
                HeaderText = "Сумма",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "N2 ₽",
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                }
            });

            // Заполняем данные
            decimal cartTotal = 0;
            foreach (var item in cartItems)
            {
                decimal itemTotal = item.IsWeighted ?
                    item.Price * (decimal)item.Weight :
                    item.Price;

                dataGridViewCart.Rows.Add(
                    item.Name,
                    item.IsWeighted ? item.Weight.ToString("0.00") : 1.ToString(),
                    item.IsWeighted ? "кг" : "шт.",
                    item.Price,
                    itemTotal
                );

                cartTotal += itemTotal;
            }

            // Добавляем итоговую строку
            dataGridViewCart.Rows.Add(
                "ИТОГО:",
                "",
                "",
                "",
                cartTotal
            );
            dataGridViewCart.Rows[dataGridViewCart.Rows.Count - 1].DefaultCellStyle.Font =
                new Font("Segoe UI", 9, FontStyle.Bold);

            // Настройка внешнего вида
            dataGridViewCart.EnableHeadersVisualStyles = false;
            dataGridViewCart.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
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
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
            base.OnFormClosing(e);
        }
    }
}
