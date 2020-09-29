using System;
using System.Collections.Generic;

namespace Assignment_1_Programming_Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            PrintTriangle(n);

            int n2 = 10;
            PrintSeriesSum(n2);

            int[] A = new int[] { 1, 4, 2, 6 }; ;
            bool check = MonotonicCheck(A);
            Console.WriteLine(check);
            Console.WriteLine();

            int[] nums = new int[] { 3, 1, 4, 1, 5 };
            int k = 2;
            int pairs = DiffPairs(nums, k);
            Console.WriteLine(pairs + " pair(s) found with difference " + k);
            Console.WriteLine();

            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "dis";
            int time = BullsKeyboard(keyboard, word);
            Console.WriteLine(time);
            Console.WriteLine();

            string str1 = "goulls";
            string str2 = "gobullskr";
            int minEdits = StringEdit(str1, str2);
            Console.WriteLine(minEdits);

        }

        public static void PrintTriangle(int x)
        {
            try
            {
                int spaces = x - 1; // Variable to store the no. of blank spaces to leave before printing
                for(int i=1; i<=x; i++)
                {
                    for(int j=1; j<=spaces; j++)
                    {
                        Console.Write(" "); // Print a space
                     }
                    spaces--; // Decrement value of 'spaces' after each space has been printed
                    for(int k=1; k<=2*i-1; k++)
                    {
                        Console.Write("*"); // Prints the asterisk for that particular row
                    }
                    Console.WriteLine(); // Prints a new line in which the loops listed above run again
                    Console.WriteLine(); // Formatting for better viewability
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing PrintTriangle()");
            }
        }

        public static void PrintSeriesSum(int n)
        {
            try
            {
                List<int> resultList = new List<int>(); // Initialize a new list to store results of computation
                int i = 1; // Initialize a variable for looping
                while (resultList.Count < n) // Condition to check if we have reached desired no. of elements in the list after each loop iteration
                {
                    
                    if (i%2 != 0) // Check if 'i' is an odd number
                    {
                        resultList.Add(i); // If odd, add the number to our resultList
                    }
                    i++; // Increment i for the next step
                }

                int sum = 0; //Initialize the sum variable 

                Console.Write("The odd numbers are: ");
                foreach (int j in resultList) // Looping through the various elements of the list
                {
                    Console.Write(j + " ");
                    sum += j; // Summing the elements of the list cumulatively
                }

                Console.WriteLine();
                Console.WriteLine("The sum is : " + sum); // Print the sum
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("Exception occured while computing PrintSeriesSum()");
            }
        }

        public static bool MonotonicCheck(int[] n)
        {
            try
            {
                //Console.WriteLine(n.Length);
                //Console.WriteLine(n[0]);

                bool mono_increasing = true; // Set flag for monotonically increasing
                bool mono_decreasing = true; // Set flag for monotonically decreasing
                for (int i = 0; i < n.Length - 1; i++) // Iterate through each element of the array
                {
                    if (n[i] < n[i + 1]) // Check if second element is larger than first element; If yes --> decreasing_flag = False
                    {
                        mono_decreasing = false;
                    }
                }
                for (int i = 0; i < n.Length - 1; i++) // Iterate through each element of the array
                {
                    if (n[i] > n[i + 1]) // Check if second element is smaller than first element; If yes --> increasing_flag = False
                    {
                        mono_increasing = false;
                    }
                }
                return mono_increasing || mono_decreasing; // If it is either monotonically increasing OR decreasing, return TRUE.
            }
            catch
            {
                Console.WriteLine("Exception occured while computing MonotonicCheck()");
            }
            Console.WriteLine();
            return false;
        }

        public static int DiffPairs(int[] J, int k)
        {
            try
            {
                Array.Sort(J); // Sorting the array before starting the search as logic assumes that the preceding number in array is always smaller

                int i = 0; // Initialize 'i' to start from first value in array
                int m = 1; // Initialize 'm' to start from second value in array
               
                int arr_size = J.Length; // Store the length of array in a variable for easier computation
                int pairs = 0; // Initialize the result variable

                while(i < arr_size && m < arr_size) // Check if looping variables are within index of array
                {
                    if (J[m] - J[i] == k) // Check if difference between array elements equals 'k'
                    {
                        pairs += 1; 
                        m++;
                        i++;
                        while (m < arr_size && J[m] == J[m - 1]) // Check if preceding element is same as current element; If yes --> Increment 'm'
                        {
                            m++;
                        }
                    }
                    else if (J[m] - J[i] > k) // Check if difference is less than 'k'; If yes --> Increment 'm'
                    {
                        m++;
                        if(m - i == 0) // Update 'm' if 'm' & 'i' are at same array index
                        {
                            m++;
                        }
                    } else
                    {
                        m++; // If difference is not equal to or lesser than 'k', increment 'm'
                    }

                }
                return pairs;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing DiffPairs()");
            }

            return 0;
        }

        public static int BullsKeyboard(string keyboard, string word)
        {
            try
            {
                char[] keyboardArray = keyboard.ToCharArray(); // Convert keyboard pattern into an array to extract index positions
                char[] wordArray = word.ToCharArray(); // Convert input word into an array to extract index positions
                 
                int word_length = word.Length; // Compute word length as we are going to be iterating over it

                List<int> letter_position = new List <int>(); // Create a list to append index positions of each letter from keyboard

                for (int i = 0; i < word_length; i++)
                {
                    int position = Array.IndexOf(keyboardArray, wordArray[i]); // Find index of each letter in the word from keyboard
                    letter_position.Add(position); // Add found index to position list
                }

                int distance = 0; // Initialize variable 'distance' to compute distance between every pair of letters in keyboard
                int total_dist = 0; // Initialize variable to sum the 'total_distance' for all letters

                for (int k=0; k <word_length; k++) // Iterate over stored index position of each letter in the input word
                {
                    if(k == 0) // Check if it is the starting letter; If yes --> Add index to total_distance
                    {
                        distance += letter_position[k];
                        total_dist += distance;
                    }
                    else 
                    {
                        distance = Math.Abs(letter_position[k] - letter_position[k - 1]); // Calculate absolute value of difference in index positions between the two letters
                        total_dist += distance; // Add the difference to total_distance
                    }
                }
                

                return total_dist; // Return the total distance
            }
            catch
            {
                Console.WriteLine("Exception occured while computing BullsKeyboard()");
            }

            return 0;
        }

        public static int StringEdit(string str1, string str2)
        {
            try
            {
                int s1_len = str1.Length; // Initialize length of first string for iterating through characters
                int s2_len = str2.Length; // Initialize length of second string for iterating through characters

                int[,] matrix = new int[s1_len + 1, s2_len + 1]; // Create a matrix of size [(length + 1) x (length + 1)] for dynamic distance computation

                for(int i = 0; i <= s1_len; i++) // Looping through the matrix of words
                {
                    for(int j = 0; j <= s2_len; j++)
                    {
                        if(j == 0) // Check if letter of second word is empty; If yes --> Operation = Remove characters from str1 to convert to str2
                        {
                            matrix[i, j] = i;
                            continue;
                        }

                        if(i == 0) // Check if letter of first word is empty; If yes --> Operation = Insert characters in str1 to convert to str2
                        {
                            matrix[i, j] = j;
                            continue;
                        }

                        matrix[i, j] = int.MaxValue; // If neither condition is met --> Initialize operations reqd. to a high value
                    }
                }

                for(int i = 1; i <= s1_len; i++)
                {
                    for(int j = 1; j <= s2_len; j++)
                    {
                        if(str1[i - 1] == str2[j - 1]) // Check if letters in both words are the same; If yes --> Replace with min. value from matrix
                        {
                            matrix[i, j] = Math.Min(matrix[i, j], matrix[i - 1, j - 1]); 
                        }
                        else // If first condition is not met --> Replace with min value + 1
                        {
                            matrix[i, j] = Math.Min(matrix[i, j], matrix[i - 1, j - 1] + 1);
                        }

                        matrix[i, j] = Math.Min(matrix[i, j], matrix[i - 1, j] + 1);

                        matrix[i, j] = Math.Min(matrix[i, j], matrix[i, j - 1] + 1);
                    }
                }
                return matrix[s1_len, s2_len];
            }
            catch
            {
                Console.WriteLine("Exception occured while computing StringEdit()");
            }

            return 0;
        }
    }

}
