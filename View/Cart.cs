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

        private int DataGridViewRowIndex = -1;
        private List<Product> cartProducts;
        public event EventHandler DeleteProductRequested;

        public void DisplayProducts(List<Product> cartItems)
        {
            cartProducts = cartItems;

            // Настройка DataGridView
            dataGridViewCart.AutoGenerateColumns = false;
            dataGridViewCart.RowHeadersVisible = false;
            dataGridViewCart.AllowUserToAddRows = false;
            dataGridViewCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCart.ReadOnly = true;

            // Очистка и настройка колонок
            dataGridViewCart.Columns.Clear();
            dataGridViewCart.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false },
                new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Товар", Width = 150, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
                new DataGridViewTextBoxColumn { Name = "Quantity", HeaderText = "Кол-во", Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight } },
                new DataGridViewTextBoxColumn { Name = "Unit", HeaderText = "Ед.изм.", Width = 60 },
                new DataGridViewTextBoxColumn { Name = "PricePerUnit", HeaderText = "Цена за ед.", Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight } },
                new DataGridViewTextBoxColumn { Name = "TotalPrice", HeaderText = "Сумма", Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Font = new Font("Segoe UI", 9, FontStyle.Bold) } }
            );

            // Группируем товары по ID
            var groupedItems = cartItems
                .GroupBy(p => p.Id)
                .Select(g => new {
                    Product = g.First(),
                    Count = g.Count(),
                    TotalWeight = g.Sum(p => p.Weight),
                    TotalPrice = g.Sum(p => p.IsWeighted ? p.Price * (decimal)p.Weight : p.Price)
                })
                .ToList();

            // Заполняем данные
            decimal cartTotal = 0;
            foreach (var group in groupedItems)
            {
                var product = group.Product;
                string quantity = product.IsWeighted ?
                    group.TotalWeight.ToString("0.00") :
                    group.Count.ToString();

                dataGridViewCart.Rows.Add(
                    product.Id,
                    product.Name,
                    quantity,
                    product.IsWeighted ? "кг" : "шт.",
                    product.Price + " ₽",
                    group.TotalPrice + " ₽"
                );

                cartTotal += group.TotalPrice;
            }

            // Добавляем итоговую строку
            if (groupedItems.Any())
            {
                int lastRowIndex = dataGridViewCart.Rows.Add(
                    null, // ID
                    "ИТОГО:",
                    null, // Quantity
                    null, // Unit
                    null, // PricePerUnit
                    cartTotal + " ₽"
                );

                dataGridViewCart.Rows[lastRowIndex].DefaultCellStyle.Font =
                    new Font("Segoe UI", 9, FontStyle.Bold);
            }

            // Настройка внешнего вида
            dataGridViewCart.EnableHeadersVisualStyles = false;
            dataGridViewCart.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
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

        private void dataGridViewCart_SelectionChanged(object sender, EventArgs e)
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCart.SelectedRows.Count == 0)
            {
                ShowError("Выберите товар для удаления");
                return;
            }
            else
            {
                // Получаем ID из выбранной строки
                var selectedRow = dataGridViewCart.SelectedRows[0];
                int productId = (int)selectedRow.Cells["Id"].Value;
                for (int i = 0; i < cartProducts.Count; i++) 
                {
                    if (cartProducts[i].Id == productId) 
                    { 
                        DeleteProductRequested?.Invoke(i, EventArgs.Empty);
                        break;
                    }
                }
            }
        }
        public void UpdateCartCounter(int count)
        {
            labelCart.Text = $"Корзина: {count}";
            labelCart.ForeColor = count == 0 ? Color.Gray : Color.Black;
        }
    }
}
