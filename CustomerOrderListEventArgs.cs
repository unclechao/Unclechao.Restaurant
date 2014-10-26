using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unclechao.Restaurant
{
    public class CustomerOrderListEventArgs : EventArgs
    {
        public Dictionary<string, int> OrderList
        {
            get;
            set;
        }
    }
}
