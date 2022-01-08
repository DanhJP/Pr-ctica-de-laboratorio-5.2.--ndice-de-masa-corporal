using ImcApp.Models;
using System;
using Xamarin.Forms;



namespace ImcApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LimpiarIU();
        }

        private void LimpiarIU()
        {
            PesoEntry.Text = string.Empty;
            EstaturaEntry.Text = string.Empty;
            ImcLabel.Text = string.Empty;
            SituacionNutricionalLabel.Text = string.Empty;
            
        }

        private string GetEstadoNutricional(CalculadoraImc.EstadoNutricional estado)
        {
            string situacion;
            switch(estado)
            {
                case CalculadoraImc.EstadoNutricional.PesoBajo:
                    situacion = "Peso bajo";
                    break;
                case CalculadoraImc.EstadoNutricional.PesoNormal:
                    situacion = "Peso normal";
                    break;
                case CalculadoraImc.EstadoNutricional.SobrePeso:
                    situacion = "Sobrepeso";
                    break;
                case CalculadoraImc.EstadoNutricional.Obesidad:
                    situacion = "Obesidad";
                    break;
                case CalculadoraImc.EstadoNutricional.ObesidadExtrema:
                    situacion = "Obesidad extrema";
                    break;
                default: 
                    situacion = string.Empty;
                    break;
            }
            return situacion;
        }


        private void CalcularButton_Clicked(object sender, EventArgs e)
        {
            decimal peso; 
            decimal estatura;
            decimal imc;
            CalculadoraImc.EstadoNutricional estadoNutricional;
            bool pesoEsConvertible = decimal.TryParse(PesoEntry.Text, out peso);
            bool estaturaEsConvertible = decimal.TryParse(EstaturaEntry.Text, out estatura);
            if (pesoEsConvertible && estaturaEsConvertible)
            {
                imc = CalculadoraImc.IndiceDeMasaCorporal(peso, estatura);
                estadoNutricional = CalculadoraImc.SituacionNutricional(imc);
                //ImcLabel.Text = imc.ToString();
                ImcLabel.Text = string.Format("{0}", imc);
                SituacionNutricionalLabel.Text = GetEstadoNutricional(estadoNutricional);
            }
            else
            {
                DisplayAlert(
                    "Alerta", 
                    "El peso y la estatura deben ser valores numéricos.",
                    "Aceptar");
            }
        }

        private void LimpiarButton_Clicked(object sender, EventArgs e)
        {
            LimpiarIU();
        }
    }
}
