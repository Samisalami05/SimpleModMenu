using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMod
{
    internal class SledData
    {
        public MeshInterpretter originalValues;
        public MeshInterpretter newValues;

        public SledData()
        {
            this.originalValues = new MeshInterpretter();
            this.newValues = new MeshInterpretter();
            originalValues.power = 1;
        }
    }
}
