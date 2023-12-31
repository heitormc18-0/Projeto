using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto.Areas.Admin.Services;

namespace Projeto.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminRelatorioVendasController : Controller
    {
        private readonly RelatorioVendasServices _relatorio;
        public AdminRelatorioVendasController(RelatorioVendasServices
        relatorio)
        {
            _relatorio = relatorio;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Relatorio(DateTime? di,
        DateTime? df)
        {

            if (!di.HasValue)
            {
                di = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!df.HasValue)
            {
                df = DateTime.Now;
            }
            ViewData["di"] = di.Value.ToString("yyyy-MM-dd");
            ViewData["df"] = df.Value.ToString("yyyy-MM-dd");
            var result = await _relatorio.BuscaPorData(di, df);
            return View(result);
        }
    }
}