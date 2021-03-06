// Copyright 2010 The Noda Time Authors. All rights reserved.
// Use of this source code is governed by the Apache License 2.0,
// as found in the LICENSE.txt file.

using NUnit.Framework;

namespace NodaTime.Test
{
    public partial class DateTimeZoneTest
    {
        // The current implementation caches every half hour, -12 to +15.
        [Test]
        public void ForOffset_UncachedExample_NotOnHalfHour()
        {
            var offset = Offset.FromSeconds(123);
            var zone1 = DateTimeZone.ForOffset(offset);
            var zone2 = DateTimeZone.ForOffset(offset);

            Assert.AreNotSame(zone1, zone2);
            Assert.IsTrue(zone1.IsFixed);
            Assert.AreEqual(offset, zone1.MaxOffset);
            Assert.AreEqual(offset, zone1.MinOffset);
        }

        [Test]
        public void ForOffset_UncachedExample_OutsideCacheRange()
        {
            var offset = Offset.FromHours(-14);
            var zone1 = DateTimeZone.ForOffset(offset);
            var zone2 = DateTimeZone.ForOffset(offset);

            Assert.AreNotSame(zone1, zone2);
            Assert.IsTrue(zone1.IsFixed);
            Assert.AreEqual(offset, zone1.MaxOffset);
            Assert.AreEqual(offset, zone1.MinOffset);
        }

        [Test]
        public void ForOffset_CachedExample()
        {
            var offset = Offset.FromHours(2);
            var zone1 = DateTimeZone.ForOffset(offset);
            var zone2 = DateTimeZone.ForOffset(offset);
            // Caching check...
            Assert.AreSame(zone1, zone2);

            Assert.IsTrue(zone1.IsFixed);
            Assert.AreEqual(offset, zone1.MaxOffset);
            Assert.AreEqual(offset, zone1.MinOffset);
        }

        [Test]
        public void ForOffset_Zero_SameAsUtc()
        {
            Assert.AreSame(DateTimeZone.Utc, DateTimeZone.ForOffset(Offset.Zero));
        }
    }
}
