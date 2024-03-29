using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using System.Diagnostics;
using TravelNotes.Models;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;

namespace TravelNotes.Controllers
{
	public class PersonalPageController : Controller
	{
		private readonly IWebHostEnvironment _hostingEnvironment;
		//Set UserId for Testing -> To be Modified Later
		int UserId = 1;
		private readonly TravelContext _context;

		public PersonalPageController(TravelContext context, IWebHostEnvironment hostingEnvironment)
		{
			_context = context;
			_hostingEnvironment = hostingEnvironment;
		}

		//Load Article DataList for ViewPersonaPage
		public IActionResult ViewPersonalPage()
		{
			string cookieValue;
			bool result = Request.Cookies.TryGetValue("UsernameCookie", out cookieValue);
			if (result)
			{
				UserId = Convert.ToInt32(cookieValue);
			}
			else
			{
				UserId = 2;
				//處理 Cookie 不存在的情況
			}
			var users = _context.users.FirstOrDefault(a => a.UserId == UserId);
			var article = _context.article.Where(p => p.UserId == UserId);
			var UsersArticleViewModel = new UsersArticleViewModel
			{
				users = users,
				article = article
			};
			return View(UsersArticleViewModel);
		}

		//Search Article for ViewPersonalPage
		[HttpPost]
		public IActionResult ViewPersonalPage(string search)
		{
			string cookieValue;
			bool result = Request.Cookies.TryGetValue("UsernameCookie", out cookieValue);
			if (result)
			{
				UserId = Convert.ToInt32(cookieValue);
			}
			else
			{
				UserId = 2;
				//處理 Cookie 不存在的情況
			}
			// 在?存中使用正?表?式，所以先?索所有文章到?存中
			var users = _context.users.FirstOrDefault(a => a.UserId == UserId);
			var articles = _context.article
				.Where(a => a.ArticleState == "發佈" && a.UserId == UserId)
				.ToList();
			// 定?正?表?式?匹配 HTML ??
			Regex htmlTagRegex = new Regex("<.*?>");
			// 使用 LINQ 在?存中?行?一步的??和排序
			articles = articles
				.Where(a => string.IsNullOrWhiteSpace(search) ||
					(a.Contents != null && htmlTagRegex.Replace(a.Contents, "").Contains(search)) ||
					(a.Title != null && a.Title.Contains(search)))
				.OrderByDescending(a => a.ArticleId)
				.ToList();
			// ??据?或其他地方?取 UsersArticleViewModel ?型的?据
			UsersArticleViewModel viewModel = new UsersArticleViewModel();
			// 假? articles 是 IEnumerable<Article> ?型的模型?据
			viewModel.article = articles; // ?文章列表?值???模型的 article ?性
			viewModel.users = users;
			// 返回??，并???模型?????
			return View(viewModel);
		}

		//Load Article DataList for PersonaPage
		//public IActionResult PersonalPage(/*int? UserId*/)
		//{
		//	string cookieValue;
		//	bool result = Request.Cookies.TryGetValue("UsernameCookie",out cookieValue);
		//	if (result)
		//	{
		//		UserId = Convert.ToInt32(cookieValue);
		//	}
		//	else
		//	{
		//		UserId = 2;
		//		//處理 Cookie 不存在的情況
		//	}
		//	var users = _context.users.FirstOrDefault(a => a.UserId == UserId);
		//	var article = _context.article.Where(p => p.UserId == UserId);
		//	var UsersArticleViewModel = new UsersArticleViewModel
		//	{
		//			users = users,
		//			article = article
		//	};
		//	return View(UsersArticleViewModel);
		//	//var usersArticleViewModel = _context.UsersArticleViewModels.FirstOrDefault();
		//	//ViewBag.article = _context.article.Where((a => a.UserId == UserId)).ToList();
		//	//return View(_context.users.ToList());
		//}

