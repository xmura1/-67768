using ProductLibrary;
using System;
using System.Windows.Forms;

namespace ProductUI
{
    public partial class Form1 : Form
    {
        private ProductCatalog catalog = new ProductCatalog();

        public Form1()
        {
            InitializeComponent();
        }

        private void RefreshGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = catalog.GetAllProducts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var product = new Product(
                txtId.Text,
                txtName.Text,
                txtCategory.Text,
                txtDescription.Text,
                decimal.Parse(txtPrice.Text),
                int.Parse(txtQuantity.Text)
            );
            catalog.AddProduct(product);
            RefreshGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            catalog.RemoveProduct(txtId.Text);
            RefreshGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var p = catalog.SearchById(txtId.Text);
            if (p != null)
                MessageBox.Show($"Найден: {p.Name}");
            else
                MessageBox.Show("Не найден.");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            catalog.SaveToFile("products.json");
            MessageBox.Show("Сохранено");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            catalog.LoadFromFile("products.json");
            RefreshGrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
