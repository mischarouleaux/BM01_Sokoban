﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SokobanSolver
{
	public class SokobanSolver
	{
		private class Board
		{
			public string Cur { get; internal set; }
			public string Sol { get; internal set; }
			public int X { get; internal set; }
			public int Y { get; internal set; }

			public Board(string cur, string sol, int x, int y)
			{
				Cur = cur;
				Sol = sol;
				X = x;
				Y = y;
			}
		}

		private string destBoard, currBoard;
		private int playerX, playerY, nCols;

        /// <summary>
        /// Main program with different levels to play.
        /// </summary>
		public static void Main(string[] a)
		{
			string level2 = "#######," +
						   "#     #," +
						   "#     #," +
						   "#. #  #," +
						   "#. $$ #," +
						   "#.$$  #," +
						   "#.#  @#," +
						   "#######";

			string level3 = "########," +
						  "#  #  ##," +
						  "# $@$  #," +
						  "#. #  .#," +
						  "########";

			string level4 = "####," +
							"#@.#," +
							"#$ #," +
							"#  #," +
							"# $#," +
							"#. #," +
							"#  #," +
							"####";

			string level5 = "########," +
							"####   #," +
							"#@$  # #," +
							"#. $  .#," +
							"########";

			string level = "########," +
						   "#@ #   #," +
						   "#  #.  #," +
						   "#  # $ #," +
						   "## $ ###," +
						   "##   ###," +
						   "##.  ###," +
						   "########";



			System.Console.WriteLine("Level:\n");
			foreach (string line in level.Split(','))
			{
				System.Console.WriteLine(line);
			}
			System.Console.WriteLine("\nSolution:\n");
			var sol = new SokobanSolver(level.Split(',')).Solve();
			System.Console.WriteLine(sol);
			System.Console.Write(sol.Count());
		}

        /// <summary>
        /// The function will find a solution when possible.
        /// </summary>
        /// <returns>The solution</returns>
		private string Solve()
		{
			char[,] dirLabels = { { 'u', 'U' }, { 'r', 'R' }, { 'd', 'D' }, { 'l', 'L' } };
			int[,] dirs = { { 0, -1 }, { 1, 0 }, { 0, 1 }, { -1, 0 } };
			ISet<string> history = new HashSet<string>();
			LinkedList<Board> open = new LinkedList<Board>();

			history.Add(currBoard);
			open.AddLast(new Board(currBoard, string.Empty, playerX, playerY));

			while (!open.Count.Equals(0))
			{
				Board item = open.First();
				open.RemoveFirst();
				string cur = item.Cur;
				string sol = item.Sol;
				int x = item.X;
				int y = item.Y;

				for (int i = 0; i < dirs.GetLength(0); i++)
				{
					string trial = cur;
					int dx = dirs[i, 0];
					int dy = dirs[i, 1];

					// are we standing next to a box ?
					if (trial[(y + dy) * nCols + x + dx] == '$')
					{
						// can we push it ?
						if ((trial = Push(x, y, dx, dy, trial)) != null)
						{
							// or did we already try this one ?
							if (!history.Contains(trial))
							{

								string newSol = sol + dirLabels[i, 1];

								if (IsSolved(trial))
									return newSol;

								open.AddLast(new Board(trial, newSol, x + dx, y + dy));
								history.Add(trial);
							}
						}
						// otherwise try changing position
					}
					else if ((trial = Move(x, y, dx, dy, trial)) != null)
					{
						if (!history.Contains(trial))
						{
							string newSol = sol + dirLabels[i, 0];
							open.AddLast(new Board(trial, newSol, x + dx, y + dy));
							history.Add(trial);
						}
					}
				}
			}
			return "No solution";
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SokobanSolver.SokobanSolver"/> class.
        /// </summary>
        /// <param name="board">Board.</param>
		SokobanSolver(string[] board)
		{
			nCols = board[0].Length;
			StringBuilder destBuf = new StringBuilder();
			StringBuilder currBuf = new StringBuilder();

			for (int r = 0; r < board.Length; r++)
			{
				for (int c = 0; c < nCols; c++)
				{

					char ch = board[r][c];

					destBuf.Append(ch != '$' && ch != '@' ? ch : ' ');
					currBuf.Append(ch != '.' ? ch : ' ');

					if (ch == '@')
					{
						this.playerX = c;
						this.playerY = r;
					}
				}
			}
			destBoard = destBuf.ToString();
			currBoard = currBuf.ToString();
		}

        /// <summary>
        /// Move the specified x, y, dx, dy and trialBoard.
        /// </summary>
        /// <returns>The move.</returns>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="dx">Dx.</param>
        /// <param name="dy">Dy.</param>
        /// <param name="trialBoard">Trial board.</param>
		private string Move(int x, int y, int dx, int dy, string trialBoard)
		{

			int newPlayerPos = (y + dy) * nCols + x + dx;

			if (trialBoard[newPlayerPos] != ' ')
				return null;

			char[] trial = trialBoard.ToCharArray();
			trial[y * nCols + x] = ' ';
			trial[newPlayerPos] = '@';

			return new string(trial);
		}

        /// <summary>
        /// Push the specified x, y towards dx, dy on the trialBoard.
        /// </summary>
        /// <returns>The push.</returns>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="dx">Dx.</param>
        /// <param name="dy">Dy.</param>
        /// <param name="trialBoard">Trial board.</param>
		private string Push(int x, int y, int dx, int dy, string trialBoard)
		{

			int newBoxPos = (y + 2 * dy) * nCols + x + 2 * dx;

			if (trialBoard[newBoxPos] != ' ')
				return null;

			char[] trial = trialBoard.ToCharArray();
			trial[y * nCols + x] = ' ';
			trial[(y + dy) * nCols + x + dx] = '@';
			trial[newBoxPos] = '$';

			return new string(trial);
		}

        /// <summary>
        /// Checks if the current board is solved.
        /// </summary>
        /// <returns><c>true</c>, if solved was ised, <c>false</c> otherwise.</returns>
        /// <param name="trialBoard">Trial board.</param>
		private bool IsSolved(string trialBoard)
		{
			for (int i = 0; i < trialBoard.Length; i++)
				if ((destBoard[i] == '.')
						!= (trialBoard[i] == '$'))
					return false;
			return true;
		}
	}
}