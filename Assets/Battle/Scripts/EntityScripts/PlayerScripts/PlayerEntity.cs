using Assets.Scripts.DropScripts;
using Assets.Scripts.EntityScripts;
using Assets.Scripts.EntityScripts.EnemyScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    public class PlayerEntity : BasicEntity
    {
        public TMP_Text EnergyCounter;
        int Energy = 9;

        public void Start()
        {
            IsPlayer = true;
            EnergyCounter = transform.Find("EnergyIcon").GetChild(0).GetComponent<TMP_Text>();
            HpCounter = transform.Find("HpCounter").GetComponent<TMP_Text>();
            BlockCounter = transform.Find("BlockCounter").GetComponent<TMP_Text>();
            ParryCounter = transform.Find("ParryCounter").GetComponent<TMP_Text>();
            DodgeCounter = transform.Find("DodgeCounter").GetComponent<TMP_Text>();
            EnergyCounter.text = ""+Energy;
            MaxHp = 100;
            Hp = MaxHp;
        }
        void Update()
        {
            HpBar.maxValue = MaxHp;
            HpBar.value = Hp;
            HpCounter.text = Hp + "/" + MaxHp;
            BlockCounter.text = "" + Block;
            ParryCounter.text = "" + ParryPoints;
            DodgeCounter.text = "" + DodgePoints;
        }

        public bool PlayCard(CardDropScript card, PlayerEntity player, IEntity target)
        {
            bool ret = false;
            if ((card.Stats.Effect.Target == CardScripts.CardEffect.TargetTypes.enemy) && (!target.IsPlayer))
            {
                ret = CheckCost(card, player, target);
            }
            else if ((card.Stats.Effect.Target == CardScripts.CardEffect.TargetTypes.self) && (target.IsPlayer))
            {
                Debug.Log("CostCheck On Player Passed");
                ret = CheckCost(card, player, target);
            }

            return ret;
        }

        public bool CheckCost(CardDropScript card, PlayerEntity player, IEntity target)
        {
            bool ret = false;
            if (Energy - card.Stats.Cost.Value >= 0)
            {
                Energy -= card.Stats.Cost.Value;
                AttackManager.Play(card.Stats.Effect, player, new List<IEntity> { target });
                card.Disapear();
                EnergyCounter.text = "" + Energy;
                ret = true;
            }
            return ret;
        }

        public void NextTurn()
        {
            Energy = 9;
            Block = 0;
            ParryPoints = 0;
            DodgePoints = 0;
            EnergyCounter.text = "" + Energy;
        }
    }
}
