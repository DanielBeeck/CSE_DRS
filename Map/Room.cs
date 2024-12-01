using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;

namespace GameStateManagementSample.Models.Map
{
    public class Room
    {
        private Tile[,] tiles;
        private bool[] blocked = new bool[4]; // wird für Map generation genutzt
        private Texture2D grass;
        private Texture2D grass2;
        private Texture2D grass3;
        private Texture2D hole;
        private Texture2D tree;

        private Random random = new Random();

        public Room() {
            for (int i = 0; i < blocked.Length; i++)
            {
                blocked[i] = false;
            }
         }

        public void LoadTextures(ContentManager content)
        {
            grass = content.Load<Texture2D>("Map/grass");
            grass2 = content.Load<Texture2D>("Map/grass2");
            grass3 = content.Load<Texture2D>("Map/grass3");
            hole = content.Load<Texture2D>("Map/hole");
            tree = content.Load<Texture2D>("Map/tree");

        }
        // damit der aktuelle stand sichtbar ist, sobald MapGenerator fertig ist kann GenerateRoom ohne Random im konstruktor gelöscht werden
        public void GenerateRoom()
        {
            tiles = new Tile[random.Next(10, 20), random.Next(10, 20)];
            int rdmNumber;
            Vector2 tilePos = new Vector2(0, 0);
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                tilePos.X = 0;
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    rdmNumber = random.Next(1, 10);
                    if (rdmNumber <= 6)
                        tiles[i, j] = new Tile(tilePos, grass, false);
                    if (rdmNumber > 6 && rdmNumber <= 8)
                        tiles[i, j] = new Tile(tilePos, grass2, false);
                    if (rdmNumber > 8 && rdmNumber <= 10)
                        tiles[i, j] = new Tile(tilePos, grass3, false);

                    tilePos.X += 100;
                }
                tilePos.Y += 100;
            }
            tilePos.X = 0;
            tilePos.Y = 0;
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                tilePos.X = 0;
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    if (i == 0 || j == 0 || j == tiles.GetLength(1) - 1 || i == tiles.GetLength(0) - 1)
                    {
                        tiles[i, j] = new Tile(tilePos, tree, true);
                    }
                    tilePos.X += 100;
                }
                tilePos.Y += 100;
            }
        }

        public void GenerateRoom(Random random, Vector2 roomPos)
        {
            tiles = GenerateRoomArray();
            int rdmNumber;
            Vector2 tilePos = roomPos;
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                tilePos.X = roomPos.X;

                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    rdmNumber = random.Next(1, 10);
                    if (rdmNumber <= 6)
                        tiles[i, j] = new Tile(tilePos, grass, false);
                    if (rdmNumber > 6 && rdmNumber <= 8)
                        tiles[i, j] = new Tile(tilePos, grass2, false);
                    if (rdmNumber > 8 && rdmNumber <= 10)
                        tiles[i, j] = new Tile(tilePos, grass3, false);

                    tilePos.X += 100;
                }
                tilePos.Y += 100;
            }
            tilePos.X = roomPos.X;
            tilePos.Y = roomPos.Y;
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                tilePos.X = roomPos.X;
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    if (i == 0 || j == 0 || j == tiles.GetLength(1) - 1 || i == tiles.GetLength(0) - 1)
                    {
                        tiles[i, j] = new Tile(tilePos, tree, true);
                    }
                    tilePos.X += 100;
                }
                tilePos.Y += 100;
            }
        }

        public void DrawRoom(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    spriteBatch.Draw(grass, tiles[i, j].getPos(), Color.White); //damit die baumtexturen einen gras hintergrund haben
                    spriteBatch.Draw(tiles[i, j].getTexture(), tiles[i, j].getPos(), Color.White);
                }
            }
            // This loop is to load the trees over the green textures
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    if (i == tiles.GetLength(0) - 1)
                        spriteBatch.Draw(grass, new Vector2(tiles[i, j].getPos().X, tiles[i, j].getPos().Y + 100), Color.White);
                    if (tiles[i, j].getTexture() == tree)
                        spriteBatch.Draw(tiles[i, j].getTexture(), tiles[i, j].getPos(), Color.White);
                }

            }
        }

        public Tile[,] GetTiles()
        {
            return tiles;
        }

        private Tile[,] GenerateRoomArray()
        {
            return new Tile[random.Next(10, 20), random.Next(10, 20)];
        }

        public void blockDirection(int direction){
            blocked[direction] = true;
        }

        public bool allDirectionsBlocked(){
            if(blocked[0]== true && blocked[1]== true && blocked[2]== true && blocked[3]== true)
                return true;
            else
                return false;
        }

        public bool isDirectionBlockedOn(int direction){
            return blocked[direction];
        }
        
    }
}
