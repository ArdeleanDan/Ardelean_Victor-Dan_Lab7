namespace Ardelean_Victor_Dan_Lab7;

using Ardelean_Victor_Dan_Lab7.Models;
public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (ShopList)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveShopListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (ShopList)BindingContext;
        await App.Database.DeleteShopListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductPage((ShopList)this.BindingContext));


    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (ShopList)BindingContext;

        listView.ItemsSource = await App.Database.GetListProductsAsync(shopl.ID);
    }
    void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        
    }
    async void OnDeleteItemButtonClicked(object sender, EventArgs e)
    {
        var selectedProduct = listView.SelectedItem as Product;
        if (selectedProduct == null)
            return;

        var shopList = (ShopList)BindingContext;

        var listProductEntry =
            await App.Database.GetListProductEntryAsync(shopList.ID, selectedProduct.ID);

        if (listProductEntry != null)
        {
            await App.Database.DeleteListProductAsync(listProductEntry);
        }

        listView.ItemsSource = await App.Database.GetListProductsAsync(shopList.ID);
    }
    var items = await App.Database.GetShopsAsync();
    ShopPicker.ItemsSource = (System.Collections.IList) items;
    ShopPicker.ItemDisplayBinding = new Binding("ShopDetails");
    Shop selectedShop = (ShopPicker.SelectedItem as Shop);
    slist.ShopID = selectedShop.ID;
}