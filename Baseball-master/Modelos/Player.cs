using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBall.Modelos
{
    public class Player
    {
        public String PlayerId { get; set; }
        public int BirthYear { get; set; }
        public int BirthMonth { get; set; }
        public int BirthDay { get; set; }
        public String BirthCountry { get; set; }
        public String BirthState { get; set; }
        public String BirthCity { get; set; }
        public int DeathYear { get; set; }
        public int DeathMonth { get; set; }
        public int DeathDay { get; set; }
        public String DeathCountry { get; set; }
        public String DeathState { get; set; }
        public String DeathCity { get; set; }
        public String NameFirst { get; set; }
        public String NameLast { get; set; }
        public String NameGiven { get; set; }
        public int Weight { get; set; }
        public double Height { get; set; }
        public String Bats { get; set; }
        public String Throws { get; set; }
        public DateTime Debut { get; set; }
        public DateTime FinalGame { get; set; }
        public String RetroID { get; set; }
        public String BbrefID { get; set; }

    }
}
