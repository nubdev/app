 using System.Web;
 using Machine.Specifications;
 using app.web.core.aspnet;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(WebFormPageFactory))]  
  public class WebFormPageFactorySpecs
  {
    public abstract class concern : Observes<ICreateViewsForReports,
                                      WebFormPageFactory>
    {
        
    }

   
    public class when_creating_the_page_for_a_report : concern
    {
      Establish c = () =>
      {
        view_to_path_registry = depends.on<IFindPathsToAspxs>();
        the_model = 42;
        the_page_that_displays = fake.an<IDisplayA<int>>();
        the_path = "blah.aspx";

        view_to_path_registry.setup(x => x.get_the_path_to_the_view_for<int>()).Return(the_path);
        depends.on<CreateRawPage_Behaviour>((x,the_page_type) =>
        {
          x.ShouldEqual(the_path);
          the_page_type.ShouldEqual(typeof(IDisplayA<int>));
          return the_page_that_displays;
        });

      };

      Because b = () =>
        result =sut.create_view_that_can_display(the_model);

      It should_populate_the_data_for_the_created_page = () =>
        the_page_that_displays.report.ShouldEqual(the_model);
        
      It should_return_the_created_instance_of_the_page_that_displays_the_data = () =>
        result.ShouldEqual(the_page_that_displays);
        

      static int the_model;
      static IHttpHandler result;
      static IFindPathsToAspxs view_to_path_registry;
      static IDisplayA<int> the_page_that_displays;
      static string the_path;
    }
  }
}
