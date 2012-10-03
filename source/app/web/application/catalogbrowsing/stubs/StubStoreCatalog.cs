using System.Collections.Generic;
using System.Linq;

namespace app.web.application.catalogbrowsing.stubs
{
  public class StubStoreCatalog : IFindInformationInTheStore
  {
    public IEnumerable<DepartmentItem> get_the_main_departments()
    {
      return Enumerable.Range(1, 100).Select(x => new DepartmentItem {name = x.ToString("Department 0")});
    }

    public IEnumerable<ProductItem> get_the_products_using(ViewProductsInADepartmentRequest request)
    {
      return Enumerable.Range(1, 100).Select(x => new ProductItem{name = x.ToString("Product 0")});
    }

    public IEnumerable<DepartmentItem> get_departments_using(ViewSubDepartmentRequest request)
    {
      return Enumerable.Range(1, 50).Select(x => new DepartmentItem {name = x.ToString("Sub Department 0")});
    }
  }
}