using ISSFlyBy.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ISSFlyBy.Views
{
    public partial class ISSLiveView : ContentPage
    {
        private readonly ISSLiveViewModel viewModel;

        public ISSLiveView()
        {
            InitializeComponent();

            // Verbindet die Applikationslogik (ViewModel) mit der Oberfläche (View)
            BindingContext = viewModel = new ISSLiveViewModel();

            // Sorgt dafür, dass beim Start die Karte komplett herausgezoomt ist.
            mapControl.MoveToRegion(new MapSpan(mapControl.VisibleRegion.Center, 180, 180));
        }
    }
}
