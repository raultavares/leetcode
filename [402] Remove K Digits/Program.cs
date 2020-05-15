using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _402.Remove_K_Digits
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(RemoveKdigits("31114", 3));
        }

        static public string RemoveKdigits(string num, int k)
        {
            // define the word length,
            int size = num.Length;

            // edge case where need to remove all elements
            if (size == k)
                return "0";

            Stack<int> stk = new Stack<int>();

            int counter = 0;

            // loop through the whole word
            while (counter < size)
            {
                // check if number on top of stack is greater than current number
                while ((k >0 && stk.Count > 0 && stk.Peek() > num[counter] - '0'))
                {
                    // if yes, pop it and decrease the removal factor
                    stk.Pop();
                    k--;
                }

                // push the new element that is GREATER than stack top
                stk.Push(num[counter] - '0');
                counter++;
            }

            // after all elements are in, delete k elements to handle duplicates
            while (k > 0)
            {
                stk.Pop();
                k--;
            }

            // build the string with the values in stack
            StringBuilder sb = new StringBuilder();

            while (stk.Count >0)
            {
                sb.Insert(0,stk.Pop());
            }

           // remove leading zeroes
            while (sb.Length > 1 && sb[0] == '0')
            {
                sb.Remove(0, 1);
            }

            // return the string
            return sb.ToString();

        }
    }
}
