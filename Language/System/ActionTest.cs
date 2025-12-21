namespace Language;

using System;
using NUnit.Framework;

public class ActionTest
{
    [Test]
    public void DelegateTest()
    {
        // delegate版
        Action action = delegate
        {
            Console.WriteLine($"{GetType().FullName}.{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
        };
        action?.Invoke();
    }

    [Test]
    public void LambdaTest()
    {
        // ラムダ式 版
        var action = () =>
            Console.WriteLine($"{GetType().FullName}.{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
        action?.Invoke();
    }

    [Test]
    public void Var1Test()
    {
        // var(パターン1) 版
        var action = new Action(delegate()
        {
            Console.WriteLine($"{GetType().FullName}.{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
        });
        action?.Invoke();
    }

    [Test]
    public void Var2Test()
    {
        // var(パターン2) 版
        var action = new Action(() =>
        {
            Console.WriteLine($"{GetType().FullName}.{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
        });
        action?.Invoke();
    }
}