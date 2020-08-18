﻿using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace TestNativeList2.Shared.Controls
{
    class WaterfallCollectionDelegate : UICollectionViewDelegate
    {
        #region Computed Properties
        public WaterfallCollectionView CollectionView { get; set; }
        #endregion

        #region Constructors
        public WaterfallCollectionDelegate(WaterfallCollectionView collectionView)
        {

            // Initialize
            CollectionView = collectionView;

        }
        #endregion

        #region Overrides Methods
        public override bool ShouldHighlightItem(UICollectionView collectionView, NSIndexPath indexPath)
        {
            // Always allow for highlighting
            return true;
        }

        public override void ItemHighlighted(UICollectionView collectionView, NSIndexPath indexPath)
        {
            // Get cell and change to green background
            var cell = collectionView.CellForItem(indexPath);
            cell.ContentView.BackgroundColor = UIColor.FromRGB(183, 208, 57);
        }

        public override void ItemUnhighlighted(UICollectionView collectionView, NSIndexPath indexPath)
        {
            // Get cell and return to blue background
            var cell = collectionView.CellForItem(indexPath);
            cell.ContentView.BackgroundColor = UIColor.FromRGB(164, 205, 255);
        }
        #endregion
    }
}
