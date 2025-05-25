
/// <summary>
/// Base class for all view models in the application, providing core MVVM functionality.
/// </summary>
/// <remarks>
/// Implements the INotifyPropertyChanged interface to support two-way data binding between
/// view models and views. This class serves as the foundation for the MVVM pattern in the application,
/// allowing derived view models to easily notify the UI when property values change and automatically
/// update bound UI elements.
/// </remarks>
public class BaseViewModel : INotifyPropertyChanged
{
    /// <summary>
    /// Event that is raised when a property value changes, notifying bound UI elements to update.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Raises the PropertyChanged event for a specific property.
    /// </summary>
    /// <param name="propertyName">The name of the property that changed. When not specified,
    /// the name of the calling property will be used automatically.</param>
    /// <remarks>
    /// The CallerMemberName attribute automatically provides the property name when this 
    /// method is called from a property setter, eliminating the need for string literals.
    /// </remarks>
    protected void OnPropertyChanged(
        [CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Sets a property's backing field value and raises the PropertyChanged event if the value has changed.
    /// </summary>
    /// <typeparam name="T">The type of the property.</typeparam>
    /// <param name="backingField">Reference to the backing field of the property.</param>
    /// <param name="value">The new value to set.</param>
    /// <param name="propertyName">The name of the property that changed. When not specified,
    /// the name of the calling property will be used automatically.</param>
    /// <remarks>
    /// This method provides an efficient way to implement property setters in derived view models,
    /// as it only raises the PropertyChanged event when the value actually changes.
    /// </remarks>
    protected void SetValue<T>(ref T backingField, T value,
        [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(backingField, value)) return;
        backingField = value;
        OnPropertyChanged(propertyName);
    }
}
