using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisLabel.Models
{
    public partial class Order : ObservableObject
    {
        [ObservableProperty]
        private DateTime startdate;

        [ObservableProperty]
        private DateTime enddate;

        [ObservableProperty]
        private int primarykey;

        public override string ToString()
        {
            return base.ToString();
        }

        public Order(DateTime startdate, DateTime enddate, int primarykey)
        {
            this.startdate = startdate;
            this.enddate = enddate;
            this.primarykey = primarykey;
        }
    }
}
