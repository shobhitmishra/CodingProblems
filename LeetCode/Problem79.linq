<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
</Query>

void Main()
{
	var input = new char[,] { {'A','B','C','E' }, {'S','F','C','S' }, {'A','D','E','E'}};
	var ob = new Solution();
	var word = "SEECCZ";
	ob.Exist(input,word).Dump();
}

// Define other methods and classes here
public class Solution
{
	public bool Exist(char[,] board, string word)
	{
		var used = new bool[board.GetLength(0), board.GetLength(1)];
		for (int i = 0; i < board.GetLength(0); i++)
		{
			for (int j = 0; j < board.GetLength(1); j++)
			{
				if(ExistHelper(board, word, i , j, 0, used))
					return true;
			}
		}
		return false;
	}
	
	private bool ExistHelper(char[,] board, string word, int i, int j, int length, bool[,] used)
	{
		if(length == word.Length)
			return true;
		if(i < 0 || j < 0 || i == board.GetLength(0) || j == board.GetLength(1))
			return false;
		if(used[i,j])
			return false;
		if(board[i,j] != word[length])
			return false;
		
		used[i,j] = true;
		
		if(ExistHelper(board, word, i + 1, j, length +1, used) ||
			ExistHelper(board, word, i - 1, j, length +1, used) ||
			ExistHelper(board, word, i, j - 1, length +1, used) ||
			ExistHelper(board, word, i, j + 1, length +1, used)
		)
			return true;
		
		used[i,j] = false;
		return false;
	}
}