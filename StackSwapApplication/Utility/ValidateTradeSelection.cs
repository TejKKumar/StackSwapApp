using Microsoft.AspNetCore.Mvc.TagHelpers;
using StackSwapApplication.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace StackSwapApplication.Utility
{
    public class ValidateTradeSelectionAttribute : ValidationAttribute
    {
        public ValidateTradeSelectionAttribute() 
        { 
            const string defaultMsg = "Please select a card";
            ErrorMessage ??= defaultMsg;
        }

        protected override ValidationResult? IsValid(object? value,
                                        ValidationContext validationContext)

        {
            List<CardCheckBox> cards = (List<CardCheckBox>) validationContext.ObjectInstance;    

            List<CardCheckBox> bCheck =  cards.Where(c => c.IsChecked == true).ToList();

            return bCheck.Count  == 0? new ValidationResult("Please select atleast one card") :   ValidationResult.Success;
        }
    }
}
