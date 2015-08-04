using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("isStepped");
            Console.WriteLine("====================");
            Console.WriteLine(isStepped(new int[] { 1, 1, 1, 5, 5, 5, 5, 8, 8, 8 }));
            Console.WriteLine(isStepped(new int[] { 1, 1, 5, 5, 5, 5, 8, 8, 8 }));
            Console.WriteLine(isStepped(new int[] { 5, 5, 5, 15 }));
            Console.WriteLine(isStepped(new int[] { 3, 3, 3, 2, 2, 2, 5, 5, 5 }));
            Console.WriteLine(isStepped(new int[] { 3, 3, 3, 2, 2, 2, 1, 1, 1 }));
            Console.WriteLine(isStepped(new int[] { 1, 1, 1 }));
            Console.WriteLine(isStepped(new int[] {  1, 1, 1, 1, 1, 1, 1 }));
            
            Console.WriteLine("=====================");
            Console.WriteLine("isRapidlyIncreasing");
            Console.WriteLine("====================");
            Console.WriteLine(isRapidlyIncreasing(new int[] { 1, 3, 9, 27 }));
            Console.WriteLine(isRapidlyIncreasing(new int[] { 1, 3, 200, 500 }));
            Console.WriteLine(isRapidlyIncreasing(new int[] { 1 }));
            Console.WriteLine(isRapidlyIncreasing(new int[] { 1, 3, 9, 26 }));
            Console.WriteLine(isRapidlyIncreasing(new int[] { 1, 3, 7, 26 }));
            Console.WriteLine(isRapidlyIncreasing(new int[] { 1, 3, 8, 26 }));
            
            Console.WriteLine("=====================");
            foreach (var item in Factor(991))
            {
                Console.WriteLine(item);
            }
            

            Console.ReadLine();
        }


        static int isStepped(int[] a)
        {
            int[] distinctValues = new int[a.Length];
            int[] ValueOccurrences = new int[a.Length];
            int distinctIndex = 0;
            int numberofDistinctValues = 0;
            for (int i = 0; i < a.Length; i++)
            {
               
                if (i < a.Length - 1)
                {
                    if (a[i] > a[i + 1])
                    {
                        return 0;
                    }
                }
               int isExist = 0;
                for (int k = 0; k < distinctValues.Length; k++)
                {
                    if(a[i] == distinctValues[k]) {
                        distinctIndex = k;
                        isExist = 1;
                        break;
                    }
                }
                
                if (isExist == 1)
                {
                    ValueOccurrences[distinctIndex]++;
                }
                else
                {
                    // new distinct value
                    if(distinctValues[distinctIndex] > 0 && distinctValues[distinctIndex] != a[i])
                    {
                        distinctIndex++;
                    }
                    numberofDistinctValues++;
                     distinctValues[distinctIndex] = a[i];
                    ValueOccurrences[distinctIndex]++;
                   
                }
               
            }

            for (int i = 0; i < numberofDistinctValues; i++)
            {
                if(ValueOccurrences[i] < 3) {
                    return 0;
                }
            }

            return 1;
        }

        static int isRapidlyIncreasing(int[] a)
        {
            int israpid = 1;
            if (a.Length == 1)
            {
                israpid = 1;
            }
            else
            {
                for (int i = 1; i < a.Length; i++)
                {
                    int rapidvalue = a[i];
                    int prevtotalvalue = 0;
                    for (int j = 0; j < i; j++)
                    {
                        prevtotalvalue += a[j];
                    }
                    int va = 2 * prevtotalvalue;
                    if (rapidvalue <= va)
                    {
                        return 0;
                    }
                    
                }
            }

            return israpid;
        }

        public static List<int> Factor(int number)
        {
            List<int> factors = new List<int>();
            int max = (int)Math.Sqrt(number);  //round down
            for (int factor = 1; factor <= max; ++factor)
            { //test from 1 to the square root, or the int below it, inclusive.
                if (number % factor == 0)
                {
                    factors.Add(factor);
                    if (factor != number / factor)
                    { // Don't add the square root twice!  Thanks Jon
                        factors.Add(number / factor);
                    }
                }
            }
            return factors;
        }

    }
}
