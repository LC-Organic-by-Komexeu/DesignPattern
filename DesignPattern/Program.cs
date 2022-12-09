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

// Console.WriteLine("使用裝飾者模式Test");
// var forDecorator = new Decoractor.Test.ForTestCase();
// Decoractor.Test.ITestCase DecoractorTest =
// new Decoractor.Test.DesignPattern3(
//         new Decoractor.Test.DecoractorTest(forDecorator, ConsoleColor.Cyan)
//     , ConsoleColor.DarkMagenta);


Console.WriteLine("使用觀察者模式Test");
var Sub = new Subjection("頻道1");
var Sub1 = new Subjection("頻道2");
var Obs = new Observer("Jhon");
var Obs1 = new Observer("Amy");
var Obs2 = new Observer("May");
var Obs3 = new Observer("Apple");
Sub.RegisterObserver(Obs3);

Sub.Announcement = $"公告:感謝關注{Sub.SubjectionName}";
Sub.UnRegisterObserver(Obs3);
Sub.Announcement = $"公告:{Sub.SubjectionName}公告變更";
Console.WriteLine("==============");
Sub.RegisterObserver(Obs2);
Console.WriteLine("==============");
Sub.RegisterObserver(Obs1);
Sub.Announcement = $"公告:{Sub.SubjectionName}公告變更2";
Console.WriteLine("==============");
Sub.RegisterObserver(Obs);

Console.WriteLine("===============================");
Sub1.RegisterObserver(Obs);
Sub1.Announcement = $"公告:感謝訂閱{Sub1.SubjectionName}";