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

    }

}
