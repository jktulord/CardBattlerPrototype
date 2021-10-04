using Assets.Scripts.EntityScripts.EnemyScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.DropScripts
{
    public interface IPlayPlace
    {
        public void Play(CardDropScript card, IEnemy enemy);
    }
}
