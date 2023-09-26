namespace ObjectConsoleApp
{
    struct ObjectStruct //结构通常存储在栈上 类通常存储堆 创建实例都是通过new关键字 类通过引用传入 / 结构值传入
    {
        public int Value { get; set; }
    }

    internal class PhoneCustomer
    {

        public int Age { get; set; } = 42;//自动实现属性初始化

        public string? LastName
        {
            /* protected .*/
            get;
            private set;
            //gets/set设置不同的修饰符 ,且必须有一个方法可对外访问，否则会报编译错误
        }

        public string? FirstName { get; set; }

        public string? Say()
        {
            return FirstName;
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            var phoneCustomer = new PhoneCustomer
            {
                FirstName = "andy"
            };
            Console.WriteLine(phoneCustomer.Say());
        }
    }
}

