using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3GUI
{
    public enum MeasureType { m, ml, l, bbls };
    public class Volume
    {
        private double value;
        private MeasureType type;
        public Volume(double value, MeasureType type)
        {
            this.value = value;
            this.type = type;
        }
        public string Verbose()
        {
            string typeVerbose = "";
            switch (this.type)
            {
                case MeasureType.m:
                    typeVerbose = "куб.м.";
                    break;
                case MeasureType.ml:
                    typeVerbose = "мл.";
                    break;
                case MeasureType.l:
                    typeVerbose = "л.";
                    break;
                case MeasureType.bbls:
                    typeVerbose = "б.";
                    break;
            }
            return String.Format("{0} {1}", this.value, typeVerbose);
        }
        public static Volume operator +(Volume instance, double number)
        {

            var newValue = instance.value + number;
            var volume = new Volume(newValue, instance.type);
            return volume;
        }
        public static Volume operator +(double number, Volume instance)
        {
            return instance + number;
        }
        public static Volume operator *(Volume instance, double number)
        {

            var newValue = instance.value * number;
            var volume = new Volume(newValue, instance.type);
            return volume;
        }
        public static Volume operator *(double number, Volume instance)
        {
            return instance * number;
        }
        public static Volume operator -(Volume instance, double number)
        {

            var newValue = instance.value - number;
            var volume = new Volume(newValue, instance.type);
            return volume;
        }
        public static Volume operator -(double number, Volume instance)
        {
            return instance - number;
        }
        public static Volume operator /(Volume instance, double number)
        {

            var newValue = instance.value / number;
            var volume = new Volume(newValue, instance.type);
            return volume;
        }
        public static Volume operator /(double number, Volume instance)
        {
            return instance / number;
        }
        public Volume To(MeasureType newType)
        {
            var newValue = this.value;
            if (this.type == MeasureType.l)
            {
                switch (newType)
                {
                    case MeasureType.m:
                        newValue = this.value / 1000;
                        break;
                    case MeasureType.ml:
                        newValue = this.value * 1000;
                        break;
                    case MeasureType.l:
                        newValue = this.value;
                        break;
                    case MeasureType.bbls:
                        newValue = this.value / 158.99;
                        break;
                }
            }
            else if (newType == MeasureType.l)
            {
                switch (this.type)
                {
                    case MeasureType.m:
                        newValue = this.value * 1000;
                        break;
                    case MeasureType.ml:
                        newValue = this.value / 1000;
                        break;
                    case MeasureType.l:
                        newValue = this.value;
                        break;
                    case MeasureType.bbls:
                        newValue = this.value * 158.99;
                        break;
                }
            }
            else
            {
                newValue = this.To(MeasureType.l).To(newType).value;
            }
            return new Volume(newValue, newType);
        }
        public static Volume operator +(Volume instance1, Volume instance2)
        {
            return (instance1 + instance2.To(instance1.type).value);
        }

        public static Volume operator -(Volume instance1, Volume instance2)
        {
            return (instance1 - instance2.To(instance1.type).value);
        }
        public static Volume operator *(Volume instance1, Volume instance2)
        {
            return (instance1 * instance2.To(instance1.type).value);
        }
        public static Volume operator /(Volume instance1, Volume instance2)
        {
            return (instance1 / instance2.To(instance1.type).value);
        }
    }
}

