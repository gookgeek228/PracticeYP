using System;
using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using PracticeYP.Models;

namespace PracticeYP.ViewModels
{
	public partial class JuryViewModel : ViewModelBase
	{
        [ObservableProperty] List<User> juryList;
        [ObservableProperty] List<User> juryList0;
        [ObservableProperty] string textFind;
        [ObservableProperty] string fio;

        public JuryViewModel()
        {
            juryList = Db.Users.Where(x => x.IdRole == 5).ToList();
            juryList0 = juryList;
        }

        public void ApplyFilters()
        {
            juryList = juryList0;

            if (!string.IsNullOrEmpty(textFind))
            {
                JuryList = JuryList.Where(x => x.Fio.Contains(textFind, StringComparison.OrdinalIgnoreCase)).ToList();
            }

        }

        public void GoBack()
        {
            if (MainWindowViewModel.Instance.PreviousPage == "AuthPageView")
            {
                MainWindowViewModel.Instance.PageSwitcher = new AuthPageView();
            }
            else if (MainWindowViewModel.Instance.PreviousPage == "OrganizerView")
            {
                MainWindowViewModel.Instance.PageSwitcher = new OrganizerView();
            }
        }

        partial void OnTextFindChanged(string value)
        {
            ApplyFilters();
        }
    }
}