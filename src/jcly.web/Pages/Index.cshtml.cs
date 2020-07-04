﻿using System.Threading.Tasks;

using jcly.lib.DAL.Base;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace jcly.web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly BaseDAL _dal;

        [BindProperty]
        public string URL { get; set; }

        public IndexModel(ILogger<IndexModel> logger, BaseDAL dal)
        {
            _logger = logger;
            _dal = dal;
        }

        public void OnGet() => Page();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var key = await _dal.InsertURLAsync(URL);

            return RedirectToPage(string.IsNullOrEmpty(key) ? "./Error" : $"./Generated?key={key}");
        }
    }
}