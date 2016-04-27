using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GRFQL.Tests
{
    public class QueryParserTests
    {
        [Fact]
        public void AnEmptyQueryReturnsNothing()
        {
            var QueryParser = new QueryParser(string.Empty);
        }
    }

    public class QueryParser
    {
        private readonly string _query;

        public QueryParser(string query)
        {
            _query = query;
        }

        public GQLHttpResponse Parse()
        {
            return new GQLHttpResponse(200, string.Empty);
        }
    }

    public class GQLHttpResponse
    {
        public int HttpResponseCode { get; }
        public string HttpResponse { get; }
        public GQLHttpResponse(int httpResponseCode, string httpResponse)
        {
            HttpResponseCode = httpResponseCode;
            HttpResponse = httpResponse;
        }
    }
}
