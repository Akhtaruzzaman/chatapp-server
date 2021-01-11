using Domain.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.Library.Sys_Enum;

namespace Domain.Messenger
{
    [Table("Messages")]
    public class Messages : Entity
    {
        public Guid FromId { get; set; }
        public virtual Users From { get; set; }
        public Guid ToId { get; set; }
        public virtual Users To { get; set; }
        public SeenStatus SeenStatus { get; set; }
        public string Message { get; set; }
    }
}
