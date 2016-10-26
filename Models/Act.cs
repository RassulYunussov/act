using System;
using System.ComponentModel.DataAnnotations;
namespace act.Models
{
    public class Act
    {
        public int Id {get;set;}
        public int? DocumentNumber {get;set;}
        public DateTime Date {get;set;}
        [StringLength(5)]
        public string SupplierName {get;set;}
        [StringLength(5)]
        public string ClientName {get;set;}
        public string SupplierBin {get;set;}
        public string ClientBin {get;set;}
    }

}