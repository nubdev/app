using System;

namespace app.core.containers.basic
{
  public class Container:  IFetchDependencies
  {
    IFindDependencyFactories factories;

    public Container(IFindDependencyFactories factories)
    {
      this.factories = factories;
    }

    public Dependency an<Dependency>()
    {
      var factory = factories.get_the_factory_that_can_create(typeof(Dependency));
      var item = factory.create();
      return (Dependency)item;
    }
  }
}