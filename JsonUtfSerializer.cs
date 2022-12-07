public class JsonUtfSerializer : PayloadBinarySerializer
{
    public override T FromBytes<T>(byte[] bytes) => JsonSerializer.Deserialize<T>(Encoding.UTF8.GetString(bytes))!;
    public override byte[] ToBytes<T>(T payload) => Encoding.UTF8.GetBytes(JsonSerializer.Serialize(payload));
}
