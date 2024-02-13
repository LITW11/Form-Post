﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class PostDemoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FormPost(string value)
        {
            return View(new FormPostViewModel
            {
                Value = value
            });
        }
    }
}