		//Search Article for PersonalPage
		//[HttpPost]
		public IActionResult PersonalPage(string? search,int? userId)
		{
			users users;//當前頁面使用者
			int loginUserId = 0;
			string cookieValue;
			bool result = Request.Cookies.TryGetValue("UsernameCookie", out cookieValue);
			if (result)
			{
				loginUserId = Convert.ToInt32(cookieValue);
			}
			if (userId == null)
			{
                if (loginUserId != 0)
                {
					users = _context.users.FirstOrDefault(a => a.UserId == loginUserId);
                }
                else
                {
                    return RedirectToAction("Login", "Member");
                }
            }
			else
			{
				users = _context.users.FirstOrDefault(a => a.UserId == userId);
            }

			var articles = _context.article
				.Where(a => a.ArticleState == "發佈" && a.UserId == users.UserId)
				.ToList();
			// 定?正?表?式?匹配 HTML ??
			Regex htmlTagRegex = new Regex("<.*?>");
			// 使用 LINQ 在?存中?行?一步的??和排序
			articles = articles
				.Where(a => string.IsNullOrWhiteSpace(search) ||
					(a.Contents != null && htmlTagRegex.Replace(a.Contents, "").Contains(search)) ||
					(a.Title != null && a.Title.Contains(search)))
				.OrderByDescending(a => a.ArticleId)
				.ToList();
			// ??据?或其他地方?取 UsersArticleViewModel ?型的?据
			UsersArticleViewModel viewModel = new UsersArticleViewModel();
			// 假? articles 是 IEnumerable<Article> ?型的模型?据
			viewModel.article = articles; // ?文章列表?值???模型的 article ?性
			viewModel.users = users;
			ViewBag.loginUserId = loginUserId;
			// 返回??，并???模型?????
			return View(viewModel);
		}

		//Upload & Save Headshot DataList for PersonalPage
		[HttpPost]
		public string UserImage(IFormFile file)
		{
			string cookieValue;
			bool result = Request.Cookies.TryGetValue("UsernameCookie", out cookieValue);
			if (result)
			{
				UserId = Convert.ToInt32(cookieValue);
			}
			else
			{
				UserId = 2;
				//處理 Cookie 不存在的情況
			}
			string imgFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img");
			if (!Directory.Exists(imgFolder))
			{
				Directory.CreateDirectory(imgFolder);
			}
			string userFolder = Path.Combine(imgFolder, "user" + UserId);
			if (!Directory.Exists(userFolder))
			{
				Directory.CreateDirectory(userFolder);
			}
			string headshotFolder = Path.Combine(userFolder, "headshot");
			if (!Directory.Exists(headshotFolder))
			{
				Directory.CreateDirectory(headshotFolder);
			}
			string uploadsFolder = Path.Combine(headshotFolder);
			if (!Directory.Exists(uploadsFolder))
			{
				Directory.CreateDirectory(uploadsFolder);
			}
			string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
			string filePath = Path.Combine(uploadsFolder + "\\", uniqueFileName);
			var stream = new FileStream(filePath, FileMode.Create);
			file.CopyTo(stream);
			string srcString = "/img/" + Path.GetRelativePath(imgFolder, filePath).Replace('\\', '/');
			var UserImage = _context.users.FirstOrDefault(x => x.UserId == UserId);
			UserImage!.Headshot = srcString;
			_context.SaveChanges();
			// 更新??模型中的用??像信息
			var viewModel = new UsersArticleViewModel
			{
				// 其他??模型?据
				users = UserImage // 更新用??像信息
			};
			//return PartialView("ArticleCard", viewModel); // ?更新后的??模型??到??中
			return ("Ok");
		}

		//Update & Save User DataList for PersonalPage
		[HttpPost]
		public IActionResult Save(string userName, string Phone, string Mail, string Gender, string Pwd, string Nickname, DateOnly Birthday, string Address, string Introduction, string Interest)
		{
			string cookieValue;
			bool result = Request.Cookies.TryGetValue("UsernameCookie", out cookieValue);
			if (result)
			{
				UserId = Convert.ToInt32(cookieValue);
			}
			else
			{
				UserId = 2;
				//處理 Cookie 不存在的情況
			}
			users a = _context.users.FirstOrDefault(a => a.UserId == UserId);
			a.UserName = userName;
			a.Phone = Phone;
			a.Mail = Mail;
			a.Gender = Gender;
			a.Pwd = Pwd;
			a.Nickname = Nickname;
			a.Birthday = Birthday;
			a.Address = Address;
			a.Introduction = Introduction;
			a.Interest = Interest;
			_context.SaveChanges();
			return RedirectToAction("PersonalPage");
		}

