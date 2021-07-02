using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BigSchool.Models
{
    public class Course
    {
        public int Id { get; set; }
        public ApplicationUser Lecture { get; set; }
        [Required]
        public string LectureId { get; set; }

        [StringLength(255)]
        public string Place { get; set; }
        [DataType(DataType.Date)]
        public DateTime dateTime { get; set; }

        public Category Category { get; set; }

        public byte CategoryId { get; set; }
    }
}