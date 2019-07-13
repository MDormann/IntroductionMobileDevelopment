using ISSFlyBy.ViewModels;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ISSFlyBy.Views
{
    public partial class ISSFlyByView : ContentPage
    {
        private readonly ISSFlyByViewModel viewModel;

        public ISSFlyByView()
        {
            InitializeComponent();

            BindingContext = viewModel = new ISSFlyByViewModel();
        }
    }
}
