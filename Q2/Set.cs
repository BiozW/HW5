class Set
{
    private UniqueLinkedList<int>[] listArray;
    private int listCount;
    private int listMaxLength;

    public Set(int maxLength, int listCount)
    {
        this.listCount = listCount;
        this.listMaxLength = (int)Math.Ceiling((double)maxLength/listCount);
        this.listArray = new UniqueLinkedList<int>[this.listCount];
        for(int i=0; i<this.listCount; i++)
        {
            this.listArray[i] = new UniqueLinkedList<int>();
        }
    }

    public void Add(int value)
    {
        if(value > 0 || value <= this.listCount * this.listMaxLength)
        {
            this.listArray[value % this.listCount].Add(value);
        }
    }

    public void Remove(int value)
    {
        if(value > 0 || value <= this.listCount * this.listMaxLength)
        {
            this.listArray[value % this.listCount].Remove(value);
        }
    }

    public bool Search(int value)
    {
        if(value > 0 || value <= this.listCount * this.listMaxLength)
        {
            return this.listArray[value % this.listCount].Search(value);
        }
        return false;
    }

    public override string ToString()
    {
        string msg = "";
        for(int i=0; i<this.listCount; i++)
        {
            for(int j=0; j<this.listArray[i].GetLength(); j++)
            {
                msg += string.Format("{0}, ", this.listArray[i].Get(j));
            }
        }
        msg = string.Format("Set({0})", msg);
        return msg;
    }
}