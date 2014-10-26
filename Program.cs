using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unclechao.Restaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            Waiter w = new Waiter(1, "yalan.mao", new Cook(1, "chao.zhang"));
            Customer c1 = new Customer(1, "zhongqi.zhang");
            w.AddRelatedCustomerAndCook(c1);
            Customer c2 = new Customer(2, "liwu.zuo");
            w.AddRelatedCustomerAndCook(c2);
            c1.Add("香辣肉丝", 2);
            c1.Add("宫保鸡丁", 1);
            c2.Add("白开水", 5);
            c1.Add("米饭", 2);
            c1.Order();
            c2.Order();

            Console.ReadKey();
        }
    }
}
