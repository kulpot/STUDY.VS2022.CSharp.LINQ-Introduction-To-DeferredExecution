using System;
using System.Collections.Generic;

//ref link:https://www.youtube.com/watch?v=V3xx5EvPDAE&list=PL90AF0EFFEF782D27&index=14
// Deferred Execution - exist because of Yield statement

static class MainClass
{
    static IEnumerable<T> Where<T>(this IEnumerable<T> items, Func<T, bool> gauntlet)
    {
        Console.WriteLine("Where");
        foreach (T item in items) 
            if(gauntlet(item))
                yield return item;
    }
    static IEnumerable<R> Select<T, R>(this IEnumerable<T> items, Func<T, R> transform)
    {
        Console.WriteLine("Select");
        foreach (T item in items)
            yield return transform(item);
    }
    static void Main()
    {
        int[] stuff = { 4, 8, 1, 9 };
        IEnumerable<int> result =
            from i in stuff
            where i < 5
            select i + 6;
        IEnumerable<int> rator = result.GetEnumerator();
        while(rator.MoveNext())
            Console.WriteLine(rator.Current);
    }
}