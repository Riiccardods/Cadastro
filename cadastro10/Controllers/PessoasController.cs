using Microsoft.AspNetCore.Mvc;
using cadastro10.Models;
using cadastro10.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // Certifique-se de incluir esta diretiva

namespace cadastro10.Controllers
{
    public class PessoasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PessoasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pessoas/Create
        public IActionResult Create()
        {
            // Verifica se existe uma mensagem de sucesso e passa para a View via ViewBag
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }
            return View();
        }

        // POST: Pessoas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pessoa);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Cadastro realizado com sucesso!";
                return RedirectToAction(nameof(Create));
            }
            return View(pessoa);
        }

        // GET: Pessoas/List
        public async Task<IActionResult> List()
        {
            var pessoasList = await _context.Pessoas.OrderByDescending(p => p.Id).ToListAsync();
            return View(pessoasList);
        }
    }
}
