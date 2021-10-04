using Assets.Scripts.CardScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.EntityScripts.EnemyScripts
{
    public interface IEnemy : IEntity
    {
        public List<ICardEffect> Attacks { get; set; }

        public void NextTurn();

        public void ShowNextIntetion();
    }
}
