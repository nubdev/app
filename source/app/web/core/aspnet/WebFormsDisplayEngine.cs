using System.Web;

namespace app.web.core.aspnet
{
  public class WebFormsDisplayEngine : IDisplayInformation
  {
    ICreateViewsForReports handler_factory;
    GetTheCurrentlyExecutingRequest_Behaviour current_request_resolution;

    public WebFormsDisplayEngine(ICreateViewsForReports handler_factory,
                                 GetTheCurrentlyExecutingRequest_Behaviour current_request_resolution)
    {
      this.handler_factory = handler_factory;
      this.current_request_resolution = current_request_resolution;
    }

    public WebFormsDisplayEngine():this(new WebFormPageFactory(),
                                        () => HttpContext.Current)
    {
    }

    public void display<ReportModel>(ReportModel model)
    {
      handler_factory.create_view_that_can_display(model).ProcessRequest(current_request_resolution());
    }
  }
}