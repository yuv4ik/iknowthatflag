using System.Collections.Generic;
using Xamarin.Forms;

namespace IKnowThatFlag.Controls
{
    public class MultiChoiceView : StackLayout
    {
        public List<string> Choices
        {
            get { return (List<string>)GetValue(ChoicesProperty); }
            set { SetValue(ChoicesProperty, value); }
        }

        public static readonly BindableProperty ChoicesProperty =
            BindableProperty.Create(nameof(Choices), typeof(List<string>), typeof(MultiChoiceView), null,
                                     BindingMode.Default, null, OnItemsSourceChanged);

        static void OnItemsSourceChanged(BindableObject bindable, object oldvalue, object newvalue) =>
            ((MultiChoiceView)bindable).PopulateMultiChoiceView();

        public string SelectedChoice
        { 
            get { return (string)GetValue(SelectedChoiceProperty); }
            set { SetValue(SelectedChoiceProperty, value); }
        }

        public static readonly BindableProperty SelectedChoiceProperty =
            BindableProperty.Create(nameof(SelectedChoice), typeof(string), typeof(MultiChoiceView), defaultBindingMode: BindingMode.TwoWay);

        void PopulateMultiChoiceView()
        {
            this.Children.Clear();
            foreach(var choice in Choices)
            {
                var btn = new Button
                {
                    Text = choice
                };
                btn.Clicked += (sender, e) => SelectedChoice = choice;
                this.Children.Add(btn);
            }
        }
    }
}

