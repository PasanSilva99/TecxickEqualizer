using System;

namespace TecxickEqualizer0._1
{
    class EqPresets
    {
        private String Name { get; set; }
        private Double[] EQValues { get; set; }

        public EqPresets(String name, Double[] values)
        {
            Name = name;
            EQValues = values;
        }
    }
}
