uisng System;
using System.Text;

//a linked list of a data type - parent class for the sorted & unsorted linked lists which contains most of the functionality
namespace LinkedLists{
//abstract class because the add method is abstract
  public abstract class LinkedList<T>{
    protected LinkedListNode<T> head;
    protected int count; //quicker and convinient way to keep track of the count
    
    #region Constructor
    protected LinkedList(){
      head = null;
      count = 0; //start as empty
    }
    #endregion
    
    //gets the number of nodes in the list
    
    public int Count{
      get {
        return count;
      }
    }
    #region Properties
    
    public LinkedListNode<T>Head{
      get {
        return head;
      }
    }
    #end region
    #region Public methods
    
    //abstract add method - an unsorted list can do this much more easily than a sorted list can
    public absrtact void Add(T item);
    
    //removes all the items from the linked list
    public void Clear(){
      //unlink all nodes so they can be garbage collected - if an object in memory has a reference to it, it can't be collected
      if(head != null){
        LinkedListNode<T> previousNode = head;
        LinkedListNode<T> currentNode = head.Next;
        previousNode.Next = null;
        
        //currentNode will be null when get to the end of the list
        while(currentNode != null){
          previousNode = currentNode;
          currentNode = currentNode.Next;
          previousNode.Next = null; //disconnect currentNode from previousNode
        }
      }
      //reset to empty linked list
      head = null;
      count = 0;
    }
    
    //removes the given item from the list
    public bool Remove(T item){
    //can't remove from an empty list
      if(head == null){
        return false;
      }else if(head.Value.Equals(item)){
      //remove from head of list, need to make sure that the linked list still has a head to get to other nodes
        head = head.Next;
        count --;
        return true;
      }else{
      //normal traversal after dealing with special cases
      //keep track of both nodes
        LinkedListNode<T> previousNode = head;
        LinkedListNode<T> currentNode = head.Next;
        while(currentNode != null && !currentNode.Value.Equals(item)){
        //advance through the list if haven't found the item looking for and haven't reached the end
          previousNode = currentNode;
          currentNode = currentNode.Next;
        }
        
        //check for didn't find item
        if(currentNode == null){
          return false;
        }else{
        //set link, reduce count
        // make the reference jump over currentNode => currentNode no longer has a reference to it and it's not part of the list anymore 
          previousNode.Next = currentNode.Next;           
          count--;
          return true;
        }
      }
    }
    
    //finds the given item in the list and returns null if the item wasn't found in the list
    public LinkedListNode<T> Find(T item){
      LinkedListNode<T> currentNode = head;
      while(currentNode != null && currentNode.Value.Equals(item)){
        currentNode = currentNode.Next;
      }
      
      //return node for item if found
      if(currentNode != null){
        return currentNode;
      }else{
        return null; //couldn't find that item in the list
      }
    }
    
    //converts the linked list ot a comma separated string of values
    public override String ToString(){
      StringBuilder builder = new StringBuilder();
      LinkedListNode<T> currentNode = head;
      int nodeCount = 0;
      while(currentNode != null){
        nodeCount++;
        builder.Append(currentNode.Value);
        if(nodeCount < count){
          builder.Append(",");
        }
        currentNode = currentNode.Next;
      }
      return builder.ToString();
    }
  #endregion
  }
}
