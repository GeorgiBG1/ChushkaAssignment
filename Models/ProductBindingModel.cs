﻿using ChushkaAssignment.Data.Enums;

namespace ChushkaAssignment.Models
{
    public class ProductBindingModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public List<ProductType> Types { get; set; }
    }
}
