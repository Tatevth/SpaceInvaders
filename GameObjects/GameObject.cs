﻿using SpaceInvaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    abstract class GameObject
    {
        public GameObjectPlace gameObjectPlace { get; set; }

        public char Figure { get; set; }

        public GameObjectType gameObjectType { get; set; }
    }
}
