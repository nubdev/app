namespace app.web.core
{
  public interface IProcessRequests
  {
    void handle(IEncapsulateRequestDetails request);
  }

  public class FrontController : IProcessRequests
  {
    IFindCommands command_registry;

    public FrontController(IFindCommands command_registry)
    {
      this.command_registry = command_registry;
    }

    public FrontController():this(new CommandRegistry())
    {
    }

    public void handle(IEncapsulateRequestDetails request)
    {
      command_registry.get_the_command_that_can_process(request).process(request);
    }
  }
}