using EvidencaPridelkov.View.NotesView;
using EvidencaPridelkov.View.OrderView;
using EvidencaPridelkov.View.ProductView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencaPridelkov.ViewModels
{
    public class LinkViewModel
    {
        private INavigation _navigation;
        public Command ProductBtn { get; }
        public Command OrderBtn { get; }
        public Command NotesBtn { get; }

        public LinkViewModel(INavigation navigation)
        {
            _navigation = navigation;
            ProductBtn = new Command(ProductBtnTappedAsync);
            OrderBtn = new Command(OrderBtnTappedAsync);
            NotesBtn = new Command(NotesBtnTappedAsync);
        }

        private async void ProductBtnTappedAsync(object obj)
        {
            await _navigation.PushAsync(new ProductListView());
        }

        private async void OrderBtnTappedAsync(object obj)
        {
            await _navigation.PushAsync(new OrderListView());
        }

        private async void NotesBtnTappedAsync(object obj)
        {
            await _navigation.PushAsync(new NotesListView());
        }
    }
}
