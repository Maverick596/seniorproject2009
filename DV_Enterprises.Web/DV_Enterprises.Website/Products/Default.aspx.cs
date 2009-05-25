using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using DV_Enterprises.Web.Data.Domain;
using DV_Enterprises.Web.Presenter.Products;
using DV_Enterprises.Web.Presenter.Products.Interface;

namespace Products
{
    public partial class Default : Page, IDefault
    {
        private DefaultPresenter _presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new DefaultPresenter();
            _presenter.Init(this);
        }

        public void LoadData(List<Product> products)
        {
            lvProducts.DataSource = products;
            lvProducts.DataBind();
        }

        public void lvProdusts_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var litProductId = e.Item.FindControl("litProductID") as Literal;
            var linkProductName = e.Item.FindControl("linkProductName") as HyperLink;
            var lbEdit = e.Item.FindControl("lbEdit") as LinkButton;

            lbEdit.Attributes.Add("ProductID", litProductId.Text);
            
            linkProductName.NavigateUrl = string.Format("~/Products/ViewProduct.aspx?ProductID={0}", litProductId.Text);

        }

        public void lbEdit_Click(object sender, EventArgs e)
        {
            var lbEdit = sender as LinkButton;
            _presenter.EditProduct(Convert.ToInt32(lbEdit.Attributes["ProductID"]));
        }
}
}