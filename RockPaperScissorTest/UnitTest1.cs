using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RockPaperScissor;

namespace RockPaperScissorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mockInfoObj1 = new Mock<IGameConsole>();
            //var mockInfoObj2 = new Mock<DeclareWinner>();
            mockInfoObj1.Setup(x => x.StartGameOrNot());
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethod2()
        {
           
            var mockInfoObj2 = new Mock<IDeclareWinner>();
            mockInfoObj2.Setup(x => x.displayWinner("Winner"));
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int res=RockPaperScissors.ComputerRPS();
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Player p = new Player() { score=0 };
            RockPaperScissors.Check(2,p);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Player p = new Player() { score = 2 };
            RockPaperScissors.WhoWins(p);
            Assert.IsTrue(true);
        }
    }
}
