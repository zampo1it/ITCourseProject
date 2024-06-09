using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITProjectTryThree.Data;
using ITProjectTryThree.Models;
using Microsoft.AspNetCore.Authorization;
using ITProjectTryThree.Interfaces;
using ITProjectTryThree.Models.ViewModels;

namespace ITProjectTryThree.Controllers
{
    public class CollectionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPhotoService _photoService;

        public CollectionsController(ApplicationDbContext context, IPhotoService photoService)
        {
            _context = context;
            _photoService = photoService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Collections.ToListAsync());
        }

        [Authorize]
        public IActionResult Create()
        {
            var model = new Collection();
            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collection = await _context.Collections
                .FirstOrDefaultAsync(m => m.id == id);
            if (collection == null)
            {
                return NotFound();
            }
            List<Item> items = new List<Item>();
            var count = await _context.Items.Where(m => m.CollectionId == id).CountAsync();
            items = await _context.Items.Where(e => e.CollectionId == id).ToListAsync();

            var response = new DetailsViewModel(collection, items, User.GetUserId());
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CollectionsViewModel input)
        {

            if (input.Image == null)
            {
                input.ImagePath = "https://i.ibb.co/g9Jy7Bx/2.png";
            }
            else
            {
                var result = await _photoService.AddPhotoAsync(input.Image);
                input.ImagePath = result.Url.ToString();
            }
            input.Date = DateTime.Now;
            var collection = CreateCollectionFromViewModel(input);
            if (collection.Title == null)
            {
                collection.Title = "no title";
			}
			if (collection.Description == null)
			{
				collection.Description = "no description";
			}
			_context.Collections.Add(collection);
            await _context.SaveChangesAsync();
            return RedirectToAction("UserPage", "Account");
        }

        private Collection CreateCollectionFromViewModel(CollectionsViewModel input)
        {
            return new Collection
            {
                Owner = User.Identity.Name,
                Title = input.Title,
                Type = input.Type,
                Description = input.Description,
                Image = input.Image,
                ImagePathString = input.ImagePath,
                IntName1 = input.IntName1,
                IntName2 = input.IntName2,
                IntName3 = input.IntName3,
                StringName1 = input.StringName1,
                StringName2 = input.StringName2,
                StringName3 = input.StringName3,
                BoolName1 = input.BoolName1,
                BoolName2 = input.BoolName2,
                BoolName3 = input.BoolName3,
                Date = input.Date,
            };
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collection = await _context.Collections.FindAsync(id);
            if (collection == null)
            {
                return NotFound();
            }
            return View(collection);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Collection collection)
        {
            if (id != collection.id)
            {
                return NotFound();
            }
            
            var existingCollection = await _context.Collections.FindAsync(id);
            if (existingCollection == null)
            {
                return NotFound();
            }
            collection.Date = existingCollection.Date;
            if (collection.Image == null)
            {
                if (existingCollection.ImagePathString == null)
                    collection.ImagePathString = "https://i.ibb.co/g9Jy7Bx/2.png";
                else
                    collection.ImagePathString = existingCollection.ImagePathString;
            }
            else
            {
                var result = await _photoService.AddPhotoAsync(collection.Image);
                collection.ImagePathString = result.Url.ToString();
            }
			if (collection.Title == null)
			{
				collection.Title = "no title";
			}
			if (collection.Description == null)
			{
				collection.Description = "no description";
			}
			_context.Entry(existingCollection).State = EntityState.Detached;
            _context.Update(collection);
            await _context.SaveChangesAsync();
            return RedirectToAction("UserPage", "Account");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collection = await _context.Collections
                .FirstOrDefaultAsync(m => m.id == id);
            if (collection == null)
            {
                return NotFound();
            }

            return View(collection);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var collection = await _context.Collections.FindAsync(id);
            if (collection != null)
            {
                _context.Collections.Remove(collection);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("UserPage", "Account");
        }

        private bool CollectionExists(int id)
        {
            return _context.Collections.Any(e => e.id == id);
        }
    }
}
