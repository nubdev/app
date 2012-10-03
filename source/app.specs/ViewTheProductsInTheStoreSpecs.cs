namespace app.specs
{
    using System.Collections.Generic;

    using Machine.Specifications;

    using app.web.application.catalogbrowsing;
    using app.web.core;

    using developwithpassion.specifications.extensions;
    using developwithpassion.specifications.rhinomocks;

    public class ViewTheProductsInTheStoreSpecs
    {
        public abstract class concern : Observes<ISupportAUserFeature,
                                  ViewTheProductsInTheStore>
        {
        }

        public class when_run : concern
        {
            Establish c = () =>
            {
                request = fake.an<IEncapsulateRequestDetails>();
                products_repository = depends.on<IFindProducts>();
                display_engine = depends.on<IDisplayInformation>();
                the_products = new List<ProductItem>();

                products_repository.setup(x => x.get_the_products()).Return(the_products);
            };

            Because b = () =>
              sut.process(request);

            It should_display_the_products = () =>
            display_engine.received(x => x.display(the_products));

            static IEncapsulateRequestDetails request;

            static IFindProducts products_repository;
            static IDisplayInformation display_engine;
            static IEnumerable<ProductItem> the_products;
        }

    }
}