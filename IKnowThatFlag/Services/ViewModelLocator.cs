using Xamarin.Forms;

namespace IKnowThatFlag.Services
{
    public static class ViewModelLocator
    {
        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable) =>
            (bool)bindable.GetValue(AutoWireViewModelProperty);

        public static void SetAutoWireViewModel(BindableObject bindable, bool value) =>
            bindable.SetValue(AutoWireViewModelProperty, value);

        static ITypeMapperService mapper = (Application.Current as App).DependencyResolver.Resolve<ITypeMapperService>();

        static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            var viewType = view.GetType();
            var viewModelType = mapper.MapViewToViewModel(viewType);
            var viewModel =  (Application.Current as App).DependencyResolver.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
    }
}
