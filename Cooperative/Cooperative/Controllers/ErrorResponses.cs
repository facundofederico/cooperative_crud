public static class ErrorResponses
{
    // Responses for Item creation errors.

    public static string InvalidName => "The name must not be empty but less than 80 characters.";
    
    public static string InvalidDescription => "The description must not be empty.";
    
    public static string InvalidPrice => "The price must not be a negative number.";


    // Responses for BudgetItem creation errors.

    public static string InvalidQuantity => "The quantity must be greater than 0.";
    
    public static string InvalidDiscount => "The discount must be a number between 0 and 1.";
}