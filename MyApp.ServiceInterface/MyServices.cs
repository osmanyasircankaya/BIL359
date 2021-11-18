using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using ServiceStack;
using MyApp.ServiceModel;
using Microsoft.Data.SqlClient;


namespace MyApp.ServiceInterface
{
    public class MyServices : Service
    {
        private readonly IConfiguration configuration;

        public MyServices(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public object Any(Hello request)
        {
            var keyName = request.Name;
            var sql = "Select value from Ders_odev where [key]=@key";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = connection.Query<string>(sql, new {key = keyName});
                return result.Any() ? new HelloResponse {Result = result.First()} : new HelloResponse {Result = "there is no value for this key"};
            }
        }

        public object Any(GetLinks request) => new GetLinksResponse
        {
            Results = new Dictionary<string, string>
            {
                {"servicestack.net", "https://servicestack.net"},
                {"StackOverflow", "http://stackoverflow.com/search?q=servicestack"},
                {"Customer Forums", "https://forums.servicestack.net"},
                {"Issue Tracker", "https://github.com/ServiceStack/Issues"},
                {"Feature Requests", "http://servicestack.uservoice.com/forums/176786-feature-requests"},
                {"Release Notes", "https://servicestack.net/release-notes"},
                {"Live Demos", "https://github.com/ServiceStackApps/LiveDemos"},
                {".NET Core Live Demos", "https://github.com/NetCoreApps/LiveDemos"},
                {"Gistlyn", "http://gistlyn.com"},
            }
        };

        public object Any(GetPost request) => new GetPostResponse
        {
            Id = request.Id,
            Title = $"Title {request.Id}",
            Description = $"Post Description {request.Id}",
        };
    }
}