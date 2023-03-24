using NUnit.Framework;
using tdd_bobs_bagels.CSharp.Main;

namespace tdd_bobs_bagels.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Core _core;
        public CoreTests()
        {
            _core = new Core();
        }

       
        [Test]
        public void AddBagelAndCheckBasketForIt()
        {
            //q1
            string bagel = "Scrambled Egg Bagel";

            Basket basket = new Basket();

            Assert.IsTrue(basket.AddBagelToBasket(bagel));

            Assert.IsTrue(basket.Bagels.Contains(bagel));
        }

        [Test]
        public void RemoveBagelAndCheckItsGone()
        {
            //q2
            string bagel = "Scrambled Egg Bagel";

            Basket basket = new Basket();

            Assert.IsTrue(basket.AddBagelToBasket(bagel));

            Assert.IsTrue(basket.Bagels.Contains(bagel));

            Assert.IsTrue(basket.RemoveBagel(bagel));

            Assert.IsFalse(basket.Bagels.Contains(bagel));
        }
        [Test]
        public void CheckForBasketOverfill()
        {
            //q3
            Basket basket = new Basket();
            Assert.IsTrue(basket.MaxCapacity > 0);

            for(int i = 1; i<= basket.MaxCapacity; i++)
            {
                basket.AddBagelToBasket($"Bagel{i}");
            }

            //check basket is at maximum capacity
            Assert.IsTrue(basket.Bagels.Count == basket.MaxCapacity);

            //check we cant add another bagel
            Assert.IsFalse(basket.AddBagelToBasket("bagel6"));

        }
        [Test]  
        public void CheckYouCanChangeBasketOverfill()
        {
            //q4
            Basket basket = new Basket();
            basket.MaxCapacity = 100;

            for (int i = 1; i <= basket.MaxCapacity; i++)
            {
                basket.AddBagelToBasket($"Bagel{i}");
            }
            Assert.IsTrue(basket.Bagels.Count == basket.MaxCapacity);
        }
        [Test]
        public void BasketEmptiesWhenMaxCapacityChanges()
        {
            //test sets maxcapacity to 100 and then fills 100 bagels
            //test then changes maxcapacity to 3 and checks that the basket was emptied
            //note: we can't have a bagel count = 100 when maxcapacity is set?!
            Basket basket = new Basket();
            basket.MaxCapacity = 100;

            for (int i = 1; i <= basket.MaxCapacity; i++)
            {
                basket.AddBagelToBasket($"Bagel{i}");
            }
            Assert.IsTrue(basket.Bagels.Count == basket.MaxCapacity);

            basket.MaxCapacity = 3;
            Assert.IsTrue(basket.Bagels.Count == 0);
        }
        [Test]
        public void TryAndRemoveAnItemThatDoesntExist()
        {
            //q5
            Basket basket = new Basket();
            basket.MaxCapacity = 100;

            for (int i = 1; i <= basket.MaxCapacity; i++)
            {
                basket.AddBagelToBasket($"Bagel{i}");
            }
            Assert.IsTrue(basket.Bagels.Count == basket.MaxCapacity);

            string bagel = "Bagel101";  // that bagel that doesn't exist


            //following test should pass.. an attempt to remove a Bagel that isn't should be false
            Assert.IsFalse(basket.RemoveBagel("Bagel101"));
        }

    }
}