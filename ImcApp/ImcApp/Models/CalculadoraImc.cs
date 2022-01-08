using System;
using System.Collections.Generic;
using System.Text;

namespace ImcApp.Models
{
    public class CalculadoraImc
    {
        public static decimal IndiceDeMasaCorporal(decimal peso, decimal estatura)
             => peso / (estatura * estatura);

        //public decimal Peso { get; set; }
        //public decimal Estatura { get; set; }


        public enum EstadoNutricional
        {
            PesoBajo, 
            PesoNormal, 
            SobrePeso, 
            Obesidad, 
            ObesidadExtrema
        }

        public EstadoNutricional SituacionNutricional (decimal imc)
        {
            if (imc < 18.5M)
            {
                return EstadoNutricional.PesoBajo;
            }
            else if (imc < 25.0M)
            {
                return EstadoNutricional.PesoNormal;
            }
            else if (imc < 30.0M)
            {
                return EstadoNutricional.SobrePeso;
            }
            else if (imc < 40.0M)
            {
                return EstadoNutricional.Obesidad;
            }
            else
            {
                return EstadoNutricional.ObesidadExtrema;
            }

        }

        
    }
}
