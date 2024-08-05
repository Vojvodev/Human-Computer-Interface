using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Plane_Fight
{
    internal class Plane
    {
        public int PLANE_SPEED = 2;

        private int currentPositionX { get; set; }
        private int currentPositionY { get; set; }
        private char direction { get; set; }      // 'N', 'W', 'S', 'E'

        private MainWindow mainWindow; // Reference to MainWindow -- NOT USED BUT HERE JUST TO SHOW THAT THIS IS HOW IT CAN BE DONE
                                                                    // ANOTHER WAY IS TO INCLUDE THE RECTANGLE INSIDE THE PLANE CLASS (MAKES MORE SENSE)



        public Plane() { }
        public Plane(MainWindow mainWindow, int currentPositionX, int currentPositionY, char direction)
        {
            this.mainWindow = mainWindow;
            this.currentPositionX = currentPositionX;
            this.currentPositionY = currentPositionY;
            this.direction = direction;
        }


        public char getDirection() { return direction; }
        public void setDirection(char direction) { this.direction = direction; }

        public int getCurrentPositionX() {  return currentPositionX; }
        public int getCurrentPositionY() {  return currentPositionY; }



        
        // Adjusts the internal coordinates of the plane
        public void movePlane()
        {
            int futurePositionY = 0;
            int futurePositionX = 0;
            

            switch (direction)
            {
                case 'N':
                    futurePositionY = this.currentPositionY - PLANE_SPEED;
                    if (futurePositionY > 2) { this.currentPositionY = futurePositionY; }
                    else { this.direction = 'S'; }
                    break;

                case 'S':
                    futurePositionY = this.currentPositionY + PLANE_SPEED;
                    if (futurePositionY < 478) { this.currentPositionY = futurePositionY; }
                    else this.direction = 'N';
                    break;

                case 'E':
                    futurePositionX = this.currentPositionX + PLANE_SPEED;
                    if (futurePositionX < 778) { this.currentPositionX = futurePositionX; }
                    else this.direction = 'W';
                    break;

                case 'W':
                    futurePositionX = this.currentPositionX - PLANE_SPEED;
                    if (futurePositionX > 2) { this.currentPositionX = futurePositionX; }
                    else this.direction = 'E';
                    break;

            }
        }


        


    }
}
