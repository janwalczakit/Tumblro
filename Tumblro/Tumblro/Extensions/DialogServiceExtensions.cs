using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tumblro
{
    public static class DialogServiceExtensions
    {
        public static async Task ShowNotificationAsync(this IDialogService dialogService, string message, Action<IDialogResult> callBack)
        {
            await dialogService.ShowDialogAsync("DismissableDialog", new DialogParameters($"message={message}"));
        }
    }
}
