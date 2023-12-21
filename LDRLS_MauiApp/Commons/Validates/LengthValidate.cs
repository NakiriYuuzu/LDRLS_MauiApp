namespace LDRLS_MauiApp.Commons.Validates;

public class LengthValidate
{
    public static readonly BindableProperty AttachBehaviorProperty =
        BindableProperty.CreateAttached("AttachBehavior", typeof(bool),
            typeof(LengthValidate), false, propertyChanged: OnAttachBehaviorChanged);

    public static bool GetAttachBehavior(BindableObject view)
    {
        return (bool)view.GetValue(AttachBehaviorProperty);
    }

    public static void SetAttachBehavior(BindableObject view, bool value)
    {
        view.SetValue(AttachBehaviorProperty, value);
    }

    private static readonly BindableProperty MaxLengthProperty =
        BindableProperty.Create("MaxLength", typeof(int), typeof(LengthValidate), 0);

    private static int GetMaxLength(BindableObject view)
    {
        return (int)view.GetValue(MaxLengthProperty);
    }

    internal static void SetMaxLength(BindableObject view, int value)
    {
        view.SetValue(MaxLengthProperty, value);
    }

    static void OnAttachBehaviorChanged(BindableObject view, object oldValue, object newValue)
    {
        Entry? entry = view as Entry;
        if (entry == null)
        {
            return;
        }

        bool attachBehavior = (bool)newValue;
        if (attachBehavior)
        {
            entry.TextChanged += OnEntryTextChanged;
        }
        else
        {
            entry.TextChanged -= OnEntryTextChanged;
        }
    }

    static void OnEntryTextChanged(object? sender, TextChangedEventArgs args)
    {
        int charLength = args.NewTextValue.Length;
        ((Entry)sender!).TextColor = charLength > GetMaxLength((View)sender) ? Colors.Red : Colors.Black;
    }
}