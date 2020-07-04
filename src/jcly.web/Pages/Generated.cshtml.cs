using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace jcly.web.Pages
{
    public class GeneratedModel : PageModel
    {
        private readonly ILogger<GeneratedModel> _logger;

        [BindProperty(SupportsGet = true)]
        public string Key { get; set; }

        public GeneratedModel(ILogger<GeneratedModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            if (string.IsNullOrEmpty(Key))
            {
                return RedirectToPage("./Error");
            }

            Key = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/{Key}";

            return Page();
        }
    }
}