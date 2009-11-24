﻿#region Copyright and license information
// Copyright 2001-2009 Stephen Colebourne
// Copyright 2009 Jon Skeet
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

namespace NodaTime
{
    /// <summary>
    /// Interface describing a time zone. Most users won't need to call any
    /// of the methods on this, instead 
    /// </summary>   
    public interface IDateTimeZone
    {
        /// <summary>
        /// Returns the transition occurring strictly after the specified instant,
        /// or null if there are no further transitions.
        /// </summary>
        /// <param name="instant">The instant after which to consider transitions.</param>
        /// <returns>The instant of the next transition, or null if there are no further transitions.</returns>
        Instant? NextTransition(Instant instant);

        /// <summary>
        /// Returns the transition occurring strictly before the specified instant,
        /// or null if there are no earlier transitions.
        /// </summary>
        /// <param name="instant">The instant before which to consider transitions.</param>
        /// <returns>The instant of the previous transition, or null if there are no further transitions.</returns>
        Instant? PreviousTransition(Instant instant);
        
        /// <summary>
        /// Returns the offset from UTC, where a positive duration indicates that local time is later
        /// than UTC. In other words, local time = UTC + offset.
        /// </summary>
        /// <param name="instant">The instant for which to calculate the offset.</param>
        /// <returns>The offset from UTC at the specified instant.</returns>
        Duration GetOffsetFromUtc(Instant instant);

        /// <summary>
        /// Returns the offset from local time to UTC, where a positive duration indicates that UTC is earlier
        /// than local time. In other words, UTC = local time - (offset from local).
        /// </summary>
        /// <param name="localTime">The instant for which to calculate the offset.</param>
        /// <returns>The offset at the specified local time.</returns>
        Duration GetOffsetFromLocal(LocalDateTime localTime);

        /// <summary>
        /// The Olson database ID for the time zone.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Indicates whether the time zone is fixed, i.e. contains no transitions.
        /// </summary>
        bool IsFixed { get; }
    }
}
