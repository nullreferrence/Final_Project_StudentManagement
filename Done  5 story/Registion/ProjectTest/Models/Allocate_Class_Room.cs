using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectTest.Models
{
    public class Allocate_Class_Room
    {
        public int Allocate_Class_RoomID { set; get; }
        public virtual Department ADepartment { set; get; }

        public virtual Course ACourse { set; get; }

        public int CourseId { set; get; }
        public virtual Room ARoom { set; get; }
        public int RoomId { set; get; }

        [DisplayName("Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [DisplayName("From")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime TimeFrom { get; set; }

        
        [DisplayName("To")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime  TimeTo { get; set; }





    }
}