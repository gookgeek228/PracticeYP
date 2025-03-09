using System;
using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using PracticeYP.Models;

namespace PracticeYP.ViewModels
{
	public partial class MemberViewModel : ViewModelBase
	{
        [ObservableProperty] List<User> members;
        [ObservableProperty] List<User> members0;
        [ObservableProperty] string textFind;
        [ObservableProperty] string fio;

        public MemberViewModel()
        {
            members = Db.Users.Where(x=>x.IdRole == 2).ToList();
            members0 = members;
        }

        public void ApplyFilters()
        {
            members = members0;

            if (!string.IsNullOrEmpty(textFind))
            {
                Members = Members.Where(x => x.Fio.Contains(textFind, StringComparison.OrdinalIgnoreCase)).ToList();
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