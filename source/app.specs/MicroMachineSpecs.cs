
using Machine.Specifications;
using app.MicroMachines;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof(MicroMachine))]
    public class MicroMachineSpecs
    {
        public abstract class concern : Observes<MicroMachine>
        {
        }


        public class when_asking_a_micro_machine_where_its_at : concern
        {
            private Establish c = () =>
            {
              car = new MicroMachine();
              intended_result = "N0,0";
        };

            private Because b = () =>
              result = car.return_heading_and_location();

            private It should_retrieve_the_correct_heading_and_grid_location = () =>
              result.ShouldEqual(intended_result);

            private static MicroMachine car;
            private static string result;
            private static string intended_result;
        }

        public class when_moving_vertically : concern
        {
            private Establish c = () =>
            {
                car = new MicroMachine();
                number_of_steps = 2;
                intended_result = 2;
            };

            private Because b = () =>
                car.move_vertical(number_of_steps);

            private It should_have_the_correct_vertical_position = () =>
                car.get_vertical_point().ShouldEqual(intended_result);

            private static MicroMachine car;
            private static int number_of_steps;
            private static int intended_result;
        }

        public class when_moving_horizontally : concern
        {
            private Establish c = () =>
            {
                car = new MicroMachine();
                number_of_steps = 2;
                intended_result = 2;
            };

            private Because b = () =>
                                car.move_horizontal(number_of_steps);

            private It should_have_the_correct_horizontal_position = () =>
                car.get_horizontal_point().ShouldEqual(intended_result);

            private static MicroMachine car;
            private static int number_of_steps;
            private static int intended_result;
        }

        public class when_turning_a_MicroMachine: concern
        {
            private Establish c = () =>
            {
              car = new MicroMachine();
              input = "R";
              intended_heading = "E";
            };

            private Because b = () =>
              car.turn(input);

            private It should_have_the_correct_heading = () =>
              car.get_heading().ShouldEqual(intended_heading);

            private static MicroMachine car;
            private static string intended_heading;
            private static string input;
        }

        public class when_passing_a_full_movement_input : concern
        {
           private Establish c = () =>
            {
              car = new MicroMachine();
              input = "R3L2L1";
              intended_location = "W3,3";
            };

            private Because b = () =>
              car.move(input);

            private It should_have_the_correct_heading = () =>
              car.return_heading_and_location().ShouldEqual(intended_location);

            private static MicroMachine car;
            private static string intended_location;
            private static string input; 
        }
    }

}
