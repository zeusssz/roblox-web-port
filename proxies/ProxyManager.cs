using System;
using System.Collections.Generic;
using System.IO;

namespace RobloxInputApi
{
    public class ProxyManager
    {
        private readonly List<Uri> _proxies;
        private int _currentProxyIndex = -1;

        public ProxyManager(string filePath)
        {
            _proxies = new List<Uri>();

            foreach (var line in File.ReadLines(filePath))
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    _proxies.Add(new Uri(line));
                }
            }

            if (_proxies.Count == 0)
            {
                throw new Exception("No proxies found in the provided file.");
            }
        }

        public Uri GetNextProxy()
        {
            _currentProxyIndex = (_currentProxyIndex + 1) % _proxies.Count;
            return _proxies[_currentProxyIndex];
        }
    }
}
