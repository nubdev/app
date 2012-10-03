using System.Web;
using app.web.application.catalogbrowsing;

namespace app.web.core.stubs
{
  public class StubRequestFactory : ICreateRequests
  {
    public IEncapsulateRequestDetails create_from(HttpContext raw_request)
    {
      return new StubRequest();
    }

    class StubRequest : IEncapsulateRequestDetails
    {
      InputModel IEncapsulateRequestDetails.map<InputModel>()
      {
        object item = new ViewSubDepartmentRequest();
        return (InputModel) item;
      }
    }
  }
}