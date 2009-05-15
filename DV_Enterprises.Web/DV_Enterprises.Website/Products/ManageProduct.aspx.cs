using System;
using System.Web.UI;
using DV_Enterprises.Web.Data.Domain;
using DV_Enterprises.Web.Presenter.Products;
using DV_Enterprises.Web.Presenter.Products.Interface;

namespace Products
{
    public partial class ManageProduct : Page, IManageProduct
    {
        private ManageProductPresenter _presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new ManageProductPresenter();
            _presenter.Init(this, IsPostBack);
        }

        public void LoadData(Product product)
        {
            litProductId.Text = product.ID.ToString();
            txtName.Text = product.Name;
            txtDescription.Text = product.Description;
            txtPrice.Text = product.Price.ToString();
            cboIsActive.Checked = product.IsActive;
        }

        protected void butSubmit_Click(object sender, EventArgs e)
        {
            var product = new Product
                              {
                                  ID = litProductId.Text.Length != 0 ? Convert.ToInt32(litProductId.Text) : 0,
                                  Name = txtName.Text,
                                  Description = txtDescription.Text,
                                  Price = Convert.ToDecimal(txtPrice.Text),
                                  IsActive = cboIsActive.Checked,
                              };

            _presenter.SaveProduct(product);
            Response.Redirect("~/Products/Default.aspx");
        }
}
}