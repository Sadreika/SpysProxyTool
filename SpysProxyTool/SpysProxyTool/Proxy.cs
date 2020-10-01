namespace SpysProxyTool
{
    public class Proxy
    {
        public string proxyAddress;
        public string port;
        public Proxy(string proxyAddress, string port)
        {
            this.proxyAddress = proxyAddress;
            this.port = port;
        }
    }
}
