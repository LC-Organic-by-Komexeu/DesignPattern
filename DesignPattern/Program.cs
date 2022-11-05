using Factory;

// Console.WriteLine("假設計模式Test");
// DesignPattern3 designPatternTest = new DesignPattern3(ConsoleColor.Blue);
// designPatternTest.Action();

// Console.WriteLine("裝飾者模式Test");
// DecoractorTest decoractorTest = new DecoractorTest(ConsoleColor.Green);
// decoractorTest.Action();

// Console.WriteLine("使用工廠模式Test");
// FactoryTest factoryTest = new FactoryTest(ConsoleColor.Cyan);
// // factoryTest.Action(TestCaseEnum.DecoractorTest);
// // factoryTest.Action(TestCaseEnum.DesignPattern3);
// factoryTest.Action();

Console.WriteLine("使用裝飾者模式Test");
var forDecorator = new Decoractor.Test.ForTestCase();
Decoractor.Test.ITestCase DecoractorTest =
new Decoractor.Test.DesignPattern3(
        new Decoractor.Test.DecoractorTest(forDecorator, ConsoleColor.Cyan)
    , ConsoleColor.DarkMagenta);