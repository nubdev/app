namespace app.web.core
{
  public interface IProcessOneRequest
  {
    void process(IEncapsulateRequestDetails request);
    bool can_handle(IEncapsulateRequestDetails request);
  }
}