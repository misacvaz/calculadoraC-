using System;
using System.Collections.Generic;
using System.Linq; // Necessário para o método TakeLast

namespace CalculadoraCalculo;

    public class Calculo
    {
        // Lista para armazenar o histórico das operações
        private List<string> _historico = new List<string>();

        // Método para somar dois números
        public int Somar(int num1, int num2)
        {
            int resultadoSama = num1 + num2;
            _historico.Add($"{num1} + {num2} = {resultadoSama}");
            return resultadoSama;
        }

        // Método para subtrair dois números
        public int Subtrair(int num1, int num2)
        {
            int resultadoSubtrair = num1 - num2;

           
           _historico.Add($"{num1} - {num2} = {resultadoSubtrair}");
            

            return resultadoSubtrair;
        }

        // Método para multiplicar dois números
        public int Multiplicar(int num1, int num2)
        {
            int resultadoMultiplicacar = num1 * num2;
            _historico.Add($"{num1} * {num2} = {resultadoMultiplicacar}");
        return resultadoMultiplicacar;
    }

        // Método para dividir dois números, com tratamento de exceção para divisão por zero
        public double Dividir(int num1, int num2)
        {
            if (num2 == 0) throw new DivideByZeroException("Divisão por zero não é permitida.");
            double resultadoDivider = (double)num1 / num2;
            _historico.Add($"{num1} / {num2} = {resultadoDivider}");
            return resultadoDivider;
        }

        // Método para retornar os últimos 5 históricos
        public List<string> Historico()
        {
           return _historico.Count > 5 ? _historico.GetRange(_historico.Count - 5, 5) : new List<string>(_historico); // Retorna os últimos 5 registros
        }
    }