		//Load Photo DataList for LookBack
		public IActionResult Year()
		{
			string cookieValue;
			bool result = Request.Cookies.TryGetValue("UsernameCookie", out cookieValue);
			if (result)
			{
				UserId = Convert.ToInt32(cookieValue);
			}
			else
			{
				UserId = 2;
				//處理 Cookie 不存在的情況
			}
			var LookBack = _context.LookBack.Where(a => a.UserId == UserId).ToList();
			var photo = _context.photo.Where(p => p.UserId == UserId && p.PhotoDescription != "1").ToList();
			//photo.FirstOrDefault().PhotoPath
			var data = from p in photo
					   join l in LookBack
					   on p.PhotoId equals l.PhotoId
					   select new LookBackPhotoViewModel2
					   {
						   PhotoPath = p.PhotoPath,
						   Yid = l.Yid,
					   };
			var bag = data.ToList();
			var LookBackPhotoViewModel = new LookBackPhotoViewModel
			{
				LookBack = LookBack,
				photo = photo,
				photoPaths = bag,
				
			};
			ViewBag.pic1 = bag.FirstOrDefault(a => a.Yid == 1);
			ViewBag.pic2 = bag.FirstOrDefault(a => a.Yid == 2);
			ViewBag.pic3 = bag.FirstOrDefault(a => a.Yid == 3);
			ViewBag.pic4 = bag.FirstOrDefault(a => a.Yid == 4);
			ViewBag.pic5 = bag.FirstOrDefault(a => a.Yid == 5);
			ViewBag.pic6 = bag.FirstOrDefault(a => a.Yid == 6);
			ViewBag.pic7 = bag.FirstOrDefault(a => a.Yid == 7);
			ViewBag.pic8 = bag.FirstOrDefault(a => a.Yid == 8);
			ViewBag.pic9 = bag.FirstOrDefault(a => a.Yid == 9);
			ViewBag.pic10 = bag.FirstOrDefault(a => a.Yid == 10);
			ViewBag.pic11 = bag.FirstOrDefault(a => a.Yid == 11);
			ViewBag.pic12 = bag.FirstOrDefault(a => a.Yid == 12);


			//ViewBag.LookBackPhotoViewModel = data;
			//var result = data.FirstOrDefault(a => a.Yid == 1);
			//var result = data.FirstOrDefault(a => a.Yid == 1);
			//var result = data.FirstOrDefault(a => a.Yid == 1);
			//var result = data.FirstOrDefault(a => a.Yid == 1);
			//var result = data.FirstOrDefault(a => a.Yid == 1);
			//var result = data.FirstOrDefault(a => a.Yid == 1);
			//var result = data.FirstOrDefault(a => a.Yid == 1);
			//var result = data.FirstOrDefault(a => a.Yid == 1);
			//var result = data.FirstOrDefault(a => a.Yid == 1);

			//return View(bag);
			return View(LookBackPhotoViewModel);
		}

		//Upload & Save for LookBack Page
		[HttpPost]
		public string SaveLookBackImage(int Yid, int PhotoId, int id)
		{
			string cookieValue;
			bool result = Request.Cookies.TryGetValue("UsernameCookie", out cookieValue);
			if (result)
			{
				UserId = Convert.ToInt32(cookieValue);
			}
			else
			{
				UserId = 2;
				//處理 Cookie 不存在的情況
			}
			var LookBackImage = _context.LookBack.FirstOrDefault(a => a.UserId == UserId);
			var data = _context.LookBack.FirstOrDefault(a => a.Yid == Yid && a.UserId == UserId);

			if (data != null)
			{
				data.PhotoId = PhotoId;

			}
			else
			{
				LookBack lookBack = new LookBack();
				lookBack.PhotoId = PhotoId;
				lookBack.Yid = Yid;
				lookBack.UserId = UserId;
				_context.LookBack.Add(lookBack);
			}

			_context.SaveChanges();
			return "look:" + Yid + "照片id:" + PhotoId;
		}

