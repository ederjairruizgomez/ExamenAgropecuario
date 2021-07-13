using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class GeoReferencias
    {
        public int IdGeoReferencia { get; set; }
        public ML.Estado Estado { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public List<object> geoReferencias { get; set; }
    }
}
