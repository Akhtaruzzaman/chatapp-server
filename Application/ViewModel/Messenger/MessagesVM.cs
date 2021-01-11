using Domain;
using Domain.Master;
using Domain.Messenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.Library.Sys_Enum;

namespace Application.ViewModel.Messenger
{
    public class MessagesVM : Entity
    {
        public Guid FromId { get; set; }
        public string FromName { get; set; }
        public Guid ToId { get; set; }
        public string ToName { get; set; }
        public SeenStatus SeenStatus { get; set; }
        public string Message { get; set; }
        public Messages ToEntity()
        {
            return new Messages()
            {
                Id = this.Id,
                FromId = this.FromId,
                ToId = this.ToId,
                Message = this.Message,
                SeenStatus = this.SeenStatus,

                CreatedAt = this.CreatedAt,
                CreatedBy = this.CreatedBy,
                CreatedFrom = this.CreatedFrom,
                UpdatedAt = this.UpdatedAt,
                UpdatedBy = this.UpdatedBy,
                UpdatedFrom = this.UpdatedFrom,
                IsArchived = this.IsArchived
            };
        }
    }
}
