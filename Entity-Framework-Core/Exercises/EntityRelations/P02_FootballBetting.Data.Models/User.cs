using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models
{
    public class User
    {
        public User()
        {
            this.Bets= new HashSet<Bet>();
        }

        [Key]
        public int UserId { get; set; }

        [MaxLength(ValidationConstants.UserUsernameMaxLength)]
        public string Username { get; set; } = null!;
        
        [MaxLength(ValidationConstants.UserPasswordMaxLength)]
        public string Password { get; set; } = null!;

        [MaxLength(ValidationConstants.UserEmailMaxLength)]
        public string Email { get; set; } = null!;

        [MaxLength(ValidationConstants.UserNameMaxLength)]
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}
