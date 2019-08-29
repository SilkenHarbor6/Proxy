using Proxy.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proxy.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class addPage : ContentPage
	{
		public addPage ()
		{
			InitializeComponent ();
            BindingContext = new addPageViewModel();
		}
	}
}