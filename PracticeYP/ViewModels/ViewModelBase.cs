using CommunityToolkit.Mvvm.ComponentModel;
using PracticeYP.Models;

namespace PracticeYP.ViewModels
{
    public partial class ViewModelBase : ObservableObject
    {
        [ObservableProperty] YpContext db = new YpContext();
    }
}
