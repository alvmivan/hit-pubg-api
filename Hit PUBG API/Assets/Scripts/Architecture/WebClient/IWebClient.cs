using System;

namespace Architecture.WebClient
{
    public interface IWebClient
    {
        IObservable<string> Get(string url, params (string key, string value)[] headers);

        IObservable<string> Post(string uri, string data, params (string key, string value)[] headers);
        // IObservable<string> Put(string url, string body, params (string key, string value)[] headers);
        // IObservable<string> Delete(string url, string body, params (string key, string value)[] headers);
    }
}