using System.Web;

namespace app.web.core
{
  public interface ICreateRequests
  {
    IEncapsulateRequestDetails create_from(HttpContext raw_request); 
  }
}