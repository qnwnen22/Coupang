using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Coupang
{
    public class HmacGenerator
    {
        public string GenerateHmac(string method, string url, string accessKey, string secretKey)
        {
            var dateTimeStamp = DateTime.Now.ToUniversalTime().ToString("yyMMddTHHmmssZ");
            var message = string.Format("{0}{1}{2}", dateTimeStamp, method, url.Replace("?", string.Empty));

            var keyBytes = ASCIIEncoding.Default.GetBytes(secretKey);
            var messageBytes = ASCIIEncoding.Default.GetBytes(message);

            var hashBytes = default(byte[]);
            using (var hash = new HMACSHA256(keyBytes))
            {
                hashBytes = hash.ComputeHash(messageBytes);
            }

            var signature = BitConverter.ToString(hashBytes).Replace("-", string.Empty).ToLower();
            return String.Format("CEA algorithm=HmacSHA256, access-key={0}, signed-date={1}, signature={2}", accessKey, dateTimeStamp, signature);
        }
    }
}
