using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PracticeYP.ViewModels;

namespace PracticeYP;

public partial class MemberView : UserControl
{
    public MemberView()
    {
        DataContext = new MemberViewModel();
        InitializeComponent();
    }
}