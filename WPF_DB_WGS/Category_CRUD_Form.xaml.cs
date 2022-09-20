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
    /// Interaction logic for Category_CRUD_Form.xaml
    /// </summary>
    public partial class Category_CRUD_Form : Window
    {
        EFCFContext db;
        ObservableCollection<Category> categoryCollection;
        public Category_CRUD_Form()
        {
            InitializeComponent();
            db = new EFCFContext();
        }

        private void MianLoaded_Loaded(object sender, RoutedEventArgs e)
        {
            categoryCollection = new ObservableCollection<Category>(db.Categories);
            lstCategory.DataContext = categoryCollection;

            btnCancel.IsEnabled = false;
            btnSave.IsEnabled = false;
        }

        private void lstProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainLoaded.DataContext = lstCategory.SelectedItem as Category;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Add Empty record in observable collection
            categoryCollection.Add(new Category());  //new empty Category object added at last position append

            //make that record as an active selection
            //Newly added record is at last position
            //If i have 5 records , 1 record at position 0 then last record at position 4 
            lstCategory.SelectedIndex = categoryCollection.Count - 1;

            //focus CategoryId
            txtCategoryId.Focus();

            btnAdd.IsEnabled = false;
            btnEdit.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnCancel.IsEnabled = true;
            btnSave.IsEnabled = true;
            btnExit.IsEnabled = false;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Category category = lstCategory.SelectedItem as Category;
            categoryCollection.Remove(category);

            lstCategory.SelectedIndex = 0;

            btnAdd.IsEnabled = true;
            btnEdit.IsEnabled = true;
            btnDelete.IsEnabled = true;
            btnCancel.IsEnabled = false;
            btnSave.IsEnabled = false;
            btnExit.IsEnabled = true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Category newCategory = lstCategory.SelectedItem as Category;
            db.Categories.Add(newCategory);
            db.SaveChanges();
            MessageBox.Show("Record Inserted");

            btnAdd.IsEnabled = true;
            btnEdit.IsEnabled = true;
            btnDelete.IsEnabled = true;
            btnCancel.IsEnabled = false;
            btnSave.IsEnabled = false;
            btnExit.IsEnabled = true;
            lstCategory.SelectedIndex = 0;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(txtCategoryId.Text);
            //search for Category by id
            Category updateCategory = db.Categories.SingleOrDefault(p => p.CategoryId == id);

            if (updateCategory == null)
            {
                MessageBox.Show("Record not Found");
            }
            else
            {
                Category UpdateData = lstCategory.SelectedItem as Category;

                updateCategory.CategoryName = UpdateData.CategoryName;

                db.SaveChanges();
                MessageBox.Show("Reord updated");
            }

            lstCategory.SelectedIndex = 0;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you want to delete", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                //read textbox id value
                int id = Convert.ToInt32(txtCategoryId.Text);
                //search for category by id
                Category deleteCategory = db.Categories.SingleOrDefault(p => p.CategoryId == id);

                //if not found
                if (deleteCategory == null)
                {
                    MessageBox.Show("Record not Found");
                }
                else
                {
                    categoryCollection.Remove(deleteCategory);
                    db.Categories.Remove(deleteCategory);
                    db.SaveChanges();
                    MessageBox.Show("Record deleted");
                }
                lstCategory.SelectedIndex = 0;
            }
        }
    }
}
