using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dinda.Models
{
    public class Madrinhas
    {
        public int Id { get; set; }
        public int ConhecimentosId { get; set; }
        public Conhecimentos Conhecimentos { get; set; }
    }
}
