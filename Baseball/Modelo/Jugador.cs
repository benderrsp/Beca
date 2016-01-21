using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Jugador
    {
        public string NombreCompleto { get; set; }
        public string playerID { get; set; }
        public int birthYear { get; set; }
        public int birthMonth { get; set; }
        public int birthDay { get; set; }
        public string birthCountry{ get; set; }
        public string birthState { get; set; }
        public string birthCity { get; set; }
        public int deathYear { get; set; }
        public int deathMonth { get; set; }
        public int deathDay { get; set; }
        public string deathCountry{ get; set; }
        public string deathState { get; set; }
        public string deathCity { get; set; }
        public string nameFirst { get; set; }
        public string nameLast { get; set; }
        public string nameGiven { get; set; }
        public int weight { get; set; }
        public float height { get; set; }
        public string bats { get; set; }
        public string throws { get; set; }
        public DateTime debut { get; set; }
        public DateTime finalGame { get; set; }
        public string retroID { get; set; }
        public string bbrefID { get; set; }
        public string salarie { get; set; }
        public bool esfiambre { get; set; }
    }
}
