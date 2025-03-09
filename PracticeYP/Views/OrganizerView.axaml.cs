using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PracticeYP.ViewModels;

namespace PracticeYP;

public partial class OrganizerView : UserControl
{
    public OrganizerView()
    {
        InitializeComponent();
        DataContext = new OrganizerViewModel();
    }
}