using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HistoryOfComputers.Data;
using HistoryOfComputers.Models;
using Microsoft.AspNetCore.Identity;

namespace HistoryOfComputers.Controllers
{
    public class ArticleController : Controller
    {
        private readonly HistoryContext _context;
        private readonly UserManager<ApplicationUser> _userManager; //dcowan: need Identity users

        public ArticleController(HistoryContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }



        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);

        }


        // GET: Article
        public async Task<IActionResult> Index(int? id)
        {
            //var historyContext = (from a in  _context.Articles select a); //put include here

            //if(id != null)
            //{    
            //    historyContext = historyContext.Where(x=> x.PeriodID == id.Value);
            //}
            IQueryable<Article> articles = _context.Articles
                .Where(c => !id.HasValue || c.PeriodID == id)
                .OrderBy(i => i.Year).Include(x => x.TimePeriod);
            
            return View(await articles
                .ToListAsync());
        }

        // GET: Article/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //var viewModel = new Models.HistoryViewModels.ArticleCommentData();
            //viewModel.Articles = await _context.Articles.Include(i => i.Comments).ToListAsync();

            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .Include(a => a.TimePeriod)
                .SingleOrDefaultAsync(m => m.ArticleID == id);
            if (article == null)
            {
                return NotFound();
            }

            var comments = _context.Comments.Where(a => a.ArticleID == id).ToList();

            ViewData["comments"] = comments;

            return View(article);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment([Bind("ArticleID,UserID,CommentText")] Comment comment)
        {
            if (ModelState.IsValid)
            {

                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = comment.ArticleID });
            }

            var article = await _context.Articles
                .Include(a => a.TimePeriod)
                .SingleOrDefaultAsync(m => m.ArticleID == comment.ArticleID);

            return View(article);
        }

            // GET: Article/Create
            public IActionResult Create()
        {
            ViewData["PeriodID"] = new SelectList(_context.TimePeriods, "PeriodID", "PeriodName");
            return View();
        }

        // POST: Article/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArticleID,PeriodID,Title,Year,Body,Reference,Image")] Article article)
        {
            if (ModelState.IsValid)
            {
                _context.Add(article);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["PeriodID"] = new SelectList(_context.TimePeriods, "PeriodID", "PeriodName", article.PeriodID);
            return View(article);
        }

        // GET: Article/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.SingleOrDefaultAsync(m => m.ArticleID == id);
            if (article == null)
            {
                return NotFound();
            }
            ViewData["PeriodID"] = new SelectList(_context.TimePeriods, "PeriodID", "PeriodName", article.PeriodID);
            return View(article);
        }

        // POST: Article/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArticleID,PeriodID,Title,Year,Body,Reference,Image")] Article article)
        {
            if (id != article.ArticleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.ArticleID))
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
            ViewData["PeriodID"] = new SelectList(_context.TimePeriods, "PeriodID", "PeriodName", article.PeriodID);
            return View(article);
        }

        // GET: Article/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .Include(a => a.TimePeriod)
                .SingleOrDefaultAsync(m => m.ArticleID == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Article/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await _context.Articles.SingleOrDefaultAsync(m => m.ArticleID == id);
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.ArticleID == id);
        }
    }
}
