namespace app.web.core
{
  public interface IProcessOneRequest
  {
    void process(IEncapsulateRequestDetails request);
    bool can_handle(IEncapsulateRequestDetails request);
  }

  public class RequestCommand : IProcessOneRequest
  {
    public void process(IEncapsulateRequestDetails request)
    {
      throw new System.NotImplementedException();
    }

    public bool can_handle(IEncapsulateRequestDetails request)
    {
        return true;
    }
  }
}