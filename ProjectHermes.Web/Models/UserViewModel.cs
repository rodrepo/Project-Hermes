using ProjectHermes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectHermes.Web.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public UserType UserType { get; set; }
        public bool IsActive { get; set; }

        // Auditable
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}