using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace TestNativeList2.Shared.Controls
{
    class TextCollectionViewCell : UICollectionViewCell
    {
        public static NSString Key = new NSString("CollectionViewCell1");
        public UILabel label;

        public TextCollectionViewCell(IntPtr handle) : base(handle)
        {
            BackgroundColor = UIColor.FromRGB(164, 205, 255);
            label = new UILabel();

            ContentView.AddSubview(label);
        }

        public void UpdateCell(string text)
        {
            label.Text = text;
            label.Frame = new CGRect(5, 5, ContentView.Bounds.Width, 26);
        }
    }
}
