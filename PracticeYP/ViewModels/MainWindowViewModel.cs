using CommunityToolkit.Mvvm.ComponentModel;
using PracticeYP.Models;
using System.Collections.Generic;
using System.Linq;

namespace PracticeYP.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty] ViewModelBase pageSwitcher;
        [ObservableProperty] private string previousPage;

        public MainWindowViewModel()
        {
            Instance = this;
            PageSwitcher = new EventPageViewModel();
            previousPage = pageSwitcher?.GetType().Name;
        }

        public static MainWindowViewModel Instance { get; set; }
    }
}
