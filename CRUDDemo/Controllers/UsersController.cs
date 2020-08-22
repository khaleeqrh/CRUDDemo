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


    }
}
