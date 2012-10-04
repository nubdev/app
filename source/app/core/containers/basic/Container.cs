using System;

namespace app.core.containers.basic
{
  public class Container:  IFetchDependencies
  {
    IFindDependencyFactories factories;
    private ItemCreationFailure_Behaviour failureBehavior;

    public Container(IFindDependencyFactories factories, ItemCreationFailure_Behaviour failureBehavior)
    {
      this.factories = factories;
      this.failureBehavior = failureBehavior;
    }

    public Dependency an<Dependency>()
    {
        Dependency item = default(Dependency);
        try
        {
            var factory = factories.get_the_factory_that_can_create(typeof (Dependency));
            item = (Dependency)(factory.create());
        }
        catch (Exception e)
        {
            throw failureBehavior.Invoke(typeof (Dependency), e);
        }
        return (Dependency)item;
    }
  }
}