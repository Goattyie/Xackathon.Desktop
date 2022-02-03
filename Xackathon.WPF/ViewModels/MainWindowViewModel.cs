using DevExpress.Mvvm;
using System.Windows.Controls;
using System.Windows.Input;
using Xackathon.WPF.Pages;

namespace Xackathon.WPF.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel(Page page)
        {
            CurrentPage = page;
        }
        public Page CurrentPage { get; set; }
        public ICommand ChangeOnCreateRequestPage => new DelegateCommand(() => { CurrentPage = new CreateRequestPage(); });
        public ICommand ChangeOnProblemCategoryPage => new DelegateCommand(() => { CurrentPage = new ProblemCategoryPage(); });
    }
}
