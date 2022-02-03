using Xackathon.WPF.DI;
using Xackathon.WPF.ViewModels;

namespace Xackathon.WPF
{
    public class ViewModelLocator
    {
        public CreateRequestViewModel CreateRequestViewModel => IoC.Resolve<CreateRequestViewModel>();
        public ProblemCategoryViewModel ProblemCategoryViewModel => IoC.Resolve<ProblemCategoryViewModel>();
        public MainWindowViewModel MainWindowViewModel => IoC.Resolve<MainWindowViewModel>();
    }
}
