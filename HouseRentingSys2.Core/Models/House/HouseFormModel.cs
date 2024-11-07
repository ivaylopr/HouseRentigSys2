using System.ComponentModel.DataAnnotations;
using static HouseRentingSys2.Core.Constants.MessageConstants;
using static HouseRentingSys2.Infrastructure.Constants.DataConstants;

namespace HouseRentingSys2.Core.Models.House
{
	public class HouseFormModel
	{
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(HouseTitleMaxLength,
            MinimumLength = HouseTitleMinLength,
            ErrorMessage = LenghtMessage)]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(AddressMaxLength,
            MinimumLength = AddressMinLength,
            ErrorMessage = LenghtMessage)]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage =RequiredMessage)]
        [StringLength(DescriptionMaxLength,
            MinimumLength =DescriptionMinLength,
            ErrorMessage =LenghtMessage)]
        public string Description { get; set; }=null!;
        [Required(ErrorMessage =RequiredMessage)]
        [Display(Name ="Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage =RequiredMessage)]
        [Range(typeof(decimal),HouseRentingPriceMin, HouseRentingPriceMax,
            ErrorMessage ="Price per month must be a positive number and less then {2} leva")]
        [Display(Name = "Price per month")]
        public decimal PricePerMonth { get; set; }

        [Display(Name ="Category")]
        public int CategoryId { get; set; }

        public IEnumerable<HouseCategoryServiceModel> Categories { get; set; } = new List<HouseCategoryServiceModel>();
    }
}
