﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Application.DTOs
{
    public class ResultQuery<T>
    {
        public int Total { get; set; }
        public List<T> Items { get; set; }
    }
}
