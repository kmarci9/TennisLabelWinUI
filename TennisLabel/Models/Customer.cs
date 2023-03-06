using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisLabel.Models
{
    public partial class Customer : ObservableObject
    {
        [ObservableProperty]
        private string firstname;

        [ObservableProperty]
        private string lastname;

        [ObservableProperty]
        private string country;

        [ObservableProperty]
        private string city;

        [ObservableProperty]
        private int zip;

        [ObservableProperty]
        private string phone;

        public int ID { get; set; }

        public override string ToString()
        {
            return Lastname + " " + Firstname;
        }


    }
}
