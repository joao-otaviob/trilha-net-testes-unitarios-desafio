using System;
using System.Collections.Generic;

public class Calculadora
{
    private List<string> historico;

    public Calculadora()
    {
        historico = new List<string>();
    }

    public int Somar(int numero1, int numero2)
    {
        int resultado = numero1 + numero2;
        RegistrarOperacao("SOMAR", numero1, numero2, resultado);
        return resultado;
    }

    public int Subtrair(int numero1, int numero2)
    {
        int resultado = numero1 - numero2;
        RegistrarOperacao("SUBTRAIR", numero1, numero2, resultado);
        return resultado;
    }

    public int Multiplicar(int numero1, int numero2)
    {
        int resultado = numero1 * numero2;
        RegistrarOperacao("MULTIPLICAR", numero1, numero2, resultado);
        return resultado;
    }

    public int Dividir(int numero1, int numero2)
    {
        if (numero2 == 0)
        {
            throw new ArgumentException("Não é possível dividir por zero.");
        }

        int resultado = numero1 / numero2;
        RegistrarOperacao("DIVIDIR", numero1, numero2, resultado);
        return resultado;
    }

    public List<string> ObterHistorico()
    {
        return historico;
    }

    private void RegistrarOperacao(string operacao, int numero1, int numero2, int resultado)
    {
        string registro = $"{DateTime.Now}: {operacao} {numero1} e {numero2} resultam em {resultado}";
        historico.Add(registro);
        if (historico.Count > 3)
        {
            historico.RemoveAt(0);
            
        }
    }
}

