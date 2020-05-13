using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _540.Single_Element_in_a_Sorted_Array
{
    class Program
    {
        static void Main(string[] args)
        {

            // input array will always have odd numbers
            int[] nums = { 2,2,3 };

            // method 1 = (O) n log n
            Console.WriteLine(BinarySearch(nums, 0, nums.Length - 1));
            
            // method 2 - linear search (O)n
            Console.WriteLine(LineSearch(nums));
        }

        static public int BinarySearch(int[] nums, int low, int high)
        {
            // if the pointer direction ->> is greater than the pointer going direction <<-, nothing is found, return any number
            if (low > high)
                return 0;

            // if only one element found, return it as the single
            if (low == high)
                return nums[low];

            // get array mid (the formula below is overflow free, use it always to get array mid)
            int mid = low + (high - low) / 2;

            // if the mid value is even
            if (mid % 2 == 0)
            {
                // check if array at position mid is equal to the next element
                if (nums[mid] == nums[mid + 1])
                    // if true call this function again passing the second element from the mid to the right as new low and end of array as high
                    return BinarySearch(nums, mid + 2, high);
                else
                    // if not, just call the function passing start of array as low and mid as new high
                    return BinarySearch(nums, low, mid);
            }
            else // if the mid value is odd
            {

                // check if array at position mid is equal to the previous element
                if (nums[mid] == nums[mid - 1])
                    // if true call this function again passing the first element from the mid to the right as new low and end of array as high
                    return BinarySearch(nums, mid + 1, high);
                else
                    // if not, just call the function passing start of array as low and mid-1 as new high
                    return BinarySearch(nums, low, mid - 1);

            }

        }

        static public int LineSearch(int[] nums)
        {
            // notice i is going 2 places at a time, so iterate through last but one
            for (int i = 0; i < nums.Length - 1; i += 2)
            {
                // since we are avoiding numbers together to get the single, check each pair for equality
                if (nums[i] != nums[i+1])
                {
                    // if different return the first number
                    return nums[i];
                }
            }

            // if nothing is found, element is the last, return it
            return nums[nums.Length -1];
        }
    }
}
