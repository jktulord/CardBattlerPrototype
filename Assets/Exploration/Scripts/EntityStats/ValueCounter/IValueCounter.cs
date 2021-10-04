using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Exploration.Scripts.EntityStats.ValueCounter
{
    public interface IValueCounter
    {
        public int MaxValue { get; set; }
        public int Value { get; set; }
    
    }
}
