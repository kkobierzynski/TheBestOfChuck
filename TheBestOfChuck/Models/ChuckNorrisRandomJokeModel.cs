﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestOfChuck.Models
{
    internal class ChuckNorrisRandomJokeModel
    {
        public List<string> Categories { get; set; }
        public string Created_at { get; set; }
        public string Icon_url { get; set; }
        public string Id { get; set; }
        public string Updated_at { get; set; }
        public string Url { get; set; }
        public string Value { get; set; }
    }
}
