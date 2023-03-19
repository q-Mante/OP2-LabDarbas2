namespace LabDarbas2_19.App_Class
{
    public class LinkedInformations
    {
        private sealed class Node
        {
            public Information Value { get; set; }
            public Node Address { get; set; }

            public Node(Information value = null, Node address = null)
            {
                Value = value;
                Address = address;
            }
        }

        public int Count { get; private set; }

        private Node Head;
        private Node Tail;
        private Node Selected;

        public LinkedInformations()
        {
            Count = 0;
            Head = null;
            Tail = null;
            Selected = null;
        }

        public void Add(Information value)
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

        public void Remove(Information value)
        {
            // fix
        }

        public void Sort()
        {
            for (Node node1 = Head; node1 != null; node1 = node1.Address)
            {
                Node min = node1;
                for (Node node2 = node1.Address; node2 != null; node2 = node2.Address)
                {
                    if (node2.Value.CompareTo(min.Value) < 0)
                        min = node2;
                }
                (node1.Value, min.Value) = (min.Value, node1.Value);
            }
        }

        public Information Find(Information value)
        {
            for (Node node1 = Head; node1 != null; node1 = node1.Address)
            {
                if (node1.Value.Equals(value))
                    return node1.Value;
            }
            return null;
        }

        public bool Contains(Information value)
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

        public Information Get()
        {
            return Selected.Value;
        }
    }
}