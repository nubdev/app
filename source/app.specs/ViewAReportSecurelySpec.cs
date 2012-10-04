using System.Security.Principal;
using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using app.web.core.aspnet;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(UserConstrainedQuery<>))]
  public class ConstainedQuerySpecs
  {
    public abstract class concern : Observes<IFetchAReport<AReport>,
                                      UserConstrainedQuery<AReport>>
    {
    }

    public class when_quering_for_data : concern
    {
      public class and_the_user_meets_the_query_specification : concern
      {
        Establish c = () =>
        {
          request = fake.an<IEncapsulateRequestDetails>();
          original = depends.on<IFetchAReport<AReport>>();
          access_rights = depends.on<IDetermineIfAUserMeetsACondition>();
          principal = fake.an<IPrincipal>();
          depends.on<GetTheCurrentUser_Behaviour>(() => principal);
          access_rights.setup(x => x.is_authorized(principal)).Return(true);
          the_report = new AReport();

          original.setup(x => x.fetch_using(request)).Return(the_report);
        };

        Because b = () =>
          result = sut.fetch_using(request);

        It should_run_the_original_query = () =>
          result.ShouldEqual(the_report);

        static IEncapsulateRequestDetails request;
        static IFetchAReport<AReport> original;
        static IPrincipal principal;
        static IDetermineIfAUserMeetsACondition access_rights;
        static AReport the_report;
        static AReport result;
      }
    }

    public class AReport
    {
    }
  }
}