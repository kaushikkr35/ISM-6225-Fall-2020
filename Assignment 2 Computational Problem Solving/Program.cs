using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;

namespace Assignment2_Fall2020
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Question 1");
            int n = 7;
            Console.WriteLine("Any Complexity"); // Print title for better readability
            PrintPatternAnyComplexity(n);
            Console.WriteLine(); // Printing empty line for better readability
            Console.WriteLine("Linear Complexity"); 
            PrintPatternLinearComplexity(n);
            Console.WriteLine(); // Printing empty line for better readability


            Console.WriteLine("Question 2");
            int[] array1 = new int[] {1, 3, 5, 4, 7 };
            int result = LongestSubSeq(array1);
            Console.WriteLine(result);
            Console.WriteLine(); // Printing empty line for better readability


            Console.WriteLine("Question 3");
            int[] array2 = new int[] { 1, 2, 3, 4, 5, 5 };
            PrintTwoParts(array2);
            Console.WriteLine(); // Printing empty line for better readability


            Console.WriteLine("Question 4");
            int[] array3 = new int[] { -7, -3, 2, 3, 11 };
            int[] result2 = SortedSquares(array3);
            Console.WriteLine(string.Join(", ", result2));
            Console.WriteLine(); // Printing empty line for better readability

            Console.WriteLine("Question 5");
            int[] nums1 = { 3, 6, 2 };
            int[] nums2 = { 6, 3, 6, 7, 3 };
            int[] intersect1 = Intersect(nums1, nums2);
            foreach (int i in intersect1)    
            {
                Console.Write("{0} ", i);
            }

            Console.WriteLine(); // Printing empty line for better readability
            Console.WriteLine("Question 6");
            int[] arr = new int[] { 1, 2, 2, 1, 1, 3 };
            Console.WriteLine(UniqueOccurrences(arr));
            Console.WriteLine(); 

            Console.WriteLine("Question 7");
            int[] numbers = { 0, 1, 3, 50, 75 };
            Console.WriteLine(numbers);
            int lower = 0;
            int upper = 99;
            List<String> ResultList = Ranges(numbers, lower, upper);
            // Printing the results
            string[] Ranges_Result = ResultList.ToArray();
            Console.WriteLine(string.Join(", ", Ranges_Result));
            Console.WriteLine(); // Printing empty line for better readability

            Console.WriteLine("Question 8");
            string[] names = new string[] { "pes", "fifa", "gta", "pes(2019)" };
            string[] namesResult = UniqFolderNames(names);
            Console.WriteLine(string.Join(", ", namesResult));


        }

        public static void PrintPatternAnyComplexity(int n)

        {
            try
            {
                for(int i = 1; i <= n; i++) // Looping to generate pattern
                {
                    Console.Write(string.Concat(Enumerable.Repeat("*", i))); // Concatenate asterisks 'i' times to generate pattern
                    Console.WriteLine(); // Print next line 
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static void PrintPatternLinearComplexity(int n)

        {
            try // Complexity = O(2n) i.e. O(n) 
            {
                string res = ""; // Initialize empty string to append asterisks for pattern 
                for(int i = 1; i <= n; i++) // Loop to add one asterisk each iteration to the string O(n)
                {
                    res += "*"; // Add the asterisk to the string O(1)
                    Console.WriteLine(res); // Printing the string during each iteration - O(1)
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        public static int LongestSubSeq(int[] nums)
        {
            try
            {
                int result = 1; // Intialize result to '1' (since we compare current element with previous element)
                int start = 0; // We do not know the longest subsequence currently. So, assume such a sequence does not exist

                if (nums.Length == 0) // Check if array is empty. If yes, return 0. 
                    return 0;

                if (nums.Length == 1) // Check if array has a single element only. If yes, return 1. 
                    return 1;
                else // If no, loop through elements of the array 
                {
                    for (int i = 1; i < nums.Length; i++) // Loop through elements of the array 
                    {
                        if (nums[i] > nums[i - 1]) // Check if array is increasing
                            result++; // If yes, increment result by 1
                        else
                            result = 1; // If no, assign result = 1 (prev & current element might be same) 
                        if (result > start) // To handle corner case where array has elements that increase, decrease & then increase in random manner.
                            start = result; // Update the start value to check for next sequence 
                    }
                }
         

                return start;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void PrintTwoParts(int[] array2)
        {
            try
            {
                if (array2.Length <= 1)
                    Console.WriteLine("Cannot split the array. Need a minimum of two elements in the array to create a split");

                int sum = array2.Sum(); // Sum elements of array to find their total
                int stop = sum / 2; // Divide the total by half to determine the splitting point

                List<int> first_part = new List<int>(); // Create a new list to store the first subset 
                List<int> second_part = new List<int>(); // Create a new list to store the second subset

                int first_sum = 0; // Summing for the first part to maintain O(n) time complexity
                int second_sum = 0; // Summing for the second part to maintain O(n) time complexity

                for (int i = 0; i < array2.Length; i++) // Loop through each element of input array 
                {
                    if (first_sum < stop) // Check if sum of first part is lesser than the splitting point
                    {
                        first_sum += array2[i];
                        first_part.Add(array2[i]); // If yes, add element to first subset
                    }
                    else if (first_sum == stop) // If no, check if first_sum = splitting point 
                    {
                        if (second_sum < stop) // If part 1 has reached splitting point, check if sum of part 2 is lesser than splitting point
                        {
                            second_sum += array2[i];
                            second_part.Add(array2[i]); // If yes, add element to second subset  
                        }
                    }
                }

                if (first_sum == second_sum) // Check if sum of both parts are equal. If yes, convert lists to arrays and print the elements
                {
                    int[] arr1 = first_part.ToArray();
                    int[] arr2 = second_part.ToArray();

                    Console.WriteLine(string.Join(", ", arr1));
                    Console.WriteLine(string.Join(", ", arr2));
                }
                else
                    Console.WriteLine("False"); // If no, print output as False since the input array cannot be split into equal parts

            }
            catch (Exception)
            {

                throw;
            }

        }

        public static int[] SortedSquares(int[] A)
        {
            try
            {
                int[] res = new int[A.Length]; // Create an array for storing results 
                int index_pos = A.Length - 1; // Index set to last position of array to enter highest squares first
                
                int start = 0; // Variable to denote the start of the array 
                int stop = A.Length - 1; // Variable to denote end of the array 

                if (A == null || A.Length == 0) // Corner case - If there are no elements in the array
                    Console.WriteLine("No values in array");
                
                while(start <= stop) // We know that input array is sorted, but it contains both negative & positive values
                {
                    if(Math.Abs(A[start]) >= Math.Abs(A[stop])) // Compare absolute value of first & last elements
                    {
                        res[index_pos] = A[start] * A[start]; // If abs(start) >= final value, store square of the same in last index position of list
                        start++; // Increment start to move to the next element of the array
                    }
                    else
                    {
                        res[index_pos] = A[stop] * A[stop]; // If final value >= abs(start), store square of final value in index position
                        stop--; // Decrement stop to move pointer one position to left of elements in the right
                    }

                    index_pos--; // Decrement index position after each iteration to store the squares in descending order
                }

                return res; // Return the list with sorted squares of input

            }
            catch (Exception)
            {

                throw;
            }
        }
        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            try
            {
                Dictionary<int, int> looping_dict = new Dictionary<int, int>(); // Declare a dictionary to elements of array & their count as key value pairs
                List<int> result = new List<int>(); // // Create an empty list to store the value of intersecting elements

                foreach(int i in nums1) // Looping through every element of the first array
                {
                    if (looping_dict.ContainsKey(i)) // Check if dictionary contains array element as a key
                        looping_dict[i] = looping_dict[i] + 1; // If yes, increment the value of the key-value pair 
                    else
                        looping_dict.Add(i, 1); // If no, add the key and initialize value to 1                    
                }
                    
                foreach(int j in nums2) // Looping through every element of the second array
                {
                    if(looping_dict.ContainsKey(j) && looping_dict[j] > 0) // Check if dictionary contains element as key & if value for that key is > 0
                    {
                        result.Add(j); // If yes, add the key to the result 
                        looping_dict[j]--; // Decrement the value for that key 
                    }
                }

                return result.ToArray(); // Return the result as an array 
            }
            catch
            {
                throw;
            }
        }


        public static bool UniqueOccurrences(int[] arr)
        {
            try
            {
                Dictionary<int, int> dict = new Dictionary<int, int>(); // Initialize dictionary to store elements of array & Their count as key-value pairs
                HashSet<int> check_hash = new HashSet<int>(); // Initialize hash set to check for duplicates in the dictionary 

                foreach (int i in arr) // Looping through the array 
                { 
                    if (dict.ContainsKey(i)) // Check if dictionary contains the element in array as a key already 
                        dict[i] += 1; // If yes, increment the value for that key by 1 
                    else
                        dict.Add(i, 1); // If no, add the element as a key and initialize value to 1 
                }

                foreach(int i in dict.Keys) // Looping through the keys of the dictionary 
                {
                    if (check_hash.Contains(dict[i])) // If a value exists for that 'key' in the hash table already, duplicate is present. Return false
                        return false;
                    else
                        check_hash.Add(dict[i]); // If a value is not present for that 'key' in the hash table already, enter the key into the hash table. 
                }

                return true; // Return true if there are no duplicates after looping through all keys in the dictionary 


            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<String> Ranges(int[] numbers, int lower, int upper)
        {
            try
            {
                List<String> result_list = new List<string>(); // Initialize a list to store missing ranges


                if(numbers == null || numbers.Length <= 0) // Check if array is empty
                {
                    result_list.Add(lower + "->" + upper); // If yes, range is lower to upper
                    return result_list;
                }

                if(numbers[0]!=lower) // Check if lower limit is not equal to first element
                {
                    result_list.Add(lower + "->" + (numbers[0] - 1)); // If yes, range is lower limit to (value of element - 1)
                }

                for(int i = 1; i < numbers.Length; i++) // Looping through the elemnts of the array
                {
                    if (numbers[i] == numbers[i - 1] + 1) // Check if difference between current element & previous element is 1
                        continue; // If yes, no missing ranges. We can continue. 
                    result_list.Add((numbers[i - 1] + 1) + "->" + (numbers[i] - 1)); // If no, range is (Prev Element + 1) to (Curr Element - 1) i.e. excluding current & prev element values. 
                }

                if (numbers[numbers.Length - 1] != upper) // Check if upper limit is not equal to last element 
                    result_list.Add(numbers[numbers.Length - 1] + 1 + "->" + upper); // If yes, range is (value of element + 1) to upper limit

                return result_list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static string[] UniqFolderNames(string[] names)
        {
            try
            {
                string[] result = new string[names.Length];
                Dictionary<string, int> suffixMap = new Dictionary<string, int>();

                for (int i = 0; i < names.Length; i++)
                {
                    string name = names[i];

                    if (suffixMap.ContainsKey(name))
                    {
                        int next = suffixMap[name] + 1;
                        name = $"{names[i]}({next})";

                        while (suffixMap.ContainsKey(name))
                        {
                            next++;
                            name = $"{names[i]}({next})";
                        }

                        suffixMap[names[i]] = next;
                        suffixMap[name] = 0;
                    }

                    else
                    {
                        suffixMap.Add(name, 0);
                    }

                    result[i] = name;
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
