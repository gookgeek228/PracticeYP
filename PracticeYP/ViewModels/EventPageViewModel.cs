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
        [ObservableProperty] string eventName;

        public EventPageViewModel()
        {
            events = Db.Events.ToList();
        }
    }
}