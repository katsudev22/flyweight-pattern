using flyweight_pattern.FlyweightPattern.Objects;

namespace flyweight_pattern.FlyweightPattern.Managers;

public class GameManager
{
    private SquareGenerator _squareGenerator;
    
    public GameManager()
    {
        _squareGenerator = new();
    }

    public void Update()
    {
        _squareGenerator.Update();
    }

    public void Draw()
    {
        _squareGenerator.Draw();
    }
}