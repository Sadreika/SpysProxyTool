using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpysProxyTool
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://spys.one/en/http-proxy-list/";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:81.0) Gecko/20100101 Firefox/81.0";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.Headers.Add("Accept-Language", "en-GB,en;q=0.5");
            //request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            request.Host = "spys.one";
            request.ContentType = "keep-alive";
            request.Headers.Add("DNT", "1");
            request.Headers.Add("Upgrade-Insecure-Requests", "1");
           
            var response = (HttpWebResponse)(request.GetResponse());
            List<Proxy> proxyAddressList = new List<Proxy>();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                HtmlDocument htmlDocument = new HtmlDocument();
                StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                htmlDocument.Load(streamReader);
                //font[@class='spy14']
                foreach (HtmlNode proxyAddress in htmlDocument.DocumentNode.SelectNodes("//tr[@class='spy1x']//font[@class='spy14']"))
                {
                    Console.WriteLine(proxyAddress.InnerText);
                   // Proxy newProxyObject = new Proxy(proxyAddress.SelectSingleNode();
                   // proxyAddressList.Add(newProxyObject);
                }
                Console.WriteLine("KKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK");
                foreach (HtmlNode proxyAddress in htmlDocument.DocumentNode.SelectNodes("//tr[@class='spy1xx']//font[@class='spy14']"))
                {
                    Console.WriteLine(proxyAddress.InnerText);
                    // Proxy newProxyObject = new Proxy(proxyAddress.SelectSingleNode();
                    // proxyAddressList.Add(newProxyObject);
                }
            }
            foreach (Proxy proxy in proxyAddressList)
            {
               // Console.WriteLine(proxy.proxyAddress + " " + proxy.port);
            }
        }
    }
}
