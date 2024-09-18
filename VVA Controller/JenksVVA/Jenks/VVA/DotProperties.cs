using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProtoBuf;

namespace Jenks.VVA
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class DotProperties 
    {
        [ProtoMember(1, IsRequired = true)]
        public float distance_m = 1f;

        [ProtoMember(2, IsRequired = true)]
        public float size_deg = 0.08f;

        [ProtoMember(3, IsRequired = true)]
        public float density_deg2 = 0.2f;

        [ProtoMember(4, IsRequired = true)]
        public float sdVelocity_deg_per_s = 10f;

        public DotProperties() { }

        public string ToLogString()
        {
            return $"size={size_deg}, density={density_deg2}, velocity s.d.={sdVelocity_deg_per_s}";
        }
    }
}
