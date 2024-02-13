﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication9.Models
{
    public class SearchProductsViewModel
    {
        public List<Product> Products { get; set; }
        public int MinStock { get; set; }
        public int MaxStock { get; set; }
    }
}