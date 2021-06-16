using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Clear();
			Console.CursorVisible = false;
			Game game = new Game(4, 3, 2);
			game.StartGame();
		}
	}

	public class Game
	{
		private bool gameRunning;
		private Player player;
		private int maxNormalEnemies;
		private int maxMovingEnemies;
		private int maxShootingEnemies;
		List<NormalEnemy> normalEnemies;
		List<MovingEnemy> movingEnemies;
		List<ShootingEnemy> shootingEnemies;

		public Game(int maxNormalEnemies, int maxMovingEnemies, int maxShootingEnemies)
		{
			this.gameRunning = true;
			this.player = new Player();
			this.maxNormalEnemies = maxNormalEnemies;
			this.maxMovingEnemies = maxMovingEnemies;
			this.maxShootingEnemies = maxShootingEnemies;
			AddAllEnemies();
		}

		private void AddAllEnemies()
        {
			for (int i = 0; i < MaxNormalEnemies; i++)
            {
				NormalEnemy normalEnemy = new NormalEnemy();
				NormalEnemies.Add(normalEnemy); //something wrong here
			}

			for (int i = 0; i < MaxMovingEnemies; i++)
			{
				MovingEnemies.Add(new MovingEnemy());
			}

			for (int i = 0; i < MaxShootingEnemies; i++)
			{
				ShootingEnemies.Add(new ShootingEnemy());
			}

		}

		public void StartGame()
		{
			while (gameRunning == true)
			{
				PlayerMovement();
				UpdateAll();
				CheckCollision();
			}
		}

		private void PlayerMovement()
		{
			if (Console.KeyAvailable)
			{
				ConsoleKey key = Console.ReadKey(true).Key;
				if (key.Equals(ConsoleKey.A))
				{
					player.MoveLeft();
				}
				if (key.Equals(ConsoleKey.D))
				{
					player.MoveRight();
				}
			}
		}

		private void UpdateAll()
		{
			WriteLives();
			player.WriteSymbol();
			System.Threading.Thread.Sleep(200);

			for (int i = 0; i < NormalEnemies.Count; i++)
			{
				NormalEnemies[i].Move();
			}

			for (int i = 0; i < MovingEnemies.Count; i++)
			{
				MovingEnemies[i].Move();
			}

			for (int i = 0; i < ShootingEnemies.Count; i++)
			{
				ShootingEnemies[i].Move();
				foreach (Bullet bullet in ShootingEnemies[i].Bullets)
                {
					bullet.Move();
                }
			}
		}

		private void WriteLives()
		{
			Console.SetCursorPosition(Console.WindowLeft, Console.WindowTop);
			Console.Write(player.Lives);
		}

		private void CheckCollision()
		{
			//unfinished
		}

		public int MaxNormalEnemies
        {
            get { return maxNormalEnemies; }
            set { maxNormalEnemies = value; }
        }
		public int MaxMovingEnemies
		{
			get { return maxMovingEnemies; }
			set { maxMovingEnemies = value; }
		}
		public int MaxShootingEnemies
		{
			get { return maxShootingEnemies; }
			set { maxShootingEnemies = value; }
		}

		public List<NormalEnemy> NormalEnemies
        {
			get { return normalEnemies; }
			set { normalEnemies = value; }
        }

		public List<MovingEnemy> MovingEnemies
		{
			get { return movingEnemies; }
			set { movingEnemies = value; }
		}

		public List<ShootingEnemy> ShootingEnemies
		{
			get { return shootingEnemies; }
			set { shootingEnemies = value; }
		}
	}

	public abstract class Actor
	{
		private string symbol;
		private int xPos;
		private int yPos;
		private int xSpeedLeft;
		private int xSpeedRight;
		private int ySpeedUp;
		private int ySpeedDown;

		public Actor()
		{

		}

		public void DeleteSymbol()
		{
			Console.SetCursorPosition(XPos, YPos);
			Console.Write(" ");
		}

		public void WriteSymbol()
		{
			Console.SetCursorPosition(XPos, YPos);
			Console.Write(Symbol);
		}

		public string Symbol
		{
			get { return symbol; }
			set { symbol = value; }
		}

		public int XPos
		{
			get { return xPos; }
			set
			{
				if (value >= 0 && value <= Console.WindowWidth)
				{
					xPos = value;
				}
			}
		}

		public int YPos
		{
			get { return yPos; }
			set
			{
				if (value >= 0 && value <= Console.WindowHeight)
				{
					yPos = value;
				}
			}
		}

		public int XSpeedLeft
		{
			get { return xSpeedLeft; }
			set { xSpeedLeft = value; }
		}

		public int XSpeedRight
		{
			get { return xSpeedRight; }
			set { xSpeedRight = value; }
		}

		public int YSpeedUp
		{
			get { return ySpeedUp; }
			set { ySpeedUp = value; }
		}

		public int YSpeedDown
		{
			get { return ySpeedDown; }
			set { ySpeedDown = value; }
		}
	}

	public class Player : Actor
	{
		private int lives;

		public Player() : base()
		{
			this.Symbol = "P";
			this.XPos = Console.WindowWidth / 2;
			this.YPos = Console.WindowHeight;
			this.XSpeedLeft = 1;
			this.XSpeedRight = 1;
			this.YSpeedUp = 0;
			this.YSpeedDown = 0;
			this.Lives = 3;
		}

		public void MoveLeft()
		{
			DeleteSymbol();
			if (XPos - XSpeedLeft >= 0)
            {
				XPos -= XSpeedLeft;
				WriteSymbol();
			}
		}

		public void MoveRight()
		{
			DeleteSymbol();
			if (XPos + XSpeedRight <= Console.WindowWidth)
			{
				XPos += XSpeedRight;
				WriteSymbol();
			}
		}

		public int Lives
		{
			get { return lives; }
			set { lives = value; }
		}
	}

	public abstract class Evil : Actor
	{
		private Random randInt = new Random();

		public Evil() : base()
		{
			this.YSpeedUp = 0;
		}

		public abstract void Move();

		public Random Randint
		{
			get { return randInt; }
			set { randInt = value; }
		}
	}

	public class NormalEnemy : Evil
	{
		public NormalEnemy() : base()
		{
			this.Symbol = "E";
			this.XPos = this.Randint.Next(0, Console.WindowWidth);
			this.YPos = 0;
			this.XSpeedLeft = 0;
			this.XSpeedRight = 0;
			this.YSpeedDown = 1;
		}

		public override void Move()
		{
			DeleteSymbol();
			if (YPos <= Console.WindowHeight)
			{
				YPos += YSpeedDown;
				WriteSymbol();
			}
		}
	}

	public class MovingEnemy : Evil
	{
		public MovingEnemy() : base()
		{
			this.Symbol = "M";
			this.XPos = this.Randint.Next(0, Console.WindowWidth);
			this.YPos = 0;
			this.XSpeedLeft = 1;
			this.XSpeedRight = 1;
			this.YSpeedDown = 1;
		}

		public override void Move()
		{
			DeleteSymbol();
			if (YPos <= Console.WindowHeight)
			{
				YPos += YSpeedDown;
				int randomInt = Randint.Next(0, 3);
				if (randomInt == 1)
				{
					if (XPos - XSpeedLeft >= 0)
                    {
						XPos -= XSpeedLeft;
						WriteSymbol();
					}
				}
				else
				{
					if (XPos + XSpeedRight <= Console.WindowWidth)
					{
						XPos += XSpeedRight;
						WriteSymbol();
					}
				}
			}
		}
	}

	public class ShootingEnemy : Evil
	{
		private int maxDelay;
		private int delayCount;
		private List<Bullet> bullets;

		public ShootingEnemy() : base()
		{
			this.Symbol = "S";
			this.XPos = this.Randint.Next(0, Console.WindowWidth);
			this.YPos = 0;
			this.XSpeedLeft = 0;
			this.XSpeedRight = 0;
			this.YSpeedDown = 1;
			this.maxDelay = 3;
			this.delayCount = 0;
			this.bullets = new List<Bullet>();
		}

		public override void Move()
		{
			DeleteSymbol();
			if (YPos <= Console.WindowHeight)
			{
				YPos += YSpeedDown;
				WriteSymbol();
				Shoot();
			}
		}

		private void Shoot()
		{
			if (DelayCount < MaxDelay)
            {
				Bullet bullet = new Bullet(XPos, YPos + 1);
				WriteBulletStart(bullet);
				Bullets.Add(bullet);
				DelayCount++;
			}
            else
            {
				DelayCount = 0;
            }
		}

		private void WriteBulletStart(Bullet bullet)
        {
			Console.SetCursorPosition(XPos, YPos + 1);
			Console.Write(bullet.Symbol);
		}

		public int MaxDelay
        {
			get { return maxDelay; }
			set { maxDelay = value; }
        }

		public int DelayCount
		{
			get { return delayCount; }
			set { delayCount = value; }
		}

		public List<Bullet> Bullets
		{
			get { return bullets; }
			set { bullets = value; }
		}
	}

	public class Bullet : Evil
	{
		public Bullet(int xStart, int yStart) : base()
		{
			this.Symbol = "B";
			this.XPos = xStart;
			this.YPos = yStart;
			this.XSpeedLeft = 0;
			this.XSpeedRight = 0;
			this.YSpeedDown = 2;
		}

		public override void Move()
		{
			DeleteSymbol();
			if (YPos <= Console.WindowHeight)
			{
				YPos += YSpeedDown;
				WriteSymbol();
			}
		}
	}
}
