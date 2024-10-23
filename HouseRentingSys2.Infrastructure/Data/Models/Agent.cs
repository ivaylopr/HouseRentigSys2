using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HouseRentingSys2.Infrastructure.Constants.DataConstants;

namespace HouseRentingSys2.Infrastructure.Data.Models
{
    public class Agent
    {
        [Key]
        [Comment("Agent identifier")]
        public int Id { get; set; }
        [Required]
        [MaxLength(AgentPhoneNumberMaxLength)]
        [Comment("Agent phone number")]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [Comment("User Identityfier")]
        public string UserId { get; set; } = string.Empty;
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;
        public IEnumerable<House> Houses { get; set; } = new List<House>();
    }
}
