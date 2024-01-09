﻿using Newtonsoft.Json;
using Reactivities.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reactivities.Application.Profiles
{
    public class Profile
    {
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Image { get; set; }
        public string Bio { get; set; }
        [JsonProperty("following")]
        public bool IsFollowed { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingCount { get; set; }
        public ICollection<Photo> Photos { get; set; } 
    }
}