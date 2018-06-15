using System;

namespace LinkedLists{
//implement the IComparable interface to keep the order correct
  public class SortedLinkedList<T> : LinkedList<T> where T:IComparable{
    #region Constructors
    
    public SortedLinkedList() : base(){
    }
    
    #endregion
    
    #region Public methods
    
    public override void Add(T item){
      if(head == null){
        head = new LinkedListNode<T>(item, null);
      }else if(head.Value.CompareTo(item) > 0){
      //adding before head
        head = new LinkedListNode<T>(item, head);
      }else{
        //find place to add new node
        LinkedListNode<T> previousNode = null;
        LinkedListNode<T> currentNode = head;
        while(currentNode != null && currentNode.Value.CompareTo(item) < 0){
          previousNode = currentNode;
          currentNode = currentNode.next;
        }
        //link in new node between previous node and current node - the place to put it
        previousNode.next = new LinkedListNode<T>(item, currentNode);
      }
      count++;
    }
    #endregion
  }
}
