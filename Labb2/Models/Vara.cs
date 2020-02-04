using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Labb2.Models
{
    public class Vara
    {
        public int ID { get; set; }

        public string Namn { get; set; }

        public double Pris { get; set; }

        public int ButikAntal { get; set; }

        public int LagerAntal { get; set; }
    }
}