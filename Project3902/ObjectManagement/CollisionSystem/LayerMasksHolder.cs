using System.Collections.Generic;

namespace Project3902
{
    class LayerMasksHolder
    {
        public Layer MainLayer { get; set; }
        public List<Layer> Masks { get; set; }

        public LayerMasksHolder(Layer mainLayer, Layer[] masks)
        {
            MainLayer = mainLayer;
            Masks = new List<Layer>();
            Masks.AddRange(masks);
        }
    }
}
