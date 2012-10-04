using System.Collections.Generic;
using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using app.web.core.aspnet;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewAReport<>))]
  public class ViewAReportSpecs
  {
    public abstract class concern : Observes<ISupportAUserFeature,
                                      ViewAReport<AReport>>
    {
    }

    public class when_viewing_a_report : concern
    {
      Establish c = () =>
      {
        request = fake.an<IEncapsulateRequestDetails>();
        display_engine = depends.on<IDisplayInformation>();
        the_report = new AReport();
        query = depends.on<IFetchAReport<AReport>>();

        query.setup(x => x.fetch_using(request)).Return(the_report);
      };

      Because b = () =>
        sut.process(request);

      It should_display_the_report_found_using_the_query = () =>
        display_engine.received(x => x.display(the_report));

      static IEncapsulateRequestDetails request;
      static IDisplayInformation display_engine;
      static AReport the_report;
      static IFetchAReport<AReport> query;
    }

    public class AReport
    {
    }
  }
}