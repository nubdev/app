using System;

namespace app.core.containers
{
  public delegate Exception ItemCreationFailure_Behaviour(Type type_that_could_not_be_created,Exception inner);
}