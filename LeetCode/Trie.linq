<Query Kind="Program" />

void Main()
{
	Trie trie  = new Trie();
	trie.Insert("abcdef");
	Console.WriteLine (trie.Search("abcdef"));
	Console.WriteLine (trie.StartsWith("abcdefg"));
}

// Define other methods and classes here
class TrieNode {
    // Initialize your data structure here.
    
	// indicates if this node is a leaf node
    public bool isWord;
	//how many words start with this prefix
	public int prefix; 
	//reference to children node
	public TrieNode[] children; 
	public TrieNode()
	{
		isWord = false;
		prefix = 0;
		children = new TrieNode[26];
	}
    
}

public class Trie {
    private TrieNode root;

    public Trie() {
        root = new TrieNode();
    }

    // Inserts a word into the trie.
    public void Insert(String word) {
        InsertHelper(word, this.root);
    }

    // Returns if the word is in the trie.
    public bool Search(string word) {
        return SearchHelper(word, this.root);
    }

    // Returns if there is any word in the trie
    // that starts with the given prefix.
    public bool StartsWith(string word) {
         return StartsWith(word, this.root);
    }
	private void InsertHelper(string word, TrieNode node)
	{
		node.prefix++;
		// if we pass an empty string
		if(string.IsNullOrEmpty(word))
		{
			node.isWord = true;			
			return;
		}	
		
		char first = word[0];
		if(node.children[first - 'a'] == null)
		{
			node.children[first - 'a'] = new TrieNode();
		}
		string remaining = word.Substring(1);
		
		InsertHelper(remaining, node.children[first - 'a']);
	}
	
	private bool SearchHelper(string word, TrieNode node)
	{
		if(string.IsNullOrEmpty(word))
			return node.isWord;
		if(node.children[word[0] - 'a'] == null)
			return false;
		else
			return SearchHelper(word.Substring(1), node.children[word[0] - 'a']);
	}
	
	private bool StartsWith(string word, TrieNode node)
	{
		if(string.IsNullOrEmpty(word))
			return node.prefix >= 1;
		if(node.children[word[0] - 'a'] == null)
			return false;
		else
			return StartsWith(word.Substring(1), node.children[word[0] - 'a']);
	}
}