using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Unclechao.Restaurant
{
    public delegate void CookingFinishEventHandle(object sender, CookFinsihEventArgs e);
    public class Cook
    {
        #region property
        int jobNO;

        public int TableId
        {
            get { return jobNO; }
            private set { jobNO = value; }
        }

        string name;

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        Queue<Customer> cookList;
        public Queue<Customer> CookList
        {
            get { return cookList; }
        }
        Thread cookThread;

        #endregion

        public Cook(int no, string name)
        {
            this.jobNO = no;
            this.name = name;
            cookList = new Queue<Customer>();
            cookThread = new Thread(Cooking);
            cookThread.Start();
        }

        public void Cooking()
        {
            while (true)
            {
                if (cookList.Count > 0)
                {
                    Customer customer = cookList.Dequeue();
                    foreach (var item in customer.OrderList.Keys)
                    {
                        //模拟做一道菜需要1秒钟
                        Thread.Sleep(1000);
                    }
                    if (CookingFinish != null)
                    {
                        CookingFinish(this, new CookFinsihEventArgs() { Serve4customer = customer });
                    }
                }
                //休息3秒
                Thread.Sleep(3000);
            }
        }
        public event CookingFinishEventHandle CookingFinish;
    }
}
