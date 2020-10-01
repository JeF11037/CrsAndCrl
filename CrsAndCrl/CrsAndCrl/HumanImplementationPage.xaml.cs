using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrsAndCrl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HumanImplementationPage : ContentPage
    {
        public HumanImplementationPage()
        {
            InitializeComponent();
            TTTImplementation ttt = new TTTImplementation(grid, label_score, label_text, null, false);
        }
    }
}