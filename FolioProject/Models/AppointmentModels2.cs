using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FolioProject.Models
{
    public class AppointmentModels2
    {
        public int Id { get; set; }
        public int MedicImageId { get; set; }
        public MedicImage MedicImage { get; set; }
        
        [Required]
        public DateTime AppointmentTime { get; set; }
        public String Description { get; set; }

    }

}