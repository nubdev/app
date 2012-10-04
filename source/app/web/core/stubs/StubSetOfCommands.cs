using System;
using System.Collections;
using System.Collections.Generic;
using app.web.application.catalogbrowsing;
using app.web.application.catalogbrowsing.stubs;
using app.web.core.aspnet;

namespace app.web.core.stubs
{
  public class StubSetOfCommands : IEnumerable<IProcessOneRequest>
  {
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<IProcessOneRequest> GetEnumerator()
    {
      yield return create_command_for_viewing(new GetTheMainDepartments());
      yield return create_command_for_viewing(new GetTheDepartmentsInADepartment());
      yield return create_command_for_viewing(new GetTheProductsInADepartment());
    }

    IProcessOneRequest create_command_for_viewing<Report>(IFetchAReport<Report> query)
    {
      //      return new RequestCommand(x => true, new ViewAReport<Report>(query));
      throw new NotImplementedException();
    }

    public class GetTheDepartmentsInADepartment : IFetchAReport<IEnumerable<DepartmentItem>>
    {
      public IEnumerable<DepartmentItem> fetch_using(IEncapsulateRequestDetails request)
      {
        return new StubStoreCatalog().get_departments_using(request.map<ViewSubDepartmentRequest>());
      }
    }

    public class GetTheProductsInADepartment : IFetchAReport<IEnumerable<ProductItem>>
    {
      public IEnumerable<ProductItem> fetch_using(IEncapsulateRequestDetails request)
      {
        return new StubStoreCatalog().get_the_products_using(request.map<ViewProductsInADepartmentRequest>());
      }
    }

    public class GetTheMainDepartments : IFetchAReport<IEnumerable<DepartmentItem>>
    {
      public IEnumerable<DepartmentItem> fetch_using(IEncapsulateRequestDetails request)
      {
        return new StubStoreCatalog().get_the_main_departments();
      }
    }
  }
}