using System.Collections.Generic;
using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
    [Subject(typeof(ViewTheMainDepartmentsInTheStore))]
    public class ViewTheMainDepartmentsInTheStoreSpecs
    {
        public abstract class concern : Observes<ISupportAUserFeature,
                                          ViewTheMainDepartmentsInTheStore>
        {
        }

        public class when_run : concern
        {
            Establish c = () =>
            {
                request = fake.an<IEncapsulateRequestDetails>();
                information_in_the_store_repository = depends.on<IFindInformationInTheStore>();
                display_engine = depends.on<IDisplayInformation>();
                the_main_departments = new List<DepartmentItem>();

                information_in_the_store_repository.setup(x => x.get_the_main_departments()).Return(the_main_departments);
            };

            Because b = () =>
              sut.process(request);

            It should_display_the_departments = () =>
            display_engine.received(x => x.display(the_main_departments));

            static IEncapsulateRequestDetails request;
            static IFindInformationInTheStore information_in_the_store_repository;
            static IDisplayInformation display_engine;
            static IEnumerable<DepartmentItem> the_main_departments;
        }
    }
}