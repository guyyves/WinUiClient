using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUiClient.Data
{
    internal class Bewoner
    {
        public long Id {  get; set; }
        public string Name { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Job {  get; set; }
    }
}
