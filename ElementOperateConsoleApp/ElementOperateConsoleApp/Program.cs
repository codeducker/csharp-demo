namespace ElementOperateConsoleApp
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            //多维数组
            int[,] mutiArray = new int[3,4];
            Console.WriteLine(mutiArray[2,3]);

            //锯齿数组
            int[][] gArray = new int[3][];
            gArray[0] = new int[2] { 1, 2 };
            gArray[1] = new int[3];//需要先初始化
            gArray[1][0] = 2;
            for (var i = 0; i < gArray.Length; i++)
            {
                if (gArray[i] != null)
                {
                    for (int j = 0; j < gArray[i].Length; j++)
                    {
                        Console.WriteLine(gArray[i][j]);
                    }
                }
            }

            Person[] persons = new Person[2];
            persons[0] = new Person(age: 1, name: "andy");
            foreach (var person in persons)
            {
                if (person != null)
                {
                    Console.WriteLine($"age: {person.Age} , name: {person.Name}");
                }
            }

            int[] integers = new int[3]{1,23,4};
            Console.WriteLine(integers);

            string[] targets = { "her", "is", "body" };
            for (int i = targets.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(targets[i]);
            }

            //数组引用类型
            object[] array = new object[10];
            array[0] = 1;
            array[1] = "hello";
            foreach (var o in array)
            {
                Console.WriteLine(o);
            }
        }
    }

    class Person
    {
        public int Age { get; }

        public string Name { get; }

        public Person(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }
    }
}