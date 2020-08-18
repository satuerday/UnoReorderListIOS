using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace TestNativeList2.Shared.Controls
{
    [Register("WaterfallCollectionView")]
    class WaterfallCollectionView : UICollectionView
    {
        #region Computed Properties
        public WaterfallCollectionSource Source
        {
            get
            {
                return (WaterfallCollectionSource)DataSource;
            }
        }
        #endregion

        #region Constructors
        public WaterfallCollectionView(IntPtr handle) : base(handle)
        {
        }
        #endregion

        #region Constructors
        public WaterfallCollectionView(CGRect frame, UICollectionViewLayout layout) : base(frame, layout)
        {
            UILongPressGestureRecognizer uILongPressGesture = new UILongPressGestureRecognizer(longPressGesture);
            this.AddGestureRecognizer(uILongPressGesture);
        }
        #endregion
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            // Initialize
            DataSource = new WaterfallCollectionSource(this);
            Delegate = new WaterfallCollectionDelegate(this);

        }
        private void longPressGesture(UILongPressGestureRecognizer longPressGesture)
        {
            switch (longPressGesture.State)
            {
                case UIGestureRecognizerState.Began:
                    {
                        Console.WriteLine("long press start");
                        CGPoint touchPoint = longPressGesture.LocationInView(this);
                        NSIndexPath selectedIndexPath = this.IndexPathForItemAtPoint(touchPoint);
                        if (null != selectedIndexPath)
                        {
                            this.BeginInteractiveMovementForItem(selectedIndexPath);
                        }
                    }

                    break;

                case UIGestureRecognizerState.Changed:
                    {
                        Console.WriteLine("long press changed");
                        CGPoint touchPoint = longPressGesture.LocationInView(this);
                        this.UpdateInteractiveMovement(touchPoint);
                    }
                    break;
                case UIGestureRecognizerState.Ended:
                    {
                        Console.WriteLine("long press end");
                        this.EndInteractiveMovement();
                        break;
                    }

                default:
                    {
                        this.CancelInteractiveMovement();
                        break;
                    }
            }
        }
    }
}
