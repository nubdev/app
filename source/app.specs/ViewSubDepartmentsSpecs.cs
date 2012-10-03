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


    public class when_run : ViewTheMainDepartmentsInTheStoreSpecs.concern
    {
      Establish c = () =>
      {
        request = fake.an<IEncapsulateRequestDetails>();
        department_repository = depends.on<IFindDepartments>();
        display_engine = depends.on<IDisplayInformation>();
        the_sub_departments = new List<DepartmentItem> {new DepartmentItem()};
        parent_department = new DepartmentItem();

        request.setup(x => x.parent_department).Return(parent_department);

        department_repository.setup(x => x.get_departments_in(parent_department)).Return(the_sub_departments);
      };

      Because b = () =>
        sut.process(request);

      It should_display_the_departments = () =>
        display_engine.model.ShouldEqual(the_sub_departments);

      static IEncapsulateRequestDetails request;
      static IFindDepartments department_repository;
      static IDisplayInformation display_engine;
      static IEnumerable<DepartmentItem> the_sub_departments;
      static DepartmentItem parent_department;
    }
  }
}