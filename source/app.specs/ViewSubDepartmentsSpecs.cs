using System.Collections.Generic;
using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  public class ViewSubDepartmentsSpecs
  {
    public abstract class concern : Observes<ISupportAUserFeature,
                                      ViewSubDepartments>
    {
    }


    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IEncapsulateRequestDetails>();
        information_in_the_store_repository = depends.on<IFindInformationInTheStore>();
        display_engine = depends.on<IDisplayInformation>();
        sub_request = fake.an<ViewSubDepartmentRequest>();
        the_sub_departments = new List<DepartmentItem> {new DepartmentItem()};
        parent_department = new DepartmentItem();
        request.setup(x => x.map<ViewSubDepartmentRequest>()).Return(sub_request);

        information_in_the_store_repository.setup(x => x.get_departments_using(sub_request)).Return(the_sub_departments);
      };

      Because b = () =>
        sut.process(request);

      It should_display_the_departments = () =>
        display_engine.received(x => x.display(the_sub_departments));

      static IEncapsulateRequestDetails request;
      static IFindInformationInTheStore information_in_the_store_repository;
      static IDisplayInformation display_engine;
      static IEnumerable<DepartmentItem> the_sub_departments;
      static DepartmentItem parent_department;
      static ViewSubDepartmentRequest sub_request;
    }
  }
}