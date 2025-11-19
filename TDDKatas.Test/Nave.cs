namespace TDDKatas;

public abstract class Nave
{
    public abstract  TiposNave Tipo { get;  }
    public abstract  int CantidadPermitida { get;  }
    public abstract  int Tamanio { get;  }
    public abstract  string Descripcion { get;  }

    public static Nave Crear(TiposNave tipo)
    {
        if (tipo == TiposNave.Canionero) return new Canionero();
        if (tipo == TiposNave.Destructor) return new Destructor();
        return new Portaviones();
    
    }
}

internal class Canionero : Nave
{
    public override TiposNave Tipo { get;  } = TiposNave.Canionero;
    public override int CantidadPermitida { get; } = 4;
    public override int Tamanio { get; } = 1;
    public override string Descripcion { get;  } = "Cañonero";
}

internal class Destructor : Nave
{
    public override TiposNave Tipo { get;  } = TiposNave.Destructor;
    public override int CantidadPermitida { get; } = 2;
    public override int Tamanio { get; } = 3;
    public override string Descripcion { get;  } = "Destructor";
}

internal class Portaviones : Nave
{
    public override TiposNave Tipo { get;  } = TiposNave.Portaviones;
    public override int CantidadPermitida { get; } = 1;
    public override int Tamanio { get; } = 4;
    public override string Descripcion { get;  } = "Portaviones";
}