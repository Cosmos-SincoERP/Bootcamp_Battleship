namespace AcorazadosTests;

public enum ResultadoDisparo
{
    Agua,
    Tocado,
    Hundido
}

public static class ResultadoDisparoExtension
{
    public static string ValorDisparo(this ResultadoDisparo resultado)
    {
        return resultado switch
        {
            ResultadoDisparo.Agua => "o",
            ResultadoDisparo.Tocado => "x",
            ResultadoDisparo.Hundido => "X",
            _ => throw new ArgumentOutOfRangeException(nameof(resultado), resultado, null)
        };
    }
}