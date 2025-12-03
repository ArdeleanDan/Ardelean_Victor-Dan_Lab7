using Microsoft.Maui.Controls;

namespace Ardelean_Victor_Dan_Lab7
{
    public class ValidationBehaviour : Behavior<Editor>
    {
        protected override void OnAttachedTo(Editor entry)
        {
            base.OnAttachedTo(entry);
            entry.TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(Editor entry)
        {
            base.OnDetachingFrom(entry);
            entry.TextChanged -= OnEntryTextChanged;
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            ((Editor)sender).BackgroundColor =
                string.IsNullOrEmpty(args.NewTextValue)
                ? Color.FromArgb("#AA4A44")
                : Color.FromArgb("#FFFFFF");
        }
    }
}
