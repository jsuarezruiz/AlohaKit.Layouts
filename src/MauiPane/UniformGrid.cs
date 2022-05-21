using Microsoft.Maui.Controls.Compatibility;

namespace MauiPane
{
    /// <summary>
    /// The UniformGrid is just like the Grid, with the possibility of multiple rows and columns, but with one important difference: 
    /// All rows and columns will have the same size. 
    /// Use this when you need the Grid behavior without the need to specify different sizes for the rows and columns.
    /// </summary>
    public class UniformGrid : Layout<View>
    {
        private double _childWidth;
        private double _childHeight;

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            Measure(width, height, 0);
            int columns = GetColumnsCount(Children.Count, width, _childWidth);
            int rows = GetRowsCount(Children.Count, columns);
            double boundsWidth = width / columns;
            double boundsHeight = _childHeight;
            Rect bounds = new Rect(0, 0, boundsWidth, boundsHeight);
            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns && count < Children.Count; j++)
                {
                    View item = Children[count];
                    bounds.X = j * boundsWidth;
                    bounds.Y = i * boundsHeight;
                    item.Layout(bounds);
                    count++;
                }
            }
        }

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            foreach (View child in Children)
            {
                if (!child.IsVisible)
                {
                    continue;
                }

                SizeRequest sizeRequest = child.Measure(double.PositiveInfinity, double.PositiveInfinity, 0);
                Size minimum = sizeRequest.Minimum;
                Size request = sizeRequest.Request;

                _childHeight = Math.Max(minimum.Height, request.Height);
                _childWidth = Math.Max(minimum.Width, request.Width);
            }

            int columns = GetColumnsCount(Children.Count, widthConstraint, _childWidth);
            int rows = GetRowsCount(Children.Count, columns);
            Size size = new Size(columns * _childWidth, rows * _childHeight);
            return new SizeRequest(size, size);
        }

        private int GetColumnsCount(int visibleChildrenCount, double widthConstraint, double maxChildWidth)
        {
            if (double.IsPositiveInfinity(widthConstraint))
            {
                return visibleChildrenCount;
            }

            return Math.Min((int)(widthConstraint / maxChildWidth), visibleChildrenCount);
        }

        private int GetRowsCount(int visibleChildrenCount, int columnsCount)
        {
            return (int)Math.Ceiling((double)visibleChildrenCount / columnsCount);
        }
    }
}