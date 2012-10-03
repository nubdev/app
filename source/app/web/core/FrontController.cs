namespace app.web.core
{
  public interface IProcessRequests
  {
    void handle(object request);
  }
  public class FrontController : IProcessRequests
  {
    public void handle(object request)
    {
      throw new System.NotImplementedException();
    }
  }
}