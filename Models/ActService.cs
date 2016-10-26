using System.ComponentModel.DataAnnotations.Schema;

namespace act.Models
{
    public class ActService
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public decimal Price {get;set;}
        public int Amount {get;set;}
        [NotMapped]
        public decimal Total 
        {
            get 
            {
                return Price*Amount;
            }
        }
    }
}