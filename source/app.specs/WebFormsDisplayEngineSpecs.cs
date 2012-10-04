using System.Web;
using Machine.Specifications;
using app.specs.utility;
using app.web.core;
using app.web.core.aspnet;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(WebFormsDisplayEngine))]
  public class WebFormsDisplayEngineSpecs
  {
    public abstract class concern : Observes<IDisplayInformation,
                                      WebFormsDisplayEngine>
    {
    }

    public class when_displaying_an_item : concern
    {
      Establish c = () =>
      {
        the_item = new  SomeItem();
        view = fake.an<IHttpHandler>();
        handler_factory = depends.on<ICreateViewsForReports>();
        the_current_context = ObjectFactory.web.create_http_context();
        depends.on<GetTheCurrentlyExecutingRequest_Behaviour>(() => the_current_context);

        handler_factory.setup(x => x.create_view_that_can_display(the_item)).Return(view);
      };

      Because b = () =>
        sut.display(the_item);


      It should_tell_the_view_to_render = () =>
        view.received(x => x.ProcessRequest(the_current_context));
        

      static ICreateViewsForReports handler_factory;
      static SomeItem the_item;
      static IHttpHandler view;
      static HttpContext the_current_context;
    }

    public class SomeItem
    {
    }
  }
}