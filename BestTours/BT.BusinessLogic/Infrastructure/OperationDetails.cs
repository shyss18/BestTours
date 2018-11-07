namespace BT.BusinessLogic.Infrastructure
{
    public class OperationDetails
    {
        public bool Succedeed { get; set; }
        public string Message { get; set; }
        public string Property { get; set; }

        public OperationDetails(bool succedeed, string message, string prop)
        {
            Succedeed = succedeed;
            Message = message;
            Property = prop;
        }
    }
}
