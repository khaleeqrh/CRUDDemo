using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDDemo.Models;
using CRUDDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CRUDDemo.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UsersController(ApplicationDbContext _db)
        {
            this._db = _db;
        }
        public IActionResult Index()
        {
            var users = _db.Users.ToList();

            return View(users);
        }
    }
}
