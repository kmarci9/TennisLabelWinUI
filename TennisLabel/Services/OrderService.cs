using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisLabel.Models;

namespace TennisLabel.Services
{
    public  class OrderService
    {
        public ObservableCollection<Order> Fill()
        {
            ObservableCollection<Order> orders = new ObservableCollection<Order>();
            orders.Add(new Order(DateTime.Today,DateTime.Now,1));
            orders.Add(new Order(DateTime.Today, DateTime.Now, 2));
            orders.Add(new Order(DateTime.Today, DateTime.Now, 3));
            return orders;
        }
    }
}
