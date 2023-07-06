using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Data.SqlTypes;

namespace Football_Player_Management_System.Models.Dto
{
    public class PlayerDTO
    {
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
