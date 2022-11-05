namespace Decoractor{
//點餐規則
public interface IDecorator
{
    public void StartUp();
    public void AddDecorator(DecoratorEnum decoratorEnum);
    public void GetDecorators();
    public bool IsHavingCurrentType(DecoratorEnum decoratorEnum);
}

//套餐
public class ForDecorator : IDecorator
{
    List<DecoratorEnum> DecoratorList { get; set; } = new List<DecoratorEnum>();
    public void StartUp()
    {
        Console.Write($"I'm {DecoratorEnum.ForDecorator.ToDesc()},");
    }
    public void AddDecorator(DecoratorEnum decoratorEnum) => DecoratorList.Add(decoratorEnum);
    public void GetDecorators()
    {
        Console.WriteLine($"Here is your {DecoratorEnum.ForDecorator.ToDesc()} :");
        DecoratorList.ForEach(x => Console.WriteLine($"I have Decorator => {x.ToDesc()}"));
    }
    public bool IsHavingCurrentType(DecoratorEnum decoratorEnum)
    {
        if (DecoratorList.Contains(decoratorEnum))
        {
            var currentColor=Console.ForegroundColor;
            Console.ForegroundColor=ConsoleColor.Red;
            Console.WriteLine($"You are having type:【{decoratorEnum.ToDesc()}】");
            Console.ForegroundColor=currentColor;
            return true;
        }
        else return false;
    }
}

//餐點模板
public class BaseDecorator : IDecorator
{
    IDecorator _decorator { get; set; }
    public BaseDecorator(IDecorator decorator)
    {
        _decorator = decorator;
    }
    public void StartUp()
    {
        _decorator.StartUp();
    }
    public void AddDecorator(DecoratorEnum decoratorEnum) => _decorator.AddDecorator(decoratorEnum);
    public void GetDecorators() => _decorator.GetDecorators();
    public bool IsHavingCurrentType(DecoratorEnum decoratorEnum) => _decorator.IsHavingCurrentType(decoratorEnum);
}

//主餐(ex:大麥克/卡拉雞腿堡)
public class Decorator1 : BaseDecorator
{
    public Decorator1(IDecorator decorator) : base(decorator)
    {
        StartUp();
    }
    public void StartUp()
    {
        base.StartUp();
        Console.WriteLine($"I got 【{DecoratorEnum.Decorator1.ToDesc()}】");
        if (!base.IsHavingCurrentType(DecoratorEnum.Decorator1))
            base.AddDecorator(DecoratorEnum.Decorator1);
        base.GetDecorators();
        Console.WriteLine();
    }

}

//附餐(ex:雞塊/薯條)
public class Decorator2 : BaseDecorator
{
    public Decorator2(IDecorator decorator) : base(decorator)
    {
        StartUp();
    }
    public void StartUp()
    {
        base.StartUp();
        Console.WriteLine($"I got 【{DecoratorEnum.Decorator2.ToDesc()}】");
        if (!base.IsHavingCurrentType(DecoratorEnum.Decorator2))
            base.AddDecorator(DecoratorEnum.Decorator2);
        base.GetDecorators();
        Console.WriteLine();
    }
}

//飲料(ex:可樂/檸檬紅茶)
public class Decorator3 : BaseDecorator
{
    public Decorator3(IDecorator decorator) : base(decorator)
    {
        StartUp();
    }
    public void StartUp()
    {
        base.StartUp();
        Console.WriteLine($"I got 【{DecoratorEnum.Decorator3.ToDesc()}】");
        if (!base.IsHavingCurrentType(DecoratorEnum.Decorator3))
            base.AddDecorator(DecoratorEnum.Decorator3);
        base.GetDecorators();
        Console.WriteLine();
    }
}}