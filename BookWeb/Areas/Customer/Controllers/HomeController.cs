using Book.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Book.DataAccess.Repository.IRepository;

namespace BookWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(string searchString)
        {
            var productList = _unitOfWork.Product.GetAll(includeProperties: "Category");

            if (!String.IsNullOrEmpty(searchString))
            {
                productList = productList.Where(p => p.Title.Contains(searchString)
                                                || p.Description.Contains(searchString)
                                                || p.Author.Contains(searchString));
            }

            return View(productList);
        }

        public IActionResult Details(int productId)
        {
            Product product = _unitOfWork.Product.Get(u => u.Id == productId, includeProperties: "Category");
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Book.Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
