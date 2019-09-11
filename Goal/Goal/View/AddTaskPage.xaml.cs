using Xamarin.Forms;

namespace Goal.View
{
    public partial class AddTaskPage : ContentPage
    {
        public ViewModel.TaskViewModel viewModel;
        private int id;


        public AddTaskPage(int id)
        {
            InitializeComponent();
            viewModel = new ViewModel.TaskViewModel(id);
            Content.BindingContext = viewModel;
            this.id = id;
        }

        public AddTaskPage(Model.Task task, int id)
        {
            InitializeComponent();
            viewModel = new ViewModel.TaskViewModel(task, id);
            Content.BindingContext = viewModel;
        }
    }
}
