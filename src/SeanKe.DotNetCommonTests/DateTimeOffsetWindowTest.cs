using System;
using SeanKe.DotNetCommon;
using Xunit;

namespace SeanKe.DotNetCommonTests
{
    public class DateTimeOffsetWindowTest
    {
        [Theory]
        [InlineData(0, 1, 0, true)]
        [InlineData(0, 2, 1, true)]
        [InlineData(0, 1, 1, false)]
        [InlineData(0, 1, 2, false)]
        [InlineData(1, 2, 0, false)]
        public void DateTimeOffsetWindow_HappyPath(long openAtTicks, long closeAtTicks, long dateTimeOffsetTicksWithinWindow, bool contains)
        {
            // Arrange
            var openAt = new DateTimeOffset(openAtTicks, TimeSpan.Zero);
            var closeAt = new DateTimeOffset(closeAtTicks, TimeSpan.Zero);
            var dateTimeOffsetWithinWindow = new DateTimeOffset(dateTimeOffsetTicksWithinWindow, TimeSpan.Zero);
            var lengthTicks = closeAtTicks - openAtTicks;
            var length = new TimeSpan(lengthTicks);
            
            // Act
            var window_DateTimeOffset_DateTimeoffSet = new DateTimeOffsetWindow(openAt, closeAt);
            var window_DateTimeOffset_TimeSpan = new DateTimeOffsetWindow(openAt, length);
            
            //Assert
            Assert.Equal(window_DateTimeOffset_TimeSpan, window_DateTimeOffset_DateTimeoffSet);

            Assert.Equal(length, window_DateTimeOffset_TimeSpan.Length);
            Assert.Equal(length, window_DateTimeOffset_DateTimeoffSet.Length);

            Assert.Equal(contains, window_DateTimeOffset_TimeSpan.Contains(dateTimeOffsetWithinWindow));
            Assert.Equal(contains, window_DateTimeOffset_DateTimeoffSet.Contains(dateTimeOffsetWithinWindow));
        }
    }
}