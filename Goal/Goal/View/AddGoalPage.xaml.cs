using System.Threading.Tasks;
using Xamarin.Forms;

namespace Goal.View
{
    public partial class AddGoalPage : ContentPage
    {
        public ViewModel.GoalViewModel viewModel;

        public AddGoalPage()
        {
            InitializeComponent();
            viewModel = new ViewModel.GoalViewModel();
            Content.BindingContext = viewModel;
        }

        public async Task GoBackAsync()
        {
            await Navigation.PopToRootAsync();
        }
    }
}
