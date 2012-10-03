using System.Collections.Generic;
using System.Linq;

namespace app.web.core
{
  public interface IFindCommands
  {
    IProcessOneRequest get_the_command_that_can_process(IEncapsulateRequestDetails request);
  }

  public class CommandRegistry : IFindCommands
  {
    CreateMissingCommand_Behaviour missing_command_factory;
    IEnumerable<IProcessOneRequest> commands { get; set; }

    public CommandRegistry(IEnumerable<IProcessOneRequest> all_commands,CreateMissingCommand_Behaviour missing_command_factory)
    {
      this.missing_command_factory = missing_command_factory;
      commands = all_commands;
    }

    public IProcessOneRequest get_the_command_that_can_process(IEncapsulateRequestDetails request)
    {
      return commands.FirstOrDefault(x => x.can_handle(request)) ?? missing_command_factory();
    }
  }
}