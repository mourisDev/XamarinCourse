using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using xamaCourse01.Service.Model;
using xamaCourse01.Service;

namespace xamaCourse01
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnBuscar.Clicked += buscarCep;

        }

        private void buscarCep(object sender, EventArgs args)
        {
            string cep = txtCep.Text.Trim();
            if (isValidCep(cep))
            {
                try
                {
                    address adr = viaCEPService.GetAddrCEP(cep);
                    if (adr != null)
                    {
                        lblResult.Text = string.Format("Endereço: {0}, {1} {2}", adr.localidade, adr.uf, adr.logradouro);
                    }
                    else
                    {
                        DisplayAlert("Erro", "CEP não encontrado, " + txtCep.Text.Trim(), "OK");
                    }
                }catch(Exception e)
                {
                    DisplayAlert("Erro", e.Message, "OK");
                    
                }
            }
        }

        private bool isValidCep(string cep)
        {
            if (cep.Length != 8)
            {
                DisplayAlert("Erro", "Cep inválido! O CEP deve conter 8 caracteres.", "OK");
                return false;
            }

            int novoCep = 0;
            if(!int.TryParse(cep, out novoCep))
            {
                DisplayAlert("Erro", "Cep inválido! O CEP conter apenas números.", "OK");
                return false;
            }
            return true;
        }
    }

}
