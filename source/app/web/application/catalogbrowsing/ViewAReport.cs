using app.web.core;
using app.web.core.aspnet;

namespace app.web.application.catalogbrowsing
{
  public class ViewAReport<Report> : ISupportAUserFeature
  {
    IDisplayInformation display_engine;
    IFetchAReport<Report> query;

    public ViewAReport(IDisplayInformation display_engine, IFetchAReport<Report> query)
    {
      this.display_engine = display_engine;
      this.query = query;
    }

    public void process(IEncapsulateRequestDetails request)
    {
      display_engine.display(query.fetch_using(request));
    }
  }
}