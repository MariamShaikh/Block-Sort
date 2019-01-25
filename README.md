# Block-Sort
Implementation of Block Sort 
This c# implementation of Block Sort has been completed by:
Maaz Khan (17b-012-CS)
Mariam Shaikh (17b-062-CS)
Syeda Ayman Maqsood (17b-013-CS)


Block sort basically uses insertion and merge sort to sort a given array. First a linear search is performed, which checks if the given array is already sorted or not. If the linear search gives a false result, the original array is divided, resulting in two blocks A & B. these blocks are sorted using insertion sort. Subarrays are further divided, taking the square root of the size of the original array.
Merge operation is applied on both the blocks (A & B), which sorts the array completely. 
This code works efficiently on large sizes of data.

Thank you. 

