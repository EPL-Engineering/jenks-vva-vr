using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProtoBuf;

namespace Jenks.VVA
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class WallProperties
    {
        [ProtoMember(1, IsRequired = true)]
        public float wallDistance_m = 50f;

        [ProtoMember(2, IsRequired = true)]
        public float barWidth_m = 0.8f;

        [ProtoMember(3, IsRequired = true)]
        public float barSpacing_m = 10f;

        [ProtoMember(4, IsRequired = true)]
        public float wallHeight_m = 20f;

        [ProtoMember(5, IsRequired = true)]
        public float wallOffset_m = 7.8f;

        public WallProperties() { }

        public string ToLogString()
        {
            return $"wall distance={wallDistance_m}, wall height={wallHeight_m}, wall offset={wallOffset_m}, bar width={barWidth_m}, bar spacing={barSpacing_m}";
        }
    }
}
