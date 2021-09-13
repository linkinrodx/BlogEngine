namespace BlogEngine.Services.Util
{
    public enum StateEnum : byte
    {
        Active = 1,
        Inactive = 2
    }

    public enum PostStateEnum : short
    {
        Created = 1,
        Submitted = 2,
        Approved = 3,
        Rejected = 4,
        Published = 5,
        Deleted = 6
    }
}
