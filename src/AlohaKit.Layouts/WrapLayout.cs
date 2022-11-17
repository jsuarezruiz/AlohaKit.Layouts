using Microsoft.Maui.Controls.Compatibility;

namespace AlohaKit.Layouts
{
    /// <summary>
    /// The WrapLayout will position each of its child controls next to the other, horizontally (default) or vertically, 
    /// until there is no more room, where it will wrap to the next line and then continue. 
    /// Use it when you want a vertical or horizontal collection controls that automatically wraps when there's no more room.
    /// Based on https://github.com/xamarin/xamarin-forms-samples/tree/master/UserInterface/CustomLayout/WrapLayout
    /// </summary>
    public class WrapLayout : Layout<View>
    {
        public static readonly BindableProperty OrientationProperty =
            BindableProperty.Create(nameof(Orientation), typeof(StackOrientation), typeof(WrapLayout), StackOrientation.Vertical,
                BindingMode.TwoWay, propertyChanged: (bindable, oldvalue, newvalue) => ((WrapLayout)bindable).InvalidateMeasure());

        public StackOrientation Orientation
        {
            get { return (StackOrientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public static readonly BindableProperty SpacingProperty =
            BindableProperty.Create(nameof(Spacing), typeof(double), typeof(WrapLayout), default(double),
                BindingMode.TwoWay, propertyChanged: (bindable, oldvalue, newvalue) => ((WrapLayout)bindable).InvalidateMeasure());

        public double Spacing
        {
            get { return (double)GetValue(SpacingProperty); }
            set { SetValue(SpacingProperty, value); }
        }

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            if (WidthRequest > 0)
                widthConstraint = Math.Min(widthConstraint, WidthRequest);

            if (HeightRequest > 0)
                heightConstraint = Math.Min(heightConstraint, HeightRequest);

            double internalWidth = double.IsPositiveInfinity(widthConstraint) ? double.PositiveInfinity : Math.Max(0, widthConstraint);
            double internalHeight = double.IsPositiveInfinity(heightConstraint) ? double.PositiveInfinity : Math.Max(0, heightConstraint);

            if (double.IsPositiveInfinity(widthConstraint) && double.IsPositiveInfinity(heightConstraint))
            {
                return new SizeRequest(Size.Zero, Size.Zero);
            }

            return Orientation == StackOrientation.Vertical
                ? VerticalMeasure(internalWidth, internalHeight)
                : HorizontalMeasure(internalWidth, internalHeight);
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            if (Orientation == StackOrientation.Vertical)
                VerticalLayout(x, y, width, height);
            else
                HorizontalLayout(x, y, width, height);
        }

        private SizeRequest VerticalMeasure(double widthConstraint, double heightConstraint)
        {
            int columnCount = 1;

            double width = 0;
            double height = 0;
            double minWidth = 0;
            double minHeight = 0;
            double heightUsed = 0;

            foreach (var item in Children)
            {
                var size = item.Measure(widthConstraint, heightConstraint);
                width = Math.Max(width, size.Request.Width);

                var newHeight = height + size.Request.Height + Spacing;
                if (newHeight > heightConstraint)
                {
                    columnCount++;
                    heightUsed = Math.Max(height, heightUsed);
                    height = size.Request.Height;
                }
                else
                    height = newHeight;

                minHeight = Math.Max(minHeight, size.Minimum.Height);
                minWidth = Math.Max(minWidth, size.Minimum.Width);
            }

            if (columnCount > 1)
            {
                height = Math.Max(height, heightUsed);
                width *= columnCount;
            }

            return new SizeRequest(new Size(width, height), new Size(minWidth, minHeight));
        }

        private void VerticalLayout(double x, double y, double width, double height)
        {
            double colWidth = 0;
            double yPos = y, xPos = x;

            foreach (var child in Children.Where(c => c.IsVisible))
            {
                var request = child.Measure(width, height);

                var childWidth = request.Request.Width;
                var childHeight = request.Request.Height;
                colWidth = Math.Max(colWidth, childWidth);

                if (yPos + childHeight > height)
                {
                    yPos = y;
                    xPos += colWidth + Spacing;
                    colWidth = 0;
                }

                var region = new Rect(xPos, yPos, childWidth, childHeight);
                LayoutChildIntoBoundingRegion(child, region);
                yPos += region.Height + Spacing;
            }
        }

        private SizeRequest HorizontalMeasure(double widthConstraint, double heightConstraint)
        {
            int rowCount = 1;

            double width = 0;
            double height = 0;
            double minWidth = 0;
            double minHeight = 0;
            double widthUsed = 0;

            foreach (var item in Children)
            {
                var size = item.Measure(widthConstraint, heightConstraint);
                height = Math.Max(height, size.Request.Height);

                var newWidth = width + size.Request.Width + Spacing;
                if (newWidth > widthConstraint)
                {
                    rowCount++;
                    widthUsed = Math.Max(width, widthUsed);
                    width = size.Request.Width;
                }
                else
                    width = newWidth;

                minHeight = Math.Max(minHeight, size.Minimum.Height);
                minWidth = Math.Max(minWidth, size.Minimum.Width);
            }

            if (rowCount > 1)
            {
                width = Math.Max(width, widthUsed);
                height = (height + Spacing) * rowCount - Spacing;
            }

            return new SizeRequest(new Size(width, height), new Size(minWidth, minHeight));
        }

        private void HorizontalLayout(double x, double y, double width, double height)
        {
            double rowHeight = 0;
            double yPos = y, xPos = x;

            foreach (var child in Children.Where(c => c.IsVisible))
            {
                var request = child.Measure(width, height);

                var childWidth = request.Request.Width;
                var childHeight = request.Request.Height;
                rowHeight = Math.Max(rowHeight, childHeight);

                if (xPos + childWidth > width)
                {
                    xPos = x;
                    yPos += rowHeight + Spacing;
                    rowHeight = 0;
                }

                var region = new Rect(xPos, yPos, childWidth, childHeight);
                LayoutChildIntoBoundingRegion(child, region);
                xPos += region.Width + Spacing;
            }
        }
    }
}