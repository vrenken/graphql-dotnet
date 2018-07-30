using System.Net;
using System.Threading.Tasks;
using Example;
using Xunit;

namespace GraphQL.Harness.Tests
{
    public class BasicTests : SystemTestBase<Startup>
    {
        [Fact]
        public async Task Query_Hero()
        {
            await run(_ =>
            {
                var input = new GraphQLRequest
                {
                    Query = @"{ hero { name} }"
                };
                _.Post.Json(input).ToUrl("/api/graphql");
                _.StatusCodeShouldBe(HttpStatusCode.OK);
                _.GraphQL().ShouldBeSuccess(@"{ ""hero"": { ""name"": ""R2-D2"" }}");
            });
        }

        [Fact]
        public async Task Query_Hero_Using_Start_Directive()
        {
            await run(_ =>
            {
                var input = new GraphQLRequest
                {
                    Query = @"query data @start(path:""person:Stark/Tony"") { hero { name} }"
                };
                _.Post.Json(input).ToUrl("/api/graphql");
                _.StatusCodeShouldBe(HttpStatusCode.OK);
                _.GraphQL().ShouldBeSuccess(@"{ ""hero"": { ""name"": ""R2-D2"" }}");
            });
        }
    }
}
