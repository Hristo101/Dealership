﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Core.Models.Query
{
    public class AllQueriesViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string? AdminResponse { get; set; } = string.Empty;
        public string CarImage { get; set; }
        public string Description { get; set; }
        public string Make {  get; set; }
        public string Model { get; set; }
    }
}
