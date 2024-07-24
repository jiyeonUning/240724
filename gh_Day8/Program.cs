namespace gh_Day8
{

    // 과제 1. 제네릭 주석 달기 과제
    // 이번 수업에서 나왔던 코드를 작성한 후, 각 줄마다 해당 코드의 역할에 대한 주석을 작성한다.


    public abstract class Item // = 추상클래스 생성
    {
        public string Name { get; private set; }

        public Item(string name)
        {
            Name = name;
        }
    }

    public class Potion : Item  // 추상클래스를 상속받는 '포션' 자식클래스
    {
        public Potion(string name) : base(name) { }  // 이름이 초기화 될 수 있도록 생성자 생성
    }

    public class Inventory<T> where T : Item // 인벤토리 클래스 : 클래스를 제네릭 타입으로 설정.
                                             // : where T : ~ 을 통해 사용 제약을 걺으로써, Item의 자식 클래스만 입력이 가능하도록 설정
                                             // = '아이템 목록 출력 메서드' 에서, 해당 메서드가 적용이 가능한 형식에서만 사용할 수 있게 해준 것
    {
        private T[] _list;  // 아이템을 담아둘 배열을 선언
        private int _index; // 배열이 현재 가리키고 있는, 데이터를 저장할 수 있는 정수형의 변수를 선언

        public Inventory(int size) // 배열 인스턴스 생성
        {
            _list = new T[size];
        }

        public void Add(T item) // = 아이템 추가 메서드
        {
            if (_index < _list.Length)  // = _index가 배열의 길이 내부에 있을 때만 가능하도록, if문 사용
            {
                _list[_index] = item; // 칸에 아이템을 넣고
                _index++;   // 한칸을 더 만든다
            }
        }

        public void Remove() // = 아이템 삭제 메서드
        {
            if (_index > 0)
            {
                _index--; // 한 칸을 지우고
                _list[_index] = null; // 칸의 값을 null, 즉 없는 것으로 만든다
            }
        }

        public void PrintItemNames() // 아이템 목록 출력 메서드
        {
            Console.WriteLine("아이템 목록 : ");

            foreach (T item in _list) // = 배열을 순회하여 목록을 출력한다.
            {
                if (item != null) // null, 즉 아이템이 없는 경우를 제외하는 if문 작성해서 현재 가지고 있는 아이템만 출력할 수 있게 한다.
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
    }


    // =====================================================================================


    public class Program
    {
        static void Main(string[] args) // = 동작 확인을 위한 Main
        {
            Inventory<Potion> potionInventory = new(10); // 일반화 클래스의 인스턴스 생성.
                                                         // IF : < >의 class가 Item을 상속받지 않았다면, 인스턴스를 생성할 수 없다.

            potionInventory.Add(new Potion("체력 포션")); // 아이템 추가
            potionInventory.Add(new Potion("마나 포션"));
            potionInventory.Add(new Potion("경험치 포션"));
            potionInventory.Add(new Potion("활력 포션"));

            potionInventory.Remove(); // 아이템 삭제
            potionInventory.Remove();

            potionInventory.PrintItemNames(); // 아이템 목록 출력
        }
    }
}