using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace act.Models
{
    public class Act
    {
        public int Id {get;set;}
        public int? DocumentNumber {get;set;}
        public DateTime Date {get;set;}
        public string SupplierName {get;set;}
        public string ClientName {get;set;}
        public string SupplierBin {get;set;}
        public string ClientBin {get;set;}

        public virtual ICollection<ActService> Services {get;set;}

        public Act ()
        {
          Services = new LinkedList<ActService>();
        }

        public decimal Total 
        {
            get
            {
               return Services?.Sum(x=>x.Total)??0;
            }
        }
    }

}