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
    public partial class ComputerImplementationPage : ContentPage
    {
        TTTImplementation ttt;
        public ComputerImplementationPage()
        {
            InitializeComponent();
            ttt = new TTTImplementation(grid, label_score, label_text, label_role, true);
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ttt.ChangeRole();
        }
    }
}