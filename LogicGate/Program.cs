namespace LogicGate;

using LogicGate.Components;

public class Program
{
    public static void Main(string[] args)
    {
        bool inputA = false;
        bool inputB = true;
        bool inputC = true;

        var and1 = new GateAND(2);
        var not1 = new GateNOT();
        var or1 = new GateOR(2);
        var not2 = new GateNOT();

        and1.Connect(inputA);
        and1.Connect(inputB);
        not1.Connect(inputC);

        or1.Connect(and1);
        or1.Connect(not1);

        not2.Connect(or1);

        Console.WriteLine(not2.Output);

    }
}


