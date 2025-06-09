public class Solution {
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            map[nums[i]] = i;

            int complemento = target - nums[i];

            if (map.ContainsKey(complemento) && map[complemento] != i)
            {
                return new int[] { i, map[complemento] };
            }
        }
        return new int[] {};
    }
}



