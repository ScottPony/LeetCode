using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var mat = new int[2][];
            mat[0] = new int[] { 1, 2 };
            mat[1] = new int[] { 3, 4 };
            //var matrixReshape = MatrixReshape(mat, 4, 1);
            //var maxOnes = FindMaxConsecutiveOnes(new int[]{1, 1, 0, 1, 1, 1});
            var r = FindErrorNums(new int[] { 1, 2, 2, 4 });
        }

        #region Array

        //566. Reshape the Matrix
        private static int[][] MatrixReshape(int[][] mat, int r, int c) {
            int l = mat.Length;
            int w = mat[0].Length;
        
            if(l*w != r*c) return mat;
            int[][] reshaped = new int[r][];
            for (int column = 0; column < r; column++)
            {
                reshaped[column] = new int[c];
            }
            int index = 0;
            for(int i=0;i<r;i++)
            {
                for(int j=0;j<c;j++)
                {
                    reshaped[i][j] = mat[index/w][index%w];
                    index++;
                }
            }
        
            return reshaped;
        }
        
        //485. Max Consecutive Ones
        private static int FindMaxConsecutiveOnes(int[] nums) {
            var max = 0;
            var cur = 0;
        
            foreach (var t in nums)
            {
                cur = t==0 ? 0 : ++cur;
                max = Math.Max(max, cur);
            }
        
            return max;
        
        }
        
        //645. Set Mismatch
        private static int[] FindErrorNums(int[] nums) {
            var r = new int[2];
        
            if(nums.Length == 1) return nums;
        
            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i+1] != nums[i]+1)
                {
                    r[0] = nums[i];
                    r[1] = nums[i]+1;
                    break;
                }
            }
        
            return r;
        }
        
        //697. Degree of an Array
        private static int FindShortestSubArray(int[] nums) {
            //Dictionary(element, index)
            IDictionary<int ,int> left = new Dictionary<int, int>();
            IDictionary<int ,int> right = new Dictionary<int, int>();
            //Each element count dictionary(element, frequence count)
            IDictionary<int ,int> count = new Dictionary<int, int>();
        
            for (int i = 0; i < nums.Length; i++)
            {
                if(!left.ContainsKey(nums[i])) left.Add(nums[i], i);
                if(right.ContainsKey(nums[i]))
                {
                    right[nums[i]] = i;
                }
                else
                {
                    right.Add(nums[i], i);
                }
                if(count.ContainsKey(nums[i]))
                {
                    count[nums[i]] = count[nums[i]] + 1;
                }
                else
                {
                    count.Add(nums[i], 1);
                }
            }

            var answer = nums.Length;
            //Find degree
            var degree = count.Values.Max();
        
            //Find the most frequence element index
            foreach (var countKey in count.Keys)
            {
                if (count[countKey] == degree)
                {
                    answer = Math.Min(answer, right[countKey] - left[countKey] + 1);
                }
            }

            return answer;
        }
        
        //766. Toeplitz Matrix
        private static bool IsToeplitzMatrix(int[][] matrix) {
            var m = matrix.Length;
            var n = matrix[0].Length;
            var result = true;
        
            for(int i = 1; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if(i - 1 >= 0 && j - 1 >= 0)
                    {
                        if (matrix[i][j] != matrix[i - 1][j - 1]) result = false;
                    }
                }
            }
        
            return result;
        }

        #endregion
        
    }
}