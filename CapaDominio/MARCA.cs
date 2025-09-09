using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaDominio

{
    public class MARCA
    {
        public int Id { get; set; }
        public string  Descripcion { get; set; }
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
