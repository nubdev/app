 using Machine.Specifications;
 using app.core.containers;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(DependencyFactories))]  
  public class DependencyFactoriesSpecs
  {
    public abstract class concern : Observes<IFindDependencyFactories,
                                      DependencyFactories>
    {
        
    }

   
    public class when_finding_a_factory_to_create_a_dependency : concern
    {
      public class and_it_has_the_factory
      {
        Establish c = () =>
        {
          factory_that_can_create_the_item = fake.an<ICreateOneDependency>();

        };

        Because b = () =>
          result = sut.get_the_factory_that_can_create(typeof(int));

        It should_return_the_factory_that_creates_the_dependency = () =>
          result.ShouldEqual(factory_that_can_create_the_item);

        static ICreateOneDependency result;
        static ICreateOneDependency factory_that_can_create_the_item;
      }
        
    }
  }
}
