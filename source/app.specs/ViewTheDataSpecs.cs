using System.Collections.Generic;
using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
    [Subject(typeof(ViewTheData))]
    public class ViewTheDataSpecs
    {
        public abstract class concern : Observes<ISupportAUserFeature,
                                          ViewTheData>
        {
        }

        public class when_run : concern
        {
            Establish c = () =>
            {
                request = fake.an<IEncapsulateRequestDetails>();
                information_repository = depends.on<IFindInformation>();
                display_engine = depends.on<IDisplayInformation>();
                the_items = new List<Item>();

                information_repository.setup ( x => x.map<ViewTheData>()).Return(the_items);
            };

            Because b = () =>
              sut.process(request);

            It should_display_the_items = () =>
            display_engine.received(x => x.display(the_items));

            static IEncapsulateRequestDetails request;
            static IFindInformation information_repository;
            static IDisplayInformation display_engine;
            static IEnumerable<Item> the_items;
        }
    }
}