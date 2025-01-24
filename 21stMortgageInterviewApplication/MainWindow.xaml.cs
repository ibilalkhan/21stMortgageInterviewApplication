using System;
using System.Linq;
using System.ComponentModel;
using System.Windows;

namespace _21stMortgageInterviewApplication
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _inputText;
        private string _result;

        public event PropertyChangedEventHandler PropertyChanged;

        public string InputText
        {
            get { return _inputText; }
            set
            {
                _inputText = value;
                OnPropertyChanged("InputText");
            }
        }

        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged("Result");
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this; // Binding the ViewModel to the View
        }

        private void FindLargestValueButton_Click(object sender, RoutedEventArgs e)
        {
            FindLargestValue();
        }

        private void FindSumEvenNumbersButton_Click(object sender, RoutedEventArgs e)
        {
            FindSumOfEvenNumbers();
        }

        private void FindSumOddNumbersButton_Click(object sender, RoutedEventArgs e)
        {
            FindSumOfOddNumbers();
        }

        public void FindLargestValue()
        {
            // Check if InputText is null or empty
            if (string.IsNullOrWhiteSpace(InputText))
            {
                Result = "Invalid input. Please enter numbers.";
                return;
            }

            var numbers = InputText.Split(',')
                                   .Select(s => int.TryParse(s.Trim(), out int number) ? number : (int?)null)
                                   .Where(n => n.HasValue)
                                   .Select(n => n.Value)
                                   .ToList();

            if (numbers.Any())
            {
                Result = "Largest Value: " + numbers.Max().ToString();
            }
            else
            {
                Result = "Invalid numbers.";
            }
        }

        public void FindSumOfEvenNumbers()
        {
            // Check if InputText is null or empty
            if (string.IsNullOrWhiteSpace(InputText))
            {
                Result = "Invalid input. Please enter numbers.";
                return;
            }

            var numbers = InputText.Split(',')
                                   .Select(s => int.TryParse(s.Trim(), out int number) ? number : (int?)null)
                                   .Where(n => n.HasValue)
                                   .Select(n => n.Value)
                                   .ToList();

            if (numbers.Any())
            {
                var evenSum = numbers.Where(n => n % 2 == 0).Sum();
                Result = "Sum of Even Numbers: " + evenSum.ToString();
            }
            else
            {
                Result = "Invalid numbers.";
            }
        }

        public void FindSumOfOddNumbers()
        {
            // Check if InputText is null or empty
            if (string.IsNullOrWhiteSpace(InputText))
            {
                Result = "Invalid input. Please enter numbers.";
                return;
            }

            var numbers = InputText.Split(',')
                                   .Select(s => int.TryParse(s.Trim(), out int number) ? number : (int?)null)
                                   .Where(n => n.HasValue)
                                   .Select(n => n.Value)
                                   .ToList();

            if (numbers.Any())
            {
                var oddSum = numbers.Where(n => n % 2 != 0).Sum();
                Result = "Sum of Odd Numbers: " + oddSum.ToString();
            }
            else
            {
                Result = "Invalid numbers.";
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
