using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    class WorkingClass
    {
        public int InsertionSorting()
        {
            Console.Write("\nProgram for sorting a numeric array using Insertion Sorting");
            Console.Write("\n\nEnter number of elements: ");
            int max = Convert.ToInt32(Console.ReadLine());
            int[] numarray = new int[max];
            for (int i = 0; i < max; i++)
            {
                numarray[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int k = 0; k < max; k++)
            {
                Console.Write(numarray[k] + " ");
            }
            Console.Write("\n");
            for (int i = 1; i < max; i++)
            {
                int j = i;
                while (j > 0)
                {
                    if (numarray[j - 1] > numarray[j])
                    {
                        int temp = numarray[j - 1];
                        numarray[j - 1] = numarray[j];
                        numarray[j] = temp;
                        j--;
                    }
                    else
                    {
                        break;
                    }
                }
                Console.Write("Iteration " + i.ToString() + ": ");
                for (int k = 0; k < max; k++)
                    Console.Write(numarray[k] + " ");
                Console.Write("\n");
            }
            Console.WriteLine("Sorted Array");
            for (int i = 0; i < max; i++)
            {
                Console.Write(numarray[i] + " ");
            }
            return 0;
        }
    }
}
