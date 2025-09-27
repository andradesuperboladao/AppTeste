using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AppTeste.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls.Platform;
using Windows.Networking.NetworkOperators;

namespace AppTeste.ViewModels
{
    public partial class CoinViewModel : ObservableObject
    {
        public CoinViewModel()
        {
            Application.Current.MainPage.DisplayAlert("Mensagem", "Bem vindo", "fechar");
            FlipCommand = new Command(Flip);
        }
        public ICommand FlipCommand { get; set; }

        [ObservableProperty]
        public string _ladoEscolhido = "";

        [ObservableProperty]
        public string _imagem = "";

        [ObservableProperty]
        public string _resultado = "";

        public async void Flip()
        {
            try
            {
                if (string.IsNullOrEmpty(_ladoEscolhido)) {
                    throw new Exception("Selecione o lado da moeda");                
                }
                string Nome = await Application.Current.MainPage.DisplayPromptAsync("Identificação", "Digite seu nome");
                

                string diadasemana = 
                await Application.Current.MainPage.DisplayActionSheet("Dia da semana ", "cancelar", string.Empty,"Domingo","Segunda","Terça","Quarta","Quinta","Sexta","Sabado");

                Coin coin = new Coin();

                _resultado = $"{Nome}, " + coin.Jogar(_ladoEscolhido);
                _imagem = $"{coin.Lado}.png";

                
                OnPropertyChanged(nameof(Resultado));
                OnPropertyChanged(nameof(Imagem));

                bool retorno = await Application.Current.MainPage.DisplayAlert("Mensagem", "deseja jogar novamente?","sim", "nao");

                if(retorno)
                {
                    _resultado = string.Empty;
                    _imagem = string.Empty;

                    OnPropertyChanged(nameof(Resultado));
                    OnPropertyChanged(nameof(Imagem));
                   
                }
            }
            catch (Exception ex )
            {
                await Application.Current.MainPage.DisplayAlert("Mensagem", ex.Message, "fechar");
                
            }
        
        }

    }
}
