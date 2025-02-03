using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces.Entities
{
    public interface IEquipo
    {
        public int id { get; set; }
        public string casco { get; set; }
        public string armadura { get; set; }
        public string arma1 { get; set; }
        public string arma2 { get; set; }
        public string guanteletes { get; set; }
        public string grebas { get; set; }
    }
}