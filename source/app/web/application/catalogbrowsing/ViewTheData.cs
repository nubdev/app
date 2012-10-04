using app.web.application.catalogbrowsing.stubs;
using app.web.core;
using app.web.core.aspnet;

namespace app.web.application.catalogbrowsing
{
    public class ViewTheData : ISupportAUserFeature
    {
        IFindInformationInTheStore information_repository;
        IDisplayInformation display_engine;

        public ViewTheData(IFindInformationInTheStore information_repository,
                                                IDisplayInformation display_engine)
        {
            this.information_repository = information_repository;
            this.display_engine = display_engine;
        }

        public ViewTheData()
            : this(new StubStoreCatalog(),
                   new WebFormsDisplayEngine())
        {
        }

        public void process(IEncapsulateRequestDetails request)
        {
            display_engine.display(information_repository.get_the_main_departments());
        }
    }
}