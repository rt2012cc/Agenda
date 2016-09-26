using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Agenda.Data;
using Agenda.Models;
using System.Collections.Generic;

namespace Agenda.Controllers
{
    public class ContatosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContatosController(ApplicationDbContext context)
        {
            _context = context;    
        }
        
        public async Task<IActionResult> Index(string Pesquisar)
        {
            #region Pesquisa

            var _contatos = new List<Contato>();

            if (string.IsNullOrEmpty(Pesquisar) == false)
                _contatos = await _context.Contato.Where(p => p.Nome.Contains(Pesquisar)).ToListAsync();
            else
                _contatos = await _context.Contato.ToListAsync();

            return View(_contatos); 

            #endregion
        }

        // GET: Contatos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            #region Details

            if (id == null)
                return NotFound();

            var _contato = await _context.Contato.SingleOrDefaultAsync(m => m.Id == id);

            if (_contato == null)
                return NotFound();


            return View(_contato); 

            #endregion
        }

        // GET: Contatos/Create
        public IActionResult Create()

        {
            return View();
        }

        // POST: Contatos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,DataNascimento,Email,Telefone,Cpf")] Contato contato)
        {
            #region Create 

            if (ModelState.IsValid)
            {
                _context.Add(contato);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(contato); 

            #endregion
        }

        // GET: Contatos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            #region Edit

            if (id == null)
            {
                return NotFound();
            }

            var _contato = await _context.Contato.SingleOrDefaultAsync(m => m.Id == id);

            if (_contato == null)
            {
                return NotFound();
            }

            return View(_contato); 

            #endregion
        }

        // POST: Contatos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DataNascimento,Email,Nome,Telefone,Cpf")] Contato contato)
        {
            #region Edit

            if (id != contato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (ContatoExists(contato.Id) == false)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("Index");
            }

            return View(contato); 

            #endregion
        }

        // GET: Contatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            #region Delete

            if (id == null)
            {
                return NotFound();
            }

            var _contato = await _context.Contato.SingleOrDefaultAsync(m => m.Id == id);

            if (_contato == null)
            {
                return NotFound();
            }

            return View(_contato); 

            #endregion
        }

        // POST: Contatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, bool notUsed)
        {
            var _contato = await _context.Contato.SingleOrDefaultAsync(m => m.Id == id);

            if (_contato != null)
            {
                _context.Contato.Remove(_contato);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index"); 
            }
            else
                return NotFound();
        }
        
        private bool ContatoExists(int id)
        {
            return _context.Contato.Any(e => e.Id == id);
        }
    }
}
