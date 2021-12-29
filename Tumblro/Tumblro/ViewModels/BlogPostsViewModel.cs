using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tumblro.ViewModels
{
    public class BlogPostsViewModel : BindableBase, INavigationAware
    {
        public BlogPostsViewModel(IDialogService dialogService)
        {
            NumberPostList = Enumerable.Range(1, 20).ToList();
            TypeList = new List<string>() { "text", "quote", "link", "answer", "video", "audio", "photo", "chat" };
            Reload = new DelegateCommand(async () => await LoadData(true));
            _dialogService = dialogService;
        }

        public interface IInitializeAsync
        {
            Task InitializeAsync(INavigationParameters parameters);
        }
        public DelegateCommand Reload { get; private set; }
        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.Count != 0)
            {
                IsLoading = true;
                //get a single typed parameter
                BlogName = parameters.GetValue<string>("BlogName");
                SelectedType = parameters.GetValue<string>("SelectedType");
                SelectedNumberPosts = parameters.GetValue<int>("NumberPosts");
                Task.Run(async () => await LoadData());
            }
        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        private IDialogService _dialogService;

        /// <summary>
        /// Loads data for BlogName 
        /// </summary>
        /// <param name="check">True if blog existence verification needed. False is default</param>
        /// <returns></returns>
        private async Task LoadData(bool check = false)
        {
            IsLoading = true;

            if (check)
            {

                bool result = await HelpMethods.CheckIfBlogExistsAsync(BlogName.ToLower());

                if (result)
                {
                  
                }
                else
                {
                    ShowDialog();
                    IsLoading = false;
                    return;
                }
            }

            using (var client = new HttpClient())
            {
                try
                {
                    string URL = "https://api.tumblr.com/v2/blog/" + BlogName.ToLower() + ".tumblr.com/posts?api_key=" + Constants.ApiKey + "& type=" + SelectedType + "&limit=" + SelectedNumberPosts.ToString();
                    HttpResponseMessage response = await client.GetAsync(URL);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        Response = JsonConvert.DeserializeObject<Data>(result);
                        Items = new ObservableCollection<Post>(Response.response.posts);
                        IsLoading = false;
                        BlogName = BlogName;
                    }
                }
                catch (Exception ex)
                {
                    var a = ex.Message;
                }
            }
        }
        /// <summary>
        /// Shows simple dialog form 
        /// </summary>
        private void ShowDialog()
        {
            var message = "There is no such blog or something else went wrong. Try again!";
            //using the dialog service as-is
            _dialogService.ShowDialog("DismissableDialog", new DialogParameters($"message={message}"), r =>
            {

            });
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

        private string _selectedType { get; set; }
        public string SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value;
                RaisePropertyChanged("SelectedType");
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
        private int _selectedNumberPosts { get; set; }
        public int SelectedNumberPosts
        {
            get { return _selectedNumberPosts; }
            set
            {
                _selectedNumberPosts = value;
                RaisePropertyChanged("SelectedNumberPosts");
            }
        }

        private Data _response { get; set; }
        public Data Response
        {
            get { return _response; }
            set
            {
                _response = value;
                RaisePropertyChanged("Response");
            }
        }

        private ObservableCollection<Post> _items { get; set; }
        public ObservableCollection<Post> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                RaisePropertyChanged("Items");
            }
        }

        private int _numberPosts = 0;
        public int NumberPosts
        {
            get { return _numberPosts; }
            set
            {
                _numberPosts = value;
                RaisePropertyChanged("NumberPosts");
            }
        }

        private string _blogName = "";
        public string BlogName
        {
            get { return _blogName; }
            set
            {
                _blogName = value;
                RaisePropertyChanged("BlogName");
            }
        }

        private string _postType = "";
        public string PostType
        {
            get { return _postType; }
            set
            {
                _postType = value;
                RaisePropertyChanged("PostType");
            }
        }

        private bool _isLoading = false;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                RaisePropertyChanged("IsLoading");
            }
        }

        private byte[] _blogImage = null;
        public byte[] BlogImage
        {
            get { return _blogImage; }
            set
            {
                _blogImage = value;
                RaisePropertyChanged("BlogImage");
            }
        }

        private ImageSource _blogImageSource = null;
        public ImageSource BlogImageSource
        {
            get { return _blogImageSource; }
            set
            {
                _blogImageSource = value;
                RaisePropertyChanged("BlogImageSource");
            }
        }
    }
}
