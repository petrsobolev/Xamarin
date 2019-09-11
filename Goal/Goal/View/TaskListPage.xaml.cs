using System;
using System.Linq;
using Xamarin.Forms;

namespace Goal.View
{
    public partial class TaskListPage : ContentPage
    {
        public static ViewModel.TaskViewModel viewModel;
        private int id;

        public TaskListPage(int id)
        {
            InitializeComponent();
            label.Text += "\n" + App.GoalTable.GetItem(id).ShortName;
            this.id = id;
            viewModel = new ViewModel.TaskViewModel(id);
            Content.BindingContext = viewModel;
            listViewTask.ItemTapped += OnItemTapped;
        }

        public async void OnDelete(object sender, EventArgs e)
        {
            var item = ((MenuItem)sender).CommandParameter;
            var task = (Model.Task)item;
            var answer = await DisplayAlert("Delete", task.Id + " " + task.Description + " delete context action", "OK", "No");
            if (answer)
            {
                App.TaskTable.DeleteItem(task.Id);
                OnAppearing();
            }
        }

        protected override void OnAppearing()
        {
            listViewTask.ItemsSource = App.TaskTable.GetItems().Where(x => x.IdOfGoal == id);
        }

        private async void ButtonAddTask(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AddTaskPage(id));
        }

        private void ButtonDeleteTask(object sender, System.EventArgs e)
        {

        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new TaskPage((Model.Task)e.Item));
            listViewTask.SelectedItem = null;
        }
    }
}
