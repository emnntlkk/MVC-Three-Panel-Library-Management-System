using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Models.Siniflarim
{
    public class TabloListele
    {
        public IEnumerable<TBLKITAP> tablo1 { get; set; }
        public IEnumerable<TBLHAKKIMIZDA> tablo2 { get; set; }

    }
}