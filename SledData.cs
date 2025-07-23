using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleModMenu
{
    internal class SledData
    {
        public MeshInterpretter originalValues;
        public MeshInterpretter newValues;

        public SledData()
        {
            this.originalValues = new MeshInterpretter();
            this.newValues = new MeshInterpretter();
        }

        public SledData(MeshInterpretter originalValues, MeshInterpretter newValues)
        {
            this.originalValues = originalValues;
            this.newValues = newValues;
        }

        public void resetToOriginal()
        {
            CopyValues(originalValues, newValues);
        }

        public static void CopyValues(MeshInterpretter originValues, MeshInterpretter destinationValues)
        {
            destinationValues.power = originValues.power;
            destinationValues.lugHeight = originValues.lugHeight;
            destinationValues.pitchFactor = originValues.pitchFactor;
            destinationValues.coefficientOfFriction = originValues.coefficientOfFriction;
            destinationValues.snowPushForceFactor = originValues.snowPushForceFactor;
        }
    }
}
