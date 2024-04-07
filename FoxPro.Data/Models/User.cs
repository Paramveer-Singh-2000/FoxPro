using FoxPro.Auth.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxPro.Data.Models
{
    public class User : ApplicationUser
    {
        public string Name { get; set; }
        public List<string>? Technologies { get; set; }
        public Guid ProjectsId { get; set; }
        public ICollection<Project>? Projects { get; set; }
        public string? Image { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
