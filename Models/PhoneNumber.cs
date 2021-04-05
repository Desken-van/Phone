using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Phone.Models
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        [Required]
        [Phone]
        public string Number { get; set; }
    }

}
