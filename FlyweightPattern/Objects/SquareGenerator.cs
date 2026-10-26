using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace flyweight_pattern.FlyweightPattern.Objects;

public class SquareGenerator
{
    private bool flyweight = false;
    public List<Square> Squares;
    public List<SquareF> SquaresF;

    private Random _random;
    private readonly float _spawnCooldown;
    private float _spawnRate;
    
    public SquareGenerator()
    {
        Squares = new();
        SquaresF = new();
        _random = new();
        _spawnCooldown = 0.05f;
        _spawnRate = 0f;
    }

    public void Update()
    {
        _spawnRate += Globals.Time;
        SpawnSquare();

        if (!flyweight)
            foreach (Square square in Squares)
                square.Update();
        
        if (flyweight)
            foreach (SquareF square in SquaresF)
                square.Update();
    }

    public void Draw()
    {
        if (!flyweight)
            foreach (Square square in Squares)
                square.Draw();
        
        if (flyweight)
            foreach (SquareF square in SquaresF)
                square.Draw();
    }

    private void SpawnSquare()
    {
        if (_spawnRate >= _spawnCooldown)
        {
            Vector2 position = new(Globals.GameWindow.X / 2, Globals.GameWindow.Y / 2);
            
            Color[] colors = { Color.IndianRed, Color.CadetBlue, Color.Crimson, Color.DarkGoldenrod };
            Color color = colors[_random.Next(colors.Length)];
            
            float angle = (float)(_random.NextDouble() * Math.PI * 2);
            Vector2 direction = new((float)Math.Cos(angle), (float)Math.Sin(angle));

            if (!flyweight)
            {
                Square square = new(position, color, direction);
                Squares.Add(square);
                Console.WriteLine($"Entity quantity: {Squares.Count}");
            }
            else
            {
                SquareF square = new(position, color, direction);
                SquaresF.Add(square);
                Console.WriteLine($"Entity quantity>: {SquaresF.Count}");
            }
            
            _spawnRate = 0f;
        }
    }
}