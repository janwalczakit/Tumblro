using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tumblro.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService, IDialogService dialogService)
            : base(navigationService)
        {
            Title = "Tumblr";
            ShowTumblr = new DelegateCommand(async () => await ShowTAsync());
            _navigationService = navigationService;
            _dialogService = dialogService;
            TypeList = new List<string>() { "text", "quote", "link", "answer", "video", "audio", "photo", "chat" };
            NumberPostList = Enumerable.Range(1, 20).ToList();
        }

        public DelegateCommand ShowTumblr { get; private set; }

        private INavigationService _navigationService;
        private IDialogService _dialogService;

        /// <summary>
        /// Shows simple dialog form 
        /// </summary>
        private void ShowDialog()
        {
            var message = "There is no such blog or something else went wrong. Try again!";
            _dialogService.ShowDialog("DismissableDialog", new DialogParameters($"message={message}"), r =>
            {

            });
        }

        /// <summary>
        /// Checks if data in entry and two pickers is valid 
        /// </summary>
        /// <returns>bool</returns>
        private bool ValidateData()
        {
            PostTypeValidation = true;
            PostNumberValidation = true;
            EntryValidation = true;

            bool anyvalidation = false;

            if (BlogName == null || BlogName.Length == 0)
            {
                EntryValidation = false;
                EntryValidationText = "UserName must be longer than 0";
                anyvalidation = true;
            }
            if (SelectedType == "")
            {
                PostTypeValidation = false;
                PostTypeValidationText = "Please select posts type";
                anyvalidation = true;
            }

            if (SelectedNumberPosts == 0)
            {
                PostNumberValidation = false;
                PostNumberValidationText = "Please select posts quantity";
                anyvalidation = true;
            }

            if (anyvalidation) return false;
            else return true;
        }

        private 

        /// <summary>
        /// Loads data for BlogName 
        /// </summary>
        /// <param name="check">True if blog existence verification needed. False is default</param>
        /// <returns></returns>
        async Task ShowTAsync()
        {
            if (!ValidateData()) return;


            bool result = await HelpMethods.CheckIfBlogExistsAsync(BlogName.ToLower());

            if(result)
            {
                var navParameters = new NavigationParameters { { "BlogName", BlogName }, { "SelectedType", SelectedType }, { "NumberPosts", SelectedNumberPosts } };
                await _navigationService.NavigateAsync("BlogPosts", navParameters, animated: true);
            }
            else
            {
                ShowDialog();
            }
        }

        private List<string> _typeList { get; set; }
        public List<string> TypeList
        {
            get { return _typeList; }
            set
            {
                _typeList = value;
                RaisePropertyChanged("TypeList");
            }
        }

        private string _selectedType { get; set; } = "";
        public string SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value;
                PostTypeValidation = true;
                RaisePropertyChanged("SelectedType");
            }
        }

        private bool _entryValidation { get; set; } = true;
        public bool EntryValidation
        {
            get { return _entryValidation; }
            set
            {
                _entryValidation = value;
                RaisePropertyChanged("EntryValidation");
            }
        }

        private bool _postTypeValidation { get; set; } = true;
        public bool PostTypeValidation
        {
            get { return _postTypeValidation; }
            set
            {
                _postTypeValidation = value;
                RaisePropertyChanged("PostTypeValidation");
            }
        }

        private bool _postNumberValidation { get; set; } = true;
        public bool PostNumberValidation
        {
            get { return _postNumberValidation; }
            set
            {
                _postNumberValidation = value;
                RaisePropertyChanged("PostNumberValidation");
            }
        }

        private string _entryValidationText { get; set; } = "";
        public string EntryValidationText
        {
            get { return _entryValidationText; }
            set
            {
                _entryValidationText = value;
                RaisePropertyChanged("EntryValidationText");
            }
        }

        private string _postNumberValidationText { get; set; } = "";
        public string PostNumberValidationText
        {
            get { return _postNumberValidationText; }
            set
            {
                _postNumberValidationText = value;
                RaisePropertyChanged("PostNumberValidationText");
            }
        }

        private string _postTypeValidationText { get; set; } = "";
        public string PostTypeValidationText
        {
            get { return _postTypeValidationText; }
            set
            {
                _postTypeValidationText = value;
                RaisePropertyChanged("PostTypeValidationText");
            }
        }

        private List<int> _numberPostList { get; set; }
        public List<int> NumberPostList
        {
            get { return _numberPostList; }
            set
            {
                _numberPostList = value;
                RaisePropertyChanged("NumberPostList");
            }
        }

        private int _selectedNumberPosts { get; set; } = 0;
        public int SelectedNumberPosts
        {
            get { return _selectedNumberPosts; }
            set
            {
                _selectedNumberPosts = value;
                PostNumberValidation = true;
                RaisePropertyChanged("SelectedNumberPosts");
            }
        }

        private string _blogName = "";
        public string BlogName
        {
            get { return _blogName; }
            set
            {
                _blogName = value;
                if (_blogName != "") EntryValidation = true;
                RaisePropertyChanged("BlogName");
            }
        }
    }
}
