namespace CreditRegistrationService
{
    public static class ErrorCodes
    {
        public static string TarrifNotFound = "TARIFF_NOT_FOUND";
        public static string OrderNotFound = "ORDER_NOT_FOUND";
        public static string OrderImpossibleToDelete = "ORDER_IMPOSSIBLE_TO_DELETE";
        public static string LoanConsideration = "LOAN_CONSIDERATION";
        public static string LoanApproved = "LOAN_ALREADY_APPROVED";
        public static string TryLater = "TRY_LATER";

        static string TarrifNotFoundMessage = "Тариф не найден";
        static string OrderNotFoundMessage = "Заявка не найдена";
        static string OrderImpossibleToDeleteMessage = "Невозможно удалить заявку";
        static string LoanConsiderationMessage = "Заявка на рассмотрении";
        static string LoanApprovedMessage = "Заявка уже одобрена";
        static string TryLaterMessage = "Попробуйте позже";

        public static Dictionary<string, string> CodeMessages = new Dictionary<string, string>()
        {
            { TarrifNotFound,TarrifNotFoundMessage},
            { OrderNotFound,OrderNotFoundMessage},
            { OrderImpossibleToDelete,OrderImpossibleToDeleteMessage},
            { LoanConsideration,LoanConsiderationMessage},
            { LoanApproved,LoanApprovedMessage},
            { TryLater,TryLaterMessage}
        };


    }
}
