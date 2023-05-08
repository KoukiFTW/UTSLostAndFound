﻿

using UTSLostAndFound.Model;
using UTSLostAndFound.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace UTSLostAndFound.ViewModel
{
    public class CategoryDetailViewModel : BaseViewModel
    {
        public ICommand TapBackCommand { get; set; }
        public ICommand TapCommand { get; private set; }

        public ObservableCollection<ProductListModel> _AllProductDataList = new ObservableCollection<ProductListModel>();
        public ObservableCollection<ProductListModel> AllProductDataList
        {
            get
            {
                return _AllProductDataList;
            }
            set
            {
                _AllProductDataList = value;
                OnPropertyChanged("AllProductDataList");
            }
        }
        public ObservableCollection<ProductListModel> _FoundItemDataList = new ObservableCollection<ProductListModel>();
        public ObservableCollection<ProductListModel> FoundItemDataList
        {
            get
            {
                return _FoundItemDataList;
            }
            set
            {
                _FoundItemDataList = value;
                OnPropertyChanged("FoundItemDataList");
            }
        }
        public string PageTitle
        {
            get
            {
                return CategoryModel.CategoryName;
            }
        }
        CategoriesModel CategoryModel { get; set; }
        public CategoryDetailViewModel(CategoriesModel data)
        {
            PopulateData();
            CategoryModel = new CategoriesModel();
            CategoryModel = data;
            TapBackCommand = new Command<object>(GoBack);
            TapCommand = new Command<ProductListModel>(SelectProduct);
        }

        void PopulateData()
        {
            AllProductDataList.Clear();
            AllProductDataList.Clear();
            AllProductDataList.Add(new ProductListModel() { Name = "Speekah", LastSeen = "Last seen:", Date = "01/03/2023", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png" });
            AllProductDataList.Add(new ProductListModel() { Name = "Leather Wristwatch", LastSeen = "Last seen:", Date = "26/04/2023", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image2.png" });
            AllProductDataList.Add(new ProductListModel() { Name = "ASMR device", LastSeen = "Last seen:", Date = "18/04/2023", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image3.png" });
            AllProductDataList.Add(new ProductListModel() { Name = "Overpriced earbuds", LastSeen = "Last seen:", Date = "04/05/2023", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image4.png" });

        }

        private async void GoBack(object obj)
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
        private async void SelectProduct(ProductListModel obj)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ProductDetails());
        }

    }
}
