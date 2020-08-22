using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CRUDDemo.Models;
using CRUDDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CRUDDemo.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public UsersController(ApplicationDbContext _db,IMapper _mapper)
        {
            this._db = _db;
            this._mapper = _mapper;
        }
        public IActionResult Index()
        {
            var users = _db.Users.ToList();
            var UsersVM = _mapper.Map<List<UserVM>>(users);
            return View(UsersVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                var copied = _mapper.Map<User>(userVM);
                _db.Users.Add(copied);
                _db.SaveChanges();
                TempData["Sasti"] = "Created";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var model = _db.Users.Where(s => s.Id == id).First();
            var ad = _mapper.Map<UserVM>(model);
            return View(ad);
        }

        [HttpPost]
        public IActionResult Update(int id, [FromForm] UserVM userVM)
        {
            if (ModelState.IsValid &&  id > 0)
            {
                var userToBeSaved = _mapper.Map<User>(userVM);

                //var model = _db.Users.Where(s => s.Id == id).First();
                //var ad = _mapper.Map<UserVM>(model);
                _db.Entry(userToBeSaved).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _db.SaveChanges();
                TempData["Sasti"] = $"Updated {userToBeSaved.FirstName}";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var userToBeDeleted = _db.Users.Where(s => s.Id == id).First();
            _db.Entry(userToBeDeleted).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _db.SaveChanges();
            TempData["Sasti"] = $"Deleted {userToBeDeleted.FirstName}";

            return RedirectToAction(nameof(Index));
        }




    }
}
