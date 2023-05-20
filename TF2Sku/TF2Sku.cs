using Sku.Enums;
using Sku.Models;

namespace TF2.Sku
{
    /// <summary>
    /// Provides functionality for converting Team Fortress 2 (TF2) Stock Keeping Unit (SKU) strings into equivalent C# objects,
    /// and also for converting these objects back into their SKU string representation.
    /// </summary>
    /// <remarks>
    /// A SKU in TF2 is a semi-colon separated string which encodes various attributes of an item.
    /// This class provides methods to parse such a SKU string into a C# object that has properties representing these attributes,
    /// and to generate a SKU string from a given object.
    /// </remarks>
    public class TF2Sku
    {
        /// <summary>
        /// Converts an <see cref="ItemElement"/> object to its SKU representation.
        /// </summary>
        /// <param name="item">The <see cref="ItemElement"/> object to convert.</param>
        /// <returns>The SKU string representing the state of the <see cref="ItemElement"/> object.</returns>
        public static string FromObject(ItemElement item)
        {
            List<string> skuParts = new() { $"{item.Defindex}", $"{(int)item.Quality}" };

            if (item.Effect != null)
            {
                skuParts.Add($"u{item.Effect}");
            }
            if (item.Australium == true)
            {
                skuParts.Add("australium");
            }
            if (item.Craftable == false)
            {
                skuParts.Add("uncraftable");
            }
            if (item.Wear != null)
            {
                skuParts.Add($"w{item.Wear}");
            }
            if (item.PaintKit != null)
            {
                skuParts.Add($"pk{item.PaintKit}");
            }
            if (item.ElevatedQuality == EQuality.Strange)
            {
                skuParts.Add("strange");
            }
            if (item.Killstreak != 0)
            {
                skuParts.Add($"kt-{item.Killstreak}");
            }
            if (item.Target != null)
            {
                skuParts.Add($"td-{item.Target}");
            }
            if (item.Festive == true)
            {
                skuParts.Add("festive");
            }
            if (item.CraftNum != null)
            {
                skuParts.Add($"n{item.CraftNum}");
            }
            if (item.CrateSn != null)
            {
                skuParts.Add($"c{item.CrateSn}");
            }
            if (item.Output != null)
            {
                skuParts.Add($"od-{item.Output}");
            }
            if (item.OutputQuality != null)
            {
                skuParts.Add($"oq-{(int)item.OutputQuality}");
            }

            return string.Join(";", skuParts);
        }

        /// <summary>
        /// Converts an SKU string into an <see cref="ItemElement"/> object.
        /// </summary>
        /// <param name="sku">The SKU string to convert.</param>
        /// <returns>An <see cref="ItemElement"/> object representing the parsed SKU string.</returns>
        public static ItemElement FromString(string sku)
        {
            var item = new ItemElement();
            Queue<string> skuParts = new(sku.Split(';'));
            if (skuParts.Count > 0 && int.TryParse(skuParts.Dequeue(), out int defindex))
            {
                item.Defindex = defindex;
            }

            if (skuParts.Count > 0 && int.TryParse(skuParts.Dequeue(), out int qualityInt))
            {
                item.Quality = (EQuality)qualityInt;
            }

            while (skuParts.Count > 0)
            {
                ProcessAttribute(skuParts.Dequeue(), ref item);
            }

            return item;
        }

        /// <summary>
        /// Processes an attribute element from the SKU string and sets the corresponding field in the provided <see cref="ItemElement"/> object.
        /// </summary>
        /// <param name="attribute">The attribute string to process.</param>
        /// <param name="item">The <see cref="ItemElement"/> object to modify based on the attribute.</param>
        private static void ProcessAttribute(string attribute, ref ItemElement item)
        {
            var attr = attribute.Replace("-", "");

            switch (attr)
            {
                case "uncraftable":
                    item.Craftable = false;
                    break;
                case "australium":
                    item.Australium = true;
                    break;
                case "festive":
                    item.Festive = true;
                    break;
                case "strange":
                    item.ElevatedQuality = EQuality.Strange;
                    break;
                default:
                    if (attr.StartsWith("kt") && int.TryParse(attr.AsSpan(2), out int ksInt))
                    {
                        item.Killstreak = ksInt;
                    }
                    else if (attr.StartsWith("u") && int.TryParse(attr.AsSpan(1), out int effect))
                    {
                        item.Effect = effect;
                    }
                    else if (attr.StartsWith("pk") && int.TryParse(attr.AsSpan(2), out int paintKit))
                    {
                        item.PaintKit = paintKit;
                    }
                    else if (attr.StartsWith("w") && int.TryParse(attr.AsSpan(1), out int wear))
                    {
                        item.Wear = wear;
                    }
                    else if (attr.StartsWith("td") && int.TryParse(attr.AsSpan(2), out int target))
                    {
                        item.Target = target;
                    }
                    else if (attr.StartsWith("n") && int.TryParse(attr.AsSpan(1), out int craftNum))
                    {
                        item.CraftNum = craftNum;
                    }
                    else if (attr.StartsWith("c") && int.TryParse(attr.AsSpan(1), out int crateSn))
                    {
                        item.CrateSn = crateSn;
                    }
                    else if (attr.StartsWith("od") && int.TryParse(attr.AsSpan(2), out int outputItem))
                    {
                        item.Output = outputItem;
                    }
                    else if (attr.StartsWith("oq") && int.TryParse(attr.AsSpan(2), out int outputQuality))
                    {
                        item.OutputQuality = (EQuality)outputQuality;
                    }
                    break;
            }
        }
    }
}