using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Exploration.Scripts.EntityStats.Perk
{
    public class Perk
    {
        public string Name;
        public string Description;

        public Perk(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
