using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSys2.Infrastructure.Data.Models
{
    [Comment("House for rent")]
    public class House
    {
        [Key]
        [Comment("House identitfier")]
        public int Id { get; set; }
        [MaxLength()]
        public string Title { get; set; }
    }
}
