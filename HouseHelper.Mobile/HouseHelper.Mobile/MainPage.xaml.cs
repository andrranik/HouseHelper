using System.Reactive.Disposables;
using HouseHelper.ViewModel;
using ReactiveUI;
using ReactiveUI.XamForms;

namespace HouseHelper.Mobile
{
    public partial class MainPage : ReactiveContentPage<MainViewModel>
    {
        public MainPage(MainViewModel model)
        {
            InitializeComponent();

            ViewModel = model;
            this.WhenActivated(disposable =>
            {
                this.Bind(ViewModel, x => x.TheText, x => x.TheTextBox.Text)
                    .DisposeWith(disposable);

                this.OneWayBind(ViewModel,
                    vm => vm.UiItems,
                    v => v.TheListView.ItemsSource);
            });
        }
    }
}