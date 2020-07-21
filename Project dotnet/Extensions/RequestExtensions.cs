using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_dotnet.Extensions
{
    public static class RequestExtensions
    {
        public static string GetToken(this HttpRequest request)
        {
            string token = "";

            foreach (var value in request.Headers.Values)
            {
                if (value.ToString().Contains("Bearer"))
                {
                    token = value.ToString();
                    token = token.Replace("Bearer ", "").Trim();
                }
            }

            return token;
        }
    }
}
