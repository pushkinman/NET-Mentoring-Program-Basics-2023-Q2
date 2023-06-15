using System;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private DoublyLinkedList<T> _list;

        public HybridFlowProcessor()
        {
            _list = new DoublyLinkedList<T>();
        }

        public T Dequeue()
        {
            if (_list.Length == 0)
                throw new InvalidOperationException("The flow is empty.");

            T item = _list.ElementAt(0);
            _list.RemoveAt(0);
            return item;
        }

        public void Enqueue(T item)
        {
            _list.Add(item);
        }

        public T Pop()
        {
            if (_list.Length == 0)
                throw new InvalidOperationException("The flow is empty.");

            T item = _list.ElementAt(_list.Length - 1);
            _list.RemoveAt(_list.Length - 1);
            return item;
        }

        public void Push(T item)
        {
            _list.Add(item);
        }
    }
}
