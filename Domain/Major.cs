using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class Major
    {
        public int MajorID { get; set; }
        public string MajorName { get; set; }
        public virtual ICollection<Faculty> Faculties { get; set; }
    }
}