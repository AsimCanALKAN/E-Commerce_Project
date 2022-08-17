﻿using System;
using Entities.Abstract;

namespace Entities.Concrete
{
    //Concrete classes are equal to Database Table
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}

