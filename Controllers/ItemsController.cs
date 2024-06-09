
using ITProjectTryThree.Data;
using ITProjectTryThree.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ITProjectTryThree.Interfaces;
using ITProjectTryThree.Models.ViewModels;

namespace ITProjectTryThree.Controllers
{
	public class ItemsController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly IPhotoService _photoService;

		public ItemsController(ApplicationDbContext context, IPhotoService photoService)
		{
			_context = context;
			_photoService = photoService;
		}

		[Authorize]
		public IActionResult Create(int? CollectionId)
		{
			CreateItemViewModel response = new CreateItemViewModel(_context.Collections.FirstOrDefault(m => m.id == CollectionId), new Item());
			return View(response);
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> Create(CreateItemViewModel item)
		{
			if (item.ThisItem.Image == null)
			{
				item.ThisItem.ImagePathString = "https://i.ibb.co/g9Jy7Bx/2.png";
			}
			else
			{
				var result = await _photoService.AddPhotoAsync(item.ThisItem.Image);
				item.ThisItem.ImagePathString = result.Url.ToString();
			}
			var collection = await _context.Collections.FindAsync(item.ThisItem.CollectionId);
			item.ThisItem.TagsList = new List<string>();

			if (item.ThisItem.Tags != null)
			{
				item.ThisItem.TagsList = item.ThisItem.Tags.Split(',').ToList();
				for (int i = 0; i < item.ThisItem.TagsList.Count; i++)
				{
					item.ThisItem.TagsList[i] = "#" + item.ThisItem.TagsList[i].Trim();
				}
			}
			else
			{
				item.ThisItem.Tags = " ";
			}
			item.ThisItem.TagsList.Add("#" + collection.Type.ToString());
			if (item.ThisItem.Title == null)
			{
				item.ThisItem.Title = "no title";
			}
			if (item.ThisItem.Description == null)
			{
				item.ThisItem.Description = "no description";
			}
			_context.Add(item.ThisItem);
			await _context.SaveChangesAsync();
			return RedirectToAction("Details", "Collections", new { id = item.ThisItem.CollectionId });

		}

		[Authorize]
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Items == null)
			{
				return NotFound();
			}
			int collectionId = 0;
			var item = await _context.Items.FindAsync(id);
			if (item != null)
			{
				collectionId = item.CollectionId;
				_context.Items.Remove(item);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction("Details", "Collections", new { id = collectionId });
		}

		[Authorize]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Items == null)
			{
				return NotFound();
			}

			var item = await _context.Items.FindAsync(id);

			if (item == null)
			{
				return NotFound();
			}

			var collection = await _context.Collections.FindAsync(item.CollectionId);

			if (collection == null)
			{
				return NotFound();
			}

			var response = new EditItemViewModel(collection, item, item.Id);
			return View(response);
		}

		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(EditItemViewModel input)
		{
			var exictingItem = await _context.Items.FindAsync(input.ThisItem.Id);
			if (input.ThisItem.Image == null)
			{
				if (exictingItem.ImagePathString == null)
					input.ThisItem.ImagePathString = "https://i.ibb.co/g9Jy7Bx/2.png";
				else
					input.ThisItem.ImagePathString = exictingItem.ImagePathString;
			}
			else
			{
				var result = await _photoService.AddPhotoAsync(input.ThisItem.Image);
				input.ThisItem.ImagePathString = result.Url.ToString();
			}

			var collection = await _context.Collections.FindAsync(input.ThisItem.CollectionId);
			input.ThisItem.TagsList = new List<string>();

			if (input.ThisItem.Tags != null)
			{
				input.ThisItem.TagsList = input.ThisItem.Tags.Split(',').ToList();
				for (int i = 0; i < input.ThisItem.TagsList.Count; i++)
				{
					input.ThisItem.TagsList[i] = "#" + input.ThisItem.TagsList[i].Trim();
				}
			}
			else
			{
				input.ThisItem.Tags = " ";
			}

			if (input.ThisItem.Title == null)
			{
				input.ThisItem.Title = "no title";
			}
			if (input.ThisItem.Description == null)
			{
				input.ThisItem.Description = "no description";
			}

			input.ThisItem.TagsList.Add("#" + collection.Type.ToString());
			var item = await _context.Items.FindAsync(input.ThisItem.Id);
			if (item == null)
			{
				return NotFound();
			}

			_context.Entry(item).State = EntityState.Detached;
			_context.Update(input.ThisItem);
			await _context.SaveChangesAsync();
			return RedirectToAction("Details", "Collections", new { id = input.ThisItem.CollectionId });
		}

		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Items == null)
			{
				return NotFound();
			}

			var item = await _context.Items.FindAsync(id);

			if (item == null)
			{
				return NotFound();
			}

			var collection = await _context.Collections.FindAsync(item.CollectionId);

			if (collection == null)
			{
				return NotFound();
			}

			var response = new DetailsItemViewModel();
			response.item = item;
			response.collection = collection;
			response.comments = await _context.Comments.Where(m => m.ItemId == item.Id).ToListAsync();
			response.userName = User.Identity.Name;
			response.userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (item.ImagePathString != null)
				response.ImagePath = item.ImagePathString;
			else
				response.ImagePath = "https://cdn-icons-png.flaticon.com/512/1710/1710414.png";
			return View(response);
		}

		[HttpPost]
		public async Task<IActionResult> SendMessage(string user, string message, int id)
		{
			if (string.IsNullOrEmpty(message))
			{
				return BadRequest("Message cannot be empty");
			}

			var item = await _context.Items.FindAsync(id);

			if (item == null)
			{
				return NotFound("Item not found");
			}

			var comment = new Comment
			{
				UserName = user,
				UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
				DateTime = DateTime.Now,
				ItemId = item.Id,
				Message = message,
			};

			_context.Comments.Add(comment);
			await _context.SaveChangesAsync();

			return RedirectToAction("Details", new { id = item.Id });
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}

