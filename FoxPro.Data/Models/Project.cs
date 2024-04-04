using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxPro.Data.Models
{
    public class Project:BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User>? Developers { get; set; }
        public Guid? ManagedBy { get; set; }
    }
}
