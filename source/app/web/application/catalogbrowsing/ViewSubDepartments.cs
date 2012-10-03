using app.web.application.catalogbrowsing.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application.catalogbrowsing
{
  public class ViewSubDepartments : ISupportAUserFeature
  {
    IFindDepartments department_repository;
    IDisplayInformation display_engine;

    public ViewSubDepartments(IFindDepartments department_repository, IDisplayInformation display_engine)
    {
      this.department_repository = department_repository;
      this.display_engine = display_engine;
    }

    public ViewSubDepartments():this(new StubDepartmentRepository(),new StubDisplayEngine())
    {
    }

    public void process(IEncapsulateRequestDetails request)
    {
      display_engine.display(department_repository.get_departments_using(request.map<ViewSubDepartmentRequest>()));
    }
  }
}