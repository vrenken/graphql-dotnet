namespace EtAlii.Ubigia.Infrastructure.Transport.GraphQL
{
    using System.Collections.Generic;
    using global::GraphQL.Types;

    public class DynamicUbigiaSchema : Schema
    {
        private readonly List<IGraphType> _dynamicSchema = new List<IGraphType>();

        private readonly ISchema _staticSchema;

        public DynamicUbigiaSchema(StaticUbigiaSchema staticSchema, string query)
            : base(staticSchema.DependencyResolver)
        {
            _staticSchema = staticSchema;

            Query = staticSchema.DependencyResolver.Resolve<UbigiaQuery>();
            Mutation = staticSchema.DependencyResolver.Resolve<UbigiaMutation>();
        }
    }
}
