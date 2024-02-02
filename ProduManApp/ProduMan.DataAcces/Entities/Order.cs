using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProduMan.DataAccess.Entities
{
    public class Order :EntityBase
    {
        public int Lp { get; set; }
        public string? NrZamowienia { get; set; }
        public string? Firma { get; set; }
        public string? Temat { get; set; }
        public string? ZamowionaIlosc { get; set; }
        public string? IloscDoZmontowania { get; set; } = null;
        public string? ZmontowanaIlosc { get; set; } = null;
        public string? Uwagi { get; set; } = null;
        public string? UwagiSmd { get; set; } = null;
        public string? UwagiTht { get; set; } = null;
        public string? UwagiSzablon { get; set; } = null;
        public string Poziom { get; set; }
        public int Tydzien { get; set; }
        public string? DzienTygodnia { get; set; }
        public string? NowyProdukt { get; set; }
        public string? Deadline { get; set; }
        public string? OsobaPrzyjmujacaZlecenie { get; set; }
        public string? Traceability { get; set; }
        public string? Pasta { get; set; }
        public string? Komponenty { get; set; }
        public string? SMD { get; set; }
        public bool THT { get; set; }
        public bool AOI { get; set; }
        public bool Mycie { get; set; }
        public bool Testowanie { get; set; }
        public bool Programowanie { get; set; }

    }
}
