using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisLabel.Models;
using TennisLabel.Services;

namespace TennisLabel.ViewModels
{
    public class OrderViewModel
    {
        private OrderService _orderService;
        public Customer Customer { get; set; }
        public ObservableCollection<Order> Orders { get; }

        public OrderViewModel(Customer customer)
        {
            this._orderService = new OrderService();
            Customer = customer;
            Orders = _orderService.Fill();
        }
    }
}
