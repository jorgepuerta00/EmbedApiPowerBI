﻿using Microsoft.PowerBI.Api.V2.Models;
using System;
using System.Runtime.Serialization;

namespace EmbedPowerBI
{
    [DataContract]
    public class Token
    {
        public string Id { get; set; }

        public string EmbedUrl { get; set; }

        public EmbedToken EmbedToken { get; set; }

        public int MinutesToExpiration
        {
            get
            {
                var minutesToExpiration = EmbedToken.Expiration.Value - DateTime.UtcNow;
                return minutesToExpiration.Minutes;
            }
        }

        public string ErrorMessage { get; internal set; }
    }
}
