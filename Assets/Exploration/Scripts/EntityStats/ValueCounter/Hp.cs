  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Exploration.Scripts.EntityStats.ValueCounter
{
    public class Hp : IValueCounter
    {
        public int MaxValue { get; set; }

        private int _value; 
        public int Value { get { return _value; } 
            set { 
                _value = value;
                if (value > MaxValue)
                    _value = MaxValue;
                if (value < 0)
                    _value = 0;
            } 
        }


        public Hp(int curValue, int maxValue)
        {
            MaxValue = maxValue;
            Value = curValue;
        }
    }
}
