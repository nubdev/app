using System;
using Machine.Specifications;
using app.core.containers;
using app.core.containers.basic;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

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
      public class and_it_has_the_dependency_factory
      {
        Establish c = () =>
        {
          the_concrete_type = fake.an<IAmADependency>();
          item_factory = fake.an<ICreateOneDependency>();
          dependency_factories = depends.on<IFindDependencyFactories>();


          dependency_factories.setup(x => x.get_the_factory_that_can_create(typeof(IAmADependency)))
            .Return(item_factory);

          item_factory.setup(x => x.create()).Return(the_concrete_type);
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

      public class and_the_dependency_factory_for_the_dependency_throws_an_exception_while_creating_the_item
      {
        Establish c = () =>
        {
          item_factory = fake.an<ICreateOneDependency>();
          dependency_factories = depends.on<IFindDependencyFactories>();
          creation_exception = new Exception();
          custom_exception = new Exception();

          depends.on<ItemCreationFailure_Behaviour>((type, inner) =>
          {
            type.ShouldEqual(typeof(IAmADependency));
            inner.ShouldEqual(creation_exception);
            return custom_exception;
          });

          item_factory.setup(x => x.create()).Throw(creation_exception);

          dependency_factories.setup(x => x.get_the_factory_that_can_create(typeof(IAmADependency)))
            .Return(item_factory);
        };

        Because b = () =>
          spec.catch_exception(() => sut.an<IAmADependency>());

        It should_rethrow_the_exception_created_by_the_item_creation_failure_behaviour = () =>
          spec.exception_thrown.ShouldEqual(custom_exception);

        static ICreateOneDependency item_factory;
        static IFindDependencyFactories dependency_factories;
        static Exception creation_exception;
        static Exception custom_exception;
      }
    }

    public interface IAmADependency
    {
    }
  }
}