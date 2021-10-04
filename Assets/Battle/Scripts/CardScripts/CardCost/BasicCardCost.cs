using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.CardScripts
{
    public class BasicCardCost : ICardCost
    {
        public int Value { get; set; }

        public BasicCardCost(int value)
        {
            Value = value;
        }
    }
}
  