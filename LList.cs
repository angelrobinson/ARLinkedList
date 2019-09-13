﻿/*
 * Name: Angela Robinson
 * Class: CSC382 Data Structures and Alghorithms
 * Date: 9/13/2019
 * Assignment: Linked List
 * Assignment Description:
 *  Implement a templated (generics) doubly-linked list.  Your linked list class should implement the following functionality:
 *  Find(dataToFind) – returns a pointer to the node whose key matches dataToFind.
 *  Insert(newData) – inserts a new node at the end of the list with a key equal to newData
 *  Delete(delNode)- deletes the node that delNode points to from the list.
 *  For extra credit, implement a function that finds the Minimum and Maximum values in your linked list.
 *  Minimum() – returns the minimum key in the list
 *  Maximum() –returns the maximum key in the list
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARLinkedList
{

    /// <summary>
    /// LList is a generic class that allows you to make a list that has links to both previous and next nodes on the list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LList<T>
    {
        /// <summary>
        /// nest class of a node to use with the LList
        /// </summary>
        public class LListNode
        {
            //variables are private by default. 
            //they can only be accessed through properties
            T item;
            LListNode next;
            LListNode previous;


            /// <summary>
            /// Item property gets and sets the item variable. 
            /// It is set with the generic 'T' datavalue to allow for all types
            /// </summary>
            public T Item
            {
                get { return item; }
                set { item = value; }
            }

            /// <summary>
            /// Next property gets and sets the next node of the list
            /// </summary>
            public LListNode Next
            {
                get { return next; }
                set { next = value; }
            }

            /// <summary>
            /// Prev property gets and sets the previous node of the list
            /// </summary>
            public LListNode Prev
            {
                get { return previous; }
                set { previous = value; }
            }

            /// <summary>
            /// Default constructor for the Node nested class.
            /// </summary>
            /// <param name="dataType">The data type that is passed into the LList T parameter</param>
            public LListNode(T dataType)
            {
                //when a node is initially made, 
                //we need to save the date into the node
                item = dataType;

                //next we put a default value to the next and previous nodes. 
                next = null;
                previous = null;

            }


        }

        //private variables of the LList<T> class
        LListNode first;
        LListNode last;
        LListNode current;
        int count;

        /// <summary>
        /// default constructor
        /// </summary>
        public LList()
        {
            first = default;
            last = default;
            current = default;
        }

        /// <summary>
        /// Allows list to be able to iterate forward when accessing in a loop
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> CountForward()
        {
            current = first;

            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
            
        }

        /// <summary>
        /// Allows list ot be able to iterate backward when accessing in a loop
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> CountBack()
        {
            current = last;

            while (current != null)
            {
                yield return current.Item;
                current = current.Prev;
            }
        }

        /// <summary>
        /// Compares Node items in list to findItem and returns the item if it is in the list or default if it doesn't
        /// </summary>
        /// <param name="findItem"></param>
        public LListNode Find(T findItem)
        {
            for (int i = 0; i < count - 1; i++)
            {
                current = first;
                if (current.Item.Equals(findItem))
                {
                    //found = true;
                    //break;
                    return current;
                }
            }

            return null;
        }

        /// <summary>
        /// Add new node at the beginning of the list
        /// </summary>
        /// <param name="firstItem">data that is to be added to the beginning of the list</param>
        public void AddFirst(T firstItem)
        {
            //create new node with the firstItem data
            LListNode toAdd = new LListNode(firstItem);

            //since this node is being added to the beginning of the list, the previous node does not need to be assigned
            //because when we created the node, the next and previous nodes automatically is set to null.
            //toAdd.Prev = null;

            //check to see if there is already a first node
            if (first != null)
            {
                //since this node is being added to the beginning of the list, the next node needs to be the orignal first node
                toAdd.Next = first;

                //add reference to the new node as the previous of the original first node
                first.Prev = toAdd;
            }
            else
            {
                //if this is the first node to be added to the list then the next node is null
                toAdd.Next = null;

                //and we need to make the new node the last node of the list
                last = toAdd;
            }
            
            //make the new node the first node of the list
            first = toAdd;

            //increase the count of the List
            count++;
        }

        /// <summary>
        /// Add new node at the end of the list
        /// </summary>
        /// <param name="lastItem">data that is to be added to the end of the list<</param>
        public void AddBack(T lastItem)
        {
            //create new node with the lastItem data
            LListNode toAdd = new LListNode(lastItem);

            //since this node is being added to the end of the list, the next node does not need to be assigned
            //because when we created the node, the next and previous nodes automatically is set to null.

            //check to see if there is already a last node
            if (last != null)
            {
                //since this node is being added to the end of the list, the prev node needs to be the orignal last node
                toAdd.Prev = first;

                //add reference to the new node as the next of the original last node
                last.Next = toAdd;
            }
            else
            {
                //if this is the first node to be added to the list then the previous and next node is null
                //and we need to make the new node the last node of the list
                last = toAdd;
            }

            //make the new node the first node of the list
            first = toAdd;

            //increase the count of the List
            count++;
        }
        public void Delete(T delItem)
        {
            for (int i = 0; i < count -1; i++)
            {
                current = first;
                if (current.Item.Equals(delItem))
                {
                    //copy the node to be deleted into a temp variable
                    var toDelete = current;

                    //update the next and previous references to the two nodes on either side of the node to be deleted
                    current.Next.Prev = current.Prev;
                    current.Prev.Next = current.Next;

                    //remove the references of the next and previous nodes on the node to be deleted
                    toDelete.Next = default;
                    toDelete.Prev = default;

                    
                }
            }

            

            //decrease the list node count
            count--;
        }
        public void Min()
        {
            //set starting point at beginning of list
            current = first;

            //create temp minimum
            var min = current;

            for (int i = 0; i < count -1; i++)
            {

            }
        }
        public void Max() { }
    }
}
