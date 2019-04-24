using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Onecore_Web.Models
{
    public class Employee
    {
        
        public int EMP_ID { get; set; }
        public int EMP_REGISTER { get; set; }
        [Required]
        public int CPY_ID { get; set; }
        [Required]
        public string EMP_FULLNAME { get; set; }
        [Required]
        public DateTime EMP_DATEBORN { get; set; }
        [Required]
        public string EMP_GENRE { get; set; }
        [Required]
        public string EMP_CPF { get; set; }
        [Required]
        public DateTime EMP_DATEADMISSION { get; set; }
        [Required]
        public string EMP_RG { get; set; }
        [Required]
        public string EMP_EMITION { get; set; }
        [Required]
        public string EMP_SCHOOLING { get; set; }
        [Required]
        public string EMP_TELEPHONE { get; set; }
        [Required]
        public string EMP_PHONE { get; set; }
        [Required]
        public string EMP_EMAIL { get; set; }
     
        public Byte? EMP_ADDRESSID { get; set; }

        public string EMP_PICTURE { get; set; }
        [Required]
        public string EMP_ROLE { get; set; }

        [Required]
        public int EM_ID { get; set; }
    }
}
