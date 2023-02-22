using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.DataAccess.Concrete.EntityFramework;

namespace Northwind.WindowsFormsUI
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private IProductService _productService = new ProductManager(new EfProductDal());
        private ICategoryService _categoryService = new CategoryManager(new EfCategoryDal());
        private IEmployeeService _employeeService = new EmployeeManager(new EfEmployeeDal());
        private ICustomerService _customerService = new CustomerManager(new EfCustomerDal());
        private ISupplierService _supplierService = new SupplierManager(new EfSupplierDal());

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
        }

        private void LoadCategories()
        {
            cmbCategory.DataSource = _categoryService.GetAll();
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";
        }


        private void LoadProducts()
        {
            dgvProducts.DataSource = _productService.GetAll();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvProducts.DataSource =
                    _productService.GetProductsByCategory(Convert.ToInt32(cmbCategory.SelectedValue));
            }
            catch 
            {
                
            }
        }

        private void txtProduct_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtProduct.Text))
            {
                LoadProducts();
            }
            else
            {
                dgvProducts.DataSource = _productService.GetProductsByProductName(txtProduct.Text);
            }
        }

        private void txtEmployee_Click(object sender, EventArgs e)
        {
            dgvProducts.DataSource = _employeeService.GetAll();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            dgvProducts.DataSource = _customerService.GetAll();
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            dgvProducts.DataSource = _supplierService.GetAll();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            dgvProducts.DataSource = _productService.GetAll();
        }
    }
}
