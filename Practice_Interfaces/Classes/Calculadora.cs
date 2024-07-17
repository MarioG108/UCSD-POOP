using Practice_Interfaces.Interfaces;

namespace Practice_Interfaces.Classes
{
    public enum Operaciones
    {
        Sumar=1, Restar, Multiplicar, Dividir
    };
    internal class Calculadora : IOperaciones
    {
        public Calculadora(decimal primervalor, decimal segundovalor)
        {
            Parametros = new PARAMETROS_GENERALES()
            {
                primer_valor = primervalor,
                segundo_valor = segundovalor
            };
        }
        public Operaciones operaciones;
        public PARAMETROS_GENERALES Parametros { get; set; }



        public float GetDivision()
        {
            Parametros.Resultado = (float)(Parametros.primer_valor / Parametros.segundo_valor);

            return Parametros.Resultado;
        }

        public float GetSuma()
        {
            Parametros.Resultado = (float)(Parametros.primer_valor + Parametros.segundo_valor);
            return Parametros.Resultado;
        }

        public float GetMultiplicacion()
        {
            Parametros.Resultado = (float)(Parametros.primer_valor + Parametros.segundo_valor);
            return Parametros.Resultado;
        }

        public float GetResta()
        {
            throw new NotImplementedException();
        }
    }
}
