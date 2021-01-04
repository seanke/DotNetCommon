using System;

namespace SeanKe.DotNetCommon
{
    public struct DateTimeOffsetWindow
    {
        public DateTimeOffset OpenAt { get; private set; }
        public DateTimeOffset CloseAt { get; private set; }

        public TimeSpan Length => CloseAt - OpenAt;

        public DateTimeOffsetWindow(DateTimeOffset openAt, TimeSpan length)
        {
            if (length.TotalSeconds < 0)
                throw new ArgumentOutOfRangeException(nameof(length), length, "Must not be a negative TimeSpan.");
            
            OpenAt = openAt;
            CloseAt = OpenAt + length;
        }

        public DateTimeOffsetWindow(DateTimeOffset openAt, DateTimeOffset closeAt)
        {
            if (openAt >= closeAt)
                throw new ArgumentException($"Must always be less than {nameof(closeAt)}", nameof(openAt));

            OpenAt = openAt;
            CloseAt = closeAt;
        }

        public bool Contains(DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset >= OpenAt && dateTimeOffset < CloseAt;
        }
    }
}