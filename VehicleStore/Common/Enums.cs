namespace VehicleStore.Common.Enums
{
    public enum VehicleStatus
    {
        Connected,
        Disconnected
    }

    public enum ResponseStatus
    {
        ServerError = 0,
        Success = 1,
        Failed = 2,
        Unauthorized = 3,
        Expired = 4
    }
}