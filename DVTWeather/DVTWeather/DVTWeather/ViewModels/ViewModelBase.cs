using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace DVTWeather.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService _navigationService { get; }

        protected IPageDialogService _pageDialogService { get; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
        }

        #region INavigationAware

        public virtual void OnNavigatedFrom(INavigationParameters parameters) { }

        public virtual void OnNavigatedTo(INavigationParameters parameters) { }

        public virtual void OnNavigatingTo(INavigationParameters parameters) { }

        #endregion INavigationAware

        public virtual void Destroy()
        {

        }
    }
}
