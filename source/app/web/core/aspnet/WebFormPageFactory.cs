using System.Web;

namespace app.web.core.aspnet
{
  public class WebFormPageFactory : ICreateViewsForReports
  {
    IFindPathsToAspxs path_registry;
    CreateRawPage_Behaviour asp_page_factory;

    public WebFormPageFactory(IFindPathsToAspxs path_registry, CreateRawPage_Behaviour asp_page_factory)
    {
      this.path_registry = path_registry;
      this.asp_page_factory = asp_page_factory;
    }

    public IHttpHandler create_view_that_can_display<Report>(Report the_item)
    {
      var path = path_registry.get_the_path_to_the_view_for<Report>();
      var page = (IDisplayA<Report>) asp_page_factory(path, typeof(IDisplayA<Report>));
      page.report = the_item;
      return page;
    }
  }
}