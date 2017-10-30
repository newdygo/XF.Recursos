using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.Recursos.GPS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoordenadaView : ContentPage
    {
        public CoordenadaView()
        {
            InitializeComponent();
        }

        private void btnCoordenada_Clicked(object sender, EventArgs e)
        {
            var localizacao = DependencyService.Get<ILocalizacao>();

            localizacao.GetCoordenada();

            MessagingCenter.Subscribe<ILocalizacao, Coordenada>(this, "coordenada", (loc, coordenada) =>
               {
                   lblLatitude.Text = coordenada.Latitude;
                   lblLongitude.Text = coordenada.Longitude;
               }
            );
        }
    }
}