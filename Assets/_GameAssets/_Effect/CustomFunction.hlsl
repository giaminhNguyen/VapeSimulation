#ifndef MYHLSLINCLEDE_INCLUDED
#define MYHLSLINCLEDE_INCLUDED

float2 Flipbook(float2 UV, float Width, float Height, float Tile, float2 Invert)
{
    Tile = floor(fmod(Tile + float(0.00001), Width*Height));
    float2 tileCount = float2(1.0, 1.0) / float2(Width, Height);
    float base = floor((Tile + float(0.5)) * tileCount.x);
    float tileX = (Tile - Width * base);
    float tileY = (Invert.y * Height - (base + Invert.y * 1));
    return (UV + float2(tileX, tileY)) * tileCount;
}


void flipUV_float(float2 uv,float2 tiles,float2 invert)
{
    float total = tiles.x * tiles.y;

    
    
}
