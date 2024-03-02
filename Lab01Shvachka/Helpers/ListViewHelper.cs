using System.Windows;
using System.Windows.Controls;

namespace Lab01Shvachka.Helpers
{
    public static class ListViewHelper
    {
        public static readonly DependencyProperty AutoResizeColumnsProperty =
            DependencyProperty.RegisterAttached(
                "AutoResizeColumns", typeof(bool), typeof(ListViewHelper),
                new UIPropertyMetadata(false, OnAutoResizeColumnsChanged));

        public static bool GetAutoResizeColumns(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoResizeColumnsProperty);
        }

        public static void SetAutoResizeColumns(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoResizeColumnsProperty, value);
        }

        private static void OnAutoResizeColumnsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ListView listView && (bool)e.NewValue)
            {
                listView.SizeChanged += (sender, args) =>
                {
                    var workingWidth = listView.ActualWidth;
                    if (workingWidth > 0)
                    {
                        GridView gView = listView.View as GridView;
                        double colWidth = workingWidth / gView.Columns.Count;
                        foreach (var column in gView.Columns)
                        {
                            column.Width = colWidth;
                        }
                    }
                };
            }
        }
    }
}