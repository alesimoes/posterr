using As.Posterr.Domain.ValueObjects;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Repositories.MongoDB.Serializers
{
    public class UsernameSerializer : IBsonSerializer<Username>
    {
        public Type ValueType => typeof(Username);

        public Username Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            return new Username(context.Reader.ReadString());
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Username value)
        {
            context.Writer.WriteString(value.ToString());
            
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            context.Writer.WriteString(((Username)value).ToString());
        }

        object IBsonSerializer.Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            return new Username(context.Reader.ReadString());
        }
    }
}
