internal class MsgPackSerializer : PayloadBinarySerializer
{
    public override T FromBytes<T>(byte[] bytes) => MessagePack.MessagePackSerializer.Deserialize<T>(bytes);
    public override byte[] ToBytes<T>(T payload) => MessagePack.MessagePackSerializer.Serialize(payload);
}
