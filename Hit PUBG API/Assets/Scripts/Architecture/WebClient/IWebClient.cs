using System;

namespace Architecture.WebClient
{
    public interface IWebClient
    {
        IObservable<string> Get(string url, params (string key, string value)[] headers);
    }
}