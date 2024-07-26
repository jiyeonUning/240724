# 과제 1. 제네릭 주석 달기 과제

이번 수업에서 나왔던 코드를 작성한 후, 각 줄마다 해당 코드의 역할에 대한 주석을 작성한다.

아래로는 강의에서 소개된 예제코드 이다.


    public abstract class Item
    {
        public string Name { get; private set; } 
                                                

        public Item(string name)
        {
            Name = name;
        }
    }

    public class Potion : Item
    {
        public Potion(string name) : base(name) { } 
    }

    public class Inventory<T> where T : Item 
                                           
                                         
    {
        private T[] _list;
        private int _index; 

        public Inventory(int size)
        {
            _list = new T[size];
        }

        public void Add(T item) 
        {
            if (_index < _list.Length) 
            {
                _list[_index] = item;
                _index++;  
            }
        }

        public void Remove()
        {
            if (_index > 0)
            {
                _index--; 
                _list[_index] = null; 
            }
        }

        public void PrintItemNames() 
        {
            Console.WriteLine("아이템 목록 : ");

            foreach (T item in _list)
            {
                if (item != null) 
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
    }


    // =====================================================================================


    public class Program
    {
        static void Main(string[] args)
        {
            Inventory<Potion> potionInventory = new(10); 
                                             

            potionInventory.Add(new Potion("체력 포션"));
            potionInventory.Add(new Potion("마나 포션"));
            potionInventory.Add(new Potion("경험치 포션"));
            potionInventory.Add(new Potion("활력 포션"));

            potionInventory.Remove();
            potionInventory.Remove();

            potionInventory.PrintItemNames(); 
        }
    }
