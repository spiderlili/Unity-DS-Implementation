using System;

namespace LinkedLists{
  public class UnsortedLinkedList<T>:LinkedList<T>{
    #region constructors
    //calls the base constructor
    public UnsortedLinknedList():base(){
    }
    #endregion
    
    #region public methods
    //adds the given item to the list
    public override void Add(T item){
      //adding to empty list
      if(head == null){
        head = new LinkedListNode<T>(item, null);
      }else{
      //add to front of list
      //the old head that is now going to be referenced as the 2nd node in the list by the new head, once assigned.
        head = new LinkedListNode<T>(item, head);
      }
      count++;
    }
  }
}
