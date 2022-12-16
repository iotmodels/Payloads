double ws = Environment.WorkingSet;

Run(new JsonUtfSerializer(), new Payloads.Json.Telemetries() { WorkingSet = ws });
Run(new CborSerializer(), new Payloads.Cbor.Telemetries() { WorkingSet = ws });
Run(new MsgPackSerializer(), new Payloads.MsgPack.Telemetries() { WorkingSet = ws });
Run(new ProtobufSerializer(Payloads.Proto.Telemetries.Parser), new Payloads.Proto.Telemetries() { WorkingSet = ws });
var inAvro = new Payloads.Avro.Telemetries() { WorkingSet = ws };
Run(new AvroSerializer(inAvro.Schema), inAvro);

static T Run<T>(PayloadBinarySerializer serializer, T payload)
{
    Console.WriteLine(serializer.GetType().Name);
    var bytes = serializer.ToBytes(payload);
    Console.Write($"{bytes.Length} bytes: ");
    bytes.ToList().ForEach(x => Console.Write($"0x{x} "));
    Console.WriteLine();
    Console.WriteLine();
    return serializer.FromBytes<T>(bytes);
}