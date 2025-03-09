using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using PracticeYP.Models;
using System.Collections.Generic;
using System.Linq;

namespace PracticeYP.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty] UserControl pageSwitcher;
        [ObservableProperty] private string previousPage;

        public User? loginedUser;

        public MainWindowViewModel()
        {
            Instance = this;
            PageSwitcher = new EventPageView();
            previousPage = pageSwitcher?.GetType().Name;
        }

        public static MainWindowViewModel Instance { get; set; }
    }
}
