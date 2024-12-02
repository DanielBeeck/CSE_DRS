using System.Security;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class Tile
{
    Vector2 pos;
    Texture2D texture;
    bool collision;

    public Tile(){}
    public Tile(Vector2 pos, Texture2D texture, bool collision = false)
    {
        this.pos = pos;
        this.texture = texture;
        this.collision = collision;
    }

    public Vector2 getPos(){
        return pos;
    }

    public Texture2D getTexture(){
        return texture;
    }

    public bool getCollision(){
        return collision;
    }

    public void setTile(Vector2 pos, Texture2D texture, bool collision){
        this.pos = pos;
        this.texture = texture;
        this.collision = collision;
    }

    public void setPos(Vector2 pos){
        this.pos = pos;
    }

    public void setTexture(Texture2D texture){
        this.texture = texture;
    }

    public void setCollison(bool collision){
        this.collision = collision;
    }

}