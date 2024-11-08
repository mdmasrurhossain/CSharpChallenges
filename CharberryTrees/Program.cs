CharberryTree tree = new CharberryTree();

Notifier announcer = new Notifier(tree);
Harvester harvester = new Harvester(tree);

while (true)
    tree.MaybeGrow();
Console.ReadLine();

public class Harvester
{
    public int _harvestCount;
    private CharberryTree _tree;
    public Harvester(CharberryTree tree)
    {
        _tree = tree;
        _tree.Ripened += HandleCharBerry;

    }

    public void HandleCharBerry()
    {
        _harvestCount++;
        _tree.Ripe = false;
        Console.WriteLine($"The tree has been harvested {_harvestCount} times.");
    }
    
}

public class Notifier
{

    public Notifier(CharberryTree tree)
    {
        tree.Ripened += OnTreeRipened;
        
    }

    public void OnTreeRipened() => Console.WriteLine("A charberry fruit has ripened!");
}



public class CharberryTree
{
    private Random _random = new Random();
    public event Action? Ripened;
    public bool Ripe { get; set; }

    public void MaybeGrow()
    {
        if (_random.NextDouble() < 0.00000001 && !Ripe)
        {
            Ripe = true;
            Ripened?.Invoke();
        }
    }
}

