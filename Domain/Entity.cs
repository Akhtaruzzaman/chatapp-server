using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public abstract class Entity
    {
        [Key]
        [Display(Name = "ID")]
        public Guid Id { get; set; }
        [Display(Name = "Archived")]
        public bool IsArchived { get; set; }


        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedFrom { get; set; }

        public Guid UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedFrom { get; set; }

        [NotMapped]
        public string sSearch { get; set; }
        public T Copy<T>()
        {
            return (T)MemberwiseClone();
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void GenerateNewGuidId()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
