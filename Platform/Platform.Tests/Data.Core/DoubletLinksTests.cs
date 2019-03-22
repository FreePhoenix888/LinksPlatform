﻿using Platform.Helpers;
using Platform.Helpers.Reflection;
using Platform.Data.Core.Doublets;
using Platform.Memory;
using Xunit;

namespace Platform.Tests.Data.Core
{
    public static class DoubletLinksTests
    {
        [Fact]
        public static void UInt64CRUDTest()
        {
            using (var scope = new Scope<Types<HeapResizableDirectMemory, LinksMemoryManager<ulong>, Links<ulong>>>())
                scope.Use<ILinks<ulong>>().TestCRUDOperations();
        }

        [Fact]
        public static void UInt32CRUDTest()
        {
            using (var scope = new Scope<Types<HeapResizableDirectMemory, LinksMemoryManager<uint>, Links<uint>>>())
                scope.Use<ILinks<uint>>().TestCRUDOperations();
        }

        [Fact]
        public static void UInt16CRUDTest()
        {
            using (var scope = new Scope<Types<HeapResizableDirectMemory, LinksMemoryManager<ushort>, Links<ushort>>>())
                scope.Use<ILinks<ushort>>().TestCRUDOperations();
        }

        [Fact]
        public static void UInt8CRUDTest()
        {
            using (var scope = new Scope<Types<HeapResizableDirectMemory, LinksMemoryManager<byte>, Links<byte>>>())
                scope.Use<ILinks<byte>>().TestCRUDOperations();
        }

        private static void TestCRUDOperations<T>(this ILinks<T> links)
        {
            var constants = links.Constants;
            
            // Create Link
            Assert.True(MathHelpers.Equals(links.Count(), (T)(Integer<T>) 0));

            var setter = new Setter<T>(constants.Null);
            links.Each(constants.Any, constants.Any, setter.SetAndReturnTrue);

            Assert.True(MathHelpers.Equals(setter.Result, constants.Null));

            var linkAddress = links.Create();

            var link = new Link<T>(links.GetLink(linkAddress));

            Assert.True(link.Count == 3);
            Assert.True(MathHelpers.Equals(link.Index, linkAddress));
            Assert.True(MathHelpers.Equals(link.Source, constants.Null));
            Assert.True(MathHelpers.Equals(link.Target, constants.Null));

            Assert.True(MathHelpers.Equals(links.Count(), (T)(Integer<T>)1));

            // Get first link
            setter = new Setter<T>(constants.Null);
            links.Each(constants.Any, constants.Any, setter.SetAndReturnFalse);

            Assert.True(MathHelpers.Equals(setter.Result, linkAddress));

            // Update link to reference itself
            links.Update(linkAddress, linkAddress, linkAddress);

            link = new Link<T>(links.GetLink(linkAddress));

            Assert.True(MathHelpers.Equals(link.Source, linkAddress));
            Assert.True(MathHelpers.Equals(link.Target, linkAddress));

            // Update link to reference null (prepare for delete)
            var updated = links.Update(linkAddress, constants.Null, constants.Null);

            Assert.True(MathHelpers.Equals(updated, linkAddress));

            link = new Link<T>(links.GetLink(linkAddress));

            Assert.True(MathHelpers.Equals(link.Source, constants.Null));
            Assert.True(MathHelpers.Equals(link.Target, constants.Null));

            // Delete link
            links.Delete(linkAddress);

            Assert.True(MathHelpers.Equals(links.Count(), (T)(Integer<T>)0));

            setter = new Setter<T>(constants.Null);
            links.Each(constants.Any, constants.Any, setter.SetAndReturnTrue);

            Assert.True(MathHelpers.Equals(setter.Result, constants.Null));
        }

        [Fact]
        public static void UInt64RawNumbersCRUDTest()
        {
            using (var scope = new Scope<Types<HeapResizableDirectMemory, LinksMemoryManager<ulong>, Links<ulong>>>())
                scope.Use<ILinks<ulong>>().TestRawNumbersCRUDOperations();
        }

