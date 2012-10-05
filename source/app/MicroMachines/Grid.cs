using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.MicroMachines
{
    public class Grid
    {
        private int height;
        private int width;

        public Grid()
        {
            this.height = 5;
            this.width = 5;
        }

        public int get_height()
        {
            return this.height;
        }

        public int get_width()
        {
            return this.width;
        }

    }
}
