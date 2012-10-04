using System;
using System.Collections.Generic;
using app.web.application.catalogbrowsing;

namespace app.web.core.aspnet.stubs
{
  public class StubPathRegistry : IFindPathsToAspxs
  {
    public string get_the_path_to_the_view_for<ReportModel>()
    {
      var paths = new Dictionary<Type, string>
      {
        {typeof(IEnumerable<DepartmentItem>), create_path_to("DepartmentBrowser")},
        {typeof(IEnumerable<ProductItem>), create_path_to("ProductBrowser")}
      };
      return paths[typeof(ReportModel)];
    }

    string create_path_to(string page)
    {
      return string.Format("~/views/{0}.aspx", page);
    }
  }
}