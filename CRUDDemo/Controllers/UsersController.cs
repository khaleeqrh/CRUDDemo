﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CRUDDemo.Controllers
{
    public class UsersController : Controller
    {

        public UsersController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}