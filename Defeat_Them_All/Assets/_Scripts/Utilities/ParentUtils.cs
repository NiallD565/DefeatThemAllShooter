﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public class ParentUtils
    {
        // use this to hold constants and repeated methods for parent objects
        // ENEMY_PARENT_NAME,  BULLET_PARENT_NAME, SPAWN_METHODS, COIN_SPAWN_METHOD, TOKEN_SPAWN_METHOD
        public const string BULLET_PARENT_NAME = "Bullets";
        public const string SPAWN_METHOD = "Spawn";
        public const string ENEMY_PARENT_NAME = "Enemies";
        public const string COIN_SPAWN_METHOD = "SpawnCoin";
        public const string TOKEN_SPAWN_METHOD = "SpawnToken";

        public static GameObject FindTokenParent()
        {
            return FindRequiredParent(TOKEN_SPAWN_METHOD);
        }

        public static GameObject FindEnemyParent()
        {
            return FindRequiredParent(ENEMY_PARENT_NAME);
        }

        public static GameObject FindBulletParent()
        {
            return FindRequiredParent(BULLET_PARENT_NAME);
        }

        public static GameObject FindCoinParent()
        {
            return FindRequiredParent(COIN_SPAWN_METHOD);
        }

        private static GameObject FindRequiredParent(string parent)
        {
            var requiredParent = GameObject.Find(parent);
            if (!requiredParent)
            {
                requiredParent = new GameObject(parent);
            }
            return requiredParent;
        }

        

    }
}