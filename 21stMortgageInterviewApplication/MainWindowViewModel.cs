using System;
using System.Linq;
using System.ComponentModel;

namespace _21stMortgageInterviewApplication
{
    public class MainWindowViewModel : INotifyPropertyChanged
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
                OnPropertyChanged("InputTextBox");
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
                Result = numbers.Max().ToString();
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
                Result = evenSum.ToString();
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
