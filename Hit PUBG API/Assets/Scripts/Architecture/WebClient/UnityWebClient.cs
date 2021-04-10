using System;
using System.Collections;
using System.Net;
using UniRx;
using UnityEngine.Networking;

namespace Architecture.WebClient
{
    public class UnityWebClient : IWebClient
    {
        public IObservable<string> Get(string url, params (string key, string value)[] headers)
        {
            var response = "";

            IEnumerator GetRoutine()
            {
                var webRequest = UnityWebRequest.Get(url);
                foreach (var (key, value) in headers) webRequest.SetRequestHeader(key, value);

                yield return webRequest.SendWebRequest();

                if (webRequest.result == UnityWebRequest.Result.Success)
                    response = webRequest.downloadHandler.text;
                else
                    throw new WebException(webRequest.error);
            }

            return GetRoutine()
                .ToObservable()
                .Select(_ => response);
        }

        public IObservable<string> Post(string uri, string data, params (string key, string value)[] headers)
        {
            var response = "";

            IEnumerator PostRoutine()
            {
                var webRequest = UnityWebRequest.Post(uri, data);
                foreach (var (key, value) in headers) webRequest.SetRequestHeader(key, value);

                yield return webRequest.SendWebRequest();
                if (webRequest.result == UnityWebRequest.Result.Success)
                    response = webRequest.downloadHandler.text;
                else
                    throw new WebException(webRequest.error);
            }

            return PostRoutine()
                .ToObservable()
                .Select(_ => response);
        }
    }
}