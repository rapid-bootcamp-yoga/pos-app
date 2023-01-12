﻿using System.ComponentModel.DataAnnotations;

namespace POS.ViewModel
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }

        [Required]
        public String CategoryName { get; set; }

        [Required]
        public String Description { get; set; }

        [Required]
        public String Picture { get; set; }
    }
}