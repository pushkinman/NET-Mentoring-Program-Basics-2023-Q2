using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private DoublyLinkedListNode<T> _head;
        private DoublyLinkedListNode<T> _tail;
        private int _count;

        public int Length => _count;

        public void Add(T e)
        {
            var newNode = new DoublyLinkedListNode<T>(e);

            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                newNode.Previous = _tail;
                _tail = newNode;
            }

            _count++;
        }

        public void AddAt(int index, T e)
        {
            if (index < 0 || index > _count)
                throw new IndexOutOfRangeException();

            if (index == _count)
            {
                Add(e);
                return;
            }

            var newNode = new DoublyLinkedListNode<T>(e);

            if (index == 0)
            {
                newNode.Next = _head;
                _head.Previous = newNode;
                _head = newNode;
            }
            else
            {
                var current = GetNodeAt(index);
                var previous = current.Previous;

                newNode.Next = current;
                newNode.Previous = previous;
                previous.Next = newNode;
                current.Previous = newNode;
            }

            _count++;
        }

        public T ElementAt(int index)
        {
            var node = GetNodeAt(index);
            return node.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public void Remove(T item)
        {
            var current = _head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, item))
                {
                    RemoveNode(current);
                    return;
                }

                current = current.Next;
            }
        }

        public T RemoveAt(int index)
        {
            var nodeToRemove = GetNodeAt(index);
            RemoveNode(nodeToRemove);
            return nodeToRemove.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private DoublyLinkedListNode<T> GetNodeAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException();

            var current = _head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current;
        }

        private void RemoveNode(DoublyLinkedListNode<T> node)
        {
            var previous = node.Previous;
            var next = node.Next;

            if (previous == null)
            {
                _head = next;
            }
            else
            {
                previous.Next = next;
                node.Previous = null;
            }

            if (next == null)
            {
                _tail = previous;
            }
            else
            {
                next.Previous = previous;
                node.Next = null;
            }

            _count--;
        }
    }

    public class DoublyLinkedListNode<T>
    {
        public T Value { get; }
        public DoublyLinkedListNode<T> Next { get; internal set; }
        public DoublyLinkedListNode<T> Previous { get; internal set; }

        public DoublyLinkedListNode(T value)
        {
            Value = value;
        }
    }
}
