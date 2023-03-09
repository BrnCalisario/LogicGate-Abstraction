using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGate.Components;

public abstract class Component
{
    public bool Output { get; set; } = false;
    protected Component[] Inputs { get; set; }
    protected int Index { get; set; } = 0;

    public Component(int inputQuantity)
    {
        Inputs = new Component[inputQuantity];
    }

    public virtual void SetOutput()
    {
        this.Output = true;
    }

    public void Connect(Component c)
    {
        if (Index >= Inputs.Length)
            throw new Exception("Limite de entradas atingido");

        this.Inputs[Index] = c;
        this.Index++;
        this.SetOutput();
    }

    public void Connect(bool Value)
    {
        if (Index >= Inputs.Length)
            throw new Exception("Limite de entradas atingido");

        this.Inputs[Index] = new Input(Value) { Output = Value };
        this.Index++;
        this.SetOutput();
    }
}

public class Input : Component
{
    public Input(bool value) : base(1)
    {
        this.Output = value;
    }
}

public class GateAND : Component
{
    public GateAND(int qtd) : base(qtd) { }

    public override void SetOutput() => 
        this.Output = !this.Inputs.Take(Index).Any(b => !b.Output);
}

public class GateOR : Component
{ 
    public GateOR(int qtd) : base(qtd) { }

    public override void SetOutput()
    {
        this.Output = this.Inputs.Take(Index).Any(b => b.Output);
    }
}

public class GateNOT : Component
{

    public GateNOT() : base(1) { }
    public GateNOT(bool value) : base(1) => this.Output = !value;

    public override void SetOutput() =>
        this.Output = !this.Inputs[0].Output;
}
