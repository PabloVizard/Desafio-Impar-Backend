using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Photo : BaseEntity
    {
        public string Base64 { get; set; }
    }
}
