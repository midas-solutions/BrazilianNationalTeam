namespace NationalTeam.Models
{
    public class Player
    {
        public string Name { get; set; }

        public virtual Team Team { get; set; }
    }
}
