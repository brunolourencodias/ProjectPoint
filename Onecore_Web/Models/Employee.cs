using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onecore_Web.Models
{
    public class Employee
    {
        
        public int EMP_ID { get; set; }
        public int EMP_REGISTER { get; set; }
        public int CPY_ID { get; set; }
        public string EMP_FULLNAME { get; set; }
        public DateTime EMP_DATEBORN { get; set; }
        public string EMP_GENRE { get; set; }
        public string EMP_CPF { get; set; }
        public DateTime EMP_DATEADMISSION { get; set; }
        public string EMP_RG { get; set; }
        public string EMP_EMITION { get; set; }
        public string EMP_SCHOOLING { get; set; }
        public string EMP_TELEPHONE { get; set; }
        public string EMP_PHONE { get; set; }
        public string EMP_EMAIL { get; set; }
        public Byte? EMP_ADDRESSID { get; set; }
        public string EMP_PICTURE { get; set; }
        public string EMP_ROLE { get; set; }
    }
}
