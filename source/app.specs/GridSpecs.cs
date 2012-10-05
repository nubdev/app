
using Machine.Specifications;
using app.MicroMachines;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof(Grid))]
    public class GridSpecs
    {
        public abstract class concern : Observes<Grid>
        {
        }

        public class when_asking_how_tall_a_grid_is : concern
        {
            private Establish c = () =>
            {
                the_grid = new Grid();
                intended_grid_height = 5;
            };
            private It should_retrieve_the_correct_grid_height = () =>
                the_grid.get_height().ShouldEqual(intended_grid_height);

            private static Grid the_grid;
            private static int intended_grid_height;
        }
        public class when_asking_how_wide_a_grid_is : concern
        {
            private Establish c = () =>
            {
                the_grid = new Grid();
                intended_grid_width = 5;
            };
            private It should_retrieve_the_correct_grid_height = () =>
                the_grid.get_width().ShouldEqual(intended_grid_width);

            private static Grid the_grid;
            private static int intended_grid_width;
        }
        
    }

}
