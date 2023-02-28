using System;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Models.Car;
using WpfApp1.Models.FrameManager;

namespace WpfApp1.Views.Pages
{
    public partial class ReservationPage : Page
    {
        private Requests request = new Requests();
        private Car currentCar;
        public ReservationPage(Car car)
        {
            InitializeComponent();
            currentCar = car;
        }

        private void Reservation_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = Convert.ToDateTime(StartDatePicker.SelectedDate.Value.Date.ToShortDateString());
            DateTime endDate = Convert.ToDateTime(EndDatePicker.SelectedDate.Value.Date.ToShortDateString());

            if((startDate.Date >= DateTime.Now.Date) && startDate.Date < endDate.Date)
            {
                PriceText.Text = PriceCounting(startDate, endDate, currentCar).ToString();
                if (MessageBox.Show($"Вы уверены, что хотите бронировать {currentCar.CarBrand} {currentCar.CarName}" +
                    $" на {startDate.ToString("d")} по {endDate.ToString("d")}?", "Вопрос",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    float totalPrice = PriceCounting(startDate, endDate, currentCar);
                    request.CarBooking(Convert.ToInt32(MainWindow.currentUser.UserId), Convert.ToInt32(currentCar.CarId), startDate, endDate, totalPrice);
                    MessageBox.Show($"{currentCar.CarBrand} {currentCar.CarName} успешно бронирован!" +
                        $" Приходите по адресу: ул. имени генерала Карбышева, 95а " +
                        $"{startDate.Date.ToString("d")} числа и оплатите аренду на сумму: {totalPrice} рублей.");
                    FrameManager.Frame.Navigate(new MainPage());
                }

                else
                {
                    ClearDatePickers();
                }
            }

            else
            {
                ClearDatePickers();
            }
        }

        private float PriceCounting(DateTime startDate, DateTime endDate, Car car)
        {
            float price = Convert.ToSingle(car.PricePerDay.Replace('.', ','));
            return (endDate.Day - startDate.Day) * price;
        }

        private void ClearDatePickers()
        {
            StartDatePicker.Text = null;
            EndDatePicker.Text = null;
            PriceText.Text = null;
        }
    }
}
