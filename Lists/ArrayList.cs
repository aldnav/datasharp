using System;
using System.Collections.Generic;
using System.Text;


namespace datasharp.Lists
{

    public class ArrayList<T> {

        private T[] collection;  // the internal array
        private int size = 0;

        public ArrayList() : this(capacity: 0) { }

        public ArrayList(int capacity) {
            collection = new T[capacity];
            size = 0;
        }

        public void Add(T item) {
            if (size == collection.Length)
            {
                Resize(ref collection, size+1);
            }
            collection[size++] = item;
        }

        public void AddAt(T item, int index) {
            if (index < 0 || index > size + 1) {
                return;
            }

            collection[index] = item;
            size++;
        }

        public void Resize(ref T[] array, int newSize) {
            T[] newCollection = new T[newSize];
            for (int i = 0; i < size; i++)
            {
                newCollection[i] = array[i];
            }
            array = newCollection;
            newCollection = null;
        }

        public int Search(T item) {
            // return LinearSearch(collection, item, size);
            return BinarySearch(collection, item, 0, size - 1);
        }

        private int BinarySearch(T[] arr, T item, int lo, int hi) {
            if (hi < lo) {
                return -1;
            }
            int pivot = (hi + lo) / 2;
            Comparer<T> comparer = Comparer<T>.Default;
            if (comparer.Compare(arr[pivot], item) > 0) {
                return BinarySearch(arr, item, lo, pivot - 1);
            } else if (comparer.Compare(arr[pivot], item) < 0) {
                return BinarySearch(arr, item, pivot + 1, hi);
            }
            return pivot;
        }

        private int LinearSearch(T[] arr, T item, int size) {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;

            for (int i = 0; i < size; ++i)
            {
                if (comparer.Equals(arr[i], item)) return i;
            }
            return -1;
        }

        public bool Remove(T item)
        {
            int indexToRemove = Search(item);
            if (indexToRemove >= 0) {
                RemoveAt(indexToRemove);
                return true;
            }
            return false;
        }

        public void RemoveAt(int index) {
            for (int i = index; i < size - 1; i++)
            {
                collection[i] = collection[i+1];
            }
            size--;
        }

        public override string ToString()
        {
            StringBuilder repr = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                repr.Append(String.Format(" {0}", collection[i].ToString()));
            }
            return repr.ToString();
        }

        public void Sort() {
            // uses QuickSort algorithm
            QuickSort(collection, 0, size - 1);
        }

        private void QuickSort(T[] arr, int left, int right) {
            // Dutch National Flag implementation of quick sort
            if (arr.Length < 2) {
                return;
            }
            int i = left;
            int j = right;
            T pivot = arr[left + (right - left) / 2];
            Comparer<T> comparer = Comparer<T>.Default;

            while (i <= j) {
                while (comparer.Compare(arr[i], pivot) < 0) i++;
                while (comparer.Compare(arr[j], pivot) > 0) j--;

                if (i <= j) {
                    T tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;
                    i++;
                    j--;
                }
            }

            if (left < j) QuickSort(arr, left, j);
            if (i < right) QuickSort(arr, i, right);
        }

        public int Length { get => size; }
        public T[] Collection { get => collection; set => collection = value; }

        public static void Reverse(ArrayList<T> arr)
        {
            for (int i = 0; i < arr.Length / 2; i++)
            {
                var temp = arr.Collection[i];
                arr.Collection[i] = arr.collection[arr.Length - 1 - i];
                arr.Collection[arr.Length - 1 - i] = temp;
            }
        }

        public static ArrayList<T> Merge(ArrayList<T> arr1, ArrayList<T> arr2) {
            ArrayList<T> arr3 = new ArrayList<T>(arr1.Length + arr2.Length);
            int arr1Bound = arr1.Length;
            int arr2Bound = arr2.Length;
            int i = 0, j = 0, k = 0;
            Comparer<T> comparer = Comparer<T>.Default;

            while (i < arr1Bound && j < arr2Bound) {
                if (comparer.Compare(arr1.Collection[i], arr2.Collection[j]) < 0) {
                    arr3.AddAt(arr1.Collection[i++], k++);
                } else {
                    arr3.AddAt(arr2.Collection[j++], k++);
                }
            }

            while (i < arr1Bound)
                arr3.AddAt(arr1.Collection[i++], k++);
            while (j < arr2Bound)
                arr3.AddAt(arr2.Collection[j++], k++);

            return arr3;
        }

    }

}
