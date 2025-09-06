using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTeste.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AppTeste.ViewModels
{
    public partial class CoinViewModel : ObservableObject
    {
        public string _ladoEscolhido = "";
        public string _imagem = "";
        public string _resultado = "";

        public void Flip()
        {
            Coin coin = new Coin();
            _resultado = coin.Jogar(_ladoEscolhido);
        }

    }
}
