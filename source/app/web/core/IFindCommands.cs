using System.Collections.Generic;
using System;

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
     foreach (IProcessOneRequest processor in commands)
     {
         if ( processor.can_handle(request) )
         {
             return processor;
         }
     }
        return null;
    }
  }
}