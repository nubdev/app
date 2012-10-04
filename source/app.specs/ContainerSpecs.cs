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
        the_concrete_type = fake.an<IAmADependency>();
        item_factory = fake.an<ICreateOneDependency>();
        dependency_factories = depends.on<IFindDependencyFactories>();

        item_factory.setup(x => x.create()).Return(the_concrete_type);

        dependency_factories.setup(x => x.get_the_factory_that_can_create(typeof(IAmADependency)))
          .Return(item_factory);
      };

      Because b = () =>
        result = sut.an<IAmADependency>();

      It should_return_the_item_created_by_the_item_factory_for_the_dependency = () =>
        result.ShouldEqual(the_concrete_type);

      static IAmADependency result;
      static IAmADependency the_concrete_type;
      static ICreateOneDependency item_factory;
      static IFindDependencyFactories dependency_factories;
    }

    public interface IAmADependency
    {
    }
  }
}
