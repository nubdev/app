using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.MicroMachines
{
    public class MicroMachine
    {
        private int horizontal_point;
        private int vertical_point;
        private String heading;

        public MicroMachine()
        {
            this.horizontal_point = 0;
            this.vertical_point = 0;
            this.heading = "N";
        }

        public int get_horizontal_point()
        {
            return this.horizontal_point;
        }

        public int get_vertical_point()
        {
            return this.vertical_point;
        }

        public String get_heading()
        {
            return this.heading;
        }

        public void set_heading(String new_heading)
        {
            this.heading = new_heading;
        }

        public string return_heading_and_location()
        {
            return this.get_heading() + this.get_horizontal_point() + "," + get_vertical_point();
        }

        public void move(string input)
        {
            throw new NotImplementedException();
        }

        public void turn(string direction_to_turn)
        {

            if (this.get_heading().Equals("N"))
            {
                if (direction_to_turn.Equals("R"))
                {
                    this.set_heading("E");
                }
                else
                {
                    this.set_heading("W");
                }
            }
            if (this.get_heading().Equals("E"))
            {
                if (direction_to_turn.Equals("R"))
                {
                    this.set_heading("S");
                }
                else
                {
                    this.set_heading("N");
                }
            }
            if (this.get_heading().Equals("S"))
            {
                if (direction_to_turn.Equals("R"))
                {
                    this.set_heading("W");
                }
                else
                {
                    this.set_heading("E");
                }
                if (this.get_heading().Equals("W"))
                {
                    if (direction_to_turn.Equals("R"))
                    {
                        this.set_heading("N");
                    }
                    else
                    {
                        this.set_heading("S");
                    }
                }
            }
        }

        public void move_horizontal(int number_of_steps)
        {
            throw new NotImplementedException();
        }

        public void move_vertical(int number_of_steps)
        {
            throw new NotImplementedException();
        }
    }
}
