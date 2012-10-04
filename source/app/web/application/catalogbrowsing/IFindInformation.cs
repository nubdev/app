using System.Collections.Generic;

namespace app.web.application.catalogbrowsing
{
    public interface IFindInformation
    {
        IEnumerable<DepartmentItem> get_the_items(ViewItemRequest request);

        object map<T1>();
    }
}