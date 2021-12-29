using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tumblro.ViewModels
{
    public class SampleDialogViewModel : BindableBase, IDialogAware
    {
        public SampleDialogViewModel()
        {
            CloseCommand = new DelegateCommand(() => RequestClose?.Invoke(null));
        }

        public event Action<IDialogParameters> RequestClose;

        public DelegateCommand CloseCommand { get; }

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters) {
            ErrorMessage = parameters.GetValue<string>("message");
        }


        private string _errorMessage { get; set; }
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                RaisePropertyChanged("ErrorMessage");
            }
        }
    }
}


