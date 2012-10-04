using System.Web;

namespace app.web.core.aspnet
{
  public interface ICreateViewsForReports
  {
    IHttpHandler create_view_that_can_display<Report>(Report the_item);
  }
}