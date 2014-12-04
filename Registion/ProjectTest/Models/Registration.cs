using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectTest.Models
{
    public class Registration
    {

        public int RegistrationId { set; get; }

        public string Name { set; get; }
        public string Email { set; get; }
        public string Contract_Number { set; get; }

        [DisplayName("Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public string Address { set; get; }

        public virtual Department ADepartment { set; get; }

        public int DepartmentId { set; get; }
    }
}