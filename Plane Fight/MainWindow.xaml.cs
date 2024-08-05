using System.Collections;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Plane_Fight
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int player1Score = 0;
        private int player2Score = 0;

        private Plane plane1;       // White Su
        private Plane plane2;      // Black Su

        private DispatcherTimer gameTimer;

        private HashSet<Key> pressedKeys = new HashSet<Key>();
        private HashSet<Bullet> shotsFired1 = new HashSet<Bullet>();
        private HashSet<Bullet> shotsFired2 = new HashSet<Bullet>();
        

        public MainWindow() 
        {
            InitializeComponent();

            plane1 = new Plane(this, 50, 50, 'E');
            plane2 = new Plane(this, 750, 450, 'W');


        InitializeGame();
        }



        private void InitializeGame()
        {
            gameTimer = new DispatcherTimer();
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Tick += GameTick;
            gameTimer.Start();

            this.KeyDown += MainWindow_KeyDown;
            this.KeyUp += MainWindow_KeyUp;
        }


        private void GameTick(object sender, EventArgs e)
        {
            try
            {
                plane1.movePlane();
                plane2.movePlane();

                foreach(var bullet in shotsFired1 ) { bullet.moveBullet(); }
                foreach(var bullet in shotsFired2 ) { bullet.moveBullet(); }


                moveRectangles();
                checkCollision();

                // Update plane positions based on pressed keys
                if (pressedKeys.Count > 0)
                {
                    foreach (var key in pressedKeys)
                    {
                        switch (key)
                        {
                            case Key.W:
                                plane1.setDirection('N');
                                break;
                            case Key.A:
                                plane1.setDirection('W');
                                break;
                            case Key.S:
                                plane1.setDirection('S');
                                break;
                            case Key.D:
                                plane1.setDirection('E');
                                break;

                            case Key.Up:
                                plane2.setDirection('N');
                                break;
                            case Key.Left:
                                plane2.setDirection('W');
                                break;
                            case Key.Down:
                                plane2.setDirection('S');
                                break;
                            case Key.Right:
                                plane2.setDirection('E');
                                break;
                        }
                    }
                }


                // Rotate planes in the direction they are going
                rotatePlanes();

            }
            catch(Exception ex) { Debug.WriteLine($"Exception in GameTick: {ex.Message}"); }
            
        }

  
        private void checkCollision()
        {
            // Create these in order to use IntersectsWith() method
            Rect p1 = new Rect(Canvas.GetLeft(Player1Rect), Canvas.GetTop(Player1Rect), Player1Rect.Width, Player1Rect.Height);
            Rect p2 = new Rect(Canvas.GetLeft(Player2Rect), Canvas.GetTop(Player2Rect), Player2Rect.Width, Player2Rect.Height);


            foreach (var bullet in shotsFired1)
            {
                // Same goes for every bullet
                Rect b = new Rect(Canvas.GetLeft(bullet.getBulletRect()), Canvas.GetTop(bullet.getBulletRect()), bullet.getBulletRect().Width, bullet.getBulletRect().Height);

                // P2 is hit
                if (p2.IntersectsWith(b))
                {
                    player1Score++;
                    Player1Score.Text = $"White: {player1Score}";

                    // Delete all the bullets
                    foreach (var bullet2 in shotsFired1) { GameCanvas.Children.Remove(bullet2.getBulletRect()); }
                    foreach (var bullet2 in shotsFired2) { GameCanvas.Children.Remove(bullet2.getBulletRect()); }

                    shotsFired1 = new HashSet<Bullet>();
                    shotsFired2 = new HashSet<Bullet>();
                }

                // Bullet is off the screen
                if (bullet.getCurrentPositionX() >= 798 || bullet.getCurrentPositionX() <= 2
                     || bullet.getCurrentPositionY() >= 498 || bullet.getCurrentPositionY() <= 2)
                {
                    GameCanvas.Children.Remove(bullet.getBulletRect());
                    shotsFired1.Remove(bullet);
                }

            }


            foreach (var bullet in shotsFired2)
            {
                // Same goes for every bullet
                Rect b = new Rect(Canvas.GetLeft(bullet.getBulletRect()), Canvas.GetTop(bullet.getBulletRect()), bullet.getBulletRect().Width, bullet.getBulletRect().Height);

                // P1 is hit
                if (p1.IntersectsWith(b))
                {
                    player2Score++;
                    Player2Score.Text = $"Black: {player2Score}";

                    // Delete all the bullets
                    foreach (var bullet2 in shotsFired1) { GameCanvas.Children.Remove(bullet2.getBulletRect()); }
                    foreach (var bullet2 in shotsFired2) { GameCanvas.Children.Remove(bullet2.getBulletRect()); }

                    shotsFired1 = new HashSet<Bullet>();
                    shotsFired2 = new HashSet<Bullet>();
                }

                // Bullet is off the screen
                if (bullet.getCurrentPositionX() >= 798 || bullet.getCurrentPositionX() <= 2
                     || bullet.getCurrentPositionY() >= 498 || bullet.getCurrentPositionY() <= 2)
                {
                    GameCanvas.Children.Remove(bullet.getBulletRect());
                    shotsFired2.Remove(bullet);
                }
            }

            checkWinner();
        }
        


        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            pressedKeys.Add(e.Key);

            
            if (e.Key == Key.Space)
            {
                if (shotsFired1.Count < 5)
                {
                    shotsFired1.Add(ShootBullet(plane1));
                }
            }
            else if (e.Key == Key.Enter)
            {
                if (shotsFired2.Count < 5)
                {
                    shotsFired2.Add(ShootBullet(plane2));
                }
            }
            else if(e.Key == Key.P) {
                if(plane2.PLANE_SPEED == 2) plane2.PLANE_SPEED = 4;
                else if (plane2.PLANE_SPEED == 4) plane2.PLANE_SPEED = 2;
            }
            else if( e.Key == Key.Q) {
                if (plane1.PLANE_SPEED == 2) plane1.PLANE_SPEED = 4;
                else if (plane1.PLANE_SPEED == 4) plane1.PLANE_SPEED = 2;
            }
        }

        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            pressedKeys.Remove(e.Key);
        }
     

        private Bullet ShootBullet(Plane plane)
        {
            Bullet bullet = new Bullet(plane.getCurrentPositionX(), plane.getCurrentPositionY(), plane.getDirection());
            Rectangle bulletRect = bullet.getBulletRect();
            GameCanvas.Children.Add(bulletRect);

            return bullet;
        }


        private void checkWinner()
        {
            if (player1Score >= 10)
            {
                gameTimer.Stop();
                MessageBox.Show("White SU Wins!", "Round Over");

                restartGame();
            }
            else if (player2Score >= 10)
            {
                gameTimer.Stop();
                MessageBox.Show("Black SU Wins!", "Round Over");

                restartGame();
            }

        }


        private void restartGame()
        {
            player1Score = 0;
            player2Score = 0;

            Player1Score.Text = $"White: {player1Score}";
            Player2Score.Text = $"Black: {player2Score}";


            plane1 = new Plane(this, 50, 50, 'E'); // White Su
            plane2 = new Plane(this, 750, 450, 'W'); // Black Su

            // Move the rectangles to their initial positions
            //moveRectangles();

            gameTimer.Start();
        }



        // Moves the rectangles we see on screen
        private void moveRectangles()
        {
            Canvas.SetLeft(Player1Rect, plane1.getCurrentPositionX());
            Canvas.SetTop(Player1Rect, plane1.getCurrentPositionY());

            Canvas.SetLeft(Player2Rect, plane2.getCurrentPositionX());
            Canvas.SetTop(Player2Rect, plane2.getCurrentPositionY());


            foreach(var bullet in shotsFired1)
            {
                Canvas.SetLeft(bullet.getBulletRect(), bullet.getCurrentPositionX());
                Canvas.SetTop(bullet.getBulletRect(), bullet.getCurrentPositionY());
            }

            foreach (var bullet in shotsFired2)
            {
                Canvas.SetLeft(bullet.getBulletRect(), bullet.getCurrentPositionX());
                Canvas.SetTop(bullet.getBulletRect(), bullet.getCurrentPositionY());
            }

        }



        private void rotatePlanes()
        {
            if (plane1.getDirection() == 'N') RotateRectangle(Player1Rect, -90);
            if (plane1.getDirection() == 'S') RotateRectangle(Player1Rect, 90);
            if (plane1.getDirection() == 'W') RotateRectangle(Player1Rect, 180);
            if (plane1.getDirection() == 'E') Player1Rect.RenderTransform = null;

            if (plane2.getDirection() == 'N') RotateRectangle(Player2Rect, 90);
            if (plane2.getDirection() == 'S') RotateRectangle(Player2Rect, -90);
            if (plane2.getDirection() == 'E') RotateRectangle(Player2Rect, 180);
            if (plane2.getDirection() == 'W') Player2Rect.RenderTransform = null;
        }


        private void RotateRectangle(Rectangle rect, double angle)
        {
            RotateTransform rotateTransform = new RotateTransform();
            rotateTransform.Angle = angle;
            rect.RenderTransform = rotateTransform;

            // Optionally, set the center of rotation
            rect.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5); // Center of the rectangle
        }

    }
}