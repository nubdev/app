using System.Collections.Generic;
using System;
using System.Linq;

namespace app.web.core
{
  public interface IFindCommands
  {
    IProcessOneRequest get_the_command_that_can_process(IEncapsulateRequestDetails request);
  }

  public class CommandRegistry : IFindCommands
  {

    private IEnumerable<IProcessOneRequest> commands { get; set; }

    public CommandRegistry(IEnumerable<IProcessOneRequest> aCommandList)
    {
        commands = aCommandList;
    }
    public IProcessOneRequest get_the_command_that_can_process(IEncapsulateRequestDetails request)
    {
        return commands.First(x => x.can_handle(request));
        return null;
    }
  }
}
