 using System.Collections.Generic;
 using System.Linq;
 using Machine.Specifications;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(CommandRegistry))]  
  public class CommandRegistrySpecs
  {
    public abstract class concern : Observes<IFindCommands,
                                      CommandRegistry>
    {
        
    }

   
    public class when_finding_a_command_that_can_handle_a_request : concern
    {
      public class and_it_has_the_command
      {
        Establish c = () =>
        {
          request = fake.an<IEncapsulateRequestDetails>();
          the_command_that_can_handle = fake.an<IProcessOneRequest>();

          all_the_possible_commands = Enumerable.Range(1,100).Select(x => fake.an<IProcessOneRequest>()).ToList();
          all_the_possible_commands.Add(the_command_that_can_handle);
          the_command_that_can_handle.setup(x => x.can_handle(request)).Return(true);

          depends.on<IEnumerable<IProcessOneRequest>>(all_the_possible_commands);
        };

        Because b = () =>
          result = sut.get_the_command_that_can_process(request);

        It should_return_the_command_that_can_handle_the_request = () =>
          result.ShouldEqual(the_command_that_can_handle);

        static IProcessOneRequest result;
        static IProcessOneRequest the_command_that_can_handle;
        static IEncapsulateRequestDetails request;
        static List<IProcessOneRequest> all_the_possible_commands;
      } 
        
    }
  }
}
