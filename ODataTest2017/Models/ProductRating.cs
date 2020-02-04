﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ODataTest2017.Models
{
    public class ProductRating
    {
        public int ID { get; set; }
        public int Rating { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}