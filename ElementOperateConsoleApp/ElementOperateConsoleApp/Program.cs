using System.Collections;

namespace ElementOperateConsoleApp
{
    internal class Program
    {
        internal static void Main(string[] args)
        {

            //IStructuralEquatable
            var musicTitles = new MusicTitles(
                new string[] { "Tubular Bells", "Hero Ridge", "War Jia", "Platinum" });
            //foreach(var musicTitle in  musicTitles){
            //    Console.WriteLine(musicTitle);
            //}

            var enumerable = musicTitles.Reverse();

            //foreach (var musicTitle in enumerable)
            //{
            //    Console.WriteLine(musicTitle);
            //}

            var subset = musicTitles.Subset(0,1);

            foreach (var musicTitle in subset)
            {
                Console.WriteLine(musicTitle);
            }

            foreach (int i in ProduceEvenNumbers(9))
            {
                Console.Write(i);
                Console.Write(" ");
            }
            // Output: 0 2 4 6 8

            IEnumerable<int> ProduceEvenNumbers(int upto)
            {
                for (int i = 0; i <= upto; i += 2)
                {
                    yield return i;
                }
            }

            Console.WriteLine(string.Join(" ", TakeWhilePositive(new[] { 2, 3, 4, 5, -1, 3, 4 })));
            // Output: 2 3 4 5

            Console.WriteLine(string.Join(" ", TakeWhilePositive(new[] { 9, 8, 7 })));
            // Output: 9 8 7

            IEnumerable<int> TakeWhilePositive(IEnumerable<int> numbers)
            {
                foreach (int n in numbers)
                {
                    if (n > 0)
                    {
                        yield return n;
                    }
                    else
                    {
                        yield break;
                    }
                }
            }


            int[] ar1 = { 1, 4, 5, 11, 13, 18 };
            int[] ar2 = { 3, 4, 5, 18, 21, 27, 33 };
            var segments = new ArraySegment<int>[2]
            {
                new ArraySegment<int>(ar1, 0, 3),
                new ArraySegment<int>(ar2, 3, 3)
            };
            var sum = SumOfSegments(segments);

            Person[] persons = new Person[4];
            persons[0] = new Person(age: 4, name: "andy1");
            persons[1] = new Person(age: 5, name: "andy2");
            persons[2] = new Person(age: 2, name: "andy3");
            persons[3] = new Person(age: 7, name: "andy4");

            var enumerator = persons.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var enumeratorCurrent = enumerator.Current;
                Console.WriteLine(enumeratorCurrent.ToString());
            }

            Console.WriteLine("-----");

            //数组作为参数可以支持协变，但是只能是引用类型，值类型数组发生报错
            CheckGet(persons);

            Array.Sort(persons, new PersonComparer(PersonCompareType.Age));
            foreach (var person in persons)
            {
                if (person != null)
                {
                    Console.WriteLine($"age: {person.Age} , name: {person.Name}");
                }
            }

            Stu[] students = new Stu[4]
            {
                new Stu("andy", 44),
                new Stu("lucy", 23),
                new Stu("candy", 65),
                new Stu("mark", 12)
            };

            Array.Sort(students);
            foreach (var student in students)
            {
                Console.Write(Convert.ToString(student.Name)+" ");
            }
            Console.WriteLine("");

            int[] unsortedArr = new int[] { 82, 341, 42, 132, 432, 45 };

            //自定义类 需实现IComparable接口且实现compareTo方法
            Array.Sort(unsortedArr);
            for (int i = 0 ; i < unsortedArr.Length;i++)
            {
                Console.Write(" " + Convert.ToString(unsortedArr[i]));
            }
            Console.WriteLine("");

            int[] intArray1 = { 1, 2 };
            int[] intArray2 = (int[])intArray1.Clone();
            Console.WriteLine(intArray2[0]);
            Console.WriteLine(intArray1[0]);
            intArray1[0] = 4;
            Console.WriteLine(intArray2[0]);
            Console.WriteLine(intArray1[0]);

            var personArr = Array.CreateInstance(typeof(Person), new int[] { 2, 3 }, new int[] { 3, 4 });
            for (int i = personArr.GetLowerBound(0); i <= personArr.GetUpperBound(0); i++)
            {
                for (int j = personArr.GetLowerBound(1); j <= personArr.GetUpperBound(1); j++)
                {
                    personArr.SetValue(new Person(i, "name:"+Convert.ToString( j)), new int[] { i, j });   
                }
            }

            PrintValues(personArr);

            Person[,] standardPersonArr = (Person[,])personArr;
            Console.WriteLine(standardPersonArr[3,4]);//此时这里从下表3 开始 长度为2  从4 开始长度为3


