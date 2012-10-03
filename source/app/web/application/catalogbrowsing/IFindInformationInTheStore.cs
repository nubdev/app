using System.Collections.Generic;

namespace app.web.application.catalogbrowsing
{
  public interface IFindInformationInTheStore
  {
    IEnumerable<DepartmentItem> get_the_main_departments();
    IEnumerable<DepartmentItem> get_departments_using(ViewSubDepartmentRequest request);
    IEnumerable<ProductItem> get_the_products_using(ViewProductsInADepartmentRequest request);
  }
}