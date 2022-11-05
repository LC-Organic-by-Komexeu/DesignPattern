using Decoractor;
using System.ComponentModel;

namespace Factory
{
    public interface ITestCase
    {
        public void Init(ConsoleColor color, TestCaseEnum testCaseEnum);
        public void Action();
        public void EndAction();
    }

    public abstract class BaseTestCase : ITestCase
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

    public class FactoryTest : BaseTestCase
    {
        public FactoryTest(ConsoleColor color)
          => base.Init(color, TestCaseEnum.FactoryTest);

        public void Action(TestCaseEnum testCaseEnum = TestCaseEnum.FactoryTest)
        {
            switch (testCaseEnum)
            {
                case TestCaseEnum.DecoractorTest:
                    new DecoractorTest(base._color).Action();
                    break;
                case TestCaseEnum.DesignPattern3:
                    new DesignPattern3(base._color).Action();
                    break;
                default:
                    foreach (var enum_item in Enum.GetValues(typeof(TestCaseEnum)))
                    {
                        var currentCase = (TestCaseEnum)enum_item;
                        if (currentCase == TestCaseEnum.FactoryTest)
                            continue;
                        Action(currentCase);
                    }
                    break;
            }
            EndAction();
        }
    }

    public class DecoractorTest : BaseTestCase
    {
        public DecoractorTest(ConsoleColor color)
          => base.Init(color, TestCaseEnum.DecoractorTest);
        public void Action()
        {
            IDecorator forDecorator = new ForDecorator();
            IDecorator decorator = new Decorator3(new Decorator2(new Decorator1(new Decorator2(forDecorator))));
            EndAction();
        }
    }

    public class DesignPattern3 : BaseTestCase
    {
        public DesignPattern3(ConsoleColor color)
          => base.Init(color, TestCaseEnum.DesignPattern3);
        public void Action()
        {
            Console.WriteLine("Action For DesignPattern3");
            EndAction();
        }
    }
}