            int[] singleWei = new int[] { 1, 2 };
            int[] twoWei = new int[] { 2, 3 };
            var myArray = Array.CreateInstance(typeof(string), singleWei, twoWei);
            for (int i = myArray.GetLowerBound(0); i <= myArray.GetUpperBound(0); i++)
            {
                for (int j = myArray.GetLowerBound(1); j <= myArray.GetUpperBound(1); j++)
                {
                    int[] myIndicesArray = new int[2] { i, j };
                    myArray.SetValue(Convert.ToString(i) + j, myIndicesArray);
                }
            }
            PrintValues(myArray);


            var twoGenInstance = Array.CreateInstance(typeof(string),2,3);
            for (int i = twoGenInstance.GetLowerBound(0); i <= twoGenInstance.GetUpperBound(0); i++)
            {
                for (int j = twoGenInstance.GetLowerBound(1); j <= twoGenInstance.GetUpperBound(1); j++)
                {
                    twoGenInstance.SetValue(i+5 + "---" + j+5, new int[] { i, j });
                }
            }
            //PrintValues(twoGenInstance);

            int[] singleLen = new int[] { 2, 3 };
            var twoGenArr = Array.CreateInstance(typeof(string),singleLen);
            for (int i = twoGenArr.GetLowerBound(0); i <= twoGenArr.GetUpperBound(0); i++)
            {
                for (int j = twoGenArr.GetLowerBound(1); j <= twoGenArr.GetUpperBound(1); j++)
                {
                    twoGenArr.SetValue(i+"---"+j,new int[]{i,j});
                }
            }

            //PrintValues(twoGenArr);

            //创建数组
            Int32[] instance = (Int32[])Array.CreateInstance(typeof(Int32),6);
            for (int i = instance.GetLowerBound(0) ; i <= instance.GetUpperBound(0); i++)
            {
                instance.SetValue((int)Math.Pow(i,3),i);
            }
            for (int i = 0; i < instance.Length; i++)
            {
                Console.WriteLine(instance.GetValue(i));
            }

            //PrintValues(instance);

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

        static int SumOfSegments(ArraySegment<int>[]? segments)
        {
            int sum = 0;
            foreach (var segment in segments)
            {
                for (int i = segment.Offset; i < segment.Offset + segment.Count; i++)
                {
                    sum += segment.Array[i];
                }
            }
            return sum;
        }

        public static void PrintValues(Array myArr)
        {
            System.Collections.IEnumerator myEnumerator = myArr.GetEnumerator();
            int i = 0;
            int cols = myArr.GetLength(myArr.Rank - 1);
            while (myEnumerator.MoveNext())
            {
                if (i < cols)
                {
                    i++;
                }
                else
                {
                    Console.WriteLine();
                    i = 1;
                }
                Console.Write("\t{0}", myEnumerator.Current);
            }
            Console.WriteLine();
        }

        public static void CheckGet(object[] array)
        {
            PrintValues(array);
        }
    }

    public enum PersonCompareType
    {
        Name,
        Age
    }

    public class MusicTitles
    {
        string[] Names;

        public MusicTitles(string[] names)
        {
            Names = names;
        }

        public IEnumerator<string> GetEnumerator()
        {
            for (int i = 0; i < 4; i++)
            {
                yield return Names[i];
            }
        }
        public IEnumerable<string> Reverse()
        {
            for (int i = 3; i >= 0; i --)
            {
                yield return Names[i];
            }
        }
        public IEnumerable<string> Subset(int index, int length)
        {
            for (int i = index; i < index + length; i++)
            {
                yield return Names[i];
            }
        }
    }

    class Stu : IComparable<Stu>
    {
        public string Name;

        public int Age;

        public int CompareTo(Stu? other)
        {
            return this.Age.CompareTo(other?.Age);
        }

        public Stu(string
            name, int age)
        {
            Name = name;
            Age = age;
        }
    }


    class Person : IEquatable<Person>
    {
        public int Id { get; private set; }

        public int Age { get; }

        public string Name { get; }

        public Person(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }

        public override string ToString() => $"{Id}, {Name} {Age}";

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return base.Equals(obj);
            }
            return Equals(obj as Person);
        }

        public override int GetHashCode() => Id.GetHashCode();


        public bool Equals(Person? other)
        {
            if (other == null)
                return base.Equals(other);
            return Id == other.Id && Name == other.Name &&
                   Age == other.Age;
        }
    }

    class PersonComparer : IComparer<Person>
    {
        private readonly PersonCompareType _compareType;
        public PersonComparer(PersonCompareType compareType)
        {
            _compareType = compareType;
        }
        public int Compare(Person? x, Person? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return 1;
            if (y == null) return -1;
            switch (_compareType)
            {
                case PersonCompareType.Name:
                    return String.CompareOrdinal(x.Name, y.Name);
                case PersonCompareType.Age:
                    return x.Age - y.Age;
                default:
                    throw new ArgumentException("unexpected compare type");
            }
        }
    }
}