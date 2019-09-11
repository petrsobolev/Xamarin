using System;

using Xamarin.Forms;

namespace Goal.CustomControl
{
    [ContentProperty("LabelEditor")]
    public partial class LabelEditor : ContentView
    {
        public LabelEditor()
        {
            InitializeComponent();
            Content.BindingContext = this;
        }

        public static readonly BindableProperty NameProperty =
            BindableProperty.Create(nameof(Name), typeof(String), typeof(LabelEditor), "", BindingMode.TwoWay);
        #region Properties

        public string LabelText
        {
            get { return this.labelShortName.Text; }
            set { this.labelShortName.Text = value; }
        }

        public string EditorText
        {
            get
            {
                return this.editorShortName.Text;
            }
            set
            {
                this.editorShortName.Text = value;
            }
        }
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        #endregion
    }
}
