using Machine.Specifications;
using app.core.containers;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(Dependencies))]
  public class DependenciesSpecs
  {
    public abstract class concern : Observes<Dependencies>
    {
    }

    public class when_accessing_the_container_facade : concern
    {
      Establish c = () =>
      {
        the_container = fake.an<IFetchDependencies>();
        GetTheActiveContainer_Behaviour resolution = () => the_container;
        spec.change(() => Dependencies.container_resolution).to(resolution);
      };

      Because b = () =>
        result = Dependencies.fetch;

      It should_return_the_facade_resolved_using_the_facade_resolution_mechanism = () =>
        result.ShouldEqual(the_container);

      static IFetchDependencies result;
      static IFetchDependencies the_container;
    }
  }
}