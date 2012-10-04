using System;

namespace app.core.containers
{
  public interface IFindDependencyFactories
  {
    ICreateOneDependency get_the_factory_that_can_create(Type dependency);
  }
}