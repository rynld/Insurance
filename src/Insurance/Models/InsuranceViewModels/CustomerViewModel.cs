using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Models.InsuranceViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }       

        
        public string PlanType { get; set; }      
        
                
    }
}
