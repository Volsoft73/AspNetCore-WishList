using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _contex;


        public ItemController(ApplicationDbContext context)
        {
            _contex = context;
        }


        public IActionResult Index()
        {

            var model = _contex.Items.ToList();

            return View("Index", model);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            _contex.Items.Add(item);

            _contex.SaveChanges();


            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var item = _contex.Items.FirstOrDefault(i => i.Id == id);

            _contex.Items.Remove(item);

            _contex.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}
