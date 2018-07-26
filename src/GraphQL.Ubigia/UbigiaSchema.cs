namespace EtAlii.Ubigia.Infrastructure.Transport.GraphQL
{
    using global::GraphQL;
    using global::GraphQL.Types;

    public class StaticUbigiaSchema : Schema
    {
        public new IDependencyResolver DependencyResolver => base.DependencyResolver;
        public StaticUbigiaSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<UbigiaQuery>();
            Mutation = resolver.Resolve<UbigiaMutation>();
        }
    }
}
