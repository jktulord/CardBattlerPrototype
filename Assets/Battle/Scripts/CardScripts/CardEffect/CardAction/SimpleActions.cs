using Assets.Scripts.EntityScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.CardScripts.CardEffect.CardAction
{
    public static class SimpleActions
    {
        public static bool Damage(IEntity self, List<IEntity> targets,  List<int> values)
        {
            values[0] = BlockDamage(targets[0], values[0]);

            targets[0].Hp -= values[0];


            targets[0].ShowDamageNumber(values[0]);
            return true;
        }

        public static int BlockDamage(IEntity target, int value)
        {
            if (target.Block > 0)
            {
                if (target.Block - value < 0)
                {
                    value -= target.Block;
                    target.Block = 0;

                }
                else
                {
                    target.Block -= value;
                    value = 0;
                }
            }
            return value;
        }

        // --- Damage functs --- 
        public static void Heal(IEntity target, int value)
        {
            target.Hp += value;
        }
        public static void Block(IEntity target, int value)
        {
            target.Block += value;
        }
        public static void Parry(IEntity target, int value)
        {
            target.ParryPoints += value;
        }
        public static void Dodge(IEntity target, int value)
        {
            target.DodgePoints += value;
        }

    }
}

