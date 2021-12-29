using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tumblro.ViewModels
{
    public class SampleDialogViewModel : IDialogAware
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

        public void OnDialogOpened(IDialogParameters parameters) { }
    }
}


