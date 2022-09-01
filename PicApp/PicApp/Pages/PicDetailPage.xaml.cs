using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PicApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PicDetailPage : ContentPage
    {
        public PicDetailPage(Models.PicItem item = null)
        {
            InitializeComponent();
            BindingContext = item;
        }
    }
}