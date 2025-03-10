using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PracticeYP.ViewModels;

namespace PracticeYP;

public partial class JuryView : UserControl
{
    public JuryView()
    {
        DataContext = new JuryViewModel();
        InitializeComponent();
    }
}