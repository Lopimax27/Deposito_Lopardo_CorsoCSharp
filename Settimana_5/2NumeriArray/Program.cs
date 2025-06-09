public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        for (int i = 0; i < nums.Count(); i++)
        {
            for (int j = 1; j < nums.Count(); j++)
            {
                if (nums[i] + nums[j] == target && i != j)
                {
                    return new int[] { i, j };
                }
            }
        }
        return new int[] { };
    }
}
