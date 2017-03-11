using System;
using System.Net;

namespace DPXamarin.Core.Exceptions
{
    public class ComicSeriesApiException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Connection { get; set; }

        public ComicSeriesApiException(string message, HttpStatusCode statusCode)
            : base(message)
        {
            StatusCode = statusCode;
            Connection = true;
        }

        public ComicSeriesApiException(string message, bool connection, Exception inner)
            : base(message, inner)
        {
            Connection = connection;
            StatusCode = HttpStatusCode.ServiceUnavailable;
        }
    }

    public class TrackSeriesApiError
    {
        public string Message { get; set; }
    }
}
