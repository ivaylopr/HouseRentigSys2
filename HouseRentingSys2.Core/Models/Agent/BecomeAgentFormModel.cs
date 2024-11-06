using System.ComponentModel.DataAnnotations;
using static HouseRentingSys2.Core.Constants.MessageConstants;
using static HouseRentingSys2.Infrastructure.Constants.DataConstants;

namespace HouseRentingSys2.Core.Models.Agent
{
	public class BecomeAgentFormModel
	{
        [Required(ErrorMessage=RequiredMessage)]
        [StringLength(AgentPhoneNumberMaxLength,
            MinimumLength =AgentPhoneNumberMinLength,
            ErrorMessage =LenghtMessage)]
        [Display(Name ="Phone number")]
        [Phone]
        public string PhoneNumber { get; set; }=null!;
    }
}
