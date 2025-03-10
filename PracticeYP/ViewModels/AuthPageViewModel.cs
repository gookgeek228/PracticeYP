using System;
using System.Collections.Generic;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Linq;
using Avalonia.Media;
using Avalonia;
using CommunityToolkit.Mvvm.Input;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace PracticeYP.ViewModels
{
	public partial class AuthPageViewModel : ViewModelBase
	{
        [ObservableProperty] string login;
        [ObservableProperty] string password;
        [ObservableProperty] string message = "";
        [ObservableProperty] private string captchaText;
        [ObservableProperty] private Bitmap captchaImage;
        [ObservableProperty] private string userInput;
        [ObservableProperty] private string resultMessage;

        public AuthPageViewModel()
        {
            GenerateCaptcha();
        }

        public void Authorization()
        {
            if (login == "" || password == "")
            {
                Message = "��������� ��� ����!";
            }
            else
            {
                if (ResultMessage == "����� ��������!")
                {
                    if (Db.Users.FirstOrDefault(x => x.Email == login && x.Password == password && x.IdRole == 2) != null)
                    {
                        //��������
                        MainWindowViewModel.Instance.loginedUser = Db.Users.Include(x => x.IdGenderNavigation).FirstOrDefault(x => x.Email == login && x.Password == password);
                        MainWindowViewModel.Instance.PreviousPage = MainWindowViewModel.Instance.PageSwitcher?.GetType().Name;
                        MainWindowViewModel.Instance.PageSwitcher = new MemberView();
                    }
                    else if (Db.Users.FirstOrDefault(x => x.Email == login && x.Password == password && x.IdRole == 3) != null)
                    {
                        //���������
                        MainWindowViewModel.Instance.loginedUser = Db.Users.Include(x => x.IdGenderNavigation).FirstOrDefault(x => x.Email == login && x.Password == password);
                        MainWindowViewModel.Instance.PreviousPage = MainWindowViewModel.Instance.PageSwitcher?.GetType().Name;
                        MainWindowViewModel.Instance.PageSwitcher = new ModerView();
                    }
                    else if (Db.Users.FirstOrDefault(x => x.Email == login && x.Password == password && x.IdRole == 4) != null)
                    {
                        //�����������
                        MainWindowViewModel.Instance.loginedUser = Db.Users.Include(x => x.IdGenderNavigation).FirstOrDefault(x => x.Email == login && x.Password == password);
                        MainWindowViewModel.Instance.PreviousPage = MainWindowViewModel.Instance.PageSwitcher?.GetType().Name;
                        MainWindowViewModel.Instance.PageSwitcher = new OrganizerView();
                    }
                    else if (Db.Users.FirstOrDefault(x => x.Email == login && x.Password == password && x.IdRole == 5) != null)
                    {
                        //����
                        MainWindowViewModel.Instance.loginedUser = Db.Users.Include(x => x.IdGenderNavigation).FirstOrDefault(x => x.Email == login && x.Password == password);
                        MainWindowViewModel.Instance.PreviousPage = MainWindowViewModel.Instance.PageSwitcher?.GetType().Name;
                        MainWindowViewModel.Instance.PageSwitcher = new JuryView();
                    }
                    else
                    {
                        Message = "������ �����������! �������� ����� ��� ������!";
                    }
                }
                else
                {
                    Message = "�������� �����!";
                }
                
            }
            
        }

        [RelayCommand]
        public void GoBack()
        {
            MainWindowViewModel.Instance.PageSwitcher = new EventPageView();
        }

        private static readonly Random _random = new();

        [RelayCommand]
        private void GenerateCaptcha()
        {
            CaptchaText = GenerateRandomText(6);
            CaptchaImage = GenerateCaptchaImage(CaptchaText);
            UserInput = string.Empty;
            ResultMessage = string.Empty;
        }

        [RelayCommand]
        private void ValidateCaptcha()
        {
            ResultMessage = (UserInput?.ToUpper() == CaptchaText) ? "����� ��������!" : "����� �� ��������!";
        }

        private static string GenerateRandomText(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        private Bitmap GenerateCaptchaImage(string text)
        {
            var renderTarget = new RenderTargetBitmap(new PixelSize(400, 150), new Vector(96, 96));

            using (var context = renderTarget.CreateDrawingContext(true))
            {
                var backgroundBrush = Brushes.White;
                var textBrush = Brushes.Black;

                // ������� ���� ����� ������
                context.FillRectangle(backgroundBrush, new Rect(0, 0, 400, 150));

                // ����������� ���������� ������������� ������ �����
                var formattedText = new FormattedText(
                    text,
                    CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    Typeface.Default,
                    56,
                    Brushes.Black
                );

                // ����������� ������� �� �����������, ��� ����� ��������� �����
                var textPosition = new Point(
                    (400 - formattedText.Width) / 2,
                    (150 - formattedText.Height) / 2
                );

                context.DrawText(formattedText, textPosition);

                var random = new Random();

                // ���������� ��������� ������
                int numberOfCircles = random.Next(20, 30);
                for (int i = 0; i < numberOfCircles; i++)
                {
                    var circleColor = new SolidColorBrush(Color.FromArgb(
                        (byte)random.Next(150, 200),  // ��������� ����� ���
                        (byte)random.Next(256),       // ��������� ������� ���
                        (byte)random.Next(256),       // ��������� ������� ���
                        (byte)random.Next(256)        // ��������� ����� ���
                    ));

                    double radius = random.Next(10, 30);
                    double xPosition = random.Next(0, 400 - (int)radius * 2);
                    double yPosition = random.Next(0, 150 - (int)radius * 2);

                    context.DrawEllipse(circleColor, null, new Point(xPosition + radius, yPosition + radius), radius, radius);
                }

                // ���������� ��������� ����� � ������ ��������
                int numberOfLines = random.Next(5, 10);
                for (int i = 0; i < numberOfLines; i++)
                {
                    var lineColor = new SolidColorBrush(Color.FromArgb(
                        (byte)random.Next(100, 150),  // ��������� ����� ���
                        (byte)random.Next(256),       // ��������� ������� ���
                        (byte)random.Next(256),       // ��������� ������� ���
                        (byte)random.Next(256)       // ��������� ����� ���
                    ));

                    double thickness = random.Next(1, 3);
                    double startX = random.Next(0, 400);
                    double startY = random.Next(0, 150);
                    double endX = random.Next(0, 400);
                    double endY = random.Next(0, 150);

                    context.DrawLine(new Pen(lineColor, thickness), new Point(startX, startY), new Point(endX, endY));
                }
            }

            return renderTarget;
        }
    }
}