namespace Proxy.View
{
    using DLL.Model;
    using Proxy.ViewModel;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Edit 
	{
		public Edit (Persona item)
		{
			InitializeComponent ();
            BindingContext = new EditViewModel(item);
		}
	}
}