using Assets.Scripts.CardScripts;
using Assets.Scripts.CardScripts.CardEffect;
using Assets.Scripts.CardScripts.CardEffect.CardAction;
using Assets.Scripts.DropScripts;
using Assets.Scripts.EntityScripts.EnemyScripts;
using Assets.Scripts.PlayerScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.EntityScripts
{
    public static class AttackManager
    {
        public static void Play(ICardEffect card, IEntity self, List<IEntity> targets)
        {
            for (int i = 0; i < card.Actions.Count; i++)
            {
                
                card.Actions[i](self, targets, card.Values[i]);
            }
        }

    }
}
