﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class driver
    {
        static void Main(string[] args)
        {
            Random a = new Random();
            FastList<int> list = new FastList<int>(8);
            List<int> goodList = new List<int>(8);

            while (true)
            {
                int whichOne = a.Next(20);
                int num = -1;
                int num2 = -1;
                bool has;
                switch (whichOne)
                {

                    // constructor tests
                    case 0:
                        list = new FastList<int>(8);
                        goodList = new List<int>(8);
                        break;
                    case 1:
                        list = new FastList<int>(list);
                        goodList = new List<int>(goodList);
                        break;
                    case 2:
                        list = new FastList<int>(list.ToArray());
                        goodList = new List<int>(goodList.ToArray());
                        break;
                    // add remove and sort
                    case 3:// add
                        if (goodList.Count < 1000)
                        {
                            num = a.Next(7);
                            list.Add(num);
                            goodList.Add(num);
                        }
                        break;
                    case 4:// remove
                        if (list.Count > 0)
                        {
                            num = a.Next(goodList.Count);
                            list.RemoveAtOrdered(num);
                            goodList.RemoveAt(num);
                        }
                        break;
                    case 5:// sort
                        list.Sort((x, y) => x.CompareTo(y));
                        goodList.Sort((x, y) => x.CompareTo(y));
                        break;
                    // find, add range, get range
                    case 6: //find
                        num = a.Next(7);
                        list.Find(x => x == num);
                        goodList.Find(x => x == num);
                        break;
                    case 7: // add range
                        if (goodList.Count < 1000)
                        {
                            list.AddRange(list);
                            goodList.AddRange(goodList);
                        }
                        break;
                    case 8: // get range
                        num = a.Next(goodList.Count);
                        if(goodList.Count - num-1 >0)
                            num2 = a.Next(goodList.Count - num - 1);
                        if (num2 > 0)
                        {
                            list = list.GetRange(num, num2);
                            goodList = goodList.GetRange(num, num2);
                        }
                        break;
                    // contains, remove all

                    case 9: //contains
                        num = a.Next(goodList.Count);
                        has = list.Contains(num);
                        if (has != goodList.Contains(num))
                        {
                            throw new Exception();

                        }
                        break;
                    case 10: // remove all
                        if (list.Count > 0)
                        {
                            num = a.Next(goodList.Count);
                            list.RemoveAllOrdered(x => x == num);
                            goodList.RemoveAll(x => x == num);
                        }
                        break;
                    case 11: // remove all
                        if (list.Count > 0)
                        {
                            num = a.Next(7);
                            list.RemoveOrdered(num);
                            goodList.Remove(num);
                        }
                        break;
                    case 12: // clear
                        list.Clear();
                        goodList.Clear();
                        break;
                    default:
                        if (goodList.Count < 1000)
                        {
                            num = a.Next(7);
                            list.Add(num);
                            goodList.Add(num);
                        }
                        break;

                }
                if (!list.ToString().Equals(ToString(goodList)))
                {
                    Console.WriteLine("they differ because of " + whichOne + ": " + num + ", " + num2);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Success on: " + whichOne + ": " + num + ", " + num2);
                    Console.WriteLine(list.ToString());
                    Console.WriteLine(ToString(goodList));
                }
                
                
            }
        }
        public static string ToString(List<int> data)
        {
            string builder = "" + data.Count + ": ";
            int count = data.Count;
            if (count == 0)
                return builder;
            for (int i = 0; i < count - 1; i++)
            {
                builder += data[i].ToString() + ", ";
            }
            // if (count - 1 < data.Length) 
            builder += data[count - 1].ToString();
            return builder;
        }
    }
    public class FastList<T> : IEnumerable<T>
    {
        
       
        private T[] data;

        private int count;

        // Reusable enumerator
        public class Enumerator : IEnumerator<T>
        {
            private FastList<T> list;

            private int index;

            private T current;


            public Enumerator(FastList<T> list)
            {
                this.list = list;
                index = -1;
                current = default(T);
            }

            public bool MoveNext()
            {
                //Avoids going beyond the end of the collection.
               do
               {

                    if (++index >= list.Count)
                    {
                        Reset();
                        return false;
                    }
                    else
                    {
                        // Set current box to next item in collection.
                        current = list[index];
                        
                    }
                } while (current == null);
               if (current == null)
               {
                   Environment.Exit(0);
               }
                
                return true;
            }

            public void Reset()
            {
                index = -1;
            }

            void IDisposable.Dispose() { }

            T IEnumerator<T>.Current
            {
                get
                {
                    if (current == null)
                        throw new Exception();
                    return current;
                }
            }

            object System.Collections.IEnumerator.Current
            {
                get {
                    if (current == null)
                        throw new Exception();    
                    return current; 
                }
            }
        }
        public string ToString()
        {
            string builder = "" + count + ": ";
            if (count == 0)
                return builder;
            for (int i = 0; i < count-1; i++)
            {
                builder += data[i].ToString() + ", ";
            }
           // if (count - 1 < data.Length) 
            builder += data[count - 1].ToString();
            return builder;
        }
        public FastList(int size)
        {
            data = new T[size];
        }
        public FastList(T[] data)
        {

            if (data.Length > 0)
            {
                count = data.Length;
                this.data = data;
            }
            else
            {
                Console.WriteLine("this happened");
               this.data = new T[8];
            }
        }
        public FastList(FastList<T> data)
        {
            
            this.data = new T[data.Capacity];
            count = data.Count;
            for (int i = 0; i < count; i++)
            {
                this.data[i] = data[i]; 
            }

        }
        public bool Contains(T obj)
        {
            for (int i = 0; i < Count; i++)
            {
                if (obj.Equals(data[i]))
                {
                    return true;
                }
            }
            return false;
        }
        public FastList<T> GetRange(int index, int count)
        {
            T[] newData = new T[count];
            int total = count+index;
            for (int i = index; i < total; i++)
            {
                newData[i-index] = data[i];
            }
            return new FastList<T>(newData);
        }
        public void AddRange(FastList<T> list)
        {
            if (list != this)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    this.Add(list[i]);
                }
            }
            else
            {
                FastList<T> temp = new FastList<T>(list);
                this.AddRange(temp);
            }
        }
        public void Remove(T obj)// when order of this does not matter
        {
            for (int i = 0; i < Count; i++)
            {
                if (obj.Equals(data[i]))
                {
                    RemoveAt(i);
                    return;
                }
            }
            return;
        }
        public void RemoveAllOrdered(Func<T, bool> what)// when order of this does not matter
        {
            int beforeCount = Count;
            for (int i = 0; i < Count; i++)
            {
                if (what.Invoke(data[i]))
                {
                    RemoveAtOrdered(i);
                    i--;
                }
            }
            if (beforeCount > 1 && count == 0)
            {
                Console.WriteLine();
            }
            return;
        }
        public void RemoveAll(Func<T,bool> what)// when order of this does not matter
        {
            int beforeCount = Count;
            for (int i = 0; i < Count; i++)
            {
                if (what.Invoke(data[i]))
                {
                    RemoveAt(i);
                }
            }
            if (beforeCount > 1 && count == 0)
            {
                Console.WriteLine();
            }
            return;
        }
        public void RemoveOrdered(T obj) // when order of list matters
        {
            for (int i = 0; i < Count; i++)
            {
                if (obj.Equals(data[i]))
                {
                    RemoveAtOrdered(i);
                    return;
                }
            }
            return;
        }
        public void Sort(Func<T, T,int> functionDelegate)
        {
            int beforeCount = Count;
            insertionsort(functionDelegate);
            if (beforeCount > 1 && count == 0)
            {
                Console.WriteLine();
            }
            
        }
        public void insertionsort(Func<T,T,int> functionDelegate) { 
            int inner, upper; 
            T temp;
            upper = Count-1;
            for (int outer = 1; outer <= upper; outer++)
            {
                temp = data[outer];
                inner = outer;
                while (inner > 0 && functionDelegate(data[inner - 1], temp) >= 0)
                {
                    data[inner] = data[inner - 1];
                    inner -= 1;
                }

                data[inner] = temp;
            }
        }
        public T Find(Func<T,bool> functionDelegate)
        {
            int beforeCount = Count;
            for (int i = 0; i < Count; i++)
            {
                if (functionDelegate.Invoke(data[i]))
                    return data[i];
            }
            if (beforeCount != count)
            {
                Console.WriteLine();
            }
            return default(T);
        }
        public void Insert(int location, T obj)
        {
            //count++;
            for (int j = count; j > location; j--)
            {
                data[j] = data[j-1];
            }
            count++;
            data[location] = obj;
            
        }
        public void RemoveRange(int lowIndex, int highIndex)// when order of list does not matter
        {
            int beforeCount = Count;
            for (int i = lowIndex; i < highIndex; i++)
            {
                RemoveAt(i);
            }
            if (beforeCount > 1 && count == 0)
            {
                Console.WriteLine();
            }
        }
        public void RemoveAt(int index)// when order of list does not matter
        {
            count--;
            data[index] = data[count];
        }
        public void RemoveAtOrdered(int index)// when order of list matters
        {
            for (int j = index; j < count-1; j++)
            {
                data[j] = data[j + 1];
            }
           count--;           
        }
        public void Add(T obj)
        {
            if (count < data.Length)
            {
                data[count] = obj;
                count++;
            }
            else
            {
                T[] tmp;
                tmp = new T[data.Length * 2]; //TODO Review
                Array.Copy(data, tmp, data.Length);
                data = tmp;
            }
            
        }

        public void Clear()
        {
            count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public int Capacity
        {
            get
            {
                if (data == null)
                    return 0;
                return data.Length;
            }
        }
        public T[] ToArray()
        {
            T[] newData = new T[count];
            for (int i = 0; i < count; i++)
            {
                newData[i] = data[i];
            }
            return newData;
        }
        public T this[int index]
        {
            get
            {
                if (count <= index)
                    return default(T);
                return this.data[index];
            }
        }


        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }
    }
}
