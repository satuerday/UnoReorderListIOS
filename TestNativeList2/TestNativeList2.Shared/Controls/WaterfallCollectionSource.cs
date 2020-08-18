using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace TestNativeList2.Shared.Controls
{
    class WaterfallCollectionSource : UICollectionViewDataSource
    {
        #region Computed Properties
        public WaterfallCollectionView CollectionView { get; set; }
        public List<int> Numbers { get; set; } = new List<int>();
        #endregion

        #region Constructors
        public WaterfallCollectionSource(WaterfallCollectionView collectionView)
        {
            // Initialize
            CollectionView = collectionView;
            CollectionView.RegisterClassForCell(typeof(TextCollectionViewCell), TextCollectionViewCell.Key);
            // Init numbers collection
            for (int n = 0; n < 100; ++n)
            {
                Numbers.Add(n);
            }
        }
        #endregion

        #region Override Methods
        public override nint NumberOfSections(UICollectionView collectionView)
        {
            // We only have one section
            return 1;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            // Return the number of items
            return Numbers.Count;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            // Get a reusable cell and set {~~it's~>its~~} title from the item
            var cell = collectionView.DequeueReusableCell(TextCollectionViewCell.Key, indexPath) as TextCollectionViewCell;
            Console.WriteLine((int)indexPath.Item);
            cell.UpdateCell(Numbers[(int)indexPath.Item].ToString());
            Console.WriteLine("this is form source");
            return cell;
        }
        public override bool CanMoveItem(UICollectionView collectionView, NSIndexPath indexPath)
        {
            // We can always move items
            Console.WriteLine("Is Move");
            return true;
        }
        public override void MoveItem(UICollectionView collectionView, NSIndexPath sourceIndexPath, NSIndexPath destinationIndexPath)
        {
            // Reorder our list of items
            Console.WriteLine("Item move");
            var item = Numbers[(int)sourceIndexPath.Item];
            Numbers.RemoveAt((int)sourceIndexPath.Item);
            Numbers.Insert((int)destinationIndexPath.Item, item);
        }
        #endregion
    }
}
