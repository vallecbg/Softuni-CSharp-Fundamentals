using System;
using System.Collections.Generic;
using System.Linq;
using DungeonsAndCodeWizards.Models.Items;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public abstract class Bag
    {
        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }
        public int Capacity { get; }
        public readonly List<Item> items;
        private int Load => this.items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items => this.items.AsReadOnly();

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            var itemExists = this.Items.Any(i => i.GetType().Name == name);
            if (!itemExists)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            var item = this.items.First(i => i.GetType().Name == name);
            this.items.Remove(item);
            return item;
        }
    }
}
