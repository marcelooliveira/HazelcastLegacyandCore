using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SampleModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleNetCore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        private readonly IECommerceDataHazelCast eCommerceData;

        public IndexModel(ILogger<IndexModel> logger, IECommerceDataHazelCast eCommerceData)
        {
            this.logger = logger;
            this.eCommerceData = eCommerceData;
        }

        public List<CartItem> CartItems { get; private set; }

        [BindProperty]
        public string addOrange { get; set; }
        [BindProperty]
        public string addCoconut { get; set; }
        [BindProperty]
        public string addApple { get; set; }
        [BindProperty]
        public string addGrapefruit { get; set; }

        [BindProperty]
        public string checkoutSubmit { get; set; }

        public async Task OnGetAsync()
        {
            await InitializePageAsync();
        }

        private async Task InitializePageAsync()
        {
            this.CartItems = await eCommerceData.GetCartItemsAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!string.IsNullOrWhiteSpace(addOrange))
            {
                await eCommerceData.AddCartItemAsync(1, "Orange", 1.50m, 1);
            }
            if (!string.IsNullOrWhiteSpace(addCoconut))
            {
                await eCommerceData.AddCartItemAsync(2, "Coconut", 2.50m, 1);
            }
            if (!string.IsNullOrWhiteSpace(addApple))
            {
                await eCommerceData.AddCartItemAsync(3, "Apple", 1.00m, 1);
            }
            if (!string.IsNullOrWhiteSpace(addGrapefruit))
            {
                await eCommerceData.AddCartItemAsync(4, "Grapefruit", 2.0m, 1);
            }

            await InitializePageAsync();
            return Page();
        }
    }
}
