using StackSwapApplication.Models;

namespace StackSwapApplication.ViewModels
{
    public class CardCheckBox
    {
        public uint CardId { get; set; }
        public bool IsChecked { get; set; } = false;
        public Card Card { get; set; }
    }
}
