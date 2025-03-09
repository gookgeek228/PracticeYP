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
            return new string(Enumerable.Repeat(chars, length) //������� ��������� �������� � ������� 6-�� ��������
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        private Bitmap GenerateCaptchaImage(string text)
        {
            var renderTarget = new RenderTargetBitmap(new PixelSize(400, 150), new Vector(96, 96));

            using (var context = renderTarget.CreateDrawingContext(true))
            {
                var backgroundBrush = Brushes.White;
                var textBrush = Brushes.Black;
                var lineBrush = Brushes.LightGray;

                // ������� ���� ����� ������
                context.FillRectangle(backgroundBrush, new Rect(0, 0, 400, 150));

                // ����������� ���������� ������������� ������ �����
                var formattedText = new FormattedText(
                    text,                             // �����
                    CultureInfo.CurrentCulture,       //��� � �� ���������� ��� ���� ��� �����
                    FlowDirection.LeftToRight,        // ����������� ������
                    Typeface.Default,                 // �����
                    56,                               // ������ ������
                    Brushes.Black                     // ���� ������
                );

                // ����������� ������� �� �����������, ��� ����� ��������� �����
                var textPosition = new Point(
                    (400 - formattedText.Width) / 2,  // ������
                    (150 - formattedText.Height) / 2   // �����
                );


                context.DrawText(formattedText, textPosition);


                var random = new Random();
                int numberOfLines = random.Next(98, 100);

                for (int i = 0; i < numberOfLines; i++)
                {
                    // ��������� ����� ����� ������, ������� ����� � �����
                    var lineColor = new SolidColorBrush(Color.FromArgb(
                        (byte)random.Next(256),  // ��������� ����� ���
                        (byte)random.Next(256),  // ��������� ������� ���
                        (byte)random.Next(256),  // ��������� ������� ���
                        (byte)random.Next(256)   // ��������� ����� ���
                    ));

                    // ������� ��������� ����������� �.�. �������������� ��� ������������
                    bool isHorizontal = random.Next(2) == 0;

                    double lineWidth = isHorizontal ? 400 : random.Next(3, 5);  // ������ ������ ��� �������������� �����
                    double lineHeight = isHorizontal ? random.Next(3, 5) : 150;  // ������ ������ ��� ������������ �����


                    double xPosition = isHorizontal ? 0 : random.Next(0, 400 - (int)lineWidth);  // ��������� ��������� ��� ������������ �����
                    double yPosition = isHorizontal ? random.Next(0, 150 - (int)lineHeight) : 0; // ��������� ��������� ��� �������������� �����


                    context.FillRectangle(lineColor, new Rect(xPosition, yPosition, lineWidth, lineHeight));
                }
            }
            return renderTarget;
        }
    }
}