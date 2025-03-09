using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PracticeYP.Models;

namespace PracticeYP.ViewModels
{
	public partial class OrganizerViewModel : ViewModelBase
	{
		[ObservableProperty] User user = MainWindowViewModel.Instance.loginedUser;
		[ObservableProperty] string greetingMessage;
		[ObservableProperty] string genderMessage;
		[ObservableProperty] string name;
        
        public OrganizerViewModel()
        {
            if (User != null && !string.IsNullOrWhiteSpace(User.Fio))
            {
                string[] parts = User.Fio.Split(' ');
                name = parts.Length > 1 ? parts[1] : "Неизвестно";
            }
            Console.WriteLine($"GreetingMessage: {GreetingMessage}");
            Console.WriteLine($"GenderMessage: {GenderMessage}");
            Console.WriteLine($"Name: {Name}");
            CreateMessage();
            Gender();
        }

        public void CreateMessage()
        {
            int hour = DateTime.Now.Hour;
            string timeOfDay = hour switch
            {
                >= 9 and <= 11 => "yтро",
                >= 11 and < 18 => "день",
                _ => "вечер"
            };

            if (timeOfDay == "утро")
            {
                greetingMessage = $"Доброе {timeOfDay}!";
            }
            else
            {
                greetingMessage = $"Добрый {timeOfDay}!";
            }
            
        }

        public void Gender()
        {
            if (User.IdGenderNavigation.IdGender == "м")
            {
                genderMessage = "Mr";
            }
            else if (User.IdGenderNavigation.IdGender == "ж")
            {
                genderMessage = "Mrs";
            }
            else
            {
                genderMessage = string.Empty;
            }
        }

        public void GoToEvents()
        {
            MainWindowViewModel.Instance.PreviousPage = MainWindowViewModel.Instance.PageSwitcher?.GetType().Name;
            MainWindowViewModel.Instance.PageSwitcher = new EventPageView();
        }

        public void GoToMembers()
        {
            MainWindowViewModel.Instance.PreviousPage = MainWindowViewModel.Instance.PageSwitcher?.GetType().Name;
            MainWindowViewModel.Instance.PageSwitcher = new MemberView();
        }

        public void GoToJury()
        {
            MainWindowViewModel.Instance.PreviousPage = MainWindowViewModel.Instance.PageSwitcher?.GetType().Name;
            MainWindowViewModel.Instance.PageSwitcher = new JuryView();
        }
       
    }
}