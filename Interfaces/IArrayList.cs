using HW_3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_3.Interfaces
{
    public interface IArrayList<T> where T : LibraryItem
    {
        void Add(T item);
        void Remove(T item);
        void RemoveAt(int number);
        List<T> GetOnly<TSourse>();

        void RemoveById(int Id);

        List<T> ToList();
    }
}
