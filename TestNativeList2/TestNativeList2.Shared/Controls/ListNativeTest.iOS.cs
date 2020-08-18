#if __IOS__
using CoreGraphics;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Uno.UI.Controls;

namespace TestNativeList2.Shared.Controls
{
    public partial class ListNativeTest : BindableUIView
    {
        WaterfallCollectionView Waterfall;
        public ListNativeTest()
        {
            var flowLayout = new UICollectionViewFlowLayout()
            {
                ItemSize = new CGSize((float)UIScreen.MainScreen.Bounds.Size.Width - 20.0f, 50.0f),
            };
            var uICollectionView = new CGRect(0, 0, (int)UIScreen.MainScreen.Bounds.Size.Width, (int)UIScreen.MainScreen.Bounds.Size.Height);
            Waterfall = new WaterfallCollectionView(uICollectionView, flowLayout);
            Waterfall.DataSource = new WaterfallCollectionSource(Waterfall);
            Waterfall.Delegate = new WaterfallCollectionDelegate(Waterfall);

            AddSubview(Waterfall);
    
        }
      
    }
}
#endif