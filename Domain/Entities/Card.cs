using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Card : BaseEntity
    {
        [ForeignKey("Photo")]
        public int? PhotoId { get; set; }
        public string Name { get; set; }
        public CardStatus Status { get; set; }
    }
}
