using System;

namespace app.core.containers
{
  public class DependencyFactories : IFindDependencyFactories
  {
    public ICreateOneDependency get_the_factory_that_can_create(Type dependency)
    {
      throw new NotImplementedException();
    }
  }
}