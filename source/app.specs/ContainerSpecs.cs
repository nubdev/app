 using Machine.Specifications;
 using app.core.containers;
 using app.core.containers.basic;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(Container))]  
  public class ContainerSpecs
  {
    public abstract class concern : Observes<IFetchDependencies,
                                      Container>
    {
        
    }

   
    public class when_fetching_a_dependency : concern
    {

        Establish c = () =>
        {
            container = fake.an<Container>();
            spec.change(() => container.an<IFetchDependencies>());
        };
        Because b = () =>
        result = container.an<IFetchDependencies>();

        private It should_fetch_a_dependency = () =>
          result.ShouldEqual(container);

      static IFetchDependencies result;
      static Container container;
    }
  }
}
