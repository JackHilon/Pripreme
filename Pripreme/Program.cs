using System;

namespace Pripreme
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pripreme problem:
            // https://open.kattis.com/problems/pripreme 
            // I get an error: Time Limit Exceeded !!!!


            var numOfGroups = EnterNumOfGroups();
            var groups = EnterGroups(numOfGroups);

            var maxParameters = MaxArray(groups);

            int result = 0;
            int checkedSum = maxParameters[2] - maxParameters[0];
            if (maxParameters[0] > checkedSum)
                result = maxParameters[0] * 2;
            else
                result = maxParameters[2];
            Console.WriteLine(result);
        }

        private static int ArraySumExceptMax(int[] arr, int maxIndex)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i != maxIndex)
                    sum = sum + arr[i];
            }
            return sum;
        }

        private static int[] MaxArray(int[] arr)
        {
            // result {Max value, Max index, arraySum}
            int[] result = new int[3] { int.MinValue, 0, 0 };
            for (int i = 0; i < arr.Length; i++)
            {
                result[2] = result[2] + arr[i];// <-- Sum of array items

                if(result[0] < arr[i]) // max value and index
                {
                    result[0] = arr[i];
                    result[1] = i;
                }
            }
            return result;
        }

        private static int[] EnterGroups(int n)
        {
            int[] a = new int[n];
            string[] strArr = new string[n];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = 0;
                strArr[i] = " ";
            }
            try
            {
                if (n<=0)
                    throw new IndexOutOfRangeException();

                strArr = Console.ReadLine().Split(' ', n);

                for (int i = 0; i < a.Length; i++)
                {
                    a[i] = int.Parse(strArr[i]);
                }

                if (Conditions(a) == false)
                    throw new ArgumentException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterGroups(n);
            }
            return a;
        }

        private static bool Conditions(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] <= 0 || arr[i] >= 300000)
                    return false;
            }
            return true;
        }

        private static int EnterNumOfGroups()
        {
            int a = 0;
            try
            {
                a = int.Parse(Console.ReadLine());
                if (a <= 0 || a >= 300000)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterNumOfGroups();
            }
            return a;
        }
    }
}
