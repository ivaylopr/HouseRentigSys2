using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HouseRentingSys2.Infrastructure.Constants.DataConstants;

namespace HouseRentingSys2.Infrastructure.Data.Models
{
    [Comment("House category")]
    public class Category
    {
        [Key]
        [Comment("Category identifier")]
        public int Id { get; set; }
        [Required]
        [MaxLength(NameMaxLenght)]
        [Comment("Category Name")]
        public string Name { get; set; } = string.Empty;
        public IEnumerable<House> Houses { get; set; } = new List<House>();

    }
}
