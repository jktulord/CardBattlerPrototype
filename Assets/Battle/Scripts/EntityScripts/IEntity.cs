using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.EntityScripts
{
    public interface IEntity
    {
        public bool IsPlayer { get; set; }
        public int MaxHp { get; set; }
        public int Hp { get; set; }

        public int Block { get; set; }
        public int ParryPoints { get; set; }
        public int DodgePoints { get; set; }

        public void ShowDamageNumber(int value);
    }
}
