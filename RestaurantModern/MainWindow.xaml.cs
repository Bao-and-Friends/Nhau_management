using System.Windows;
using RestaurantModern.Services;
using RestaurantModern.ViewModels;

namespace RestaurantModern;

public partial class MainWindow : Window
{
    private readonly IApiService _api;
    private readonly MainViewModel _vm;

    public MainWindow() : this(new ApiService()) { }

    public MainWindow(IApiService api)
    {
        InitializeComponent();
        _api = api;
        _vm = new MainViewModel(api, OnLogout);
        DataContext = _vm;
    }

    private void OnLogout()
    {
        Dispatcher.Invoke(() =>
        {
            var authWindow = new AuthWindow(_api);
            authWindow.Show();
            Close();
        });
    }
}