using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.bowling
{
    public class bowling
    {
        private int score;
        private int[] rolls;

        public bowling()
        {
            score = 0;
            rolls = new int[21];
        }

        public int get_score()
        {
            return this.score;
        }

        public void set_score(int updated_score)
        {
            this.score = updated_score;
        }

        public int[] get_rolls()
        {
            return this.rolls;
        }
    }

    internal class scorer
    {
        public int add_throw_to_score(bowling player, int pinsKnockedDown)
        {
            int current_score;
            current_score = player.get_score();
            return current_score + pinsKnockedDown;
        }

        public void score_frame(bowling player, int pins_in_frame_1, int pins_in_frame_2)
        {
            this.add_throw_to_score(player, pins_in_frame_1);
            this.add_throw_to_score(player, pins_in_frame_2);
        }

    }


    [Subject(typeof(bowling))]
    public class BowlingSpecs
    {
        public abstract class bowling_concern : Observes<bowling>
        {
        }

        public class when_throwing_a_ball : bowling_concern
        {
            Establish c = () =>
            {
              bowler_obj = new bowling();
              scorer_obj = new scorer();
            };

            private Because b = () =>
              score = scorer_obj.add_throw_to_score(bowler_obj, 7);

            It should_return_the_number_of_pins_knocked_down  = () =>
                score.ShouldEqual(7);

            static bowling bowler_obj;
            static scorer scorer_obj;
            static int score;

        }
        public class when_scoring_a_frame : bowling_concern
        {
            Establish c = () =>
            {
              bowler_obj = new bowling();
              scorer_obj = new scorer();
            };

            private Because b = () =>
              scorer_obj.score_frame(bowler_obj, 1, 2);

            private It should_return_the_score_of_the_frame = () =>
              bowler_obj.get_score().ShouldEqual(3);

            static bowling bowler_obj;
            static scorer scorer_obj;
            static int score;
        }
        public class when_scoring_a_game : bowling_concern
        {
            Establish c = () =>
            {
                bowler_obj = new bowling();
            };

            private Because b = () =>
              bowler_obj.set_score(20);


            private It should_return_the_score_of_a_game = () =>
              bowler_obj.get_score().ShouldEqual(20);

            static bowling bowler_obj;
        }

    }
}


