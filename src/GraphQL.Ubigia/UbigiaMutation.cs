using EtAlii.Ubigia.Infrastructure.Transport.GraphQL.Types;
using GraphQL.Types;

namespace EtAlii.Ubigia.Infrastructure.Transport.GraphQL
{
    /// <example>
    /// This is an example JSON request for a mutation
    /// {
    ///   "query": "mutation ($human:HumanInput!){ createHuman(human: $human) { id name } }",
    ///   "variables": {
    ///     "human": {
    ///       "name": "Boba Fett"
    ///     }
    ///   }
    /// }
    /// </example>
    public class UbigiaMutation : ObjectGraphType<object>
    {
        public UbigiaMutation(UbigiaData data)
        {
            Name = "Mutation";

            Field<HumanType>(
                name: "createHuman",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<HumanInputType>> {Name = "human"}),
                resolve: context =>
                {
                    var human = context.GetArgument<Human>("human");
                    return data.AddHuman(human);
                });
        }
    }
}
