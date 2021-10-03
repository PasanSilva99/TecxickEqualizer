using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.Core;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TecxickEqualizer0._1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        SolidColorBrush KnobDefault = new SolidColorBrush();
        SolidColorBrush KnobHover = new SolidColorBrush();
        SolidColorBrush KnobPressed = new SolidColorBrush();
        private Double BassLevel = 0;
        private Double DetailsLevel = 0;
        private Double WidthLevel = 0;
        private Double GainLevel = 0;
        
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(1057, 610);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            KnobDefault.Color = Windows.UI.Color.FromArgb((byte)255, (byte)46, (byte)46, (byte)46);
            KnobHover.Color = Windows.UI.Color.FromArgb((byte)255, (byte)87, (byte)87, (byte)87);
            KnobPressed.Color = Windows.UI.Color.FromArgb((byte)255, (byte)38, (byte)38, (byte)38);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Hide default title bar.
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

        }

        private void prgButton_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            KnobHoverBrush(sender);
        }

        private void prgButton_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            KnobDefaultBrush(sender);
        }

        private void KnobHoverBrush(object sender)
        {
            var prgButton = sender as Grid;
            prgButton.Background = KnobHover;
        }

        private void KnobDefaultBrush(object sender)
        {
            var prgButton = sender as Grid;
            prgButton.Background = KnobDefault;
        }

        private void Knob_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
        {
            var tag = (sender as Grid).Tag.ToString();

            if (e.GetCurrentPoint(sender as Grid).Properties.MouseWheelDelta > 0)
            {
                switch (tag)
                {
                    case "KnobBass":
                        ChangeBass('+');
                        break;
                    case "KnobDetails":
                        ChangeDetails('+');
                        break;
                    case "KnobWidth":
                        ChangeWidth('+');
                        break;
                    case "KnobGain":
                        ChangeGain('+');
                        break;
                }
            }
            else
            {
                switch (tag)
                {
                    case "KnobBass":
                        ChangeBass('-');
                        break;
                    case "KnobDetails":
                        ChangeDetails('-');
                        break;
                    case "KnobWidth":
                        ChangeWidth('-');
                        break;
                    case "KnobGain":
                        ChangeGain('-');
                        break;
                }
            }
        }

        private void ChangeGain(char v)
        {
            if (v == '+')
            {
                if (GainLevel < 40) GainLevel++;
                txt_gain.Text = GainLevel.ToString("F0");
                prg_gain.Value = GainLevel;
            }
            else
            {
                if (GainLevel > -35) GainLevel++;
                txt_gain.Text = GainLevel.ToString("F0");
                prg_gain.Value = GainLevel;
            }
        }

        private void ChangeWidth(char v)
        {
            if (v == '+')
            {
                if (WidthLevel < 40) WidthLevel++;
                txt_Width.Text = (WidthLevel / 40 * 100).ToString("F0") + "%";
                prg_width.Value = (int)(WidthLevel / 40 * 100);
            }
            else
            {
                if (WidthLevel > 40) WidthLevel--;
                txt_Width.Text = (WidthLevel / 40 * 100).ToString("F0") + "%";
                prg_width.Value = (int)(WidthLevel / 40 * 100);
            }
        }

        private void ChangeDetails(char v)
        {
            if (v == '+')
            {
                if (DetailsLevel < 40) DetailsLevel++;
                txt_Details.Text = (DetailsLevel / 40 * 100).ToString("F0") + "%";
                prg_details.Value = (int)(DetailsLevel / 40 * 100);
            }
            else
            {
                if (DetailsLevel > 40) DetailsLevel--;
                txt_Details.Text = (DetailsLevel / 40 * 100).ToString("F0") + "%";
                prg_details.Value = (int)(DetailsLevel / 40 * 100);
            }
        }

        private void ChangeBass(char dir)
        {
            if (dir == '+')
            {
                if (BassLevel < 40) BassLevel++;
                txt_bass.Text = (BassLevel / 40 * 100).ToString("F0") + "%";
                prg_bass.Value = (int)(BassLevel / 40 * 100);
            }
            else
            {
                if (BassLevel > 0) BassLevel--;
                txt_bass.Text = (BassLevel / 40 * 100).ToString("F0") + "%";
                prg_bass.Value = (int)(BassLevel / 40 * 100);
            }
        }

    }
}
