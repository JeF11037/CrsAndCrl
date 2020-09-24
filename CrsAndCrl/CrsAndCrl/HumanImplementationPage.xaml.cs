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

        bool CrossOrCircle = true;

        public HumanImplementationPage()
        {
            InitializeComponent();

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                Image boxi = (Image)s;
                if (boxi.Source.ToString().Equals("File: empty.png"))
                {
                    if (CrossOrCircle)
                    {
                        boxi.Source = "cross.png";
                    }
                    else
                    {
                        boxi.Source = "circle.png";
                    }
                }
                CrossOrCircle = !CrossOrCircle;
            };

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    Image box = new Image {
                        BackgroundColor = Color.White,
                        Opacity = 0.7,
                        Margin = 2,
                        Source = "empty.png"
                    };
                    box.GestureRecognizers.Add(tapGestureRecognizer);
                    grid.Children.Add(box, y, x);
                }
            }
        }
    }
}