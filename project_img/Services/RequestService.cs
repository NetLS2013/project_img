using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Plugin.Connectivity;
using project_img.Interfaces;
using Xamarin.Forms;

namespace project_img.Services
{
    public class RequestService
    {
        private readonly JsonSerializerSettings _serializerSettings;

        public RequestService()
        {
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };

            _serializerSettings.Converters.Add(new StringEnumConverter());
        }

        public async Task<(TSuccess, TError)> GetAsync<TData, TSuccess, TError>(string uri)
        {
            HttpResponseMessage response;

            if (!CrossConnectivity.Current.IsConnected)
            {
                DependencyService.Get<IAlertService>().Short("No internet connection! Cannot load data from server.");

                return (default(TSuccess), default(TError));
            }

            var httpClient = CreateHttpClient();

            try
            {
                response = await httpClient.GetAsync(uri);

                if (!response.IsSuccessStatusCode)
                {
                    return (default(TSuccess), await DeserializeObject<TError>(response));
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"--- Error: {e.StackTrace}");
                DependencyService.Get<IAlertService>().Short("Something wrong. Try again later.");

                return (default(TSuccess), default(TError));
            }

            return (await DeserializeObject<TSuccess>(response), default(TError));
        }

        public async Task<(TSuccess, TError)> PostAsync<TData, TSuccess, TError>(string uri, TData data)
        {
            HttpResponseMessage response;

            if (!CrossConnectivity.Current.IsConnected)
            {
                DependencyService.Get<IAlertService>().Short("No internet connection! Cannot load data from server.");

                return (default(TSuccess), default(TError));
            }

            var httpClient = CreateHttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(data))
            {
                Headers = {
                    ContentType = new MediaTypeHeaderValue("application/json")
                }
            };

            try
            {
                response = await httpClient.PostAsync(uri, content);

                if (!response.IsSuccessStatusCode)
                {
                    return (default(TSuccess), await DeserializeObject<TError>(response));
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"--- Error: {e.StackTrace}");
                DependencyService.Get<IAlertService>().Short("Something wrong. Try again later.");

                return (default(TSuccess), default(TError));
            }

            return (await DeserializeObject<TSuccess>(response), default(TError));
        }

        public async Task<(TSucces, TError)> PostFormDataAsync<TData, TSucces, TError>(string uri, TData data, Stream stream)
        {
            HttpResponseMessage response;

            if (!CrossConnectivity.Current.IsConnected)
            {
                DependencyService.Get<IAlertService>().Short("No internet connection! Cannot load data from server.");

                return (default(TSucces), default(TError));
            }

            var httpClient = CreateHttpClient();
            var content = new MultipartFormDataContent();

            if (stream != null)
            {
                content.Add(new StreamContent(stream), "\"avatar\"", "\"avatar.png\""); //TODO delete hard typed variable
            }

            var keyValues = JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonConvert.SerializeObject(data));
            foreach (var keyValuePair in keyValues)
            {
                content.Add(new StringContent(keyValuePair.Value ?? ""), String.Format($"\"{keyValuePair.Key}\""));
            }

            try
            {
                response = await httpClient.PostAsync(uri, content);

                if (!response.IsSuccessStatusCode)
                {
                    return (default(TSucces), await DeserializeObject<TError>(response));
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"--- Error: {e.StackTrace}");
                DependencyService.Get<IAlertService>().Short("Something wrong. Try again later.");

                return (default(TSucces), default(TError));
            }

            return (await DeserializeObject<TSucces>(response), default(TError));
        }

        private async Task<TResult> DeserializeObject<TResult>(HttpResponseMessage responseMessage)
        {
            var serialized = await responseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings);
        }

        private HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }
    }
}
