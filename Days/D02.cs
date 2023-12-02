namespace AoC2023.Days;

public class D02 : IDay
{
    private readonly Dictionary<string, Game> _games;

    public D02()
    {
        var filePath = Path.Combine("Data", "Day02");
        var input = File.ReadAllLines(filePath);
        
        _games = new Dictionary<string, Game>();
        
        foreach (var line in input)
        {
            var split = line.Split(":");
            var (red, green, blue) = (int.MinValue, int.MinValue, int.MinValue);
            
            foreach (var round in split[1].Split(';'))
            {
                foreach (var info in round.Split(','))
                {
                    var infoSplit = info.Trim().Split(" ");
                    switch (infoSplit[1])
                    {
                        case "red":
                            var r = int.Parse(infoSplit[0]);
                            if(r > red)
                                red = r;
                            break;
                        case "green":
                            var g = int.Parse(infoSplit[0]);
                            if(g > green)
                                green = g;
                            break;
                        case "blue":
                            var b = int.Parse(infoSplit[0]);
                            if(b > blue)
                                blue = b;
                            break;
                    }
                }
            }
            _games.Add(split[0], new Game(red, green, blue));
        }
    }

    public object P1()
    {
        return _games.Where(g => g.Value.IsValidP1(12, 13, 14)).Sum(g => int.Parse(g.Key.Split(" ")[1]));
    }

    public object P2()
    {
        return _games.Values.Sum(game => game.GetPowerOfMin());
    }

    private class Game
    {
        private readonly int _red, _green, _blue;

        public Game(int red, int green, int blue)
        {
            _red = red;
            _green = green;
            _blue = blue;
        }

        public bool IsValidP1(int red, int green, int blue)
        {
            return _red <= red && _green <= green && _blue <= blue;
        }
        
        public int GetPowerOfMin()
        {
            return _red * _green * _blue;
        }
    }
}