using Assets.Scripts.CardScripts.CardEffect;
using Assets.Scripts.CardScripts.CardEffect.CardAction;
using Assets.Scripts.EntityScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.CardScripts
{
    public interface ICardEffect
    {
        public TargetTypes Target { get; set; }
        public List<Func<IEntity, List<IEntity>, List<int>, bool>> Actions { get; set; }
        public List<List<int>> Values { get; set; }

    }
}
