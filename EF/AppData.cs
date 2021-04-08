using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon_Brovushka.EF
{
    public class AppData
    {
        public static Entities Context { get; } = new Entities();
    }
}