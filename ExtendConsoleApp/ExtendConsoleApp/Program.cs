using System;

namespace ExtendConsoleApp
{
    interface IInterface
    {
        
    }
    interface IPrivateInterface
    {
        
    }

    class BasePrivateClass
    {
        public virtual int Size { get; } = 20;

        private required int Top { get; set; }

        public BasePrivateClass(int size, int top)
        {
            Size = size;
            Top = top;
        }

        public void CallBase()
        {
            Console.WriteLine("CallBase");
        }
    }

    class SecPrivateClass : BasePrivateClass
    {
        //virtual标识方法为 虚方法 可在继承类中进行重写
        public virtual void CallSec()
        {
            Console.WriteLine("CallSec");
        }
    }

    //类 单继承 但支持多接口  结构体只支持多接口
    //System.Object 为基类
    class PrivateClass : SecPrivateClass, IPrivateInterface,IInterface
    {
        private int Age { get; set; }

        public void ConsoleFork()
        {
            this.Age = 1;
        }

        public void CallBase()
        {
            Console.WriteLine("CallBasePrivate");
        }

        public void CallSec()
        {
            Console.WriteLine("CallSecPrivate");
        }

        public override int Size { //set;
                                   get; } //重载基类虚属性
    }

    internal class Program
    {
        internal static void Main(string[] args)
        {
            SecPrivateClass privateClass = new PrivateClass();
            privateClass.CallBase();
            privateClass.CallSec();//子类重载时调用方法为子类 ，修饰符为new / 不加入修饰符 此时调用父类方法 ，当修饰符为 override 时 此时调用子类方法
            var privateClass2 = new PrivateClass();
            privateClass2.CallBase();
            privateClass2.CallSec();//此时调用为子类 重写方法
        }
    }
}