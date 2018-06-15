using System;

namespace LinkedLists{
//a singly linked list node = generic type parameter => can store any data type
  public class LinkedListNode<T>{
    #region Fields
    T value;
    LinkedListNode<T> next; //reference to the next node
    #endregion
    
    #region Constructors
    //creates new node with given value and next node
    public LinkedListNode(T value, LinkedListnode<T> next){
      this.value = value;
      this.next = next;
    }
    #endregion
    
    #region Properties
    
    //get the node value
    
    public T Value{
      get {return value; }
    }
    
    //gets and sets the next node
    public LinkedListNode<T> Next{
      get {return next; } //needed to walk the list or traverse the list from the head to the tail 
      set {next = value; } //needed to add or remove nodes from the list
    }
  }

}
