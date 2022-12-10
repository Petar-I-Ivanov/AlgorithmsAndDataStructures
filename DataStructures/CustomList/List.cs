using System;

namespace DataStructures.CustomList
{
    class List<T>
    {
        private static readonly int CAPACITY = 4;

        private T[] list;
        private int count;

        public int Count
        {
            get { return count; }
        }

        public List() {
            count = 0;
            list = new T[CAPACITY];
        }

        public object this[int index]
        {
            get
            {
                BorderCheckInclusive(index);
                return list[index];
            }

            set
            {
                BorderCheckInclusive(index);
                list[index] = (T) value;
            }
        }

        public void Print()
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }

        public void Insert(int index, T value)
        {
            BorderCheckExclusive(index);

            if (count + 1 == list.Length)
            {
                list = ExtendList();
            }

            T[] temp = new T[list.Length];

            for (int i = 0; i < temp.Length; i++)
            {
                if (i < index)
                {
                    temp[i] = list[i];
                }

                else if (i == index)
                {
                    temp[i] = value;
                }

                else
                {
                    temp[i] = list[i - 1];
                }
            }

            list = temp;
            count++;
        }

        public void Add(T value)
        {
            if (count + 1 == list.Length)
            {
                list = ExtendList();
            }

            list[count] = value;
            count++;
        }

        public T RemoveAt(int index)
        {
            BorderCheckInclusive(index);

            T value = default(T);
            T[] temp = new T[list.Length];

            for (int i = 0; i < count; i++)
            {
                if (i < index)
                {
                    temp[i] = list[i];
                }

                else if (i == index)
                {
                    value = list[i];
                    continue;
                }

                else
                {
                    temp[i - 1] = list[i];
                }
            }

            temp[count - 1] = default(T);
            list = temp;
            count--;

            return value;
        }

        public int Remove(T value)
        {
            int index = -1;

            for (int i = 0; i < list.Length; i++)
            {
                if (value.Equals(list[i]))
                {
                    RemoveAt(i);
                    index = i;
                }
            }

            return index;
        }

        public bool Contains(T value)
        {
            for (int i = 0; i < count; i++)
            {
                if (value.Equals(list[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(T value)
        {
            for (int i = 0; i < count; i++)
            {
                if (value.Equals(list[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        private void BorderCheckExclusive(int index)
        {
            if (index > count || index < 0)
                throw new IndexOutOfRangeException("Invalid index");
        }

        private void BorderCheckInclusive(int index)
        {
            if (index >= count || index < 0)
                throw new IndexOutOfRangeException("Invalid index");
        }

        private T[] ExtendList()
        {
            T[] temp = new T[count + CAPACITY];
            CopyList(temp);
            return temp;
        }

        private void CopyList(T[] array)
        {
            for (int i = 0; i < count; i++)
            {
                array[i] = list[i];
            }
        }
    }
}
