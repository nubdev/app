using System;

namespace app.core.containers
{
  public class Dependencies
  {
    public static GetTheActiveContainer_Behaviour container_resolution = () =>
    {
      throw new NotImplementedException("This should be set by a startup process");
    };

    public static IFetchDependencies fetch
    {
      get { throw new System.NotImplementedException(); }
    }
  }
}