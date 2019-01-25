using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockSort
{
    class Program
    {
        static void Main(string[] args)
        {
            BlockSort();
            Console.ReadLine();
        }

        static void BlockSort()
        {
            int length = 0;
            Console.WriteLine("\t\t******** BLOCK SORT *******\n");
            Console.Write("Enter Array Length\nAns:");
            length = Convert.ToInt16(Console.ReadLine());
            BlockSortAlgorithum obj = new BlockSortAlgorithum(length);
            Console.WriteLine("\t\t**** Enter Data **** ");
            //obj.Input_Data();
            obj.RandomInput();
            obj.SortData();
        }

    }

    class BlockSortAlgorithum
    {
        //members of Algorithm class
        private int[] array;
        private int length;
        private bool Initilize = false;
        private bool Twohalves = false;

        //default constructor
        public BlockSortAlgorithum()
        {

        }

        //one argument constructor
        public BlockSortAlgorithum(int length)
        {
            this.length = length;
            initilize(length);
        }


        //initilization of Data length 
        private void initilize(int length)
        {
            if (length >= 0)
            {
                this.length = length;
                array = new int[length];
                Initilize = true;
            }
            else
                Console.WriteLine("Array Length should be non negative number");
        }


        //check the initilization and goto function that takes input from users
        public void Input_Data()
        {
            if (!Initilize)
                Console.WriteLine("Please first initilize Data and specify length");
            else
            {
                Input_Data(length);
            }
        }

        //Enter Data in Array
        private void Input_Data(int length)
        {
            for (int i = 0; i < length; i++)
            {
                int x = Convert.ToInt16(Console.ReadLine());
                array[i] = x;
                Console.WriteLine("Element[{0}]=Data[{1}]", i, array[i]);
            }
            // DisplayUnSortedData();
        }


        //use this function
        //it sort Data efficiently on large no of Data
        //like length =50
        public void RandomInput()
        {
            Random obj = new Random();
            for (int i = 0; i < length; i++)
            {
                array[i] = obj.Next(1, 10);
            }
        }

        /// <summary>
        /// Director Method
        /// first check the array is sorted if not
        /// make two halves and sort 
        /// then merge
        /// </summary>
        public void SortData()
        {
            bool check = LinearSearch();
            if (check)
                Console.WriteLine("Data is in Sorted Form:\nThankyou");
            else
            {
                Console.WriteLine("UnSorted Data Which user gives as input");
                DisplayUnSortedData();
                int mid = TwoHalf();
                DispalySortedBlockA(mid);
                DisplaySortedBlockB(mid);
                array=Msort(0, mid, array.Length);
                PrintSortedArray();
            }
        }

        //check data is sorted form or Not similar as linear search
        private bool LinearSearch()
        {
            bool check = true;
            if (!Initilize)
                Console.WriteLine("");
            else
            {
                for (int i = 0; i < length; i++)
                {
                    if (i == array.Length - 1)
                        return check;
                    else if (array[i] <= array[i + 1])
                        continue;
                    else
                        check = false;
                }
            }
            return check;
        }

        //break into two Block
        //goto BlockA represent first halve
        //then goto BlockB represent Second halve
        //Return mid ( this is a point where array divide)

        private int TwoHalf()
        {
            int mid = Convert.ToInt16(null);
            if (!Initilize)
                Console.WriteLine("");
            else
            {
                Twohalves = true;
                mid = Convert.ToInt16(array.Length / 2);

                int count1 = BlockA(mid);
                int count2 = BlockB(mid);
            }
            return mid;
        }


        //Display BlockA first halve
        private int BlockA(int end)
        {
            if (!Twohalves)
            {
                Console.WriteLine("First Initilize Array OR  divide into two halves");
                return Convert.ToInt16(null);
            }
            else
            {
                Console.WriteLine("\t\t**** BLOCK A ****");
                for (int i = 0; i < end; i++)
                {
                    Console.WriteLine("Index[{0}=Data[{1}]", i, array[i]);
                }
                return BlockA(0, end);
            }

        }

        //Then Sort BlockA & count no. of elements in blockA
        private int BlockA(int start, int end)
        {
            int j = 0;
            int count = 0;
            for (int i = start; i < end; i++)
            {
                count++;
                int temp = array[i];
                j = i - 1;

                while (j >= 0 && temp < array[j])
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = temp;
            }
            
            return count;
        }

        //Dispaly BlockB
        private int BlockB(int start)
        {
            if (!Twohalves)
            {
                Console.WriteLine("First Initilize Array OR  divide into two halves");
                return Convert.ToInt16(null);
            }
            else
            {
                Console.WriteLine("\t\t **** BLOCK B ****");
                for (int i = start; i < array.Length; i++)
                {
                    Console.WriteLine("Index[{0}=Data[{1}]", i, array[i]);
                }
                return BlockB(start, array.Length);
            }

        }

        //Then Sort BlockB & count no. of elements in blockB
        private int BlockB(int start, int end)
        {
            int j = 0;
            int count = 0;
            for (int i = start; i < end; i++)
            {
                count++;
                int temp = array[i];
                j = i - 1;

                while (j >= start && temp < array[j])
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = temp;
            }
            
            return count;
        }

        //Merge both blocks and make it sort
        private int[] Msort(int start, int mid, int end)
        {
            int b1 = mid;
            int b2 = end;
            //create temp array 
            int[] temp = new int[end];
            // Initial indexes of BlockA and BlockB
            int i = 0, j = mid;
            // Initial index of merged subarry array 
            int k = 0;


            while (i < b1 && j < b2)
            {
                if (array[i] <= array[j])
                {
                    temp[k] = array[i];
                    i++;
                }
                else
                {
                    temp[k] = array[j];
                    j++;
                }
                k++;
            }

            /* Copy remaining elements of array[] if any */
            while (i < b1)
            {
                temp[k] = array[i];
                i++;
                k++;
            }

            ///* Copy remaining elements of array[] if any */
            while (j < b2)
            {
                temp[k] = array[j];
                j++;
                k++;
            }

            return temp;
        }

        //Display unSorted Data which you give as input
        private void DisplayUnSortedData()
        {
            if (!Initilize)
                Console.WriteLine("");
            else
                for (int i = 0; i < length; i++)
                    Console.WriteLine("Index[{0}] = Data[{1}]", i, array[i]);
        }


        //Display Sorted Data in BlockA
        private void DispalySortedBlockA(int end)
        {
            if (!Twohalves)
                Console.WriteLine("");

            else
            {
                Console.WriteLine("\t ****Sorted BlockA");
                for (int i = 0; i < end; i++)
                    Console.WriteLine("Index[{0}] = Data[{1}]", i, array[i]);
            }

        }


        //Display Sorted Data in BloCKB
        private void DisplaySortedBlockB(int start)
        {
            if (!Twohalves)
                Console.WriteLine("");
            else
            {
                Console.WriteLine("\t ****Sorted BlockB");
                for (int i = start; i < array.Length; i++)
                    Console.WriteLine("Index[{0}] = Data[{1}]", i, array[i]);
            }
        }


        //Disply Final Sorted Array
        public void PrintSortedArray()
        {
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
        
    }
}