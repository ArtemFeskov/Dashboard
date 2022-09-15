using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Data.Data.ViewModels
{
    public class RegisterUserVM
    {
        public string Emeil{ get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
