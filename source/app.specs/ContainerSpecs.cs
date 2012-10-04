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
      It should_ = () =>        
        
    }
  }
}
