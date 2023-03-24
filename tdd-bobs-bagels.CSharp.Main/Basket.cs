using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_bobs_bagels.CSharp.Main
{
    public class Basket
    {
        private int _maxCapacity;

        private List<string> _bagels;

        public Basket()
        {            
             _bagels = new List<string>();
            _maxCapacity = 5;
        }

        public bool AddBagelToBasket(string bagel)
        {
            
            if(_bagels.Count < _maxCapacity)
            {
                _bagels.Add(bagel);
                
                return true;
            }
            
            return false;
        }

        public bool RemoveBagel(string bagel)
        {
            if(_bagels.Contains(bagel))
            {            
                _bagels.Remove(bagel);
                return true;
            }
            return false;
            
        }

        public List<string> Bagels { get { return _bagels; } }
        public int MaxCapacity 
        { 
            get 
            { 
                return _maxCapacity; 
            } 
            set 
            {                 
                _maxCapacity = value;
                _bagels.Clear();

            } 
        }
        public string BasketStatus()
        {
            return _bagels.Count <= _maxCapacity ? "Basket Not Full" : "Basket Full";
        }

    }
}
