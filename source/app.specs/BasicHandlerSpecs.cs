 using System.Web;
 using Machine.Specifications;
 using app.specs.utility;
 using app.web.core;
 using app.web.core.aspnet;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(BasicHandler))]  
  public class BasicHandlerSpecs
  {
    public abstract class concern : Observes<IHttpHandler,
                                      BasicHandler>
    {
        
    }

   
    public class when_processing_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IEncapsulateRequestDetails>();
        front_controller = depends.on<IProcessRequests>();
        a_context = ObjectFactory.web.create_http_context();

        request_factory = depends.@on<ICreateRequests>();

        request_factory.setup(x => x.create_from(a_context)).Return(request);
      };
      Because b = () =>
        sut.ProcessRequest(a_context);

      It should_delegate_the_processing_of_a_new_request_to_the_front_controller = () =>
        front_controller.received(x => x.handle(request));

      static IProcessRequests front_controller;
      static IEncapsulateRequestDetails request;
      static HttpContext a_context;
      static ICreateRequests request_factory;
    }
  }
}
