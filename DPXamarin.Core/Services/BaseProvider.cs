using System;
using System.Net.Http;
using System.Threading.Tasks;

using DPXamarin.Core.Exceptions;

namespace DPXamarin.Core.Services
{
    public class BaseProvider
    {
        protected string _baseUrl;

        protected HttpClient GetClient()
        {
            return GetClient(_baseUrl);
        }

        protected virtual HttpClient GetClient(string baseUrl)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);

            return client;
        }

        protected async Task Get(string url)
        {
            using (HttpClient client = GetClient())
            {
                try
                {
                    var response = await client.GetAsync(url);
                    if (!response.IsSuccessStatusCode)
                    {
                        var error = await response.Content.ReadAsAsync<TrackSeriesApiError>();
                        throw new ComicSeriesApiException(error.Message, response.StatusCode);
                    }
                }
                catch (HttpRequestException ex)
                {
                    throw new ComicSeriesApiException("", false, ex);
                }
            }
        }

        protected async Task<T> Get<T>(string url)
        {
            using (HttpClient client = GetClient())
            {
                try
                {
                    var response = await client.GetAsync(url);
                    if (!response.IsSuccessStatusCode)
                    {
                        var error = await response.Content.ReadAsAsync<TrackSeriesApiError>();
                        var message = error != null ? error.Message : "";
                        throw new ComicSeriesApiException(message, response.StatusCode);
                    }
                    return await response.Content.ReadAsAsync<T>();
                }
                catch (HttpRequestException ex)
                {
                    throw new ComicSeriesApiException("", false, ex);
                }
                catch (UnsupportedMediaTypeException ex)
                {
                    throw new ComicSeriesApiException("", false, ex);
                }
            }
        }
    }
}
