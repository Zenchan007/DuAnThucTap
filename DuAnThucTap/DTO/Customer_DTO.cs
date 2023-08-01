using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DuAnThucTap.DTO
{
    public class Customer_DTO
    {

        public int ID { get; set; } 
       
        public string Name_Customer { get; set; } = null!;

        public int Age_Customer { get; set; } 


        public string Address_Customer { get; set; } = null!;
       
        public string?  Description_Customer { get; set; }
    }
}
