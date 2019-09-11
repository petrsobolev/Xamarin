using Xamarin.Forms;

namespace Goal.View
{
    public partial class GoalPage : ContentPage
    {
        public ViewModel.GoalViewModel viewModel;
        private int id;

        public GoalPage()
        {
            InitializeComponent();
            viewModel = new ViewModel.GoalViewModel();
            Content.BindingContext = viewModel;
        }

        public GoalPage(Model.Goal model, int id)
        {
            InitializeComponent();
            viewModel = new ViewModel.GoalViewModel(model);
            Content.BindingContext = viewModel;
            this.id = id;
        }

        private async void ButtonTasks(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new TaskListPage(id));
        }
    }
}
