using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Goal.View
{
    public partial class FilePage : ContentPage
    {
        public FilePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await UpdateFileList();
        }

        async void Save(object sender, EventArgs args)
        {
            string filename = fileNameEntry.Text;
            if (String.IsNullOrEmpty(filename)) return;
            if (await DependencyService.Get<IFileWorker>().ExistsAsync(filename))
            {
                bool isRewrited = await DisplayAlert("Подверждение", "Файл уже существует, перезаписать его?", "Да", "Нет");
                if (isRewrited == false) return;
            }
            await DependencyService.Get<IFileWorker>().SaveTextAsync(fileNameEntry.Text, textEditor.Text);
            await UpdateFileList();
        }

        async void FileSelect(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem == null) return;
            string filename = (string)args.SelectedItem;
            textEditor.Text = await DependencyService.Get<IFileWorker>().LoadTextAsync((string)args.SelectedItem);
            fileNameEntry.Text = filename;
            filesList.SelectedItem = null;
        }

        async void Delete(object sender, EventArgs args)
        {
            string filename = (string)((MenuItem)sender).BindingContext;
            await DependencyService.Get<IFileWorker>().DeleteAsync(filename);
            await UpdateFileList();
        }

        async Task UpdateFileList()
        {
            filesList.ItemsSource = await DependencyService.Get<IFileWorker>().GetFilesAsync();
            filesList.SelectedItem = null;
        }
    }
}