        [Fact]
        public static void UInt32RawNumbersCRUDTest()
        {
            using (var scope = new Scope<Types<HeapResizableDirectMemory, LinksMemoryManager<uint>, Links<uint>>>())
                scope.Use<ILinks<uint>>().TestRawNumbersCRUDOperations();
        }

        [Fact]
        public static void UInt16RawNumbersCRUDTest()
        {
            using (var scope = new Scope<Types<HeapResizableDirectMemory, LinksMemoryManager<ushort>, Links<ushort>>>())
                scope.Use<ILinks<ushort>>().TestRawNumbersCRUDOperations();
        }

        [Fact]
        public static void UInt8RawNumbersCRUDTest()
        {
            using (var scope = new Scope<Types<HeapResizableDirectMemory, LinksMemoryManager<byte>, Links<byte>>>())
                scope.Use<ILinks<byte>>().TestRawNumbersCRUDOperations();
        }

        private static void TestRawNumbersCRUDOperations<T>(this ILinks<T> links)
        {
            // Constants
            var constants = links.Constants;

            var h106E = new Hybrid<T>(106L, isExternal: true);
            var h107E = new Hybrid<T>(-char.ConvertFromUtf32(107)[0]);
            var h108E = new Hybrid<T>(-108L);

            Assert.True(Equals(h106E.AbsoluteValue, 106L));
            Assert.True(Equals(h107E.AbsoluteValue, 107L));
            Assert.True(Equals(h108E.AbsoluteValue, 108L));

            // Create Link (External -> External)
            var linkAddress1 = links.Create();

            links.Update(linkAddress1, h106E, h108E);

            var link1 = new Link<T>(links.GetLink(linkAddress1));

            Assert.True(MathHelpers.Equals(link1.Source, (T)h106E));
            Assert.True(MathHelpers.Equals(link1.Target, (T)h108E));

            // Create Link (Internal -> External)
            var linkAddress2 = links.Create();

            links.Update(linkAddress2, linkAddress1, h108E);

            var link2 = new Link<T>(links.GetLink(linkAddress2));

            Assert.True(MathHelpers.Equals(link2.Source, linkAddress1));
            Assert.True(MathHelpers.Equals(link2.Target, (T)h108E));

            // Create Link (Internal -> Internal)
            var linkAddress3 = links.Create();

            links.Update(linkAddress3, linkAddress1, linkAddress2);

            var link3 = new Link<T>(links.GetLink(linkAddress3));

            Assert.True(MathHelpers.Equals(link3.Source, linkAddress1));
            Assert.True(MathHelpers.Equals(link3.Target, linkAddress2));

            // Search for created link
            var setter1 = new Setter<T>(constants.Null);
            links.Each(h106E, h108E, setter1.SetAndReturnFalse);

            Assert.True(MathHelpers.Equals(setter1.Result, linkAddress1));

            // Search for nonexistent link
            var setter2 = new Setter<T>(constants.Null);
            links.Each(h106E, h107E, setter2.SetAndReturnFalse);

            Assert.True(MathHelpers.Equals(setter2.Result, constants.Null));

            // Update link to reference null (prepare for delete)
            var updated = links.Update(linkAddress3, constants.Null, constants.Null);

            Assert.True(MathHelpers.Equals(updated, linkAddress3));

            link3 = new Link<T>(links.GetLink(linkAddress3));

            Assert.True(MathHelpers.Equals(link3.Source, constants.Null));
            Assert.True(MathHelpers.Equals(link3.Target, constants.Null));

            // Delete link
            links.Delete(linkAddress3);

            Assert.True(MathHelpers.Equals(links.Count(), (T)(Integer<T>)2));

            var setter3 = new Setter<T>(constants.Null);
            links.Each(constants.Any, constants.Any, setter3.SetAndReturnTrue);

            Assert.True(MathHelpers.Equals(setter3.Result, linkAddress2));
        }

        // TODO: Test layers
    }
}
