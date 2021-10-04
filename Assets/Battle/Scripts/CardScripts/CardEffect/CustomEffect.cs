using Assets.Scripts.CardScripts.CardEffect.CardAction;
using Assets.Scripts.EntityScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.CardScripts.CardEffect
{
    public class CustomEffect : ICardEffect
    {
        public TargetTypes Target { get; set; }

        public List<Func<IEntity, List<IEntity>, List<int>, bool>> Actions { get; set; }
        public List<List<int>> Values { get; set; }

        public CustomEffect(List<Func<IEntity, List<IEntity>, List<int>, bool>> actions, List<List<int>> values)
        {
            Target = TargetTypes.enemy;
            Actions = actions;
            Values = values;
        }
    }
}
