namespace Foxy.Flipside.Runtime
{

    public static class ArrayExt
    {

        public static T RandomItem<T>(this T[] items, Rng rng) => items[rng.InRange(0, items.Length - 1)];

    }

}