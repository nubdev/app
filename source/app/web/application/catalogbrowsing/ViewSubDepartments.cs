using app.web.core;

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

    public void process(IEncapsulateRequestDetails request)
    {
      var sub_departments = department_repository.get_departments_in(request.parent_department);
      display_engine.display(sub_departments);
    }
  }
}