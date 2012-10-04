using System;

namespace app.core.containers.basic
{
  public class Container : IFetchDependencies
  {
    IFindDependencyFactories factories;
    ItemCreationFailure_Behaviour failure_behaviour;

    public Container(IFindDependencyFactories factories, ItemCreationFailure_Behaviour failure_behaviour)
    {
      this.factories = factories;
      this.failure_behaviour = failure_behaviour;
    }

    public Dependency an<Dependency>()
    {
      return (Dependency) an(typeof(Dependency));
    }

    public object an(Type dependency)
    {
        try
        {
            var factory = factories.get_the_factory_that_can_create(dependency);
            return factory.create();
        }
        catch (Exception e)
        {
            throw failure_behaviour(dependency, e);
        }
    }
  }
}