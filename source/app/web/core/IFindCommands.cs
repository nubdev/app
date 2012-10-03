namespace app.web.core
{
  public interface IFindCommands
  {
    IProcessOneRequest get_the_command_that_can_process(IEncapsulateRequestDetails request);
  }

  class CommandRegistry : IFindCommands
  {
    public IProcessOneRequest get_the_command_that_can_process(IEncapsulateRequestDetails request)
    {
      throw new System.NotImplementedException();
    }
  }
}