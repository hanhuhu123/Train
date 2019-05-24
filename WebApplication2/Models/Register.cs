using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Register
    {
        public int Id { get; set; }
        public string RegisterName { get; set; }
        public string RegisterPwd { get; set; }
        public string Uname { get; set; }
        public string IdCard { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}