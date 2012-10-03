using System.Collections.Generic;
using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  public class ViewTheProductsInADepartmentSpecs
  {
    public abstract class concern : Observes<ISupportAUserFeature,
                                      ViewTheProductsInADepartment>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IEncapsulateRequestDetails>();
        products_repository = depends.on<IFindInformationInTheStore>();
        display_engine = depends.on<IDisplayInformation>();
        the_products = new List<ProductItem>();
        product_request = new ViewProductsInADepartmentRequest();

        products_repository.setup(x => x.get_the_products_using(product_request)).Return(the_products);
        request.setup(x => x.map<ViewProductsInADepartmentRequest >()).Return(product_request);
      };

      Because b = () =>
        sut.process(request);

      It should_display_the_products = () =>
        display_engine.received(x => x.display(the_products));

      static IEncapsulateRequestDetails request;

      static IFindInformationInTheStore products_repository;
      static IDisplayInformation display_engine;
      static IEnumerable<ProductItem> the_products;
      static ViewProductsInADepartmentRequest product_request;
    }
  }
}