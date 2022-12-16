
using Google.Protobuf;

public class ProtobufSerializer : PayloadBinarySerializer
{
    private readonly MessageParser? _parser;
    public ProtobufSerializer(MessageParser parser) => _parser = parser;
    public override T FromBytes<T>(byte[] bytes) => (T)_parser!.ParseFrom(bytes);
    public override byte[] ToBytes<T>(T payload) => ((IMessage)payload!).ToByteArray();
}
