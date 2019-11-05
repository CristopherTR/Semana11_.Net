using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Student
    {
        [Key]
        public int studentID { get; set; }
        [Required]
        public string studentName { get; set; }
        [Required]
        public string studentAddress { get; set; }
        [Required]
        public string studentLast { get; set; }
        [Required]
        public int studentCode { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
