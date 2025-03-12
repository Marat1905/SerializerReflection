using System.Runtime.Serialization;

namespace SerializerReflection.Classes
{
    [DataContract]
    public class Dev
    {
        [DataMember]
        public string Name { get; set; }
        public string Developer { get; set; }
    }
}
