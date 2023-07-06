using Football_Player_Management_System.Models.Dto;

namespace Football_Player_Management_System.Data
{
    public static class PlayerInfo
    {
        public static List<PlayerDTO> playerList = new List<PlayerDTO> {
            new PlayerDTO { Id = 1, FirstName = "Edin", LastName = "Dzeko", CurrentTeam= "Fenerbahce", MarketValue= 40000000, Currency="EURO", MarketValueEuro= 4000000},
            new PlayerDTO { Id = 2, FirstName = "Miralem", LastName = "Pjanic", CurrentTeam= "Sharjah", MarketValue= 6000000, Currency="EURO", MarketValueEuro= 6000000 }
            };
    }
}
