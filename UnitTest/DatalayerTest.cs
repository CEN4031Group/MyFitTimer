using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stopwatch0005.DataLayer;
using Stopwatch0005.Models;
using System;
using System.Linq;

namespace Stopwatch0005.UnitTest
{
    [TestClass]
    public class DatalayerTest
    {
        [TestMethod]
        public void AddToDb()
        {
            var tracker = new StopWatchTracker(DateTime.Now.ToString());
            var ctx = new StopWatchDbContext();
            ctx.stopWatchTrackers.Add(tracker);
            ctx.SaveChanges();
            Assert.IsNotNull(tracker.Id);
            ctx.Dispose();
        }

        [TestMethod]
        public void GetData()
        {
            var ctx = new StopWatchDbContext();

            var newTracker = new StopWatchTracker(DateTime.Now.ToString());
            ctx.stopWatchTrackers.Add(newTracker);
            ctx.SaveChanges();

            var trackers = ctx.stopWatchTrackers.ToList();

            Assert.AreNotEqual(0, trackers.Count());
            ctx.Dispose();
        }

        [TestMethod]
        public void DeleteData()
        {
            var ctx = new StopWatchDbContext();

            var trackers = ctx.stopWatchTrackers.ToList();

            ctx.stopWatchTrackers.RemoveRange(trackers);
            ctx.SaveChanges();

            var result = ctx.stopWatchTrackers.ToList();

            Assert.AreEqual(0, result.Count());
            ctx.Dispose();
        }
    }
}
