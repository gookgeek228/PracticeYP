using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PracticeYP.ViewModels;

namespace PracticeYP;

public partial class AuthPageView : UserControl
{
    public AuthPageView()
    {
        DataContext = new AuthPageViewModel();
        InitializeComponent();
    }
}