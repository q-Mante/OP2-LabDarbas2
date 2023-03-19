namespace LabDarbas2_19.App_Class
{
    public class LinkedShops
    {
        private sealed class Node
        {
            public Shop Value { get; set; }
            public Node Address { get; set; }

            public Node(Shop value = null, Node address = null)
            {
                Value = value;
                Address = address;
            }
        }

        public int Count { get; private set; }

        private Node Head;
        private Node Tail;
        private Node Selected;

        public LinkedShops()
        {
            Count = 0;
            Head = null;
            Tail = null;
            Selected = null;
        }

        public void Add(Shop value)
        {
            var newNode = new Node(value);

            if (Head != null)
            {
                Tail.Address = newNode;
                Tail = newNode;
                Count++;
            }
            else
            {
                Head = newNode;
                Tail = newNode;
                Count++;
            }
        }

        public void Remove(Shop value)
        {
            // fix
        }

        public Shop Find(Shop value)
        {
            for (Node node1 = Head; node1 != null; node1 = node1.Address)
            {
                if (node1.Value.Equals(value))
                    return node1.Value;
            }
            return null;
        }

        public bool Contains(Shop value)
        {
            for (Node node1 = Head; node1 != null; node1 = node1.Address)
            {
                if (node1.Value.Equals(value))
                    return true;
            }
            return false;
        }

        public void Begin()
        {
            Selected = Head;
        }

        public bool Exists()
        {
            return Selected != null;
        }

        public void Next()
        {
            Selected = Selected.Address;
        }

        public Shop Get()
        {
            return Selected.Value;
        }
    }
}