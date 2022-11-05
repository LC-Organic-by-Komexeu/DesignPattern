namespace Decoractor.Test
{
    public interface ITestCase
    {
        public void Init(ConsoleColor color, TestCaseEnum testCaseEnum);
        public void Action();
        public void EndAction();
        public string GetCruuentDesignPattern();
    }

    public class ForTestCase : ITestCase
    {
        TestCaseEnum _testCaseEnum { get; set; }
        protected ConsoleColor _color { get; set; }
        public void Init(ConsoleColor color, TestCaseEnum testCaseEnum)
        {
            _color = color;
            Console.ForegroundColor = _color;
            _testCaseEnum = testCaseEnum;

            Console.WriteLine($"=====================================================");
            Console.WriteLine($"Here is 【{GetCruuentDesignPattern()}】");
        }
        public void Action() { }
        public void EndAction() => Console.ResetColor();
        public string GetCruuentDesignPattern() => _testCaseEnum.ToDesc();
    }

    public abstract class BaseTestCase : ITestCase
    {
        ITestCase _itestCase { get; set; }
        TestCaseEnum _testCaseEnum { get; set; }
        protected ConsoleColor _color { get; set; }
        public BaseTestCase(ITestCase itestCase)
        {
            _itestCase = itestCase;
        }

        public void Init(ConsoleColor color, TestCaseEnum testCaseEnum)
        {
            _itestCase.Init(color, testCaseEnum);
        }
        public void Action() => _itestCase.Action();
        public void EndAction() => _itestCase.EndAction();
        public string GetCruuentDesignPattern() => _itestCase.GetCruuentDesignPattern();
    }

    public class FactoryTest : BaseTestCase
    {
        public FactoryTest(ITestCase itestCase, ConsoleColor color) : base(itestCase)
        {
            base.Init(color, TestCaseEnum.FactoryTest);
            Action();
        }

        public void Action()
        {
            Console.WriteLine("Action For FactoryTest");
            base.Action();
            EndAction();
        }
    }

    public class DecoractorTest : BaseTestCase
    {
        public DecoractorTest(ITestCase itestCase, ConsoleColor color) : base(itestCase)
        {
            base.Init(color, TestCaseEnum.DecoractorTest);
            Action();
        }
        public void Action()
        {
            IDecorator forDecorator = new ForDecorator();
            IDecorator decorator = new Decorator3(new Decorator2(new Decorator1(new Decorator2(forDecorator))));
            EndAction();
        }
    }

    public class DesignPattern3 : BaseTestCase
    {
        public DesignPattern3(ITestCase itestCase, ConsoleColor color) : base(itestCase)
        {
            base.Init(color, TestCaseEnum.DesignPattern3);
            Action();
        }
        public void Action()
        {
            Console.WriteLine("Action For DesignPattern3");
            base.Action();
            EndAction();
        }
    }
}