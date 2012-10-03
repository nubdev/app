namespace app.web.application.catalogbrowsing
{
    using app.web.core;

    public class ViewTheProductsInTheStore : ISupportAUserFeature
    {
        #region Implementation of ISupportAUserFeature

        IFindProducts products_repository;

        IDisplayInformation display_engine;

        public ViewTheProductsInTheStore(IFindProducts productsRepository, IDisplayInformation displayEngine)
        {
            this.products_repository = productsRepository;
            this.display_engine = displayEngine;
        }

        public void process(IEncapsulateRequestDetails request)
        {
            display_engine.display(products_repository.get_the_products());
        }

        #endregion
    }
}