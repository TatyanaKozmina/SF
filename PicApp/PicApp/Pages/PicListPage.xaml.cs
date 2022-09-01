using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PicApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PicListPage : ContentPage
    {
        public ObservableCollection<Models.PicItem> Items { get; set; }

        public PicListPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<Models.PicItem>
            {
                new Models.PicItem("Чайник", $"Chainik.png", System.DateTime.Today.AddDays(1)),
                new Models.PicItem("Мультиварка", $"Multivarka.png", System.DateTime.Today.AddDays(2)),
                new Models.PicItem("Посудомойка", $"PosudomoechnayaMashina.png", System.DateTime.Today.AddDays(3)),
                new Models.PicItem("Стиралка", $"StiralnayaMashina.png", System.DateTime.Today.AddDays(4))
            };

            PicListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await Navigation.PushAsync(new PicDetailPage((Models.PicItem)e.Item));
        }
    }
}
