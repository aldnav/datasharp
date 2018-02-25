using System;
using datasharp.Lists;

namespace datasharp
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList<int> arr = new ArrayList<int>();

            arr.Add(5);
            arr.Add(2);
            arr.Add(3);
            arr.Add(1);

            System.Console.WriteLine(arr);

            System.Console.WriteLine(arr.Search(3));
            System.Console.WriteLine(arr.Search(4));

            arr.Remove(2);
            System.Console.WriteLine(arr);

            arr.Remove(5);
            arr.Remove(3);
            arr.Remove(1);
            arr.Remove(2);
        }
    }
}
