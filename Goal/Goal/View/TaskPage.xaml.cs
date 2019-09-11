using Xamarin.Forms;

namespace Goal.View
{
    public partial class TaskPage : ContentPage
    {
        public ViewModel.TaskViewModel viewModel;

        public TaskPage(int id)
        {
            InitializeComponent();
            viewModel = new ViewModel.TaskViewModel(id);
            Content.BindingContext = viewModel;
        }

        public TaskPage(Model.Task model)
        {
            InitializeComponent();
            viewModel = new ViewModel.TaskViewModel(model);
            Content.BindingContext = viewModel;
        }
    }
}
