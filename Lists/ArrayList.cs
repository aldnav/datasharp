using System;

// Todo:
// Insert
// Search
// Delete

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
            for (int i = 0; i < array.Length; i++)
            {
                newCollection[i] = array[i];
            }
            array = newCollection;
            newCollection = null;
        }

    }

}
