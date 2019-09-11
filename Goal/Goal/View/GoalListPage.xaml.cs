using Xamarin.Forms;

namespace Goal.View
{
    public partial class GoalListPage : ContentPage
    {
        public static ViewModel.GoalViewModel viewModel;
        public GoalListPage()
        {
            InitializeComponent();
            viewModel = new ViewModel.GoalViewModel();
            Content.BindingContext = viewModel;
            listView.ItemTapped += OnItemTapped;
        }

        public async void OnDelete(object sender, System.EventArgs e)
        {
            var item = ((MenuItem)sender).CommandParameter;
            var goal = (Model.Goal)item;
            var answer = await DisplayAlert("Delete", goal.Id + " " + goal.Description + " delete context action", "OK", "No");
            if (answer)
            {
                App.GoalTable.DeleteItem(goal.Id);
                OnAppearing();
            }
        }

        protected override void OnAppearing()
        {
            listView.ItemsSource = App.GoalTable.GetItems();
        }

        private async void ButtonFile(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new FilePage());
        }

        private async void ButtonAdd(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AddGoalPage());
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Model.Goal temp = (Model.Goal)listView.SelectedItem;
            await Navigation.PushAsync(new GoalPage((Model.Goal)e.Item, temp.Id));
            listView.SelectedItem = null;
        }
    }
}
