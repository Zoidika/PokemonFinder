using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PokemonFinder.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        [BindProperty]
        public string SearchedID { get; set; }
        public async Task OnGet()
        {

        }
        public async Task OnPost()
        {

        }
    }
}
