using System.Collections.Generic;

namespace Domain
{
    public class Level
    {
        public int LevelID { get; set; }

        public string LevelName { get; set; }

        public ICollection<Faculty> Faculties { get; set; }

    }
}