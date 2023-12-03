using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

//By Tejas 
namespace StackSwapApplication.Models.BaseEntities
{
    public abstract class BaseEntity : INotifyPropertyChanged 
    {
        public abstract uint Id { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        //Method based on Micrsoft MVVM Toolkit found here: https://github.com/CommunityToolkit/dotnet/tree/main/src/CommunityToolkit.Mvvm/ComponentModel
        protected bool SetProperty<T>([NotNullIfNotNull(nameof(newValue))] ref T field, T newValue, [CallerMemberName] string? propertyName = null)
        {
            OnPropertyChanged(propertyName);
            field = newValue;
            return true;
        }
    }
}
