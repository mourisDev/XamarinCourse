using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using xamaCourse01.Service.Model;
using Newtonsoft.Json;

namespace xamaCourse01.Service
{
    public class viaCEPService
    {
        public static string uURL = "http://viacep.com.br/ws/{0}/json/";

        public static address GetAddrCEP(string cep)
        {
            string newuURL = string.Format(uURL, cep);

            WebClient wc = new WebClient();
            string content = wc.DownloadString(newuURL);

            address addrNew = JsonConvert.DeserializeObject<address>(content);

            if (addrNew.cep == null) return null;
            return addrNew;
        }

    }
}
