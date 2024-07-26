using Microsoft.AspNetCore.Mvc;
using SimplePOS.Models.Repositories.Interfaces;
using SimplePOS.ViewModels;

namespace SimplePOS.Controllers
{
    public class OutwardController : Controller
    {
        private readonly IOutwardRepository _outwardRepository;

        public OutwardController(IOutwardRepository outwardRepository)
        {
            _outwardRepository = outwardRepository;
        }

        public IActionResult Index()
        {
            var outwards = _outwardRepository.GetAllOutwards();
            var viewModel = new OutwardListViewModel
            {
                Outwards = outwards
            };

            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var outward = _outwardRepository.GetOutwardById(id);
            if (outward == null)
            {
                return NotFound();
            }

            return View(outward);
        }
    }
}
