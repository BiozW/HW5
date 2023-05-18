class UniqueLinkedList<T> where T : IEquatable<T>
{
    private Node<T> head = null;
    private int length = 0;

    public void Add(T value)
    {
        Node<T> exisitngNode = this.head;

        if(this.head == null)
        {
            Node<T> node = new Node<T>(value);
            this.head = node;
            this.length++;
        }
        else if(!this.SearchNode(value, ref exisitngNode))
        {
            Node<T> node = new Node<T>(value);
            exisitngNode.SetNext(node);
            this.length++;
        }
    }

    public void Remove(T value)
    {
        int nodeIndex = this.SearchNodeIndex(value);
        if(nodeIndex != -1)
        {
            if(nodeIndex == 0)
            {
                this.head = this.head.Next();
            }
            else
            {
                Node<T> ptr = this.GetNode(nodeIndex - 1);
                ptr.SetNext(ptr.Next().Next());
            }
            this.length--;
        }
    }

    private Node<T> GetNode(int index)
    {
        Node<T> ptr = this.head;
        while(index > 0)
        {
            ptr = ptr.Next();
            index--;
        }
        return ptr;
    }

    public T Get(int index)
    {
        return this.GetNode(index).GetValue();
    }

    public int GetLength()
    {
        return this.length;
    }

    private bool SearchNode(T value, ref Node<T> ptr)
    {
        Node<T> nextPtr = ptr;
        while(nextPtr != null)
        {
            if(nextPtr.GetValue().Equals(value))
            {
                return true;
            }
            else
            {
                ptr = nextPtr;
                nextPtr = ptr.Next();
            }
        }
        return false;
    }

    public bool Search(T value)
    {
        Node<T> ptr = this.head;
        while(ptr != null)
        {
            if(ptr.GetValue().Equals(value))
            {
                return true;
            }
            else
            {
                ptr = ptr.Next();
            }
        }
        return false;
    }

    public int SearchNodeIndex(T value)
    {
        int index = -1;
        Node<T> ptr = this.head;
        while(ptr != null)
        {
            index++;
            if(ptr.GetValue().Equals(value))
            {
                break;
            }
            else
            {
                ptr = ptr.Next();
            }
        }
        return index;
    }

    public override string ToString()
    {
        string msg = "";
        for(int i=0; i<this.GetLength(); i++)
        {
            msg += string.Format("{0}, ", this.Get(i));
        }
        msg = string.Format("UniqueLinkedList({0})", msg);
        return msg;
    }
}