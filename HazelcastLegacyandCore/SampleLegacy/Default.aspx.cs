using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleLegacy
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
            }

            RegisterAsyncTask(new PageAsyncTask(GetCartItemsAsync));
        }

        private async Task GetCartItemsAsync()
        {
            var cartItems = await ECommerceDataHazelCast.Instance.GetCartItemsAsync();
            cartItemsRepeater.DataSource = cartItems;
            cartItemsRepeater.DataBind();
        }

        protected void addOrange_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(async (t) =>
            {
                await ECommerceDataHazelCast.Instance.AddCartItemAsync(1, "Orange", 1.50m, 1);
            }));
            RegisterAsyncTask(new PageAsyncTask(GetCartItemsAsync));
        }

        protected void addCoconut_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(async (t) =>
            {
                await ECommerceDataHazelCast.Instance.AddCartItemAsync(2, "Coconut", 2.50m, 1);
            }));
            RegisterAsyncTask(new PageAsyncTask(GetCartItemsAsync));
        }

        protected void addApple_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(async (t) =>
            {
                await ECommerceDataHazelCast.Instance.AddCartItemAsync(3, "Apple", 1.00m, 1);
            }));
            RegisterAsyncTask(new PageAsyncTask(GetCartItemsAsync));
        }

        protected void addGrapefruit_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(async (t) =>
            {
                await ECommerceDataHazelCast.Instance.AddCartItemAsync(4, "Grapefruit", 2.0m, 1);
            }));
            RegisterAsyncTask(new PageAsyncTask(GetCartItemsAsync));
        }
    }
}