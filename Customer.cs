using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unclechao.Restaurant
{
    public delegate void OrderEventHandle(object sender, CustomerOrderListEventArgs e);
    public class Customer
    {
        #region property
        int tableId;

        public int TableId
        {
            get { return tableId; }
            private set { tableId = value; }
        }

        string name;

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        Dictionary<string, int> orderList;
        public Dictionary<string, int> OrderList
        {
            get { return orderList; }
            set { orderList = value; }
        }
        #endregion

        public Customer(int id, string name)
        {
            this.tableId = id;
            this.name = name;
            orderList = new Dictionary<string, int>();
        }

        /// <summary>
        /// 点一个菜
        /// </summary>
        /// <param name="dishName">菜名</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        public bool Add(string dishName, int count)
        {
            bool flag = false;
            try
            {
                if (count <= 0)
                {
                    flag = false;
                    return flag;
                }
                if (orderList.ContainsKey(dishName))
                {
                    orderList[dishName] += count;
                    Console.WriteLine("{0}已成功增加一个菜品{1}，已点数量为{2}", this.name, dishName, orderList[dishName]);
                    flag = true;
                }
                else
                {
                    orderList.Add(dishName, count);
                    Console.WriteLine("{0}已成功增加一个菜品{1}，已点数量为{2}", this.name, dishName, count);
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                flag = false;
                Console.WriteLine(ex.Message);
            }
            return flag;
        }

        /// <summary>
        /// 取消一个点过的菜
        /// </summary>
        /// <param name="dishName">菜名</param>
        /// <returns></returns>
        public bool Remove(string dishName)
        {
            bool flag = false;
            try
            {
                if (orderList.ContainsKey(dishName))
                {
                    orderList.Remove(dishName);
                    Console.WriteLine("{0}已成功取消{1}。", this.name, dishName);
                    flag = true;
                }
                else
                {
                    Console.WriteLine("{0}不在{1}的已点菜单中。", dishName, this.name);
                    flag = false;

                }
            }
            catch (Exception ex)
            {
                flag = false;
                Console.WriteLine(ex.Message);
            }
            return flag;
        }

        /// <summary>
        /// 取消一个点过的菜,并指定数量
        /// </summary>
        /// <param name="dishName">菜名</param>
        /// <param name="count">取消数量</param>
        /// <returns></returns>
        public bool Remove(string dishName, int count)
        {
            bool flag = false;
            try
            {
                if (count <= 0)
                {
                    flag = false;
                    return flag;
                }
                if (orderList.ContainsKey(dishName))
                {
                    if ((orderList[dishName] -= count) > 0)
                    {
                        orderList[dishName] -= count;
                        Console.WriteLine("{0}已成功取消{1}份{2}。", this.name, count, dishName);
                    }
                    else
                    {
                        orderList.Remove(dishName);
                        Console.WriteLine("{0}已成功取消{1}。", this.name, dishName);
                    }
                    flag = true;
                }
                else
                {
                    Console.WriteLine("{0}不在{1}的已点菜单中。", dishName, this.name);
                    flag = false;

                }
            }
            catch (Exception ex)
            {
                flag = false;
                Console.WriteLine(ex.Message);
            }
            return flag;
        }


        public void Order()
        {
            if (OrderFinished != null)
            {
                OrderFinished(this, new CustomerOrderListEventArgs() { OrderList = this.OrderList });
            }
        }
        public event OrderEventHandle OrderFinished;
    }
}
