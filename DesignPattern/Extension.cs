using System.ComponentModel;
using System.Reflection;

public static class Extension
{
    public static string ToDesc(this Enum enumValue)
    {
        FieldInfo fi = enumValue.GetType().GetField(enumValue.ToString());
        if (fi == null) return string.Empty;
        DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
        if (attributes.Any())
            return attributes.First().Description;
        else
            return enumValue.ToString();
    }
}

public enum DecoratorEnum
{
    [Description("ForDecorator(套餐)")]
    ForDecorator,
    [Description("Decorator1(主餐)")]
    Decorator1,
    [Description("Decorator2(附餐)")]
    Decorator2,
    [Description("Decorator3(飲料)")]
    Decorator3
}
public enum TestCaseEnum
{
    [Description("工廠模式")]
    FactoryTest,
    [Description("裝飾者模式")]
    DecoractorTest,
    [Description("DesignPattern 3")]
    DesignPattern3
}