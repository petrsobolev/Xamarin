using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Goal.ViewModel
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        public Model.Task task { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private static ObservableCollection<Model.Task> listTasks = new ObservableCollection<Model.Task>();
        private int id;

        public static ObservableCollection<Model.Task> ListTasks
        {
            get { return listTasks; }
            set { listTasks = value; }
        }
        public ObservableCollection<Model.Task> BindTasks
        {
            get { return listTasks; }
            set
            {
                listTasks = value;
                OnPropertyChanged("BindTasks");
            }
        }
        
        public ICommand OnSaveTaskCommand { get; protected set; }
        public ICommand OnUpdateTaskCommand { get; protected set; }
        public ICommand OnDeleteTaskCommand { get; protected set; }


        public TaskViewModel(int id)
        {
            try
            {
                ListTasks = new ObservableCollection<Model.Task>(App.TaskTable.GetItems());
            }
            catch (Exception)
            {

            }
            task = new Model.Task();
            this.id = id;
            OnSaveTaskCommand = new Command(OnSave);
            OnUpdateTaskCommand = new Command(OnUpdate);
            OnDeleteTaskCommand = new Command(OnDelete);
        }

        public TaskViewModel(Model.Task model)
        {
            task = model;
            OnSaveTaskCommand = new Command(OnSave);
            OnUpdateTaskCommand = new Command(OnUpdate);
            OnDeleteTaskCommand = new Command(OnDelete);
        }

        public TaskViewModel(Model.Task model, int id)
        {
            task = model;
            this.id = id;
            OnSaveTaskCommand = new Command(OnSave);
            OnUpdateTaskCommand = new Command(OnUpdate);
            OnDeleteTaskCommand = new Command(OnDelete);
        }


        public string ShortName
        {
            get { return task.ShortName; }
            set
            {
                if (task.ShortName != value)
                {
                    task.ShortName = value;
                    OnPropertyChanged("ShortName");
                }
            }
        }

        public string Description
        {
            get { return task.Description; }
            set
            {
                if (task.Description != value)
                {
                    task.Description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public DateTime StartAt
        {
            get { return task.StartAt; }
            set
            {
                if (task.StartAt != value)
                {
                    task.StartAt = value;
                    OnPropertyChanged("StartAt");
                }
            }
        }

        public DateTime ReachOn
        {
            get { return task.ReachOn; }
            set
            {
                if (task.ReachOn != value)
                {
                    task.ReachOn = value;
                    OnPropertyChanged("ReachOn");
                }
            }
        }

        public int PercentageOfCompletion
        {
            get { return task.PercentageOfCompletion; }
            set
            {
                if (task.PercentageOfCompletion != value)
                {
                    task.PercentageOfCompletion = value;
                    OnPropertyChanged("PercentageOfCompletion");
                }
            }
        }

        public bool Done
        {
            get { return task.Done; }
            set
            {
                if (task.Done != value)
                {
                    task.Done = value;
                    OnPropertyChanged("Done");
                }
            }
        }


        private void OnSave()
        {
            App.TaskTable.SaveItem(new Model.Task(id, ShortName, Description, StartAt, ReachOn, PercentageOfCompletion, Done));
            Application.Current.MainPage.Navigation.PopAsync();
        }

        private void OnUpdate()
        {
            App.TaskTable.UpdateItem(task);
            Application.Current.MainPage.Navigation.PopAsync();
        }

        private void OnDelete()
        {
            App.TaskTable.DeleteItem(task.Id);
            Application.Current.MainPage.Navigation.PopAsync();
        }


        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}