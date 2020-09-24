using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrsAndCrl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : ContentPage
    {
        public MainMenu()
        {
            InitializeComponent();

            NavigateCommand = new Command<Type>(async (Type pageType) =>
            {
                Page page = (Page)Activator.CreateInstance(pageType);
                await Navigation.PushAsync(page);
            });

            BindingContext = this;
        }

        public ICommand NavigateCommand { private set; get; }

        private async void HumanButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HumanImplementationPage());
        }

        private async void ComputerButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ComputerImplementationPage());
        }
    }
}