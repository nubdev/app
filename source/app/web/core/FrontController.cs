namespace app.web.core
{
  public interface IProcessRequests
  {
    void handle(object request);
  }
  public class FrontController : IProcessRequests
  {
      public FrontController(IFindCommands findCommands)
      {
          this.findCommands = findCommands;
      }

      IFindCommands findCommands;

    public void handle(object request)
    {
        var commandToExecute = findCommands.get_the_command_that_can_process(request);
        commandToExecute.process(request);
    }
  }
}