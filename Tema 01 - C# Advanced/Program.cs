using System;

namespace S1
{
    class Set<T>
    {
        T[] set { get; set; }

        public void Insert(T item)
        {
            if (set == null)
            {
                set = new T[1];
                this.set[0] = item;
            }
            else
            {
                if (Array.Exists(set, el => el.Equals(item)))
                {
                    throw new Exception("set already contains item");
                }
                T[] copy = new T[set.Length + 1];
                set.CopyTo(copy, 0);
                copy[set.Length] = item;
                set = copy;
            }
        }

        //Removes the first occurrence of a specific object from the collection
        public void Remove(T item)
        {
            // set is null?
				// yes - return;
				// no
					// check if elem exists
						// yes - remove it
						// no - cw it doesn t exist
            if (set == null)
            {
                Console.WriteLine("collection is null ");
                return;
            }
            else
            {
                bool ok = false;
                int index = 0;
                for (int i = 0; i < set.Length && ok == false; i++)
                {
                    if (set[i].Equals(item))
                    {
                        index = i;
                        ok = true;
                    }
                }

                if (ok == false)
                {
                    Console.WriteLine("elemen doesn t exist ");
                    return;
                }
                else
                {
                    T[] copy = new T[set.Length - 1];

                    for (int i = 0; i < index; i++)
                    {
                        copy[i] = set[i];
                    }

                    for (int i = index; i < set.Length - 1; i++)
                    {
                        copy[i] = set[i + 1];
                    }
                    set = copy;
                }

            }
        }

        //Contains methods specific to class Array 
        public void Remove2(T item)
        {
            if (set == null)
            {
                Console.WriteLine("collection is null ");
                return;
            }
            int index = Array.FindIndex(set, p => p.Equals(item));
            if (index == -1)
            {
                Console.WriteLine("element doesn t exist ");
                return;
            }
            else
            {
                T[] copy = new T[set.Length - 1];
                Array.Copy(set, 0, copy, 0, index);
                Array.Copy(set, index + 1, copy, index, set.Length - 1 - index);
                set = copy;

            }
        }

        public bool Contains(T item)
        {
            if (set == null)
            {
                Console.WriteLine("collection is null ");
                return false;
            }
            else
            {
                bool ok = false;
                int index = 0;
                for (int i = 0; i < set.Length && ok == false; i++)
                {
                    if (set[i].Equals(item))
                    {
                        index = i;
                        return true;
                    }
                }
                return false;
            }
        }

        public bool Contains2(T item)
        {
            return Array.FindIndex(set, p => p.Equals(item)) != -1;
        }

        public Set<T> Filter(Func<T, bool> condition_func)
        {
            Set<T> filtered_set = new Set<T>();
            foreach (T el in set)
            {
                if (condition_func(el))
                {
                    filtered_set.Insert(el);
                }
            }
            return filtered_set;
        }

        public Set<T> Merge(Set<T> other)
        {
            Set<T> set_copy = new Set<T>();
            set_copy.set = new T[set.Length];
            set.CopyTo(set_copy.set, 0);
            foreach (T el in other.set)
            {
                if (set_copy.Contains(el) == false)
                {
                    set_copy.Insert(el);
                }

            }
            return set_copy;
        }

    }
    class Program
    {

        static void Main(string[] args)
        {

            Set<int> set = new Set<int>();
            set.Insert(2);
            set.Insert(3);

            Set<int> set3 = new Set<int>();
            set3.Insert(3);
            set3.Insert(5);

            Set<int> set4 = set.Merge(set3);

            Set<string> set2 = new Set<string>();
            try
            {
                set2.Insert("aa");
                set2.Insert("bb");
                set2.Insert("cc");
                set2.Insert("aa");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            set2.Remove2("aa");
            set2.Remove2("bb");
            bool test = set2.Contains("dd");
            bool test2 = set2.Contains("bb");

            Func<int, bool> condition_func = x => x % 2==0;
            Set<int> set5 = set4.Filter(condition_func);
            Console.WriteLine("aa");
        }


    }
}
