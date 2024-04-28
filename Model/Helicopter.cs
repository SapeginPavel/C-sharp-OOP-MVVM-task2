using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Task_2_2.Model
{
    internal class Helicopter : AirCraft
    {
        public Helicopter(int maxHeightAboveGround, int stepForHeight) : base(maxHeightAboveGround, stepForHeight)
        {
        }

        public override bool Down()
        {
            if (CurrentHeightAboveGround > 0)
            {
                if (CurrentHeightAboveGround - stepForHeight < 0)
                {
                    CurrentHeightAboveGround = 0;
                }
                else
                {
                    CurrentHeightAboveGround -= stepForHeight;
                }
            }
            return true;
        }

        public override bool Up()
        {
            if (CurrentHeightAboveGround < maxHeightAboveGround)
            {
                if (CurrentHeightAboveGround + stepForHeight > maxHeightAboveGround)
                {
                    CurrentHeightAboveGround = maxHeightAboveGround;
                } else
                {
                    CurrentHeightAboveGround += stepForHeight;
                }
            }
            return true;
        }
    }
}
