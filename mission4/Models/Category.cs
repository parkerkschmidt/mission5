using System;
using System.ComponentModel.DataAnnotations;


namespace mission4.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
    }
}
