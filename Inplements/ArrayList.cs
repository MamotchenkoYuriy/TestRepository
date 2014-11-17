using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_3.Interfaces;
using HW_3.Implaments;


namespace HW_3.Implements
{
    //public class ArrayList<T> where T: ILibraryItem
    [Serializable]
    public class ArrayList<T> : IArrayList<T> where T : LibraryItem
    {
        T[] sourseMass;
        public ArrayList()
        {
        }
        public ArrayList(List<T> list)
        {
            sourseMass = list.ToArray();
        }

        public void Add(T item)
        {
            if (sourseMass == null)
            {
                sourseMass = new T[1];
                sourseMass[0] = item;
            }
            else
            {
                T[] newArray = new T[1];
                newArray[0] = item;
                sourseMass = sourseMass.Concat(newArray).ToArray();
            }
        }
        public void Remove(T item)
        {
            sourseMass = sourseMass.Where(m => m.Id != item.Id).ToArray();
        }
        public void RemoveAt(int number)
        {
            if (number >= sourseMass.Length) { return; }
            Remove(sourseMass[number]);
        }
        public List<T> GetOnly<TSourse>()
        {
            if (sourseMass != null)
            {
                return sourseMass.Where(m => m.GetType() == typeof(TSourse)).ToList<T>();
            }
            else return new List<T>();
        }

        public void RemoveById(int Id)
        {
            sourseMass = sourseMass.Where(m => m.Id != Id).ToArray();
        }

        public List<T> ToList()
        {
            if (sourseMass != null)
            {
                return sourseMass.ToList();
            }
            else return new List<T>();
        }
    }
}
