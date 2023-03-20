namespace LabDarbas2_19.App_Class
{
    /// <summary>
    /// Class which hold information as LinkedList
    /// </summary>
    public class LinkedInformations
    {
        /// <summary>
        /// Class which holds value and address to other instance of itself
        /// </summary>
        private sealed class Node
        {
            public Information Value { get; set; }
            public Node Address { get; set; }

            /// <summary>
            /// Constructor for Node class object
            /// </summary>
            /// <param name="value">Initial value</param>
            /// <param name="address">Address</param>
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

        /// <summary>
        /// Constructor for LinkedInformations class object
        /// </summary>
        public LinkedInformations()
        {
            Count = 0;
            Head = null;
            Tail = null;
            Selected = null;
        }

        /// <summary>
        /// Adds a new node containing the specified value
        /// </summary>
        /// <param name="value">Specified value</param>
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

        /// <summary>
        /// Removes the first occurrence of the specified value
        /// </summary>
        /// <param name="value">Specified value</param>
        public void Remove(Information value)
        {
            if (Head == null)
            {
                return;
            }

            if (Head.Value.Equals(value))
            {
                Head = Head.Address;
            }
            else
            {
                for (Node node1 = Head; node1 != null; node1 = node1.Address)
                {
                    if (node1.Address != null && node1.Address.Value.Equals(value))
                    {
                        node1.Address = node1.Address.Address;
                    }
                }
            }
        }

        /// <summary>
        /// Sorts the elements of a sequence
        /// </summary>
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

        /// <summary>
        /// Finds the first node that contains the specified value.
        /// </summary>
        /// <param name="value">Specified value</param>
        /// <returns>Value</returns>
        public Information Find(Information value)
        {
            for (Node node1 = Head; node1 != null; node1 = node1.Address)
            {
                if (node1.Value.Equals(value))
                    return node1.Value;
            }
            return null;
        }

        /// <summary>
        /// Determines whether a sequence contains a specified element by using the default equality comparer
        /// </summary>
        /// <param name="value">Speficied element</param>
        /// <returns>True, if contains; otherwise false</returns>
        public bool Contains(Information value)
        {
            for (Node node1 = Head; node1 != null; node1 = node1.Address)
            {
                if (node1.Value.Equals(value))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Sets LinkedList Selected node to Head
        /// </summary>
        public void Begin()
        {
            Selected = Head;
        }

        /// <summary>
        /// Checks if Selected node exists
        /// </summary>
        /// <returns>True, if exists; otherwise false</returns>
        public bool Exists()
        {
            return Selected != null;
        }

        /// <summary>
        /// Sets LinkedList Selected node to Selected node adresss
        /// </summary>
        public void Next()
        {
            Selected = Selected.Address;
        }

        /// <summary>
        /// Returns Selected node value
        /// </summary>
        /// <returns>Value</returns>
        public Information Get()
        {
            return Selected.Value;
        }
    }
}