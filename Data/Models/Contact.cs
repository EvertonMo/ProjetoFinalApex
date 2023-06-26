using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Contact : BaseModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
