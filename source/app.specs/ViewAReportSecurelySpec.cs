using System.Collections.Generic;
using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using app.web.core.aspnet;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof(ViewAReportSecurely<>))]
    public class ViewAReportSecurelySpecs
    {
        public abstract class concern : Observes<ISupportAUserFeature,
                                          ViewAReportSecurely<AReport>>
        {
        }

        public class when_viewing_a_report_securely : concern
        {
            public class if_user_has_access_to_report : concern
            {
                private Establish c = () =>
                                          {
                                              request = fake.an<IEncapsulateRequestDetails>();
                                              display_engine = depends.on<IDisplayInformation>();
                                              the_report = new AReport();
                                              query = depends.on<IFetchAReport<AReport>, IFindAccessRights<AReport>>();

                                              query.setup(x => x.fetch_using(request)).Return(the_report);
                                          };

                private Because b = () =>
                                    sut.process(request);

                private It should_display_the_report_found_using_the_query = () =>
                                                                             display_engine.received(
                                                                                 x => x.display(the_report));

                private static IEncapsulateRequestDetails request;
                private static IDisplayInformation display_engine;
                private static AReport the_report;
                private static IFetchAReport<AReport> query;
            }

            public class if_user_lacks_access_to_report : concern
            {
                private Establish c = () =>
                {
                    request = fake.an<IEncapsulateRequestDetails>();
                    display_engine = depends.on<IDisplayInformation>();
                    the_report = new AReport();
                    query = depends.on<IFetchAReport<AReport>, IFindAccessRights<AReport>>();

                    query.setup(x => x.fetch_using(request)).Return(the_report);
                };

                private Because b = () =>
                                    spec.catch_exception(sut.process(request));

                private It should_throw_security_access_exception_when_using_the_query = () =>
                    spec.exception_thrown.ShouldBeAn<SecurityException>();

                private static IEncapsulateRequestDetails request;
                private static IDisplayInformation display_engine;
                private static AReport the_report;
                private static IFetchAReport<AReport> query;
            }
        }

        public class AReport
        {
        }
    }
}