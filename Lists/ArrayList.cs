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
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;

            for (int i = 0; i < size; ++i)
            {
                if (comparer.Equals(collection[i], item)) return i;
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
            QuickSort(collection, 0, size);
        }

        private void QuickSort(T[] arr, int lo, int hi) {
            if (arr.Length < 2) {
                return;
            }
            if (lo < hi) {
                var p = Partition(arr, lo, hi);
                QuickSort(arr, lo, p - 1);
                QuickSort(arr, p + 1, hi);
            }
        }

        private int Partition(T[] arr, int lo, int hi) {
            Comparer<T> comparer = Comparer<T>.Default;
            var pivot = arr[hi];  // common practice last el as pivot
            int i = lo - 1;
            for (int j = lo; j < hi - 1; j++)
            {
                var jEl = arr[j];
                if (comparer.Compare(arr[j], pivot) < 0) {
                    i = i + 1;
                    var temp2 = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp2;
                } else if (comparer.Compare(arr[j], pivot) == 0) {
                    i += 1;
                }
            }
            var temp = arr[i + 1];
            arr[i + 1] = arr[hi];
            arr[hi] = temp;
            return i + 1;
        }

    }

}
