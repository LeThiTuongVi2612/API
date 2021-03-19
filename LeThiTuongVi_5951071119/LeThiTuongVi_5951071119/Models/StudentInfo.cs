using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace LeThiTuongVi_5951071119.Models
{
    [DataContract]
    public class StudentInfo
    {
        [DataMember(Name ="name")]
        public string HoTen { get; set; }

        [DataMember(Name = "MSSV")]
        public string MaSo { get; set; }

    }
}