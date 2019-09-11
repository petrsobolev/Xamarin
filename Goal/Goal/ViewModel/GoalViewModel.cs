using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Goal.ViewModel
{
    public class GoalViewModel : INotifyPropertyChanged
    {
        public Model.Goal goal { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private static ObservableCollection<Model.Goal> listGoals = new ObservableCollection<Model.Goal>();

        public static ObservableCollection<Model.Goal> ListGoals
        {
            get { return listGoals; }
            set { listGoals = value; }
        }
        public ObservableCollection<Model.Goal> BindGoals
        {
            get { return listGoals; }
            set
            {
                listGoals = value;
                OnPropertyChanged("BindGoals");
            }
        }
        
        public ICommand OnAddCommand { get; protected set; }
        public ICommand OnSaveCommand { get; protected set; }
        public ICommand OnUpdateCommand { get; protected set; }
        public ICommand OnDeleteCommand { get; protected set; }


        public GoalViewModel()
        {
            FillListGoalsAsync();
            goal = new Model.Goal();
            OnAddCommand = new Command(OnAdd);
            OnSaveCommand = new Command(OnSave);
            OnUpdateCommand = new Command(OnUpdate);
        }

        public GoalViewModel(Model.Goal model)
        {
            goal = model;
            OnAddCommand = new Command(OnAdd);
            OnSaveCommand = new Command(OnSave);
            OnUpdateCommand = new Command(OnUpdate);
            OnDeleteCommand = new Command(OnDelete);
        }


        public void FillListGoalsAsync()
        {
            try
            {
                ListGoals = new ObservableCollection<Model.Goal>(App.GoalTable.GetItems());
            }
            catch(Exception)
            {
                    
            }
        }


        public string ShortName
        {
            get { return goal.ShortName; }
            set
            {
                if (goal.ShortName != value)
                {
                    goal.ShortName = value;
                    OnPropertyChanged("ShortName");
                }
            }
        }

        public string Description
        {
            get { return goal.Description; }
            set
            {
                if (goal.Description != value)
                {
                    goal.Description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public DateTime ReachOn
        {
            get { return goal.ReachOn; }
            set
            {
                if (goal.ReachOn != value)
                {
                    goal.ReachOn = value;
                    OnPropertyChanged("ReachOn");
                }
            }
        }

        public bool Enable
        {
            get { return goal.Enable; }
            set
            {
                if (goal.Enable != value)
                {
                    goal.Enable = value;
                    OnPropertyChanged("Enable");
                }
            }
        }


        private void OnAdd()
        {
            goal = new Model.Goal();
            ShortName = string.Empty;
            Description = string.Empty;
            ReachOn = DateTime.Today;
            Enable = false;
        }

        private void OnSave()
        {
            App.GoalTable.SaveItem(new Model.Goal(ShortName, Description, ReachOn, Enable));
            Application.Current.MainPage.Navigation.PopAsync();
        }

        private void OnUpdate()
        {
            App.GoalTable.UpdateItem(goal);
            Application.Current.MainPage.Navigation.PopAsync();
        }

        private void OnDelete()
        {
            App.GoalTable.DeleteItem(goal.Id);
            Application.Current.MainPage.Navigation.PopAsync();
        }


        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}