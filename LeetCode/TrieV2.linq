<Query Kind="Program" />

void Main()
{
	Trie trie  = new Trie();
	trie.Insert("");
	Console.WriteLine (trie.Search("a"));
	Console.WriteLine (trie.StartsWith(""));
}

// Define other methods and classes here
public class TrieNode
{	// Initialize your data structure here.
	public TrieNode[] references;
	public bool isLeaf;
	public TrieNode()
	{
		references = new TrieNode[26];
		isLeaf = false;
	}
}

public class Trie
{
	private TrieNode root;

	public Trie()
	{
		root = new TrieNode();
	}

	// Inserts a word into the trie.
	public void Insert(String word)
	{
		var current = root;
		foreach (char ch in word)
		{
			var node = current.references[GetIndex(ch)];
			if(node == null)
			{
				node = new TrieNode();
				current.references[GetIndex(ch)] = node;
			}
			current = node;
		}
		current.isLeaf = true;
	}

	public TrieNode SearchHelper(string word)
	{
		var current = root;
		foreach (char ch in word)
		{
			var node = current.references[GetIndex(ch)];
			if (node == null)
				return node;
			current = node;
		}
		return current;
	}

	// Returns if the word is in the trie.
	public bool Search(string word)
	{
		var node = SearchHelper(word);
		if(node == null)
			return false;
		return node.isLeaf;
	}

	// Returns if there is any word in the trie
	// that starts with the given prefix.
	public bool StartsWith(string word)
	{
		var node = SearchHelper(word);
		if (node == null)
			return false;
		return true;	
	}

	private int GetIndex(char ch)
	{
		return ch - 'a';
	}
}