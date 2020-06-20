using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandApi.Models
{
    public class Command
    {
        public int Id { get; set; }
        public string HowTo { get; set; }
        public string Plataform { get; set; }
        public string CommandLine { get; set; }
    }
}
