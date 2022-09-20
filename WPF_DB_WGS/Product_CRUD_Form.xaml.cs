using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace WPF_DB_WGS
{
    /// <summary>
    /// Interaction logic for Product_CRUD_Form.xaml
    /// </summary>
    public partial class Product_CRUD_Form : Window
    {
        EFCFContext db;
        ObservableCollection<Product> productCollection;
        public Product_CRUD_Form()
        {
            InitializeComponent();
            db = new EFCFContext();
        }

        private void MainLoaded_Loaded(object sender, RoutedEventArgs e)
        {
            productCollection = new ObservableCollection<Product>(db.Products);
            lstProducts.DataContext = productCollection;

            btnCancel.IsEnabled = false;
            btnSave.IsEnabled = false;
        }

        private void lstProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainLoaded.DataContext = lstProducts.SelectedItem as Product;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Add Empty record in observable collection
            productCollection.Add(new Product());  //new empty product object added at last position append

            //make that record as an active selection
            //Newly added record is at last position
            //If i have 5 records , 1 record at position 0 then last record at position 4 
            lstProducts.SelectedIndex= productCollection.Count - 1;

            //focus productname
            txtProductId.Focus();

            btnAdd.IsEnabled = false;
            btnEdit.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnCancel.IsEnabled = true;
            btnSave.IsEnabled = true;
            btnExit.IsEnabled = false;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Product product = lstProducts.SelectedItem as Product;
            productCollection.Remove(product);

            lstProducts.SelectedIndex = 0;

            btnAdd.IsEnabled = true;
            btnEdit.IsEnabled = true;
            btnDelete.IsEnabled = true;
            btnCancel.IsEnabled = false;
            btnSave.IsEnabled = false;
            btnExit.IsEnabled = true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Product newProduct = lstProducts.SelectedItem as Product;
            db.Products.Add(newProduct);
            db.SaveChanges();
            MessageBox.Show("Record Inserted");

            btnAdd.IsEnabled = true;
            btnEdit.IsEnabled = true;
            btnDelete.IsEnabled = true;
            btnCancel.IsEnabled = false;
            btnSave.IsEnabled = false;
            btnExit.IsEnabled = true;
            lstProducts.SelectedIndex = 0;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(txtProductId.Text);
            //search for product by id
            Product updateProduct = db.Products.SingleOrDefault(p => p.ProductId == id);

            if(updateProduct == null)
            {
                MessageBox.Show("Record not Found");
            }
            else
            {
                Product UpdateData = lstProducts.SelectedItem as Product;

                updateProduct.ProductName = UpdateData.ProductName;
                updateProduct.Price = UpdateData.Price;
                updateProduct.MfgDate = UpdateData.MfgDate;

                db.SaveChanges();
                MessageBox.Show("Reord updated");
            }

            lstProducts.SelectedIndex = 0;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you want to delete", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if(result == MessageBoxResult.Yes)
            {
                //read textbox id value
                int id = Convert.ToInt32(txtProductId.Text);
                //search for product by id
                Product deleteProduct = db.Products.SingleOrDefault(p => p.ProductId == id);

                //if not found
                if(deleteProduct == null)
                {
                    MessageBox.Show("Record not Found");
                }
                else
                {
                    productCollection.Remove(deleteProduct);
                    db.Products.Remove(deleteProduct);
                    db.SaveChanges();
                    MessageBox.Show("Record deleted");
                }
                lstProducts.SelectedIndex = 0;
            }
        }
    }
}
