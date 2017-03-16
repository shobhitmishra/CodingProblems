<Query Kind="Program" />

void Main()
{
	var nums = new int[] { 3, 13, 45, 58, 90, 130 };
	var rand = new Random();
	for (int i = 0; i < 10; i++)
	{
		int key = rand.Next(-20, 50);
    	int ceil = FindCeiling(nums, key);
		key.Dump("Key is");
		if (ceil == -1)
			Console.WriteLine("Ceiling not found");
		else
			nums[ceil].Dump();
	}
}

// Define other methods and classes here
int FindCeiling(int[] nums, int key)
{
	if(key < nums[0])
		return 0;
	int left = 0;
	int right = nums.Length - 1;
	while (left < right)
	{	
		int mid = (left + right) /2;
		if(nums[mid] <= key && nums[mid + 1] > key)
			return mid + 1;
		else if(nums[mid] > key && nums[mid-1] <= key)
			return mid;
		else if (nums[mid] <= key)
			left = mid + 1;
		else
			right = mid - 1;
	}	
	return -1;
}