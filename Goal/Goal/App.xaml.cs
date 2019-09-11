using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace Goal
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "goals.db";
        private static Repository.GoalRepository goalTable;
        private static Repository.TaskRepository taskTable;

        public static Repository.GoalRepository GoalTable
        {
            get
            {
                if (goalTable == null)
                    goalTable = new Repository.GoalRepository(DATABASE_NAME);
                return goalTable;
            }
        }
        public static Repository.TaskRepository TaskTable
        {
            get
            {
                if (taskTable == null)
                    taskTable = new Repository.TaskRepository(DATABASE_NAME);
                return taskTable;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new View.GoalListPage());
        }

        protected override void OnStart()
        {
            if (Current.Properties.Keys.Contains("goals"))
                ViewModel.GoalViewModel.ListGoals = (ObservableCollection<Model.Goal>)Current.Properties["goals"];

            if (Current.Properties.Keys.Contains("tasks"))
                ViewModel.TaskViewModel.ListTasks = (ObservableCollection<Model.Task>)Current.Properties["tasks"];
        }

        protected override void OnSleep()
        {
            if (Current.Properties.Keys.Contains("goals"))
                Current.Properties["goals"] = ViewModel.GoalViewModel.ListGoals;
            else
                Current.Properties.Add("goals", ViewModel.GoalViewModel.ListGoals);

            if (Current.Properties.Keys.Contains("tasks"))
                Current.Properties["tasks"] = ViewModel.TaskViewModel.ListTasks;
            else
                Current.Properties.Add("tasks", ViewModel.TaskViewModel.ListTasks);
        }

        protected override void OnResume()
        {
            if (Current.Properties.ContainsKey("goals"))
                ViewModel.GoalViewModel.ListGoals = (ObservableCollection<Model.Goal>)Current.Properties["goals"];

            if (Current.Properties.ContainsKey("tasks"))
                ViewModel.TaskViewModel.ListTasks = (ObservableCollection<Model.Task>)Current.Properties["tasks"];
        }
    }
}
