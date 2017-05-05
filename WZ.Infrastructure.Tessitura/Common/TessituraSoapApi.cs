using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZ.Infrastructure.Tessitura
{
    public class TessituraSoapApi : com.tessiturasoftware.tessitura.Tessitura
    {
        public TessituraSoapApi() : base()
        {
            AllowSslErrors();
        }

        protected static bool handleSslErrors = false;
        protected virtual void AllowSslErrors()
        {
            if (handleSslErrors)
                return;

            System.Net.ServicePointManager.ServerCertificateValidationCallback +=

            delegate (
                Object sender1,
                System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                System.Security.Cryptography.X509Certificates.X509Chain chain,
                System.Net.Security.SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };

            handleSslErrors = true;
        }
    }
}
