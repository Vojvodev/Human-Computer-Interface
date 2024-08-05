using System.Windows.Media;
using System.Windows.Shapes;

namespace Plane_Fight
{
    internal class Bullet
    {
        public static int BULLET_SPEED = 4;

        private int currentPositionX { get; set; }
        private int currentPositionY { get; set; }
        private char direction { get; set; }      // 'N', 'W', 'S', 'E'
        
        private System.Windows.Shapes.Rectangle bulletRect;



        public Bullet() { }
        public Bullet(int currentPositionX, int currentPositionY, char direction)
        {
            this.currentPositionX = currentPositionX;
            this.currentPositionY = currentPositionY;
            this.direction = direction;

            bulletRect = new System.Windows.Shapes.Rectangle
            {
                Width = 10,
                Height = 5,
                Fill = Brushes.Black
            };

        }


        public char getDirection() { return direction; }

        public int getCurrentPositionX() { return currentPositionX; }
        public int getCurrentPositionY() { return currentPositionY; }
        public Rectangle getBulletRect() { return bulletRect;}


        // Adjusts the internal coordinates of the bullet
        public void moveBullet()
        {
            int futurePositionY = 0;
            int futurePositionX = 0;


            switch (direction)
            {
                case 'N':
                    futurePositionY = this.currentPositionY - BULLET_SPEED;
                    this.currentPositionY = futurePositionY;

                    this.bulletRect.Width = 5;
                    this.bulletRect.Height = 10;

                    /*  // For bouncing bullets
                    if (futurePositionY > 2) { this.currentPositionY = futurePositionY; }
                    else this.direction = 'S';
                    */
                    break;

                case 'S':
                    futurePositionY = this.currentPositionY + BULLET_SPEED;
                    this.currentPositionY = futurePositionY;

                    this.bulletRect.Width = 5;
                    this.bulletRect.Height = 10;

                    /*  // For bouncing bullets
                    if (futurePositionY < 478) { this.currentPositionY = futurePositionY; }
                    else this.direction = 'N';
                    */
                    break;

                case 'E':
                    futurePositionX = this.currentPositionX + BULLET_SPEED;
                    this.currentPositionX = futurePositionX;

                    /*  // For bouncing bullets
                    if (futurePositionX < 778) { this.currentPositionX = futurePositionX; }
                    else this.direction = 'W';
                    */
                    break;

                case 'W':
                    futurePositionX = this.currentPositionX - BULLET_SPEED;
                    this.currentPositionX = futurePositionX;

                    /*  // For bouncing bullets
                    if (futurePositionX > 2) { this.currentPositionX = futurePositionX; }
                    else this.direction = 'E';
                    */
                    break;

            }
        }

    }
}
