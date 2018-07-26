using GraphQL.Types;

namespace EtAlii.Ubigia.Infrastructure.Transport.GraphQL
{
    public class HumanInputType : InputObjectGraphType
    {
        public HumanInputType()
        {
            Name = "HumanInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<StringGraphType>("homePlanet");
        }
    }
}
