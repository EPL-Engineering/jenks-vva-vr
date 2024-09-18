using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProtoBuf;

namespace Jenks.VVA
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class GratingProperties
    {
        [ProtoMember(1, IsRequired = true)]
        public float distance_m = 1f;

        [ProtoMember(2, IsRequired = true)]
        public float size_deg = 0.25f;

        [ProtoMember(3, IsRequired = true)]
        public float density_deg = 0.2f;

        public GratingProperties() { }

        public string ToLogString()
        {
            return $"size={size_deg}, density={density_deg}";
        }
    }
}
