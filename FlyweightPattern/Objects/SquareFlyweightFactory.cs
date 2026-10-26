using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace flyweight_pattern.FlyweightPattern.Objects;

public class SquareFlyweightFactory
{
    private static readonly Dictionary<Color, SquareFlyweight> Cache = new();

    public static SquareFlyweight GetFlyweight(Color color)
    {
        if (!Cache.ContainsKey(color))
            Cache[color] = new SquareFlyweight(color);

        return Cache[color];
    }
}