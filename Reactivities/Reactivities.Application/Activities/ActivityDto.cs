﻿using Newtonsoft.Json;
using Reactivities.Application.Comments;
using Reactivities.Domain;
using System;
using System.Collections.Generic;

namespace Reactivities.Application.Activities
{
    public class ActivityDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }

        [JsonProperty("attendees")]
        public ICollection<AttendeeDto> UserActivities { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
    }
}