		//Model
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

        //檢視行程
        public IActionResult ViewSchedule()
        {
            string userId;
            Request.Cookies.TryGetValue("UsernameCookie", out userId);
            int id = Convert.ToInt32(userId);

            if (userId != null)
            {
                var query = (from s in _context.Spots
                             where (from o in _context.myFavor
                                    where o.UserId == id
                                    select o.SpotId).Contains(s.SpotId)
                             select s).ToList();

                return View(query);
            }

            return RedirectToAction("fail", "Member");

        }

        //從ai那邊加入到行程
        public IActionResult Schedule(string scenicSpotName)
        {
            if (scenicSpotName == null)
            {
                return RedirectToAction("ViewSchedule");
            }

            string userId;
            Request.Cookies.TryGetValue("UsernameCookie", out userId);
            int id = Convert.ToInt32(userId);
            var query = (from o in _context.Spots
                         where o.ScenicSpotName == scenicSpotName
                         select o.SpotId).ToList();

            var viewQuery = _context.Spots.Where(x => x.ScenicSpotName == scenicSpotName).ToList();

            int value = Convert.ToInt32(query[0]);

            //這裡檢查是否與資料庫重複
            var checkRepect = (from f in _context.myFavor
                               where f.UserId == id && f.SpotId == value
                               select f).ToList();

            var flag = checkRepect.Count > 0;



            if (userId != null && flag == false)
            {
                myFavor favor = new myFavor();
                favor.UserId = id;
                favor.SpotId = value;
                _context.myFavor.Add(favor);
                _context.SaveChanges();
            }
            else
            {
                return RedirectToAction("fail", "Member");
            }


            return RedirectToAction("ViewSchedule");
        }

        //移除行程
        public IActionResult Remove(string scenicSpotName)
        {

            string userId;
            Request.Cookies.TryGetValue("UsernameCookie", out userId);
            int id = Convert.ToInt32(userId);


            //檢查使用者不為空
            if (scenicSpotName != null)
            {
                //抓目前的景點ID
                var findSpotId = (from s in _context.Spots
                                  where s.ScenicSpotName == scenicSpotName
                                  select s.SpotId).ToList();
                int spotId = Convert.ToInt32(findSpotId[0]);

                //抓目前的流水號
                var checkQuery = (from f in _context.myFavor
                                  where f.UserId == id && f.SpotId == spotId
                                  select f).ToList();



                if (checkQuery.Any())
                {
                    // 如果存在相符的收藏記錄，刪除它們
                    _context.myFavor.RemoveRange(checkQuery);

                    // 儲存變更到資料庫
                    _context.SaveChangesAsync();
                }
            }

            return RedirectToAction("ViewSchedule");
        }

		// 寫貼文
		public IActionResult MarkDown(string scenicSpotName)
		{
            string userId;
            Request.Cookies.TryGetValue("UsernameCookie", out userId);
            int id = Convert.ToInt32(userId);

            if (scenicSpotName != null)
			{
                //抓目前的景點ID
                var findSpotId = (from s in _context.Spots
                                  where s.ScenicSpotName == scenicSpotName
                                  select s.SpotId).ToList();
                int spotId = Convert.ToInt32(findSpotId[0]);

                //抓目前的流水號
                var checkQuery = (from f in _context.myFavor
                                  where f.UserId == id && f.SpotId == spotId
                                  select f).ToList();

				int uuid = checkQuery[0].SpotId;

                return RedirectToAction("CreateDraft", "Article", new { SpotId = uuid });
			}

			else
			{
                return RedirectToAction("fail","Member");
            }
        }
    }
}
