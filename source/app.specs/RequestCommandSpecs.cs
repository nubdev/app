using Machine.Specifications;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(RequestCommand))]
  public class RequestCommandSpecs
  {
    public abstract class concern : Observes<IProcessOneRequest,
                                      RequestCommand>
    {
    }

    public class when_determining_if_it_can_handle_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IEncapsulateRequestDetails>();
        depends.on<MatchRequest_Behaviour>(x =>
        {
          x.ShouldEqual(request);
          return true;
        });
      };

      Because b = () =>
        result = sut.can_handle(request);

      It should_make_its_decicision_by_using_its_request_specification = () =>
        result.ShouldBeTrue();

        
      static bool result;
      static IEncapsulateRequestDetails request;
    }

    public class when_processing_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IEncapsulateRequestDetails>();
        feature = depends.on<ISupportAUserFeature>();
      };

      Because b = () =>
        sut.process(request);


      It should_trigger_the_application_feature = () =>
        feature.received(x => x.process(request));
        
      static ISupportAUserFeature feature;
      static IEncapsulateRequestDetails request;
    }
  }
}
