using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ISSFlyBy.ViewModels;

namespace ISSFlyBy.Views
{
    public partial class ISSCurrentCrewView : ContentPage
    {
        private readonly ISSCurrentCrewViewModel viewModel;

        public ISSCurrentCrewView()
        {
            InitializeComponent();

            BindingContext = viewModel = new ISSCurrentCrewViewModel();
        }
    }
}