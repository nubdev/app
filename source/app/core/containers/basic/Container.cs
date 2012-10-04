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
      try
      {
        var factory = factories.get_the_factory_that_can_create(typeof(Dependency));
        return (Dependency) (factory.create());
      }
      catch (Exception e)
      {
        throw failure_behaviour(typeof(Dependency), e);
      }
    }
  }
}