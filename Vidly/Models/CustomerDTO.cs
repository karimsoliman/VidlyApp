using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public DateTime? Birthdate { get; set; }
        public int MemberShipTypeId { get; set; }
        public MemberShipType MemberShipType { get; set; }
    }
}