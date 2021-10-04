using Assets.Exploration.Scripts.EntityStats.Perk;
using Assets.Exploration.Scripts.EntityStats.ValueCounter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Exploration.Scripts.EntityStats
{
    public class EntityStats
    {
        public IValueCounter Hp;

        public string name;

        public PerkManager PerkManager;


        public EntityStats()
        {
            name = "Goblin";
            Hp = new Hp(100, 100);
            PerkManager = new PerkManager();
            PerkManager.Perks.Add(new Perk.Perk("Brave", "gets buff when hp is less than 30%"));
        }
    }
}
