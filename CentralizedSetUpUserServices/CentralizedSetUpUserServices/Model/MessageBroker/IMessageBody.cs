namespace CentralizedSetUpUserServices.Model.MessageBroker
{
    public interface IMessageBody<T>
    {
        string AggregateId { get; }
        int? Version { get; }
        string Type { get; }
        T Data { get; }
        DateTime DateTime { get; }
        long Sequence { get; }
    }
}
