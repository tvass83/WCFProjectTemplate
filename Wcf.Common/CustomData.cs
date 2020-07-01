using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace $safeprojectname$.DTO
{
    [XmlInclude(typeof(List<string>))]
    [KnownType(typeof(List<string>))]
    public class CustomData
    {
        public string Message { get; set; }
        public object Value { get; set; }
    }
}
