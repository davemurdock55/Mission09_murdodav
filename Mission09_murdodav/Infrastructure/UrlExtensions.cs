using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_murdodav.Infrastructure
{
    public static class UrlExtensions
    {
        // Making the PathAndQuery method to return the user back to exactly where they were
        // when they clicked the "Add to Cart" button
        // passing the HTTP request
        public static string PathAndQuery(this HttpRequest request) =>
            // using an arrow function to return, if the QueryString has a value, a path with the request Path and request QueryString
            // and if the QueryString has no value, then returning the request Path converted to a string
            request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
    }
}
