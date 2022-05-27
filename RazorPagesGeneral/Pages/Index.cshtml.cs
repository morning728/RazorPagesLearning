using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesGeneral.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string test_var;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            test_var = "4";
        }

        public void OnGet()
        {
            test_var = "33";
        }
    }
}