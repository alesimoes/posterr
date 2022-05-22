using As.Posterr.Domain.ValueObjects;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Repositories.MongoDB.Serializers
{
    public class TextPostSerializer : IBsonSerializer<TextPost>
    {
        public Type ValueType => typeof(TextPost);

        public TextPost Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            return new TextPost(context.Reader.ReadString());
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, TextPost value)
        {
            context.Writer.WriteString(value.ToString());
            
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            context.Writer.WriteString(((TextPost)value).ToString());
        }

        object IBsonSerializer.Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            return new TextPost(context.Reader.ReadString());
        }
    }
}
