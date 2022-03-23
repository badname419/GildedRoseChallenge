using Microsoft.AspNetCore.Mvc;
using GildedRoseWeb.Data;
using GildedRoseWeb.Models;

namespace GildedRoseWeb.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ItemsController(ApplicationDbContext db)
        {
            _db = db;
            Shop.Items = new List<Item>
                {
                    new OrdinaryItem { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new AgedBrieItem { Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new OrdinaryItem { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new LegendaryItem { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new BackstagePassesItem
                        {
                            Name = "Backstage passes to a TAFKAL80ETC concert",
                            SellIn = 15,
                            Quality = 20
                        },
                    new ConjuredItem { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                };

            VerifyItems();
        }

        private void VerifyItems()
        {
            foreach(Item item in Shop.Items)
            {
                if(item.Quality > item.GetQualityLimit())
                {
                    item.Quality = item.GetQualityLimit();
                }
            }
        }

        public IActionResult Index()
        {
            IEnumerable<Item> objItemList = _db.Items;
            return View(objItemList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BaseItem objItem)
        {

            if(objItem.Type == "Ordinary")
            {
                Item obj = new OrdinaryItem();
                AddObject(obj, objItem);
            }
            else if(objItem.Type == "Cheese")
            {
                Item obj = new AgedBrieItem();
                AddObject(obj, objItem);
            }
            else if(objItem.Type == "Conjured")
            {
                Item obj = new ConjuredItem();
                AddObject(obj, objItem);
            }
            else if(objItem.Type == "Legendary")
            {
                Item obj = new LegendaryItem();
                AddObject(obj, objItem);
            }
            else if(objItem.Type == "Pass")
            {
                Item obj = new BackstagePassesItem();
                AddObject(obj, objItem);
            }

            return RedirectToAction("Index");
        }

        private void AddObject(Item itemObj, BaseItem baseItem)
        {
            itemObj.Name = baseItem.Name;
            itemObj.SellIn = baseItem.SellIn;
            itemObj.Quality = baseItem.Quality;
            itemObj.Type = baseItem.Type;

            if(itemObj.Type == "Legendary")
            {
                itemObj.SellIn = 0;
            }

            _db.Items.Add(itemObj);
            _db.SaveChanges();
            TempData["success"] = "Item added successfully";
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var itemFromDb = _db.Items.Find(id);
            BaseItem baseItem = new BaseItem();
            baseItem.ID = itemFromDb.ID;
            baseItem.Name = itemFromDb.Name;
            baseItem.SellIn = itemFromDb.SellIn;   
            baseItem.Quality = itemFromDb.Quality;
            baseItem.Type = itemFromDb.Type;
            
            if(itemFromDb == null)
            {
                return NotFound();
            }

            return View(baseItem);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BaseItem objItem)
        {

            if (objItem.Type == "Ordinary")
            {
                Item obj = new OrdinaryItem();
                UpdateObject(obj, objItem);
            }
            else if (objItem.Type == "Cheese")
            {
                Item obj = new AgedBrieItem();
                UpdateObject(obj, objItem);
            }
            else if (objItem.Type == "Conjured")
            {
                Item obj = new ConjuredItem();
                UpdateObject(obj, objItem);
            }
            else if (objItem.Type == "Legendary")
            {
                Item obj = new LegendaryItem();
                UpdateObject(obj, objItem);
            }
            else if (objItem.Type == "Pass")
            {
                Item obj = new BackstagePassesItem();
                UpdateObject(obj, objItem);
            }

            return RedirectToAction("Index");
        }

        private void UpdateObject(Item itemObj, BaseItem baseItem)
        {
            itemObj.Name = baseItem.Name;
            itemObj.SellIn = baseItem.SellIn;
            itemObj.Quality = baseItem.Quality;
            itemObj.Type = baseItem.Type;
            itemObj.ID = baseItem.ID;
            _db.Items.Update(itemObj);
            _db.SaveChanges();
            TempData["success"] = "Item edited successfully";
        }

        //POST
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var itemFromDb = _db.Items.Find(id);
            if (itemFromDb == null)
            {
                return NotFound();
            }
            _db.Items.Remove(itemFromDb);
            _db.SaveChanges();
            TempData["success"] = "Item deleted successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Update()
        {
            IEnumerable<Item> items = _db.Items;
            foreach (Item item in items)
            {
                item.UpdateItem();
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Reset()
        {
            IEnumerable<Item> items = Shop.Items;

            _db.Items.RemoveRange(_db.Items);

            foreach(Item item in items)
            {
                if(item.GetType().Name == "AgedBrieItem")
                {
                    item.Type = "Cheese";
                }
                else if (item.GetType().Name == "BackstagePassesItem")
                {
                    item.Type = "Pass";
                }
                else if (item.GetType().Name == "ConjuredItem")
                {
                    item.Type = "Conjured";
                }
                else if (item.GetType().Name == "LegendaryItem")
                {
                    item.Type = "Legendary";
                }
                else if (item.GetType().Name == "OrdinaryItem")
                {
                    item.Type = "Ordinary";
                }
            }

            _db.AddRange(items);
            _db.SaveChanges();
            TempData["success"] = "Table reloaded successfully";
            return RedirectToAction("Index");
        }
    }
}
