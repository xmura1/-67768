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
            listBox1.Items.Clear();
            foreach (var product in catalog.GetAllProducts())
            {
                listBox1.Items.Add($"ID: {product.Id}, Название: {product.Name}, Цена: {product.Price}₽");
            }
            
        }

    

      


        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            catalog.RemoveProduct(txtId.Text);
            RefreshGrid();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
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

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            var p = catalog.SearchById(txtId.Text);
            if (p != null)
                MessageBox.Show($"Найден: {p.Name}");
            else
                MessageBox.Show("Не найден.");
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            catalog.SaveToFile("products.json");
            MessageBox.Show("Сохранено");
        }

        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            catalog.LoadFromFile("products.json");
            RefreshGrid();
        }
    }
}
