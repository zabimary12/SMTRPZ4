﻿using Shop.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Knife> favKnives { get; set; }
    }
}
