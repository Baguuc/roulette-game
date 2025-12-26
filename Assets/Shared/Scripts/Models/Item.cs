namespace Shared.Models
{
    [System.Serializable]
    public class Item : Utils.IWeightedItem
    {
        public int id;
        public string name;
        public int value;

        public int Value { get => value; set => this.value = value; }
    }
}