namespace ApplicationCoreShipping.Model;


    public enum OrderState
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Completed,
        Canceled,
        Returned
    }
