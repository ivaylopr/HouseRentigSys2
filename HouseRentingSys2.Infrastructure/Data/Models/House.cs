using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HouseRentingSys2.Infrastructure.Constants.DataConstants;

namespace HouseRentingSys2.Infrastructure.Data.Models
{
    [Comment("House for rent")]
    public class House
    {
        [Key]
        [Comment("House identitfier")]
        public int Id { get; set; }
        [MaxLength(TitleMaxLength)]
        [Comment("Title")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(AddressMaxLength)]
        [Comment("House address")]
        public string Address { get; set; } = string.Empty;
        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("House description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("House image")]
        public string ImageUrl { get; set; } = string.Empty;
        [Required]
        //[Range(typeof(decimal),HouseRentingPriceMin,HouseRentingPriceMax,ConvertValueInInvariantCulture =true)]
        [Comment("House renting price for month")]
        [Column(TypeName ="decimal(18,2)")]
        public decimal PricePerMonth { get; set; }
        [Required]
        [Comment("Category indentifier")]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;
        [Required]
        [Comment("Agent identifier")]
        public int AgentId { get; set; }
        [ForeignKey(nameof(AgentId))]
        public Agent Agent { get; set; } = null!;
        [Comment("User id of the renter")]
        public  string? RenterId { get; set; }
    }
}
