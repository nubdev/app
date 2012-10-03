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
        department_repository = depends.on<IFindDepartments>();
        display_engine = depends.on<IDisplayInformation>();
        sub_request = fake.an<ViewSubDepartmentRequest>();
        the_sub_departments = new List<DepartmentItem> {new DepartmentItem()};
        parent_department = new DepartmentItem();
        request.setup(x => x.map<ViewSubDepartmentRequest>()).Return(sub_request);

        department_repository.setup(x => x.get_departments_using(sub_request)).Return(the_sub_departments);
      };

      Because b = () =>
        sut.process(request);

      It should_display_the_departments = () =>
        display_engine.received(x => x.display(the_sub_departments));

      static IEncapsulateRequestDetails request;
      static IFindDepartments department_repository;
      static IDisplayInformation display_engine;
      static IEnumerable<DepartmentItem> the_sub_departments;
      static DepartmentItem parent_department;
      static ViewSubDepartmentRequest sub_request;
    }
  }
}