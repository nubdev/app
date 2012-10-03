namespace app.specs
{
    using System.Collections.Generic;

    using Machine.Specifications;

    using app.web.application.catalogbrowsing;
    using app.web.core;

    using developwithpassion.specifications.extensions;
    using developwithpassion.specifications.rhinomocks;

    public class ViewSubDepartmentsInTheStoreSpecs
    {
        public abstract class concern : Observes<ISupportAUserFeature,
                                          ViewTheMainDepartmentsInTheStore>
        {
        }

        public class when_run : ViewTheMainDepartmentsInTheStoreSpecs.concern
        {
            Establish c = () =>
            {
                request = fake.an<IEncapsulateRequestDetails>();
                department_repository = depends.on<IFindDepartments>();
                display_engine = depends.on<IDisplayInformation>();
                the_sub_departments = new List<DepartmentItem>();

                department_repository.setup(x => x.get_the_sub_departments()).Return(the_sub_departments);
            };

            Because b = () =>
              sut.process(request);

            It should_display_the_departments = () =>
            display_engine.received(x => x.display(the_sub_departments));

            static IEncapsulateRequestDetails request;
            static IFindDepartments department_repository;
            static IDisplayInformation display_engine;
            static IEnumerable<DepartmentItem> the_sub_departments;
        } 
    }
}