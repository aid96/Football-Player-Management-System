using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlTypes;

namespace Football_Player_Management_System.Models
{
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CurrentTeam { get; set; }
        public double MarketValue { get; set; }
        public string Currency { get; set; }

        public DateTime CreatedDate { get; set; }
        public double MarketValueEuro { get; set; }



    }
}
