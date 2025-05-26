using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductsShop
{
    public partial class WeightInputDialog : Form
{
    public decimal Weight { get; private set; }
    
    public WeightInputDialog()
    {
        InitializeComponent();
    }
    
    private void btnOK_Click(object sender, EventArgs e)
    {
        // Проверка и преобразование введенных значений
        if (decimal.TryParse(textBox1.Text, out decimal num) && num > 0)
        {
            Weight = num;
            DialogResult = DialogResult.OK;
            Close();
        }
        else
        {
            MessageBox.Show("Пожалуйста, введите корректные числовые значения!");
        }
    }
    
    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
}
