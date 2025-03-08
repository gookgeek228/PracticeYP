using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PracticeYP.ViewModels;

namespace PracticeYP;

public partial class EventPageView : UserControl
{
    public EventPageView()
    {
        DataContext = new EventPageViewModel();
        InitializeComponent();
    }
}