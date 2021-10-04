using Assets.Scripts.CardScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class CardStats
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public ICardCost Cost { get; set; }
        public ICardEffect Effect { get; set; }
        

        public CardStats(string title, string description, ICardCost cardCost, ICardEffect cardEffect)
        {
            Title = title;
            Description = description;
            Cost = cardCost;
            Effect = cardEffect;
        }

        public void UpdateShow(Transform transform)
        {
            TMP_Text titleText = transform.Find("Title").gameObject.GetComponent<TMP_Text>();
            titleText.text = Title;
            TMP_Text descriptionText = transform.Find("Description").gameObject.GetComponent<TMP_Text>();
            descriptionText.text = Description;

            TMP_Text EnergyText = transform.Find("EnergyIcon").Find("EnergyCounter").GetComponent<TMP_Text>();
            EnergyText.text = Cost.Value + "";
        }

    }
}
