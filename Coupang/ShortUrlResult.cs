using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupang
{
    public class ShortUrlResult
    {
        public string rCode { get; set; }
        public string rMessage { get; set; }
        public class _Data
        {
            public string originalUrl { get; set; }
            public string shortenUrl { get; set; }
            public string landingUrl { get; set; }
        }
        public List<_Data> data { get; set; }
    }
}
