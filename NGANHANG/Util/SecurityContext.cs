using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGANHANG.DTO;

namespace NGANHANG.Util
{
    public class SecurityContext
    {
        private static User user;

        public static User User { get => user; set => user = value; }

        public static void ClearUser()
        {
            user = null;
        }

        private SecurityContext() { }
    }
}
