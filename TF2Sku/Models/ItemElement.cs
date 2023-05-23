using System.Text.Json;

namespace Sku.Models
{
    public record ItemElement
    {
        public int Defindex { get; set; } = 0;
        public int Quality { get; set; } = 6;
        public bool Craftable { get; set; } = true;
        public int Killstreak { get; set; } = 0;
        public bool Australium { get; set; } = false;
        public bool Festive { get; set; } = false;
        public int? Effect { get; set; } = null;
        public int? PaintKit { get; set; } = null;
        public int? Wear { get; set; } = null;
        public int? ElevatedQuality { get; set; } = null;
        public int? Target { get; set; } = null;
        public int? CraftNum { get; set; } = null;
        public int? CrateSn { get; set; } = null;
        public int? Output { get; set; } = null;
        public int? OutputQuality { get; set; } = null;

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
