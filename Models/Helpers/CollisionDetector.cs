﻿using GameStateManagementSample.Models.Entities;
using GameStateManagementSample.Models.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStateManagementSample.Models.Helpers
{
    public class CollisionDetector
    {


        public static DoorTile HasDoorTileCollision(Room room, Entity entity, Vector2 movement, ref MapGenerator map)
        {
            Tile[,] tiles = room.GetTiles();
            int x = (int)entity.Position.X + (int)movement.X - entity.Texture.Width / 2;
            int y = (int)entity.Position.Y + (int)movement.Y - entity.Texture.Height / 2;
            Rectangle entityBoundingBox = new Rectangle(x, y, entity.Texture.Width, entity.Texture.Height);
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    if (tiles[i, j] is DoorTile doorTile2 && IsIntersecting(tiles[i, j].BoundingBox, entityBoundingBox) && doorTile2.IsLastDoor)
                    {
                        return doorTile2;
                    }
                    if (tiles[i, j] is DoorTile doorTile && IsIntersecting(tiles[i, j].BoundingBox, entityBoundingBox))
                    {
                        return doorTile;
                    }
                }
            }
            return null;
        }
        /*
        public static bool HasStructureCollision(Room room, Entity entity, Vector2 movment)
        {
            Tile[,] tiles = room.GetTiles();
            int x = (int)entity.Position.X + (int)movment.X - entity.Texture.Width / 2;
            int y = (int)entity.Position.Y + (int)movment.Y - entity.Texture.Height / 2;

            Rectangle entityBoundingBox = new Rectangle(x, y, entity.Texture.Width, entity.Texture.Height);

            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    if (tiles[i, j].Collision && IsIntersecting(tiles[i, j].BoundingBox, entityBoundingBox))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        */

        public static bool HasStructureCollision(Room room, Entity entity, Vector2 movment)
        {
            Tile[,] tiles = room.GetTiles();
            if (tiles == null)
                throw new InvalidOperationException("Room tiles are not initialized.");

            if (entity.Texture == null)
                throw new InvalidOperationException("Entity texture is not initialized.");

            int x = (int)entity.Position.X + (int)movment.X - entity.Texture.Width / 2;
            int y = (int)entity.Position.Y + (int)movment.Y - entity.Texture.Height / 2;

            Rectangle entityBoundingBox = new Rectangle(x, y, entity.Texture.Width, entity.Texture.Height);

            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    if (tiles[i, j] == null)
                        continue;

                    if (tiles[i, j].Collision && IsIntersecting(tiles[i, j].BoundingBox, entityBoundingBox))
                    {
                        return true;
                    }
                }
            }
            return false;
        }



        public static bool IsIntersecting(Rectangle objA, Rectangle objB)
        {
            return objA.Intersects(objB);
        }
    }
}
