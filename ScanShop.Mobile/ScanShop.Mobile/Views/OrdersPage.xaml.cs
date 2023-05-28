﻿using ScanShop.Mobile.Models;
using ScanShop.Mobile.ViewModels;
using ScanShop.Mobile.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScanShop.Mobile.Views
{
    public partial class OrdersPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public OrdersPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}