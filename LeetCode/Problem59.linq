<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	for (int i = 0; i <=5; i++)
	{
		ob.GenerateMatrix(i).Dump();
	}
}

// Define other methods and classes here
public class Solution
{
	class Position
	{
		public int x;
		public int y;
		public Position(int i, int j)
		{
			x = i;
			y = j;
		}
	}
	enum Direction
	{
		Left,
		Right, 
		Up,
		Down
	}
	
	int left, up, right, down;
	Direction direction;
	public int[,] GenerateMatrix(int n)
	{
		left = 0;
		up = 1;
		right = down = n -1;
		direction = Direction.Right;
		var result = new int[n,n];
		if(n == 0)
			return result;
		result[0,0] = 1;
		var current = new Position(0,0);
		for (int i = 2; i <= n * n; i++)
		{
			var nextPosition = GetNextPosition(current);
			result[nextPosition.x, nextPosition.y] = i;
			current = nextPosition;
		}
		return result;
	}

	private Position GetNextPosition(Position current)
	{
		int i = current.x;
		int j = current.y;
		switch (direction)
		{
			case Direction.Right:
				j++;
				if (j == right)
				{
					direction = Direction.Down;
					right--;
				}
				break;
			case Direction.Down:
				i++;
				if (i == down)
				{
					direction = Direction.Left;
					down--;
				}
				break;
			case Direction.Left:
				j--;
				if (j == left)
				{
					direction = Direction.Up;
					left++;
				}
				break;
			case Direction.Up:
				i--;
				if (i == up)
				{
					direction = Direction.Right;
					up++;
				}
				break;
			default:
				break;
		}		
		return new Position(i,j);
	}
}