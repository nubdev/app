namespace app.web.application.catalogbrowsing
{
    using System.Collections.Generic;

    public interface IFindProducts
    {
        IEnumerable<ProductItem> get_the_products();
    }
}