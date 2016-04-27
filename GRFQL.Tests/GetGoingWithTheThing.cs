using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GRFQL.Tests
{
    public class GetGoingWithTheThing
    {
        [Fact]
        public void GetSchemaReturnsAString()
        {
            var sut = new GraphQLQuery<string, string>( (string x) => x as string);
            var result = sut.GetSchema();
            Assert.IsType<string>(result);
        }

        [Fact]
        public void ANonNullSchemaIsCreatedWhenCreatedWithContent()
        {
            var sut = new GraphQLQuery<string,string>((string query) => query );
            var result = sut.GetSchema();
            Assert.IsType<string>(result);
            Console.WriteLine(result);
            Debug.WriteLine(result);
            Assert.Equal("Thing",result);
        }
    }

    public class GraphQLQuery<TIn, TOut>
    {
        private readonly Func<TIn, TOut> _func;

        public GraphQLQuery(Func<TIn, TOut> func)
        {
            _func = func;
        }

        public string GetSchema()
        {
            return SerializeTypes(DetermineTypes(_func));
        }

        private IEnumerable<Type> DetermineTypes(Func<TIn, TOut> func)
        {
            yield return typeof (TIn);
            yield return typeof (TOut);
        }

        private string SerializeTypes(IEnumerable<Type> determineTypes)
        {
            return ConcatDetails(determineTypes.Select(t => SerializeType(t)));
        }
        private string ConcatDetails(IEnumerable<string> @select)
        {
            return @select.Aggregate(new StringBuilder(), (sb, v) => sb.AppendLine(v), sb => sb.ToString());
        }
        private string SerializeType(Type type)
        {
            return type.ToString();
        }
    }
}
