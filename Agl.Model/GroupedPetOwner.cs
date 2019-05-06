using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agl.Model
{
    public class GroupedPetOwner
    {
        public GroupedPetOwner()
        {
            Pets = new List<string>();
        }
        public string OwnerGender { get; set; }
        public List<string> Pets { get; set; }
    }
}
