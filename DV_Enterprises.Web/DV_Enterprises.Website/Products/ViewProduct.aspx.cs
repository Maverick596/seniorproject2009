using System;
using System.Web.UI;
using DV_Enterprises.Web.Data.Domain;
using DV_Enterprises.Web.Presenter.Products;
using DV_Enterprises.Web.Presenter.Products.Interface;

namespace Products
{
    public partial class ViewProduct : Page, IViewProduct
    {
        private ViewProductPresenter _presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new ViewProductPresenter();
            _presenter.Init(this, IsPostBack);
        }

        public void LoadData(Product product)
        {
            lblName.Text = product.Name;
            lblPrice.Text = product.Price.ToString();
            lblDescription.Text = product.Description;
            cboActive.Checked = product.Active;
        }
    }
}