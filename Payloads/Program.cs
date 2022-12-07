double ws = Environment.WorkingSet;

//JSON
var telemetry = new Payloads.Json.Telemetries() { WorkingSet = ws };
PayloadBinarySerializer jsonSerializer = new JsonUtfSerializer();
var jsonBytes = jsonSerializer.ToBytes(telemetry);
Console.WriteLine($"{jsonBytes.Length} json bytes: ");
jsonBytes.ToList().ForEach(x => Console.Write($"0x{x} "));
Console.WriteLine();
var jsonTel = jsonSerializer.FromBytes<Payloads.Json.Telemetries>(jsonBytes);
Console.WriteLine(jsonTel.WorkingSet);
Console.WriteLine();

//Proto
var t = new Payloads.Proto.Telemetries { WorkingSet = ws };
PayloadBinarySerializer protoSerializer = new ProtobufSerializer(Payloads.Proto.Telemetries.Parser);
var ptotoBytes = protoSerializer.ToBytes(t);
Console.WriteLine($"{ptotoBytes.Length} proto bytes: ");
ptotoBytes.ToList().ForEach(x => Console.Write($"0x{x} "));
Console.WriteLine(  );
t = protoSerializer.FromBytes<Payloads.Proto.Telemetries>(ptotoBytes);
Console.WriteLine(t.WorkingSet);
Console.WriteLine();

//Avro
var avro = new Payloads.Avro.Telemetries() { WorkingSet = ws };
PayloadBinarySerializer avroSerializer = new AvroSerializer(avro.Schema);
var avroBytes = avroSerializer.ToBytes(avro);
Console.WriteLine($"{avroBytes.Length} Avro bytes: ");
avroBytes.ToList().ForEach(x => Console.Write($"0x{x} "));
Console.WriteLine();
avro = avroSerializer.FromBytes<Payloads.Avro.Telemetries>(avroBytes);
Console.WriteLine(avro.WorkingSet);