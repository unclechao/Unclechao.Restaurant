using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unclechao.Restaurant
{
    public class Waiter
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

        Cook cook;
        public Cook Cook
        {
            get { return cook; }
            set { cook = value; }
        }

        Queue<Customer> serverTarget;
        public Queue<Customer> ServerTarget
        {
            get { return serverTarget; }
        }
        #endregion

        public Waiter(int no, string name, Cook c)
        {
            this.jobNO = no;
            this.name = name;
            this.cook = c;
            serverTarget = new Queue<Customer>();
            cook.CookingFinish += cook_CookingFinish;
        }

        public void AddRelatedCustomerAndCook(Customer c)
        {
            serverTarget.Enqueue(c);
            c.OrderFinished += c_OrderFinished;
        }

        void cook_CookingFinish(object sender, CookFinsihEventArgs e)
        {
            Cook cook = sender as Cook;
            Console.WriteLine("客人{0}的餐已准备完毕，请上菜", e.Serve4customer.Name);
        }

        void c_OrderFinished(object sender, CustomerOrderListEventArgs e)
        {
            Customer customer = sender as Customer;
            Console.WriteLine("客人{0}已提交菜单，菜单详情如下:", customer.Name);
            foreach (var item in e.OrderList)
            {
                Console.WriteLine("菜名：" + item.Key + ", 数量：" + item.Value);
            }
            Submit(customer);
        }

        private void Submit(Customer customer)
        {
            cook.CookList.Enqueue(customer);
        }
    }
}
