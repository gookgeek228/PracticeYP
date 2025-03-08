using CommunityToolkit.Mvvm.ComponentModel;
using PracticeYP.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PracticeYP.ViewModels
{
	public partial class EventPageViewModel : ViewModelBase
    {
        [ObservableProperty] List<Event> events;
        [ObservableProperty] List<Event> events0;
        [ObservableProperty] string textFind;
        [ObservableProperty] string selectedSortParametr;
        [ObservableProperty] string selectedSortOrder;
        [ObservableProperty] string eventName;

        public EventPageViewModel()
        {
            events = Db.Events.ToList();
            events0 = events;
        }

        public void GoToAuth()
        {
            MainWindowViewModel.Instance.PreviousPage = MainWindowViewModel.Instance.PageSwitcher?.GetType().Name;
            MainWindowViewModel.Instance.PageSwitcher = new AuthPageView();
        }

        public void ApplyFilters()
        {
            events = events0;

            if (!string.IsNullOrEmpty(textFind)) 
            {
                Events = Events.Where(x => x.EventName.Contains(textFind, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (selectedSortParametr == "Дата")
            {
                if (selectedSortOrder == "По возрастанию")
                {
                    Events = events.OrderBy(x => x.Date).ToList();
                }
                else if (selectedSortOrder == "По убыванию")
                {
                    Events = events.OrderByDescending(x => x.Date).ToList();
                }
            }

        }

        partial void OnTextFindChanged(string value)
        {
            ApplyFilters();
        }

        partial void OnSelectedSortParametrChanged(string value)
        {
            ApplyFilters();
        }

        partial void OnSelectedSortOrderChanged(string value)
        {
            ApplyFilters();
        }
    }
}