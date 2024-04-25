using System;

class Brake
{
    public string Side { get; private set; }

    public Brake(string side)
    {
        Side = side;
    }

    public void Disassemble()
    {
        Console.WriteLine($"Disassembling brake on {Side} side.");
    }

    public void Assemble()
    {
        Console.WriteLine($"Assembling brake on {Side} side.");
    }
}

class DrumBrakeRepair
{
    private Brake _leftBrake;
    private Brake _rightBrake;

    public DrumBrakeRepair()
    {
        _leftBrake = new Brake("left");
        _rightBrake = new Brake("right");
    }

    public void Repair()
    {
        _leftBrake.Disassemble();
        Memento memento = new Memento(_leftBrake);
        _rightBrake.Disassemble();
        memento.Restore();
        _leftBrake.Assemble();
        _rightBrake.Assemble();
    }
}

class Memento
{
    private string _side;
    private bool _isDisassembled;

    public Memento(Brake brake)
    {
        _side = brake.Side;
        _isDisassembled = true;
    }

    public void Restore()
    {
        Console.WriteLine($"Restoring brake on {_side} side.");
        _isDisassembled = false;
    }
}

class Program
{
    static void Main(string[] args)
    {
        DrumBrakeRepair repair = new DrumBrakeRepair();
        repair.Repair();
    }
}
